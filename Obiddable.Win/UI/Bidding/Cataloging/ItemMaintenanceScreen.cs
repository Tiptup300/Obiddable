using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.Conversions.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Win.Library.IO.Bidding.Cataloging;
using Obiddable.Win.Library.UI;
using System.Data;

namespace Obiddable.Win.UI.Bidding.Cataloging;
[System.ComponentModel.DesignerCategory("")]
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

   protected override void InitializeTitles()
   {
      titleLabel.Text = "Items Maintenance";
      Text = "Items Maintenance";
      subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
      topPanel.BackColor = ApplicationColors.Items;
   }

   protected override void InitializeActionsMenu(IActionMenu actionMenu)
   {
      actionsMenu.DropDownItems.AddRange([
         CreateMenuItem("Update All Item Prices", MassUpdateItemPrices),
         CreateMenuItem("Reset All Item Prices To Last Purchase Price", MassResetItemPricesToLastOrdered),
         new ToolStripSeparator(),
         CreateMenuItem("Import Items from CSV", ImportItems),
         CreateMenuItem("Export All Items to CSV", ExportItems),
         CreateMenuItem("Generate Items Import Template to CSV", GenerateItemsImportTemplate)
      ]);

      void MassUpdateItemPrices()
      {
         decimal multiplier;

         using MassUpdateItemPricesDialog dialog = new MassUpdateItemPricesDialog();

         if (dialog.ShowDialog() != DialogResult.OK)
         {
            return;
         }
         multiplier = dialog.Multiplier;

         _catalogingOperations.UpdateItems_MassPriceChange_ByBid(_bid.Id, multiplier);
         RefreshList();
      }

      void MassResetItemPricesToLastOrdered()
      {
         if (CatalogingMessaging.Instance.ConfirmItemMassResetToLastOrdered() == false)
         {
            return;
         }
         _catalogingOperations.UpdateItems_MassPriceReset_ByBid(_bid.Id);

         RefreshList();
      }

      void ImportItems()
      {
         _itemsImportOperation.ImportItems(_bid);

         RefreshList();
      }

      void ExportItems()
      {
         ItemsExports.ExportItemsToCSV(_bid, _catalogingRepo);
      }

      void GenerateItemsImportTemplate()
      {
         ItemsExports.GenerateItemsImportTemplateToCSV();
      }
   }

   protected override void InitializeColumns()
   {
      listViewMain.Columns.AddRange([
         new() { Text = "Item Id", Width = 0 },
         new() { Text = "Code", Width = 66 },
         new() { Text = "Description", Width = 955 },
         new() { Text = "Category", Width = 126 },
         new() { Text = "Unit", Width = 66 },
         new() { Text = "Allows Substitutes", Width = 150 },
         new() { Text = "Estimated Price", Width = 104, TextAlign = HorizontalAlignment.Right },
         new() { Text = "Last Order Price", Width = 115, TextAlign = HorizontalAlignment.Right },
      ]);
   }

   protected override void RefreshList()
   {
      var items = _catalogingRepo.GetItems(_bid.Id);

      listViewMain.ReplaceListViewItems(
         items
            .OrderBy(x => x.Code)
            .Select(i
               => new ListViewItem(items: [
                  $"{i.Id}",
                  i.HyphenatedFormattedCode,
                  i.Description,
                  i.Category,
                  i.Unit,
                  i.Substitutable.ToString(),
                  i.Price.ToString("$0.00000"),
                  i.Last_Order_Price.ToString("$0.00000")]
               )
               {
                  Tag = i.Id
               }
            )
      );
      ReselectItem();
   }

   protected override void ListViewDoubleClicked()
      => EditButtonClicked();

   protected override void AddButtonClicked()
   {
      using ItemEditForm addItemForm = new ItemEditForm(_bid);

      if (addItemForm.ShowDialog() != DialogResult.OK ||
         addItemForm.GetItem() is not Item addedItem)
      {
         return;
      }
      _catalogingRepo.AddItem(addedItem, _bid.Id);

      RefreshList();
   }

   protected override void EditButtonClicked()
   {
      if (SelectedItem == null ||
         _catalogingRepo.GetItem(SelectedItemTag) is not Item item)
         return;

      using ItemEditForm editItemForm = new ItemEditForm(item);

      if (editItemForm.ShowDialog() != DialogResult.OK ||
         editItemForm.GetItem() is not Item editedItem)
         return;

      _catalogingRepo.UpdateItem(editedItem);

      RefreshList();
   }

   protected override void DeleteButtonClicked()
   {
      if (SelectedItem == null ||
         _catalogingRepo.GetItem(SelectedItemTag) is not Item item)
         return;

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

      RefreshList();
   }
}
