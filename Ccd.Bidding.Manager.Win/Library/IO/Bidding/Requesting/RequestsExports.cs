using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Conversions.Excel;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting;
public static class RequestsExports
{
   private static readonly ExportFileNameFactory _fileNameGetter = new ExportFileNameFactory();

   public static void GenerateBlankRequestToCSV(Bid bid, ICatalogingRepo catalogingRepo)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "request-blank", "csv", "", DateTime.Now);
      string data = RequestsConversions.GenerateBlankRequestToCSV(bid.Id, catalogingRepo);
      string title = "Save Request Import Sheet";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

      FormsMessaging.Instance.ShowImportTemplateGeneratedSuccess();
   }

   public static void ExportBlankRequestToExcelForAllRequestors(Bid bid, IRequestingRepo requestingRepo)
   {
      List<Requestor> requestors = requestingRepo.GetRequestors_ByBid(bid.Id);
      string[] fileNames = new string[requestors.Count];
      MemoryStream[] streams = new MemoryStream[requestors.Count];

      DateTime now = DateTime.Now;

      for (int x = 0; x < requestors.Count; x++)
      {
         fileNames[x] = $"{bid.Id}-{requestors[x].Code}-{requestors[x].Name}-{requestors[x].Building}.xlsx".MakeValidFileName();
         streams[x] = new ExcelRequestExport(requestors[x]).Generate();
      }
      string description = "Save Request Excel";
      FileHelpers.SaveExcels(fileNames, streams, description);

      // dispose streams
      for (int x = 0; x < streams.Length; x++)
      {
         streams[x].Dispose();
      }

      RequestorMessaging.Instance.ShowRequestorExportAllExcelsSuccess();
   }

   public static void ExportRequestToCSV(Request request, IRequestingRepo requestingRepo, RequestMessaging requestMessaging)
   {
      if (request.RequestItems.Count == 0)
      {
         requestMessaging.ShowRequestExportNoRequestItemsError();
         return;
      }
      string fileName = _fileNameGetter.BuildFileName(request.Requestor.Bid, "request", "csv", getFileNameDetail(request), DateTime.Now);
      string data = RequestsConversions.ConvertRequestToCSV(request.Id, requestingRepo);
      string title = "Save Request Export";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
      requestMessaging.ShowRequestExportSuccess();
   }
   public static void GenerateBlankRequestToExcel(Requestor requestor)
   {
      string fileName = $"{requestor.Bid.Id}-{requestor.Code}-{requestor.Name}-{requestor.Building}.xlsx".MakeValidFileName();
      string title = "Save Request Excel";
      var excelRequestExport = new ExcelRequestExport(requestor);
      using (MemoryStream ms = excelRequestExport.Generate())
      {
         FileHelpers.SaveExcel(fileName, ms, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
      }

      RequestMessaging.Instance.ShowRequestExportSuccess();
   }
   private static string getFileNameDetail(Request r)
       => $"{r.Requestor.Code}-{r.Requestor.Name}-{r.Account_Number}";
}
