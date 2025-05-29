using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing;
using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
   public class GeneratePurchaseOrdersOperation
   {
      private readonly IBiddingRepo _biddingRepo;
      private readonly IPurchasingRepo _purchasingRepo;
      private readonly PurchasingService _purchasingService;
      private readonly PurchasingMessaging _purchasingMessaging;
      private readonly SummaryReportBuilder _summaryReportBuilder;
      private readonly VendorSummaryReportBuilder _vendorSummaryReportBuilder;
      private readonly LegacyElectionsService _legacyElectionsService;

      public GeneratePurchaseOrdersOperation(IBiddingRepo biddingRepo, IPurchasingRepo purchasingRepo,
          PurchasingService purchasingService, PurchasingMessaging purchasingMessaging,
          SummaryReportBuilder summaryReportBuilder, VendorSummaryReportBuilder vendorSummaryReportBuilder,
          LegacyElectionsService legacyElectionsService)
      {
         _biddingRepo = biddingRepo;
         _purchasingRepo = purchasingRepo;
         _purchasingService = purchasingService;
         _purchasingMessaging = purchasingMessaging;
         _summaryReportBuilder = summaryReportBuilder;
         _vendorSummaryReportBuilder = vendorSummaryReportBuilder;
         _legacyElectionsService = legacyElectionsService;
      }

      public void GeneratePurchaseOrders(Bid _bid)
      {
         IEnumerable<PurchaseOrder> purchaseOrders;

         if (_purchasingService.DoPurchaseOrdersExistOnBid(_bid.Id) && _purchasingMessaging.ConfirmPurchaseOrderGenerate() == false)
         {
            return;
         }
         if (_legacyElectionsService.Check_BidHasInvalidMultipleElections(_bid.Id))
         {
            _purchasingMessaging.ShowPurchaseOrderMultipleElectionsError();
            return;
         }
         purchaseOrders = _purchasingService.GeneratePurchaseOrders(_bid);
         _purchasingService.ClearAllPurchaseOrdersOnBid(_bid.Id);
         _purchasingService.AddPurchaseOrdersToBid(_bid.Id, purchaseOrders);
         _purchasingMessaging.ShowPurchaseOrderGenerateSuccess(purchaseOrders);
         generateReports(_bid);
      }

      private void generateReports(Bid _bid)
      {
         FileHelpers.SaveReport(_summaryReportBuilder.BuildReport(_bid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
         FileHelpers.SaveReport(_vendorSummaryReportBuilder.BuildReport(_bid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
      }
   }
}
