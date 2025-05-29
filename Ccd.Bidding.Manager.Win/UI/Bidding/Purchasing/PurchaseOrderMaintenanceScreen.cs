using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Purchasing;
using Ccd.Bidding.Manager.Win.Library.Operations.Bidding;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing
{
   public class PurchaseOrderMaintenanceScreen : MaintenanceScreen
   {
      private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
      private readonly IPurchasingRepo _purchasingRepo = new EFPurchasingRepo();
      private readonly ILegacyElectionsRepo _legacyElectionsRepo = new EFLegacyElectionsRepo();

      private readonly LegacyElectionsService _legacyElectionsService = new LegacyElectionsService(new EFLegacyElectionsRepo());
      private readonly DistributionService _distributionService = new DistributionService(new EFRequestingRepo(), new EFLegacyElectionsRepo(), new EFDistributionRepo(), new EFRespondingRepo());
      private readonly PurchasingService _purchasingOperations = new PurchasingService(new EFRespondingRepo(), new EFRequestingRepo(), new EFLegacyElectionsRepo(), new DistributionService(new EFRequestingRepo(), new EFLegacyElectionsRepo(), new EFDistributionRepo(), new EFRespondingRepo()), new EFPurchasingRepo());
      private readonly PurchasingMessaging _purchasingMessaging = new PurchasingMessaging();
      private readonly GeneratePurchaseOrdersOperation _generatePurchaseOrdersOperation
          = new GeneratePurchaseOrdersOperation(
              new EFBiddingRepo(),
              new EFPurchasingRepo(),
              new PurchasingService(new EFRespondingRepo(), new EFRequestingRepo(), new EFLegacyElectionsRepo(), new DistributionService(new EFRequestingRepo(), new EFLegacyElectionsRepo(), new EFDistributionRepo(), new EFRespondingRepo()),
                  new EFPurchasingRepo()),
              new PurchasingMessaging(),
              new SummaryReportBuilder(new EFRequestingRepo(), new EFRespondingRepo(), new DistributionService(new EFRequestingRepo(), new EFLegacyElectionsRepo(), new EFDistributionRepo(), new EFRespondingRepo())),
              new VendorSummaryReportBuilder(),
              new LegacyElectionsService(new EFLegacyElectionsRepo()));

      private Bid _bid;

      public PurchaseOrderMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
      {
         _bid = _biddingRepo.GetBid(bidId);
      }

      #region INIT 
      protected override void InitializeTitles()
      {
         titleLabel.Text = "Purchase Order Maintenance";
         Text = "Purchase Order Maintenance";
         subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
         topPanel.BackColor = ApplicationColors.Purchasing;

         addButton.Enabled = false;
         addButton.Visible = false;
         editButton.Enabled = false;
         editButton.Visible = false;
      }
      #endregion

      #region ACTIONS
      protected override void InitializeActionsMenu(IActionMenu actionMenu)
      {
         actionMenu.AddAction("Generate Purchase Orders", () =>
         {
            _generatePurchaseOrdersOperation.GeneratePurchaseOrders(_bid);
            RefreshList();
         });

         actionMenu.AddSeparator();

         actionMenu.AddActionSubMenu("Selected", (subMenu) =>
         {
            subMenu.AddAction("Export Purchase Order To Csv", () =>
               {
                  if (SelectedItem == null)
                  {
                     return;
                  }
                  var po = _purchasingRepo.GetPurchaseOrder(SelectedItemTag);
                  PurchaseOrdersExports.ExportPurchaseOrderToExcel(po);
               });
         });
      }
      #endregion

      #region BUTTONS
      protected override void AddButtonClicked()
      {
         //throw new NotImplementedException();
      }
      protected override void EditButtonClicked()
      {
         //throw new NotImplementedException();
      }
      protected override void DeleteButtonClicked()
      {
         if (SelectedItem == null)
         {
            return;
         }
         PurchaseOrder purchaseOrder = _purchasingRepo.GetPurchaseOrder(SelectedItemTag);
         if (purchaseOrder == null)
         {
            return;
         }

         if (_purchasingMessaging.ConfirmPurchaseOrderDelete() == false)
         {
            return;
         }

         _purchasingRepo.DeletePurchaseOrder(purchaseOrder.Id);

         RefreshList();
      }
      #endregion

      #region LIST
      protected override void InitializeColumns()
      {
         listViewMain.Columns.AddRange(
             new ColumnHeader[] {

                    new ColumnHeader() { Text = "Purchase Order Id", Width = 0 },
                    new ColumnHeader() { Text = "Date Generated", Width = 177 },
                    new ColumnHeader() { Text = "Vendor Name", Width = 276 },
                    new ColumnHeader() { Text = "Building Name", Width = 296 },
                    new ColumnHeader() { Text = "Line Items", Width = 73 },
                    new ColumnHeader() { Text = "Quantity Sum", Width = 101 },
                    new ColumnHeader() { Text = "Total Extended Price", Width = 146 },
             }
         );
      }
      protected override void RefreshList()
      {
         listViewMain.BeginUpdate();
         listViewMain.Items.Clear();

         List<PurchaseOrder> pos = _purchasingRepo.GetPurchaseOrders_ByBid(_bid.Id).OrderByDescending(x => x.CreationDate).ToList();

         foreach (PurchaseOrder po in pos)
         {
            var row = new ListViewItem();

            row.Text = $"{po.Id}";
            row.SubItems.Add(po.CreationDate.ToString("yyy-MM-dd-HH-mm-ss"));
            row.SubItems.Add(po.Vendor);
            row.SubItems.Add(po.Building);
            row.SubItems.Add(po.LineItems.Count.ToString());
            row.SubItems.Add(po.GetQuantitySumOfLineItems().ToString());
            row.SubItems.Add(po.GetExtendedPriceSumOfLineItems().ToString("$0.00"));

            row.Tag = po.Id;

            listViewMain.Items.Add(row);
         }

         listViewMain.EndUpdate();
         ReselectItem();
      }
      protected override void ListViewDoubleClicked()
      {
         OpenSelectedPurchaseOrder_Click(this, null);
      }
      #endregion

      #region OPENS
      private void OpenSelectedPurchaseOrder_Click(object sender, EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }
         PurchaseOrder purchaseOrder = _purchasingRepo.GetPurchaseOrder(SelectedItemTag);
         if (purchaseOrder == null)
         {
            return;
         }

         _hostForm.GoForward(new PurchaseOrderViewerScreen(_hostForm, purchaseOrder.Id));
      }
      #endregion


   }
}
