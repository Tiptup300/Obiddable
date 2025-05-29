using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
   public class RequestorMaintenanceScreen : MaintenanceScreen
   {
      private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

      private Bid _bid;

      public RequestorMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
      {
         _bid = _biddingRepo.GetBid(bidId);
      }

      #region INITS
      protected override void InitializeTitles()
      {
         titleLabel.Text = "Requestors Maintenance";
         Text = "Requestors Maintenance";
         subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
         topPanel.BackColor = ApplicationColors.Requesting;
      }
      #endregion

      #region ACTIONS
      protected override void InitializeActionsMenu(IActionMenu actionMenu)
      {
         var importRequestorsMenuItem = new ToolStripMenuItem() { Text = "Import Requestors from CSV" };
         importRequestorsMenuItem.Click += importRequestorsMenuItem_Click;

         var exportRequestorsMenuItem = new ToolStripMenuItem() { Text = "Export All Requestors to CSV" };
         exportRequestorsMenuItem.Click += ExportRequestorsMenuItem_Click;

         var exportBlankRequestForAllRequestors = new ToolStripMenuItem() { Text = "Generate Blank Requests For All Requestors to Excel" };
         exportBlankRequestForAllRequestors.Click += ExportBlankRequestForAllRequestors_Click;

         var generateRequestorsImportTemplateMenuItem = new ToolStripMenuItem() { Text = "Generate Requestor Import Template to CSV" };
         generateRequestorsImportTemplateMenuItem.Click += generateRequestorsImportTemplateMenuItem_Click;

         actionsMenu.DropDownItems.AddRange(new ToolStripItem[] {
                importRequestorsMenuItem,
                exportRequestorsMenuItem,
                generateRequestorsImportTemplateMenuItem,
                new ToolStripSeparator(),
                exportBlankRequestForAllRequestors,
                new ToolStripSeparator(),
                LoadSelectedRequestorActionMenuItems(),
                 });
      }
      private ToolStripMenuItem LoadSelectedRequestorActionMenuItems()
      {
         var selectedMenuItem = new ToolStripMenuItem() { Text = "Selected" };

         var clearRequestorsRequestsMenuItem = new ToolStripMenuItem() { Text = "Clear Requests" };
         clearRequestorsRequestsMenuItem.Click += clearRequestorsRequestsMenuItem_Click; ;

         selectedMenuItem.DropDownItems.Add(clearRequestorsRequestsMenuItem);

         return selectedMenuItem;
      }

      private void ExportBlankRequestForAllRequestors_Click(object sender, EventArgs e)
      {
         RequestsExports.ExportBlankRequestToExcelForAllRequestors(_bid, _requestingRepo);
      }
      private void generateRequestorsImportTemplateMenuItem_Click(object sender, EventArgs e)
      {
         RequestorsExports.GenerateRequestorsImportTemplateToCSV();
      }
      private void ExportRequestorsMenuItem_Click(object sender, EventArgs e)
      {
         RequestorsExports.ExportRequestorsToCSV(_bid, _requestingRepo);
      }
      private void importRequestorsMenuItem_Click(object sender, EventArgs e)
      {
         RequestorsImports.ImportRequestorsFromCSV(_bid, _requestingRepo);

         RefreshList();
      }
      private void clearRequestorsRequestsMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         Requestor requestor = _requestingRepo.GetRequestor(SelectedItemTag);
         if (requestor is null)
         {
            return;
         }

         if (RequestorMessaging.Instance.ConfirmRequestorClearRequests() == false)
         {
            return;
         }
         _requestingRepo.ClearRequests_ByRequestor(requestor.Id);
         RefreshList();

      }
      #endregion

      #region BUTTONS
      protected override void AddButtonClicked()
      {
         using (RequestorEditForm f = new RequestorEditForm(_bid))
         {
            if (f.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            _requestingRepo.AddRequestor_ToBid(f.GetRequestor(), _bid.Id);
            RequestorMessaging.Instance.ShowRequestorAddSuccess();
            RefreshList();
         }
      }
      protected override void EditButtonClicked()
      {
         if (SelectedItem == null)
         {
            return;
         }
         Requestor requestor = _requestingRepo.GetRequestor(SelectedItemTag);
         if (requestor is null)
         {
            return;
         }

         using (RequestorEditForm f = new RequestorEditForm(requestor))
         {
            if (f.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            _requestingRepo.UpdateRequestor(f.GetRequestor());
            RequestorMessaging.Instance.ShowRequestorEditSuccess();
            RefreshList();
         }
      }
      protected override void DeleteButtonClicked()
      {
         if (SelectedItem == null)
         {
            return;
         }
         Requestor requestor = _requestingRepo.GetRequestor(SelectedItemTag);
         if (requestor is null)
         {
            return;
         }

         if (requestor.Requests.Count > 0)
         {
            RequestorMessaging.Instance.ShowRequestorDelete_RequestorNotBlankError();
            return;
         }

         if (RequestorMessaging.Instance.ConfirmRequestorDelete(requestor) == false)
         {
            return;
         }
         _requestingRepo.DeleteRequestor(requestor.Id);
         RequestorMessaging.Instance.ShowRequestorDeleteSuccess();
         RefreshList();
      }
      #endregion

      #region LIST
      protected override void InitializeColumns()
      {

         listViewMain.Columns.AddRange(
             new ColumnHeader[] {

                    new ColumnHeader() { Text = "Requestor Id", Width = 0 },
                    new ColumnHeader() { Text = "Requestor Code", Width = 121 },
                    new ColumnHeader() { Text = "Building Name", Width = 239 },
                    new ColumnHeader() { Text = "Requestor Name", Width = 159 },
                    new ColumnHeader() { Text = "Requests", Width = 116, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Requested Items", Width = 169, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Quantity Sum", Width = 167, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Total Price", Width = 120, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Total Price With Overrides", Width = 171, TextAlign = HorizontalAlignment.Right  },
             }
         );
      }
      protected override void RefreshList()
      {
         listViewMain.BeginUpdate();

         listViewMain.Items.Clear();

         List<Requestor> requestors = _requestingRepo.GetRequestors_ByBid(_bid.Id);
         List<ListViewItem> listviewItems = new List<ListViewItem>();

         foreach (Requestor r in requestors)
         {
            ListViewItem newListItem = new ListViewItem();

            newListItem.Text = $"{r.Id}";

            newListItem.SubItems.Add(r.FormattedCode);
            newListItem.SubItems.Add(r.Building);
            newListItem.SubItems.Add(r.Name);
            newListItem.SubItems.Add(r.Requests.Count.ToString());
            newListItem.SubItems.Add(r.RequestItemsCount().ToString());
            newListItem.SubItems.Add(r.QuantitySum().ToString());
            newListItem.SubItems.Add(r.TotalPrice().ToString("$0.00"));
            newListItem.SubItems.Add(r.TotalPriceWithOverride().ToString("$0.00"));

            newListItem.Tag = r.Id;
            listviewItems.Add(newListItem);

         }

         listViewMain.Items.AddRange(listviewItems.ToArray());
         listViewMain.EndUpdate();
         ReselectItem();
      }
      protected override void ListViewDoubleClicked()
      {
         openRequestsMenuItem_Click(null, null);
      }
      #endregion

      #region OPENS
      private void openRequestsMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         Requestor requestor = _requestingRepo.GetRequestor(SelectedItemTag);
         if (requestor is null)
         {
            return;
         }

         RequestMaintenanceScreen f = new RequestMaintenanceScreen(_hostForm, requestor.Id);
         _hostForm.GoForward(f);

         RefreshList();

      }
      #endregion
   }
}
