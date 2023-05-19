using System;
using System.Collections.Generic;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Purchasing;
using Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Purchasing
{
    public static class PurchaseOrdersExports
    {
        private static readonly ExportFileNameFactory _fileNameGetter;
        private static readonly PurchaseOrdersConversions _purchaseOrdersConversions;

        static PurchaseOrdersExports()
        {
            _fileNameGetter = new ExportFileNameFactory();
            _purchaseOrdersConversions = new PurchaseOrdersConversions();
        }

        public static void ExportPurchaseOrderToCSV(PurchaseOrder po)
        {
            string fileName = _fileNameGetter.BuildFileName(po.Bid, "purchase-order", "csv", getFileNameDetail(po), po.CreationDate);
            string data = _purchaseOrdersConversions.ConvertPurchaseOrderToCsv(po);
            string title = "Save Purchase Order";
            FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

            PurchasingMessaging.Instance.ShowPurchaseOrderExportSuccess();
        }
        public static void ExportPurchaseOrderToExcel(PurchaseOrder po)
        {
            string fileName = _fileNameGetter.BuildFileName(po.Bid, "purchase-order", "xlsx", getFileNameDetail(po), po.CreationDate);
            ExcelPurchaseOrderExport excelPurchaseOrderExport = new ExcelPurchaseOrderExport(po);
            string title = "Export Purchase Order";
            using (MemoryStream ms = excelPurchaseOrderExport.Generate())
            {
                FileHelpers.SaveExcel(fileName, ms, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);
            }
            PurchasingMessaging.Instance.ShowPurchaseOrderExportSuccess();
        }
        private static string getFileNameDetail(PurchaseOrder po)
            => $"{po.Vendor }-{po.Building}";
    }
}
