using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI.Bidding.Responding;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Responding;
public static class VendorResponsesExports
{
   private static readonly ExportFileNameFactory _fileNameGetter = new ExportFileNameFactory();
   public static void GenerateBlankVendorResponseToCSV(Bid bid, ICatalogingRepo catalogingRepo, IRequestingRepo requestingRepo)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "vendor-response-blank", "csv", "", DateTime.Now);
      string data = VendorResponsesConversions.GenerateBlankVendorResponseToCSV(bid.Id, catalogingRepo, requestingRepo);
      string title = "Save Request Import Sheet";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

      VendorResponseMessaging.Instance.ShowVendorResponseGenerateBlankSuccess();
   }
   public static void GenerateBlankVendorResponseToExcel(Bid bid)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "vendor-response-sheet", "xlsx", "", DateTime.Now);
      string title = "Save Request Excel";
      var excelExport = new ExcelVendorResponseExport(bid);
      using (var ms = excelExport.Generate())
      {
         FileHelpers.SaveExcel(fileName, ms, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
      }

      VendorResponseMessaging.Instance.ShowVendorResponseGenerateBlankSuccess();
   }
   public static void ExportVendorResponseToCSV(VendorResponse vendorResponse, IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
   {
      string fileName = _fileNameGetter.BuildFileName(vendorResponse.Bid, "vendor-response", "csv", getFileNameDetail(vendorResponse), DateTime.Now);
      string data = VendorResponsesConversions.ConvertVendorResponseToCSV(vendorResponse.Id, respondingRepo, requestingRepo);
      string title = "Save Vendor Response Export";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

      VendorResponseMessaging.Instance.ShowVendorResponseExportSuccess();
   }
   private static string getFileNameDetail(VendorResponse vr)
       => $"{vr.VendorName}";
}
