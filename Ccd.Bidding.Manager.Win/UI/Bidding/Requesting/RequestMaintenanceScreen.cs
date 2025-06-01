using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.UI;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;
public class RequestMaintenanceScreen : MaintenanceScreen
{
   private readonly CatalogingService _catalogingService = new CatalogingService(new EFCatalogingRepo());
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly RequestMessaging _requestMessaging = new RequestMessaging();

   private Requestor _requestor;

   public RequestMaintenanceScreen(IHostForm hostForm, int requestorId) : base(hostForm)
   {
      _requestor = _requestingRepo.GetRequestor(requestorId);
   }

   #region INIT METHODS
   protected override void InitializeTitles()
   {
      titleLabel.Text = "Requests Maintenance";
      Text = "Requests Maintenance";
      subtitleLabel.Text = $"{_requestor.Bid.Id}-{_requestor.Bid.Name}-{_requestor.Code}-{_requestor.Name}-{_requestor.Building}";
      topPanel.BackColor = ApplicationColors.Requesting;
   }
   #endregion


   #region ACTIONS
   protected override void InitializeActionsMenu(IActionMenu actionMenu)
   {
      var generateRequestImportSheetMenuItem = new ToolStripMenuItem() { Text = "Generate Blank Request to CSV" };
      generateRequestImportSheetMenuItem.Click += generateRequestImportSheetMenuItem_Click;

      var generateRequestExcelMenuItem = new ToolStripMenuItem() { Text = "Generate Blank Request to Excel" };
      generateRequestExcelMenuItem.Click += GenerateRequestExcelMenuItem_Click;

      actionsMenu.DropDownItems.AddRange(new ToolStripItem[] {
             generateRequestImportSheetMenuItem,
             generateRequestExcelMenuItem,
             new ToolStripSeparator(),
             LoadSelectedRequestActionMenuItems()
         });
   }
   private ToolStripMenuItem LoadSelectedRequestActionMenuItems()
   {
      var selectedMenuItem = new ToolStripMenuItem() { Text = "Selected" };


      var clearRequestsRequestItemsMenuItem = new ToolStripMenuItem() { Text = "Clear Requested Items" };
      clearRequestsRequestItemsMenuItem.Click += clearRequestsRequestItemsMenuItem_Click;


      var importIntoSelectedRequestMenuItem = new ToolStripMenuItem() { Text = "Import Request from CSV" };
      importIntoSelectedRequestMenuItem.Click += importIntoSelectedRequestMenuItem_Click;

      var importRequestExcelMenuitem = new ToolStripMenuItem() { Text = "Import Request from Excel" };
      importRequestExcelMenuitem.Click += ImportRequestExcelMenuitem_Click;

      var generateRequestExportSheetMenuItem = new ToolStripMenuItem() { Text = "Export Request to CSV" };
      generateRequestExportSheetMenuItem.Click += generateRequestExportSheetMenuItem_Click; ;

      selectedMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
             clearRequestsRequestItemsMenuItem,
             new ToolStripSeparator(),
             importIntoSelectedRequestMenuItem,
             importRequestExcelMenuitem,
             generateRequestExportSheetMenuItem
         });

      return selectedMenuItem;
   }

   // all
   private void generateRequestImportSheetMenuItem_Click(object sender, EventArgs e)
   {
      RequestsExports.GenerateBlankRequestToCSV(_requestor.Bid, _catalogingRepo);
   }

   // selected
   private void clearRequestsRequestItemsMenuItem_Click(object sender, EventArgs e)
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }

      if (RequestMessaging.Instance.ConfirmRequestClearRequestItems(request) == false)
      {
         return;
      }
      _requestingRepo.DeleteRequestItems_ByRequest(request.Id);
      RequestMessaging.Instance.ShowRequestClearRequestItemsSuccess(request);

      RefreshList();
   }
   private void GenerateRequestExcelMenuItem_Click(object sender, EventArgs e)
   {
      RequestsExports.GenerateBlankRequestToExcel(_requestor);
   }
   private void importIntoSelectedRequestMenuItem_Click(object sender, EventArgs e)
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }
      RequestsImports.ImportRequestFromCSV(request, _catalogingService, _requestingRepo);

      RefreshList();
   }
   private void ImportRequestExcelMenuitem_Click(object sender, EventArgs e)
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }
      RequestsImports.ImportRequestFromExcel(request, _catalogingService, _requestingRepo);

      RefreshList();
   }
   private void generateRequestExportSheetMenuItem_Click(object sender, EventArgs e)
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }
      RequestsExports.ExportRequestToCSV(request, _requestingRepo, _requestMessaging);
   }
   #endregion


   #region BUTTON METHODS
   protected override void AddButtonClicked()
   {
      using (RequestAddForm f = new RequestAddForm(_requestor.Id))
      {
         if (f.ShowDialog() != DialogResult.OK)
         {
            return;
         }
         _requestingRepo.AddRequest_ToRequestor(f.GetRequest(), _requestor.Id);
         RequestMessaging.Instance.ShowRequestAddSuccess();
         RefreshList();
      }
   }
   protected override void EditButtonClicked()
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }

      RequestEditScreen f = new RequestEditScreen(request, _hostForm);
      _hostForm.GoForward(f);
      RefreshList();
   }
   protected override void DeleteButtonClicked()
   {
      if (SelectedItem == null)
      {
         return;
      }
      Request request = _requestingRepo.GetRequest(SelectedItemTag);
      if (request == null)
      {
         return;
      }

      if (request.RequestItems.Count > 0)
      {
         RequestMessaging.Instance.ShowRequestDelete_NotBlankError();
         return;
      }

      if (RequestMessaging.Instance.ConfirmRequestDelete(request) == false)
      {
         return;
      }
      _requestingRepo.DeleteRequest(request.Id);
      RequestMessaging.Instance.ShowRequestDeleteSuccess();
      RefreshList();
   }
   #endregion


   #region LIST METHODS
   protected override void InitializeColumns()
   {

      listViewMain.Columns.AddRange(
          new ColumnHeader[] {
                 new ColumnHeader() { Text = "Request Id",                   Width = 0 },
                 new ColumnHeader() { Text = "Account Number",               Width = 211 },
                 new ColumnHeader() { Text = "Requested Items",     Width = 163, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Quantity Sum",       Width = 159, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Total Price",                  Width = 120, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Total Price With Overrides",    Width = 175, TextAlign = HorizontalAlignment.Right  },
          }
      );
   }
   protected override void RefreshList()
   {
      listViewMain.BeginUpdate();

      listViewMain.Items.Clear();

      List<Request> requests = _requestingRepo.GetRequests_ByRequestor(_requestor.Id);
      List<ListViewItem> listviewItems = new List<ListViewItem>();

      foreach (Request r in requests)
      {
         ListViewItem newListItem = new ListViewItem();

         newListItem.Text = $"{r.Id}";
         newListItem.SubItems.Add(r.Account_Number);
         newListItem.SubItems.Add(r.RequestItems.Count.ToString());
         newListItem.SubItems.Add(r.QuantitySum().ToString());
         newListItem.SubItems.Add(r.ExtendedPriceSum().ToString("$0.00"));
         newListItem.SubItems.Add(r.ExtendedPriceWithOverridesSum().ToString("$0.00"));

         newListItem.Tag = r.Id;
         listviewItems.Add(newListItem);
      }

      listViewMain.Items.AddRange(listviewItems.ToArray());
      listViewMain.EndUpdate();
      ReselectItem();
   }
   protected override void ListViewDoubleClicked()
   {
      EditButtonClicked();
   }
   #endregion


}
