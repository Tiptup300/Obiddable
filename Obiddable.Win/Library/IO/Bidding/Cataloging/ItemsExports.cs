using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Conversions.Bidding.Cataloging;

namespace Obiddable.Win.Library.IO.Bidding.Cataloging;
public static class ItemsExports
{
   private static readonly ExportFileNameFactory _fileNameGetter;
   private static readonly ItemsConversions _itemsConversions;

   static ItemsExports()
   {
      _fileNameGetter = new ExportFileNameFactory();
      _itemsConversions = new ItemsConversions();
   }

   public static void GenerateItemsImportTemplateToCSV()
   {
      string fileName = "items-import-template.csv";
      string data = ItemsConversions.Instance.GenerateBlankItemsImportTemplate();
      string title = "Save Item Import Template";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
   }

   public static void ExportItemsToCSV(Bid bid, ICatalogingRepo catalogingRepo)
   {
      string fileName = _fileNameGetter.BuildFileName(bid, "items", "csv", "", DateTime.Now);
      string data = _itemsConversions.ConvertItemsToCSV(bid.Id, catalogingRepo);
      string title = "Save Items Export";
      FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
   }
}
