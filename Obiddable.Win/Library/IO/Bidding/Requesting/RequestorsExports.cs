using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Conversions.Bidding.Requesting;
using Obiddable.Win.UI;

namespace Obiddable.Win.Library.IO.Bidding.Requesting;
public static class RequestorsExports
{
   private static readonly ExportFileNameFactory _fileNameGetter = new ExportFileNameFactory();

   public static void GenerateRequestorsImportTemplateToCSV()
   {
      string fileName = "requestors-import-template.csv";
      string data = RequestorsConversions.GenerateBlankRequestorsImportTemplate();
      string title = "Save Requestors Import Template";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
   }

   public static void ExportRequestorsToCSV(Bid bid, IRequestingRepo requestingRepo)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "requestors", "csv", "", DateTime.Now);
      string data = RequestorsConversions.ConvertRequestorsToCSV(bid.Id, requestingRepo);
      string title = "Save Requestors Export";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
   }
}
