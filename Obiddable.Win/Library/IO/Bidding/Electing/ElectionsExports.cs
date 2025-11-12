using Obiddable.Library.Bidding;
using Obiddable.Library.Conversions.Bidding.Electing;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Win.UI.Bidding.Electing;

namespace Obiddable.Win.Library.IO.Bidding.Electing;
public static class ElectionsExports
{
   private static readonly ExportFileNameFactory _fileNameGetter;
   private static readonly ElectionsConversions _electionsConversions;

   static ElectionsExports()
   {
      _fileNameGetter = new ExportFileNameFactory();
      _electionsConversions = new ElectionsConversions(new EFCatalogingRepo(), new EFRespondingRepo());
   }

   public static void ExportElectionsToCSV(Bid bid)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "elections", "csv", "", DateTime.Now);
      string data = _electionsConversions.ConvertElectionsToCSV(bid.Id);
      string title = "Save Elections Export";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

      ElectingMessaging.Instance.ShowElectionExportSuccess();
   }
}
