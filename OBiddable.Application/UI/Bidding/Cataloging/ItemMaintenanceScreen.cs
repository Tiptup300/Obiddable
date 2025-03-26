using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Cataloging;
using OBiddable.Library.Bidding.Responding;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    public class ItemMaintenanceScreen : MaintenanceScreen
    {
        private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
        private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
        private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
        private readonly ICatalogingOperations _catalogingOperations = new EFCatalogingOperations();
        private readonly ItemsImportOperation _itemsImportOperation = new ItemsImportOperation(new CatalogingService(new EFCatalogingRepo()), new FormsMessaging(), new CatalogingMessaging(), new ItemsConversions());
        private Bid _bid;

        public ItemMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
        {
            _bid = _biddingRepo.GetBid(bidId);
        }

        #region INIT METHODS
        protected override void InitializeTitles()
        {
            titleLabel.Text = "Items Maintenance";
            Text = "Items Maintenance";
            subtitleLabel.Text = $"{ _bid.Id}-{ _bid.Name}";
            topPanel.BackColor = ApplicationColors.Items;
        }
        #endregion

        #region ACTIONS
        protected override void InitializeActionsMenu(IActionMenu actionMenu)
        {
            var massUpdateItemPrices = new ToolStripMenuItem() { Text = "Update All Item Prices" };
            massUpdateItemPrices.Click += MassUpdateItemPrices_Click;

            var massResetItemPrices = new ToolStripMenuItem() { Text = "Reset All Item Prices" };
            massResetItemPrices.Click += MassResetItemPrices_Click;

            var importItemsMenuItem = new ToolStripMenuItem() { Text = "Import Items from CSV" };
            importItemsMenuItem.Click += importItemsMenuItem_Click;


            var exportItemsMenuItem = new ToolStripMenuItem() { Text = "Export All Items to CSV" };
            exportItemsMenuItem.Click += ExportItemsMenuItem_Click; ;

            var generateItemsImportTemplateMenuItem = new ToolStripMenuItem() { Text = "Generate Items Import Template to CSV" };
            generateItemsImportTemplateMenuItem.Click += generateItemsImportTemplateMenuItem_Click;

            actionsMenu.DropDownItems.AddRange(new ToolStripItem[] {
                massUpdateItemPrices,
                massResetItemPrices,
                new ToolStripSeparator(),
                importItemsMenuItem,
                exportItemsMenuItem,
                generateItemsImportTemplateMenuItem });
        }
        private void MassUpdateItemPrices_Click(object sender, EventArgs e)
        {
            decimal multiplier;

            using (MassUpdateItemPricesForm f = new MassUpdateItemPricesForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                multiplier = f.Multiplier;
            }
            _catalogingOperations.UpdateItems_MassPriceChange_ByBid(_bid.Id, multiplier);
            CatalogingMessaging.Instance.ShowItemMassUpdatePricesSuccess();
            RefreshList();
        }
        private void MassResetItemPrices_Click(object sender, EventArgs e)
        {
            if (CatalogingMessaging.Instance.ConfirmItemMassResetPrices() == false)
            {
                return;
            }
            _catalogingOperations.UpdateItems_MassPriceReset_ByBid(_bid.Id);
            CatalogingMessaging.Instance.ShowItemMassResetPricesSuccess();

            RefreshList();

        }
        private void importItemsMenuItem_Click(object sender, EventArgs e)
        {
            _itemsImportOperation.ImportItems(_bid);
            RefreshList();

        }
        private void ExportItemsMenuItem_Click(object sender, EventArgs e)
        {
            ItemsExports.ExportItemsToCSV(_bid, _catalogingRepo);
        }
        public void generateItemsImportTemplateMenuItem_Click(object sender, EventArgs e)
        {
            ItemsExports.GenerateItemsImportTemplateToCSV();
        }
        #endregion

        #region LIST METHODS
        protected override void InitializeColumns()
        {
            listViewMain.Columns.AddRange(
                new ColumnHeader[] {

                    new ColumnHeader() { Text = "Item Id", Width = 0 },
                    new ColumnHeader() { Text = "Code", Width = 66 },
                    new ColumnHeader() { Text = "Description", Width = 955 },
                    new ColumnHeader() { Text = "Category", Width = 126 },
                    new ColumnHeader() { Text = "Unit", Width = 66 },
                    new ColumnHeader() { Text = "Substitutible", Width = 112 },
                    new ColumnHeader() { Text = "Estimated Price", Width = 104, TextAlign = HorizontalAlignment.Right },
                    new ColumnHeader() { Text = "Last Order Price", Width = 115, TextAlign = HorizontalAlignment.Right },
                }
            );
        }
        protected override void RefreshList()
        {
            listViewMain.ReplaceListViewItems(
                _catalogingRepo
                    .GetItems(_bid.Id)
                    .OrderBy(x => x.Code)
                    .Select(item => buildListViewItem(item))
                    .ToArray()
            );
            ReselectItem();
        }

        private static ListViewItem buildListViewItem(Item i)
        {
            ListViewItem newListItem = new ListViewItem();

            newListItem.Text = $"{ i.Id }";

            newListItem.SubItems.Add(i.HyphenatedFormattedCode);
            newListItem.SubItems.Add(i.Description);
            newListItem.SubItems.Add(i.Category);
            newListItem.SubItems.Add(i.Unit);
            newListItem.SubItems.Add(i.Substitutable.ToString());
            newListItem.SubItems.Add(i.Price.ToString("$0.00000"));
            newListItem.SubItems.Add(i.Last_Order_Price.ToString("$0.00000"));


            newListItem.Tag = i.Id;
            return newListItem;
        }



        protected override void ListViewDoubleClicked()
        {
            EditButtonClicked();
        }
        #endregion

        #region BUTTON METHODS
        protected override void AddButtonClicked()
        {
            using (ItemEditForm f = new ItemEditForm(_bid))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _catalogingRepo.AddItem(f.GetItem(), _bid.Id);
                CatalogingMessaging.Instance.ShowItemAddSuccess();
            }
            RefreshList();
        }
        protected override void EditButtonClicked()
        {
            if (SelectedItem == null)
            {
                return;
            }
            Item item = _catalogingRepo.GetItem(SelectedItemTag);
            if (item == null)
            {
                return;
            }
            using (ItemEditForm f = new ItemEditForm(item))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _catalogingRepo.UpdateItem(f.GetItem());
                CatalogingMessaging.Instance.ShowItemEditSuccess();
            }
            RefreshList();
        }
        protected override void DeleteButtonClicked()
        {
            if (SelectedItem == null)
            {
                return;
            }
            Item item = _catalogingRepo.GetItem(SelectedItemTag);
            if (item == null)
            {
                return;
            }
            if (CatalogingMessaging.Instance.ConfirmItemDelete() == false)
            {
                return;
            }
            if (_requestingRepo.Check_ItemRequested(item.Id))
            {
                CatalogingMessaging.Instance.ShowItemDelete_ItemRequestedError();
                return;
            }
            if (_respondingRepo.Check_ItemResponded(item.Id))
            {
                CatalogingMessaging.Instance.ShowItemDelete_ItemRespondedError();
                return;
            }
            _catalogingRepo.DeleteItem(item.Id);
            CatalogingMessaging.Instance.ShowItemDeleteSuccess();
            RefreshList();
        }
        #endregion

    }
}
