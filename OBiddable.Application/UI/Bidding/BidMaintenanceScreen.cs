using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ccd.Bidding.Manager.Win.Library.Operations;
using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.Operations.Bidding;
using Ccd.Bidding.Manager.Win.Library.Operations.UI;
using Ccd.Bidding.Manager.Win.Library;
using Ccd.Bidding.Manager.Win.UI.Bidding.Navigation;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using OBiddable.Library.Bidding;

namespace Ccd.Bidding.Manager.Win.UI.Bidding
{
    public class BidMaintenanceScreen : MaintenanceScreen
    {
        private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
        private readonly IBiddingOperations _biddingOperations = new EFBiddingOperations();

        private ConfigMenuShower _configMenuShower = new ConfigMenuShower();
        public BidMaintenanceScreen(IHostForm hostForm) : base(hostForm) { }

        #region INIT METHODS
        protected override void InitializeTitles()
        {
            Text = "Bids Maintenance";
            titleLabel.Text = "Bids Maintenance";
            topPanel.BackColor = ApplicationColors.Bidding;
            setSubtitleToVersion();
            configButton.Click += ConfigButton_Click;
            UpdateButtons();
        }

        private void setSubtitleToVersion()
        {
            string version;

            version = new VersionResolver().GetVersion();
            subtitleLabel.Text = $"CCD BidManager ({version})";
        }

        private void UpdateButtons()
        {
            backButton.Visible = false;
            backButton.Enabled = false;

            deleteButton.Enabled = UserConfiguration.Instance.CanDeleteBid;
            configButton.Enabled = true;
            configButton.Visible = true;
        }

        protected override void InitializeActionsMenu(IActionMenu actionMenu)
        {
            actionsMenu.DropDownItems.Add(LoadSelectedBidActionMenuItems());
        }

        private bool isBidSelected()
            => SelectedItem != null;
        private Bid getSelectedBid()
        {
            Bid output;

            output = _biddingRepo.GetBid(SelectedItemTag);
            if (output == null)
            {
                throw new Exception("Bid Not Found");
            }

            return output;
        }
        private ToolStripMenuItem LoadSelectedBidActionMenuItems()
        {
            var selectedBidActionMenuItem = new ToolStripMenuItem() { Text = "Selected" };


            selectedBidActionMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                CreateBidOperationMenuItem("Export Bid", typeof(ExportBidOperation)),
                new ToolStripSeparator(),
                CreateBidOperationMenuItem("Roll Bid", typeof(RollBidOperation)),
                CreateBidOperationMenuItem("Duplicate Bid", typeof(DuplicateBidOperation)),
                new ToolStripSeparator(),
                CreateBidOperationMenuItem("Clear Items", typeof(ClearBidsItemsOperation)),
                CreateBidOperationMenuItem("Clear Requestors", typeof(ClearBidsRequestorsOperation)),
                CreateBidOperationMenuItem("Clear Vendors", typeof(ClearBidsVendorsOperation)),
            });

            return selectedBidActionMenuItem;
        }
        #endregion

        #region LIST
        protected override void InitializeColumns()
        {
            listViewMain.Columns.AddRange(
                new ColumnHeader[] {
                    new ColumnHeader() { Text = "Bid Id",           Width = 60 },
                    new ColumnHeader() { Text = "Bid Name",         Width = 331 },
                    new ColumnHeader() { Text = "Items",      Width = 103, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Requestors", Width = 130, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Vendors",    Width = 140, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Purchase Orders",    Width = 157, TextAlign = HorizontalAlignment.Right  },
                }
            );

            listViewMain.View = View.Details;
        }
        protected override void RefreshList()
        {
            listViewMain.BeginUpdate();
            listViewMain.Items.Clear();

            List<Bid> bids = _biddingRepo.GetBids();
            List<ListViewItem> listviewItems = new List<ListViewItem>();

            foreach (Bid bid in bids)
            {
                ListViewItem item = new ListViewItem();
                item.Text = $"{ bid.Id.ToString("000000") }";
                item.SubItems.Add(bid.Name);
                item.SubItems.Add(bid.Items.Count.ToString());
                item.SubItems.Add(bid.Requestors.Count.ToString());
                item.SubItems.Add(bid.VendorResponses.Count.ToString());
                item.SubItems.Add(bid.PurchaseOrders.Count.ToString());

                item.Tag = bid.Id;
                listviewItems.Add(item);
            }

            listViewMain.Items.AddRange(listviewItems.ToArray());
            listViewMain.EndUpdate();

            listViewMain.SortByColumn(1, SortOrder.Descending);
            listViewMain.Sort();

            ReselectItem();
        }
        protected override void ListViewDoubleClicked()
        {
            promptForNextMenu();
        }

        private void promptForNextMenu()
        {
            if (SelectedItem == null)
            {
                return;
            }
            Bid bid = _biddingRepo.GetBid(SelectedItemTag);
            if (bid == null)
            {
                return;
            }
            setWorkingBid(bid.Id);
            _hostForm.GoForward(new BidNavigationScreen(_hostForm, bid.Id));
        }

        private void setWorkingBid(int bidId)
        {
            UserConfiguration.Instance.WorkingBidId = bidId;
        }
        #endregion

        #region OPERATIONS
        private ToolStripMenuItem CreateBidOperationMenuItem(string text, Type bidOperationType)
        {
            ToolStripMenuItem operationMenuitem = new ToolStripMenuItem() { Text = text, Tag = bidOperationType };
            operationMenuitem.Click += OperationMenuItem_Click;
            return operationMenuitem;
        }
        private void OperationMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                return;
            }
            Bid bid = _biddingRepo.GetBid(SelectedItemTag);
            if (bid == null)
            {
                return;
            }

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Type t = (Type)menuItem.Tag;
            if (t is null)
            {
                return;
            }
            BidDataOperation bidDataOperation = (BidDataOperation)Activator.CreateInstance(t, bid);
            bidDataOperation.Run();

            RefreshList();
        }
        #endregion

        #region BUTTON
        protected override void AddButtonClicked()
        {
            using (BidEditForm f = new BidEditForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _biddingRepo.AddBid(f.GetBid());
                BiddingMessaging.Instance.ShowBidAddSuccess();
                RefreshList();
            }
        }
        protected override void EditButtonClicked()
        {
            if (SelectedItem == null)
            {
                return;
            }
            Bid bid = _biddingRepo.GetBid(SelectedItemTag);
            if (bid == null)
            {
                return;
            }

            using (BidEditForm f = new BidEditForm(bid))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _biddingRepo.UpdateBid(f.GetBid());
                BiddingMessaging.Instance.ShowBidEditSuccess();
                RefreshList();
            }
        }
        protected override void DeleteButtonClicked()
        {
            if (SelectedItem == null)
            {
                return;
            }
            Bid bid = _biddingRepo.GetBid(SelectedItemTag);
            if (bid == null)
            {
                return;
            }

            if (BiddingMessaging.Instance.ConfirmBidDelete(bid.Items.Count, bid.Requestors.Count, bid.VendorResponses.Count, bid.PurchaseOrders.Count) == false)
            {
                return;
            }
            bool bidSuccessfullyDeleted = _biddingOperations.ClearAndDeleteBid(bid);
            if (bidSuccessfullyDeleted)
            {
                BiddingMessaging.Instance.ShowBidDeleteSuccess();

                // turn off bid addition abillities.
                UserConfiguration.Instance.CanDeleteBid = false;
            }
            else
            {
                BiddingMessaging.Instance.ShowBidDeleteFailed();
            }

            RefreshList();
        }
        private void KeyPressOnToolStrip(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        private void ConfigButton_Click(object sender, EventArgs e)
        {
            _configMenuShower.Run();
            UpdateButtons();
        }
        #endregion
    }
}
