using System.Text;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Conversions.Excel;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Requesting;
using OfficeOpenXml;

namespace OBiddable.Library.Conversions.Bidding.Requesting;

public static class RequestsConversions
{
    private const string _requestItemCSVHeader = "itemcode,quantity,overrideprice,itemdescription,unitprice,unit,itemcategory";
    public static Request ConvertCSVToRequest(this string[] fileData, int bidId, out string error, CatalogingService catalogingService)
    {
        StringBuilder err = new StringBuilder();
        Request output = new Request();
        output.RequestItems = new List<RequestItem>();

        if (fileData[0].ToLower().Trim() != _requestItemCSVHeader)
        {
            err.AppendLine($"fatal error: file header does not match");
            error = err.ToString();
            return null;
        }
        for (int x = 1; x < fileData.Length; x++)
        {
            if (fileData[x].Trim() == "")
            {
                err.AppendLine($"line skip: line blank ( line:{ x } )");
                continue;
            }
            string[] flds = fileData[x].ParseCSVRow();

            RequestItem ri = new RequestItem();

            // item code
            int itemCode = 0;
            if (!int.TryParse(flds[0], out itemCode))
            {
                err.AppendLine($"line skip: code invalid ( line:{ x } )");
                continue;
            }
            if (output.RequestItems.Any(q => q.Item.Code == itemCode))
            {
                err.AppendLine($"line skip: item code already used ( line:{ x },code:{ itemCode } )");
                continue;
            }
            Item i = catalogingService.GetItemByCode(itemCode, bidId);
            if (i is null)
            {
                err.AppendLine($"line skip: item code not found ( line:{ x },code:{ itemCode } )");
                continue;
            }
            ri.Item = i.ClearBid();

            // quantity
            int quantity = 0;
            if (!int.TryParse(flds[1], out quantity) || quantity < 1)
            {
                err.AppendLine($"line skip: quantity invalid ( line:{ x } )");
                continue;
            }
            ri.Quantity = quantity;

            // overridePrice
            decimal overridePrice = 0;
            if (!decimal.TryParse(flds[2], out overridePrice) || overridePrice < 0)
            {
                err.AppendLine($"info: overrideprice invalid, defaulting to zero ( line:{ x } )");
                overridePrice = 0;
            }
            if (overridePrice != i.Price)
            {
                ri.OverridePrice = overridePrice;
            }

            // add requestitem to list
            output.RequestItems.Add(ri);
        }

        error = err.ToString();
        return output;
    }
    public static Request ConvertExcelFileToRequest(FileInfo file, int bidId, string password, out string error, CatalogingService catalogingService)
    {
        StringBuilder err = new StringBuilder();
        Request output = new Request();
        output.RequestItems = new List<RequestItem>();

        try
        {
            using (ExcelPackage package = new ExcelPackage(file, password))
            {
                ExcelWorksheet ws = getWorksheet(package);
                if (isLegacyRequestSheet(package))
                {
                    LegacyBidRequestImport.Import(bidId, err, output, ws, catalogingService);
                }
                ModernBidRequestImport.Import(bidId, err, output, ws, catalogingService);
            }
        }
        catch (Exception e)
        {
            err.AppendLine($"error: { e.Message }");
            output = null;
        }

        error = err.ToString();
        return output;
    }

    private static bool isLegacyRequestSheet(ExcelPackage package)
    {
        if (package.Workbook.Worksheets.Any(x => x.Name == ExcelRequestExport.DEFAULT_WORK_SHEET_NAME))
        {
            return false;
        }
        else if (package.Workbook.Worksheets.Any(x => x.Name.StartsWith("BID ")))
        {
            return true;
        }
        else
        {
            throw new Exception("Now acceptable worksheets found.");
        }
    }

    private static ExcelWorksheet getWorksheet(ExcelPackage package)
    {
        if (package.Workbook.Worksheets.Count > 0)
        {
            return package.Workbook.Worksheets.First();
        }
        throw new Exception("Worksheet not found");
    }

    public static string ConvertRequestToCSV(int requestId, IRequestingRepo requestingRepo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_requestItemCSVHeader);

        var request = requestingRepo.GetRequest(requestId);
        foreach (var ri in request.RequestItems)
        {
            sb.AppendLine(
                $"{ ri.Item.FormattedCode }," +
                $"{ ri.Quantity.ToString("0") }," +
                $"{ ri.OverridePrice.ToString("0.0000") }," +
                $"{ ri.Item.Description.strip().surround() }," +
                $"{ ri.Item.Price.ToString("0.0000") }," +
                $"{ ri.Item.Unit.strip().surround() }," +
                $"{ ri.Item.Category.strip().surround() }"
            );
        }

        return sb.ToString();
    }
    public static string GenerateBlankRequestToCSV(int bidId, ICatalogingRepo catalogingRepo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_requestItemCSVHeader);

        var items = catalogingRepo.GetItems(bidId);
        foreach (Item i in items
            //.Where(x => x.Category.Trim() != "EQUIPMENT")
            .OrderBy(x => x.Code).ToList())
        {
            sb.AppendLine(
                $"{ i.FormattedCode }," +
                $"," +
                $"," +
                $"{ i.Description.strip().surround() }," +
                $"{ i.Price.ToString("0.0000") }," +
                $"{ i.Unit.strip().surround() }," +
                $"{ i.Category.strip().surround() }"
            );
        }
        return sb.ToString();
    }
}
