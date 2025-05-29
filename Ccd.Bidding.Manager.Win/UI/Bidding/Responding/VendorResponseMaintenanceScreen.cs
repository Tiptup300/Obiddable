using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Responding
{
   public class VendorResponseMaintenanceScreen : MaintenanceScreen
   {
      private readonly CatalogingService _catalogingService = new CatalogingService(new EFCatalogingRepo());
      private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
      private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

      private Bid _bid;
      public VendorResponseMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
      {
         _bid = _biddingRepo.GetBid(bidId);
      }

      #region INIT METHODS
      protected override void InitializeTitles()
      {
         titleLabel.Text = "Vendor Responses Maintenance";
         Text = "Vendor Responses Maintenance";
         subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
         topPanel.BackColor = ApplicationColors.VendorResponses;
      }
      protected override void InitializeActionsMenu(IActionMenu actionMenu)
      {
         var generateVendorsImportSheetMenuItem = new ToolStripMenuItem() { Text = "Generate Blank Vendor Response to CSV" };
         generateVendorsImportSheetMenuItem.Click += GenerateVendorsImportSheetMenuItem_Click;

         var generateVendorsImportSheetExcelMenuItem = new ToolStripMenuItem() { Text = "Generate Blank Vendor Response to Excel" };
         generateVendorsImportSheetExcelMenuItem.Click += GenerateVendorsImportSheetExcelMenuItem_Click;

         actionsMenu.DropDownItems.AddRange(new ToolStripItem[] {
                generateVendorsImportSheetMenuItem,
                generateVendorsImportSheetExcelMenuItem,
                new ToolStripSeparator(),
                LoadSelectedVendorResponseActionMenuItems(),

            });
      }
      private ToolStripMenuItem LoadSelectedVendorResponseActionMenuItems()
      {
         var selectedMenuItem = new ToolStripMenuItem() { Text = "Selected Vendor Response" };

         var clearVendorResponsesResponseItemsMenuItem = new ToolStripMenuItem() { Text = "Clear Response Items" };
         clearVendorResponsesResponseItemsMenuItem.Click += ClearVendorResponsesResponseItemsMenuItem_Click;

         var importIntoSelectedVendorResponseMenuItem = new ToolStripMenuItem() { Text = "Import Vendor Response from CSV" };
         importIntoSelectedVendorResponseMenuItem.Click += importVendorsMenuItem_Click;

         var importExcelMenuItem = new ToolStripMenuItem() { Text = "Import Vendor Response from Excel" };
         importExcelMenuItem.Click += ImportExcelMenuItem_Click;

         var exportVendorResponseMenuItem = new ToolStripMenuItem() { Text = "Export Vendor Response to CSV" };
         exportVendorResponseMenuItem.Click += ExportVendorResponseMenuItem_Click;

         selectedMenuItem.DropDownItems.AddRange(new ToolStripItem[]
         {
                clearVendorResponsesResponseItemsMenuItem,
                new ToolStripSeparator(),
                importIntoSelectedVendorResponseMenuItem,
                importExcelMenuItem,
                exportVendorResponseMenuItem,
         });

         return selectedMenuItem;
      }
      #endregion

      #region ACTIONS
      private void GenerateVendorsImportSheetExcelMenuItem_Click(object sender, EventArgs e)
      {
         VendorResponsesExports.GenerateBlankVendorResponseToExcel(_bid);
      }
      private void ImportExcelMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }

         VendorResponsesImports.ImportVendorResponseFromExcel(vendorResponse, _respondingRepo, _catalogingService);

         RefreshList();
      }
      private void ExportVendorResponseMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }

         VendorResponsesExports.ExportVendorResponseToCSV(vendorResponse, _respondingRepo, _requestingRepo);
      }
      private void ClearVendorResponsesResponseItemsMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }

         if (VendorResponseMessaging.Instance.ConfirmVendorResponseClearResponseItems(vendorResponse) == false)
         {
            return;
         }
         _respondingRepo.DeleteResponseItems_ByVendorResponse(vendorResponse.Id);
         VendorResponseMessaging.Instance.ShowVendorResponseClearResponseItemsSuccess(vendorResponse);

         RefreshList();
      }
      private void GenerateVendorsImportSheetMenuItem_Click(object sender, EventArgs e)
      {
         VendorResponsesExports.GenerateBlankVendorResponseToCSV(_bid, _catalogingRepo, _requestingRepo);
      }
      private void importVendorsMenuItem_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }

         VendorResponsesImports.ImportVendorResponseFromCSV(vendorResponse, _respondingRepo, _catalogingService);

         RefreshList();
      }
      #endregion

      #region BUTTONS
      protected override void AddButtonClicked()
      {
         using (VendorResponseAddForm f = new VendorResponseAddForm(_bid.Id))
         {
            if (f.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            _respondingRepo.AddVendorResponse_ToBid(f.GetVendorResponse(), _bid.Id);
            VendorResponseMessaging.Instance.ShowVendorResponseAddSuccess(f.GetVendorResponse());

            RefreshList();
         }
      }
      protected override void EditButtonClicked()
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }

         VendorResponseEditScreen f = new VendorResponseEditScreen(vendorResponse, _hostForm);
         _hostForm.GoForward(f);

         RefreshList();
      }
      protected override void DeleteButtonClicked()
      {
         if (SelectedItem == null)
         {
            return;
         }
         VendorResponse vendorResponse = _respondingRepo.GetVendorResponse(SelectedItemTag);
         if (vendorResponse == null)
         {
            return;
         }
         if (VendorResponseMessaging.Instance.ConfirmVendorResponseDelete(vendorResponse) == false)
         {
            return;
         }

         if (vendorResponse.ResponseItems.Count > 0)
         {
            VendorResponseMessaging.Instance.ShowVendorResponseDelete_NotBlankError();
            return;
         }

         _respondingRepo.DeleteVendorResponse(vendorResponse.Id);
         RefreshList();
      }
      #endregion

      #region LIST METHODS
      protected override void InitializeColumns()
      {

         listViewMain.Columns.AddRange(
             new ColumnHeader[] {
                    new ColumnHeader() { Text = "Vendor Response Id", Width = 0 },
                    new ColumnHeader() { Text = "Vendor Name", Width = 318 },
                    new ColumnHeader() { Text = "Responses Entered", Width = 160, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Total Price", Width = 120, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Elected Responses", Width = 163, TextAlign = HorizontalAlignment.Right  },
                    new ColumnHeader() { Text = "Total Price Elected", Width = 120, TextAlign = HorizontalAlignment.Right  },
             }
         );
      }
      protected override void RefreshList()
      {
         listViewMain.BeginUpdate();

         listViewMain.Items.Clear();

         List<VendorResponse> vendors = _respondingRepo.GetVendorResponses_ByBid(_bid.Id).OrderBy(x => x.VendorName).ToList();
         List<ListViewItem> listviewItems = new List<ListViewItem>();

         foreach (VendorResponse v in vendors)
         {
            ListViewItem newListItem = new ListViewItem();

            newListItem.Text = $"{v.Id}";
            newListItem.SubItems.Add(v.VendorName);
            newListItem.SubItems.Add(v.ResponseItems.Count.ToString());
            newListItem.SubItems.Add(v.GetGetSum_TotalPrice(_requestingRepo).ToString("$0.00"));
            newListItem.SubItems.Add(v.GetCount_Elected.ToString());
            newListItem.SubItems.Add(v.GetGetSum_ElectedTotalPrice(_requestingRepo).ToString("$0.00"));

            newListItem.Tag = v.Id;
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
}
