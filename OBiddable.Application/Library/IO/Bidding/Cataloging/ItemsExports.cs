using System;
using System.Collections.Generic;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Win.UI;
using OBiddable.Library.Bidding;
using OBiddable.Library.Conversions.Bidding.Cataloging;
using OBiddable.Library.Bidding.Cataloging;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Cataloging
{
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

            FormsMessaging.Instance.ShowImportTemplateGeneratedSuccess();
        }

        public static void ExportItemsToCSV(Bid bid, ICatalogingRepo catalogingRepo)
        {
            string fileName = _fileNameGetter.BuildFileName(bid, "items", "csv", "", DateTime.Now);
            string data = _itemsConversions.ConvertItemsToCSV(bid.Id, catalogingRepo);
            string title = "Save Items Export";
            FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

            FormsMessaging.Instance.ShowExportSuccess();
        }
    }
}
