using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Conversions.Excel;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Conversions.Bidding.Requesting
{
    public class ModernBidRequestImport
    {
        public static void Import(int bidId, StringBuilder err, Request output, ExcelWorksheet ws, CatalogingService catalogingService)
        {
            for (int row = ExcelRequestExport.FIRST_ITEM_ROW; ws.Cells[row, 1].Value != null; row++)
            {
                RequestItem ri = new RequestItem();

                // item code
                int itemCode = 0;
                if (ws.Cells[row, 1].Value.ToString().Trim() == "")
                {
                    err.AppendLine($"line skip: code blank ( line:{ row } )");
                    continue;
                }
                if (!int.TryParse(ws.Cells[row, 1].Value.ToString(), out itemCode))
                {
                    err.AppendLine($"line skip: code invalid ( line:{ row } )");
                    continue;
                }
                if (output.RequestItems.Any(q => q.Item.Code == itemCode))
                {
                    err.AppendLine($"line skip: item code already used ( line:{ row },code:{ itemCode } )");
                    continue;
                }
                Item i = catalogingService.GetItemByCode(itemCode, bidId);
                if (i is null)
                {
                    err.AppendLine($"line skip: item code not found ( line:{ row },code:{ itemCode } )");
                    continue;
                }
                ri.Item = i.ClearBid();

                // overridePrice
                decimal overridePrice = 0;
                if (ws.Cells[row, 4].Value != null)
                {
                    if (!decimal.TryParse(ws.Cells[row, 4].Value.ToString(), out overridePrice) || overridePrice < 0)
                    {
                        err.AppendLine($"info: overrideprice invalid, defaulting to zero ( line:{ row } )");
                        overridePrice = 0;
                    }
                    if (overridePrice != i.Price)
                    {
                        ri.OverridePrice = overridePrice;
                    }
                }


                // quantity
                int quantity = 0;
                if (ws.Cells[row, 6].Value is null || ws.Cells[row, 6].Value.ToString().Trim() == "")
                {
                    // item not requested
                    continue;
                }
                else if (!int.TryParse(ws.Cells[row, 6].Value.ToString(), out quantity))
                {
                    err.AppendLine($"line skip: quantity invalid ( line:{ row } )");
                    continue;
                }
                else if (quantity == 0)
                {
                    // item not requested
                    continue;
                }
                ri.Quantity = quantity;


                output.RequestItems.Add(ri);
            }
        }
    }
}
