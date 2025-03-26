using System.Text;
using OBiddable.Library.Bidding.Responding;
using OBiddable.Library.Bidding.Requesting.Extensions;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.Conversions.Bidding.Responding;

public static class VendorResponsesConversions
{
    private const string _vendorResponseCSVHeader = "itemcode,itemdescription,quantityrequested,unit,vendorpartnumber,bidprice,isalternate,altquantity,altunit,altdescription,notes";
    public static VendorResponse ConvertCSVToVendorResponse(this string[] fileData, int bidId, out string error, CatalogingService catalogingService)
    {
        StringBuilder err = new StringBuilder();
        VendorResponse output = new VendorResponse();
        output.ResponseItems = new List<ResponseItem>();

        if (fileData[0].ToLower().Trim() != _vendorResponseCSVHeader)
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
            Item item;
            string code;
            decimal price;
            decimal alternateQuantity;
            string alternateUnit;
            bool isAlternate;
            string alternateDescription;
            ResponseItem ri;

            // item
            int itemCode = 0;
            if (!int.TryParse(flds[0], out itemCode))
            {
                err.AppendLine($"line skip: itemCode invalid ( line:{ x })");
                continue;
            }
            Item i = catalogingService.GetItemByCode(itemCode, bidId);
            if (i is null)
            {
                err.AppendLine($"line skip: itemCode not found ( line:{ x },itemCode:{ itemCode } )");
                continue;
            }
            item = i.ClearBid();

            // vendorcode
            string vendorCode = flds[4];
            if (vendorCode.Length > 255)
            {
                err.AppendLine($"line skip: code invalid ( line:{ x } )");
                continue;
            }
            code = vendorCode;

            // price
            price = 0;
            if (!decimal.TryParse(flds[5], out price) || price <= 0)
            {
                err.AppendLine($"line skip: price invalid ( line:{ x } )");
                continue;
            }

            // isalternate
            bool isAlt = false;
            if (!bool.TryParse(flds[6], out isAlt))
            {
                err.AppendLine($"line skip: isAlt invalid ( line:{ x } )");
                continue;
            }
            isAlternate = isAlt;
            if (isAlt)
            {
                // alt quantity
                decimal altQuantity = 0;
                if (!decimal.TryParse(flds[7], out altQuantity) || altQuantity <= 0)
                {
                    err.AppendLine($"line skip: altQuantity invalid ( line:{ x } )");
                    continue;
                }
                alternateQuantity = altQuantity;

                // alt unit
                string altUnit = flds[8];
                if (altUnit.Length == 0 || altUnit.Length > 255)
                {
                    err.AppendLine($"line skip: altUnit invalid ( line:{ x } )");
                    continue;
                }
                alternateUnit = altUnit;

                // alt description (+ notes)
                string altDescription = flds[9] + (flds[10].Trim() != "" ? "\r\n" + flds[10] : "");
                if (altDescription.Length == 0 || altDescription.Length > 500)
                {
                    err.AppendLine($"line skip: altDescription invalid ( line:{ x } )");
                    continue;
                }
                alternateDescription = altDescription;
            }
            else
            {
                // quantity is defined if not alternate
                alternateQuantity = 0;
                alternateUnit = null;
                alternateDescription = null;
            }
            ri = new ResponseItem(
                null,
                item,
                code,
                price,
                alternateQuantity,
                alternateUnit,
                isAlternate,
                alternateDescription,
                false,
                null
                );
            output.ResponseItems.Add(ri);
        }

        error = err.ToString();
        return output;
    }
    public static VendorResponse ConvertExcelFileToVendorResponse(FileInfo file, int bidId, out string error, CatalogingService catalogingService)
    {
        StringBuilder err = new StringBuilder();
        VendorResponse output = new VendorResponse();
        output.ResponseItems = new List<ResponseItem>();

        using (ExcelPackage package = new ExcelPackage(file))
        {
            ExcelWorksheet ws = package.Workbook.Worksheets[ExcelVendorResponseExport.WORK_SHEET_NAME];

            for (int row = ExcelVendorResponseExport.FIRST_ITEM_ROW; ws.Cells[row, 1].Value != null; row++)
            {
                Item item;
                string code;
                decimal price;
                decimal alternateQuantity;
                string alternateUnit;
                bool isAlternate;
                string alternateDescription;
                ResponseItem ri;


                // item code
                string itemCodeField = ws.Cells[row, 1].Value != null ? ws.Cells[row, 1].Value.ToString().Trim() : "";
                int itemCode = 0;
                if (itemCodeField == "")
                {
                    err.AppendLine($"line skip: code blank ( line:{ row } )");
                    continue;
                }
                if (!int.TryParse(itemCodeField, out itemCode))
                {
                    err.AppendLine($"line skip: code invalid ( line:{ row } )");
                    continue;
                }
                Item i = catalogingService.GetItemByCode(itemCode, bidId);
                if (i is null)
                {
                    err.AppendLine($"line skip: item code not found ( line:{ row },code:{ itemCode } )");
                    continue;
                }
                item = i.ClearBid();

                // vendorCode
                string vendorPartCodeField = ws.Cells[row, 3].Value != null ? ws.Cells[row, 3].Value.ToString().Trim() : "";
                string vendorCode = vendorPartCodeField;
                if (vendorCode.Length > 255)
                {
                    err.AppendLine($"line skip: code invalid ( line:{ row } )");
                    continue;
                }
                code = vendorCode;

                // isalternate
                string isAltField = ws.Cells[row, 8].Value != null ? ws.Cells[row, 8].Value.ToString().Trim() : "";
                bool isAlt = false;
                if (!string.IsNullOrEmpty(isAltField) && !bool.TryParse(isAltField, out isAlt))
                {
                    err.AppendLine($"line skip: isAlt invalid ( line:{ row } )");
                    continue;
                }
                isAlternate = isAlt;
                if (isAlt)
                {
                    // alt quantity
                    string altQtyField = ws.Cells[row, 10].Value != null ? ws.Cells[row, 10].Value.ToString().Trim() : "";
                    decimal altQuantity = 0;
                    if (!decimal.TryParse(altQtyField, out altQuantity) || altQuantity <= 0)
                    {
                        err.AppendLine($"line skip: altQuantity invalid ( line:{ row } )");
                        continue;
                    }
                    alternateQuantity = altQuantity;

                    // alt unit
                    string altUnitField = ws.Cells[row, 11].Value != null ? ws.Cells[row, 11].Value.ToString().Trim() : "";
                    string altUnit = altUnitField;
                    if (altUnit.Length == 0 || altUnit.Length > 255)
                    {
                        err.AppendLine($"line skip: altUnit invalid ( line:{ row } )");
                        continue;
                    }
                    alternateUnit = altUnit;

                    // alt description
                    string altDescriptionField = ws.Cells[row, 9].Value != null ? ws.Cells[row, 9].Value.ToString().Trim() : "";
                    string altDescription = altDescriptionField;
                    if (altDescription.Length == 0 || altDescription.Length > 500)
                    {
                        err.AppendLine($"line skip: altDescription invalid ( line:{ row } )");
                        continue;
                    }
                    alternateDescription = altDescription;

                    // alt Price
                    string altUnitPriceField = ws.Cells[row, 12].Value != null ? ws.Cells[row, 12].Value.ToString().Trim() : "";
                    decimal altPrice = 0;
                    if (!decimal.TryParse(altUnitPriceField, out altPrice) || altPrice <= 0)
                    {
                        err.AppendLine($"line skip: price invalid ( line:{ row } )");
                        continue;
                    }
                    price = altPrice;
                }
                else
                {

                    // price
                    string unitPriceField = ws.Cells[row, 6].Value != null ? ws.Cells[row, 6].Value.ToString().Trim() : "";
                    price = 0;
                    if (string.IsNullOrEmpty(unitPriceField))
                    {
                        continue;
                    }
                    else if (!decimal.TryParse(unitPriceField, out price) || price <= 0)
                    {
                        err.AppendLine($"line skip: price invalid ( line:{ row } )");
                        continue;
                    }

                    // quantity is defined if not alternate
                    alternateQuantity = 0;
                    alternateUnit = null;
                    alternateDescription = null;
                }

                ri = new ResponseItem(
                    null,
                    item,
                    code,
                    price,
                    alternateQuantity,
                    alternateUnit,
                    isAlternate,
                    alternateDescription,
                    false,
                    null
                    );

                // add to list, next row
                output.ResponseItems.Add(ri);
            }
            error = err.ToString();

            package.Encryption.IsEncrypted = true;
            return output;
        }

    }
    public static string ConvertVendorResponseToCSV(int vendorResponseId, IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_vendorResponseCSVHeader);

        var vendorResponse = respondingRepo.GetVendorResponse(vendorResponseId);
        foreach (var ri in vendorResponse.ResponseItems)
        {
            sb.AppendLine(
                $"{ ri.Item.FormattedCode }," +
                $"{ ri.Item.Description.strip().surround() }," +
                $"{ ri.Item.GetRequestedQuantity(requestingRepo)  }," +
                $"{ ri.Item.Unit.strip().surround() }," +
                $"{ ri.Code.strip().surround() }," +
                $"{ ri.Price.ToString("0.0000") }," +
                $"{ ri.IsAlternate }," +
                $"{ (ri.IsAlternate ? ri.AlternateQuantity.ToString("0.0000") : "") }," +
                $"{ (ri.IsAlternate ? ri.AlternateUnit.strip().surround() : "") }," +
                $"{ (ri.IsAlternate ? ri.AlternateDescription.strip().surround() : "") }" +
                $"," // note
            );
        }

        return sb.ToString();
    }
    public static string GenerateBlankVendorResponseToCSV(int bidId, ICatalogingRepo catalogingRepo, IRequestingRepo requestingRepo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_vendorResponseCSVHeader);

        var requestedItems = catalogingRepo.GetItems(bidId).Where(x => x.GetRequestedQuantity(requestingRepo) > 0).OrderBy(x => x.Code).ToList();
        foreach (Item i in requestedItems)
        {
            sb.AppendLine(
                $"{ i.FormattedCode.strip().surround() }," +
                $"{ i.Description.strip().surround() }," +
                $"{ i.GetRequestedQuantity(requestingRepo) }," +
                $"{ i.Unit.strip().surround() }," +
                $"," +
                $"," +
                $"," +
                $"," +
                $"," +
                $"," +
                $","
            );
        }
        return sb.ToString();
    }
}
