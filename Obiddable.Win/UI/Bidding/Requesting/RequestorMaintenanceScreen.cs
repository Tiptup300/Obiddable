using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Library.EF.Bidding;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Win.Library.IO.Bidding.Requesting;
using Obiddable.Win.Library.UI;

namespace Obiddable.Win.UI.Bidding.Requesting;
public class RequestorMaintenanceScreen : MaintenanceScreen
{
   private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

   private readonly Bid _bid;

   public RequestorMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
   {
      _bid = _biddingRepo.GetBid(bidId);
   }

   protected override void InitializeTitles()
   {
      titleLabel.Text = "Requestors Maintenance";
      Text = "Requestors Maintenance";
      subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
      topPanel.BackColor = ApplicationColors.Requesting;
   }

   protected override void InitializeActionsMenu(IActionMenu actionMenu)
   {
      actionsMenu.DropDownItems.AddRange([

         CreateMenuItem("Import Requestors from CSV", () =>
         {
            RequestorsImports.ImportRequestorsFromCSV(_bid, _requestingRepo);
            RefreshList();
         }),

         CreateMenuItem("Export All Requestors to CSV", () =>
         {
            RequestorsExports.ExportRequestorsToCSV(_bid, _requestingRepo);
         }),

         CreateMenuItem("Generate Requestor Import Template to CSV", () =>
         {
            RequestorsExports.GenerateRequestorsImportTemplateToCSV();
         }),

         new ToolStripSeparator(),

         CreateMenuItem("Generate Blank Requests For All Requestors to Excel", () =>
         {
            try{
               RequestsExports.ExportBlankRequestToExcelForAllRequestors(_bid, _requestingRepo);
            }
            catch(Exception ex)
            {
               RequestorMessaging.Instance.ShowExportBlankRequestToExcelForAllRequestors_FailedError(ex);
            }
         }),

         new ToolStripSeparator(),

         new ToolStripMenuItem("Selected")
         {
            DropDownItems =
            {
               CreateMenuItem("Open Requestor's Requests", OpenRequestsForRequestor),
               CreateMenuItem("Clear Requestor's Requests", ClearRequestorsRequests)
            }
         }
      ]);
   }

   protected override void AddButtonClicked()
   {
      using var addForm = new RequestorEditForm(_bid);

      if (addForm.ShowDialog() != DialogResult.OK ||
         addForm.GetRequestor() is not Requestor newRequestor)
      {
         return;
      }
      _requestingRepo.AddRequestor_ToBid(newRequestor, _bid.Id);

      RefreshList();
   }
   protected override void EditButtonClicked()
   {
      if (SelectedItem == null ||
         _requestingRepo.GetRequestor(SelectedItemTag) is not Requestor requestor)
      {
         return;
      }

      using var editForm = new RequestorEditForm(requestor);

      if (editForm.ShowDialog() != DialogResult.OK ||
         editForm.GetRequestor() is not Requestor editedRequestor)
      {
         return;
      }
      _requestingRepo.UpdateRequestor(editedRequestor);

      RefreshList();
   }
   protected override void DeleteButtonClicked()
   {
      if (SelectedItem is null ||
         _requestingRepo.GetRequestor(SelectedItemTag) is not Requestor requestor)
      {
         return;
      }

      if (requestor.Requests.Count > 0)
      {
         RequestorMessaging.Instance.ShowRequestorDelete_RequestorNotBlankError();
         return;
      }
      if (!RequestorMessaging.Instance.ConfirmRequestorDelete(requestor))
      {
         return;
      }

      _requestingRepo.DeleteRequestor(requestor.Id);

      RefreshList();
   }

   protected override void InitializeColumns()
   {
      listViewMain.Columns.AddRange([
         new() { Text = "Requestor Id", Width = 0 },
         new() { Text = "Requestor Code", Width = 121 },
         new() { Text = "Building Name", Width = 239 },
         new() { Text = "Requestor Name", Width = 159 },
         new() { Text = "Requests", Width = 116, TextAlign = HorizontalAlignment.Right  },
         new() { Text = "Requested Items", Width = 169, TextAlign = HorizontalAlignment.Right  },
         new() { Text = "Quantity Sum", Width = 167, TextAlign = HorizontalAlignment.Right  },
         new() { Text = "Total Price", Width = 120, TextAlign = HorizontalAlignment.Right  },
         new() { Text = "Total Price With Overrides", Width = 171, TextAlign = HorizontalAlignment.Right  },
      ]);
   }
   protected override void RefreshList()
   {
      if (_requestingRepo.GetRequestors_ByBid(_bid.Id) is not List<Requestor> requestors)
         return;

      listViewMain.ReplaceListViewItems(
         requestors
            .Select(r => new ListViewItem(items: [
               $"{r.Id}",
               r.FormattedCode,
               r.Building,
               r.Name,
               r.Requests.Count.ToString(),
               r.RequestItemsCount().ToString(),
               r.QuantitySum().ToString(),
               r.TotalPrice().ToString("$0.00"),
               r.TotalPriceWithOverride().ToString("$0.00")
            ])
            { Tag = r.Id })
            .ToArray()
      );

      ReselectItem();
   }

   protected override void ListViewDoubleClicked()
   {
      OpenRequestsForRequestor();
   }

   private void OpenRequestsForRequestor()
   {
      if (SelectedItem == null ||
         _requestingRepo.GetRequestor(SelectedItemTag) is not Requestor requestor)
      {
         return;
      }

      _hostForm.GoForward(
         new RequestMaintenanceScreen(_hostForm, requestor.Id)
      );

      RefreshList();
   }

   private void ClearRequestorsRequests()
   {
      if (SelectedItem == null ||
         _requestingRepo.GetRequestor(SelectedItemTag) is not Requestor requestor)
      {
         return;
      }

      if (!RequestorMessaging.Instance.ConfirmRequestorClearRequests())
      {
         return;
      }

      _requestingRepo.ClearRequests_ByRequestor(requestor.Id);

      RefreshList();
   }
}
