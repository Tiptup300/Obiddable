using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Cataloging;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Electing;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Purchasing;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.Bidding.IO;
public static class BidsExports
{
   public static void ExportBid(Bid bid, IRespondingRepo respondingRepo, ICatalogingRepo catalogingRepo, IRequestingRepo requestingRepo, RequestMessaging requestMessaging)
   {
      string originalExportDirectory = UserConfiguration.Instance.DefaultExportsDirectory.FullName;
      bool originalSupressDialog = UserConfiguration.Instance.SupressFileLocationSelectDialog;

      string outputDirectory = FileHelpers.ShowFolderBrowserDialog(UserConfiguration.Instance.DefaultExportsDirectory.FullName, "Select folder to export bid");
      if (outputDirectory == null)
      {
         return;
      }
      UserConfiguration.Instance.DefaultExportsDirectory = new DirectoryInfo(outputDirectory);
      UserConfiguration.Instance.SupressFileLocationSelectDialog = true;

      try
      {
         // TODO export all parts individually and choose folder
         // choose folder
         // then export all into it automatically
         ItemsExports.ExportItemsToCSV(bid, catalogingRepo);
         RequestorsExports.ExportRequestorsToCSV(bid, requestingRepo);

         exportAllRequestsToCsv(bid, requestingRepo, requestMessaging);
         exportAllVendorResponsesToCsv(bid, respondingRepo, requestingRepo);
         ElectionsExports.ExportElectionsToCSV(bid);
         exportAllPurchaseOrdersToCsv(bid);
      }
      catch (Exception e)
      {
         FormsMessaging.Instance.ShowExportError(e.Message);
      }
      finally
      {
         UserConfiguration.Instance.DefaultExportsDirectory = new DirectoryInfo(originalExportDirectory);
         UserConfiguration.Instance.SupressFileLocationSelectDialog = originalSupressDialog;
      }

   }

   private static void exportAllPurchaseOrdersToCsv(Bid bid)
   {
      bid.PurchaseOrders
          .ForEach(
              purchaseOrder
                  => PurchaseOrdersExports.ExportPurchaseOrderToCSV(purchaseOrder)
          );
   }

   private static void exportAllVendorResponsesToCsv(Bid bid, IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
   {
      bid.VendorResponses
          .ForEach(
              vendorResponse
                  => VendorResponsesExports.ExportVendorResponseToCSV(vendorResponse, respondingRepo, requestingRepo)
          );
   }

   private static void exportAllRequestsToCsv(Bid bid, IRequestingRepo requestingRepo, RequestMessaging requestMessaging)
   {
      bid.Requestors
          .SelectMany(requestor => requestor.Requests)
          .Where(request => request.RequestItems.Count() > 0)
          .ToList()
          .ForEach(
              request
                  => RequestsExports.ExportRequestToCSV(request, requestingRepo, requestMessaging)
          );
   }
}
