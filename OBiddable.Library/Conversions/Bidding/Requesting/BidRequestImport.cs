using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Conversions;
using OBiddable.Library.Conversions.Excel;
using OfficeOpenXml;
using System.Text;

namespace Ccd.Bidding.Manager.Library.Conversions.Bidding.Requesting;

public class ModernBidRequestImport : IDisposable
{
    private bool _isDisposed = false;
    private readonly ICatalogingRepo _catalogingRepo;

    public ModernBidRequestImport(ICatalogingRepo catalogingRepo)
    {
        _catalogingRepo = catalogingRepo;
    }

    public void Import(int bidId, StringBuilder errorLog, Request output, ExcelWorksheet ws, ICatalogingRepo catalogingRepo)
    {
        IEnumerable<RequestItem> parsedRequestItems;
        IEnumerable<RequestItem> nonDuplicateRequestItems;


        parsedRequestItems = getRequestItemRows(ws.Cells)
            .Select(row => parse(errorLog, ws.Cells, row, catalogingRepo, bidId))
            .Where(isNonNull());

        nonDuplicateRequestItems = removeRequestItemsWithDuplicateItems(parsedRequestItems);
        output.RequestItems = nonDuplicateRequestItems.ToList();
    }

    private Func<RequestItem, bool> isNonNull()
        => requestItem => requestItem != null;
    private IEnumerable<RequestItem> removeRequestItemsWithDuplicateItems(IEnumerable<RequestItem> requestItems)
    {
        IEnumerable<RequestItem> output;
        IEnumerable<RequestItem> duplicateRequestItems;

        duplicateRequestItems = requestItems
            .Where(x =>
                requestItems.Count(y => x.Item.Id == y.Item.Id) > 1
            );
        output = requestItems.Except(duplicateRequestItems);

        return output;
    }

    private bool isAlreadyAddedToRequestItems(Item item, IEnumerable<RequestItem> requestItems)
        => requestItems.Any(x => x.Item.Id == item.Id);

    private static IEnumerable<int> getRequestItemRows(ExcelRange cells)
        => cells["a:a"]
            .Skip(ExcelRequestExport.FIRST_ITEM_ROW)
            .TakeWhile(x => x.Value != null)
            .Select(x => x.Start.Row);

    private RequestItem parse(StringBuilder errorLog, ExcelRange cells, int row, ICatalogingRepo catalogingRepo, int bidId)
    {
        RequestItem output;

        try
        {
            output = tryParse(errorLog, cells, row, catalogingRepo, bidId);
        }
        catch (ImportFailException ex)
        {
            throw new Exception($"Failed to Import: {ex.Message}");
        }
        catch (ImportLineErrorException ex)
        {
            errorLog.AppendLine(ex.Message);
            output = null;
        }
        catch (ImportLineSkipException)
        {
            output = null;
        }

        return output;
    }

    private RequestItem tryParse(StringBuilder errorLog, ExcelRange cells, int row, ICatalogingRepo catalogingRepo, int bidId)
    {
        RequestItem output;
        Item item;
        decimal overridePrice;
        int quantity;

        item = parseItemByCode(getCellValue(cells, row, 1), row, catalogingRepo, bidId);
        overridePrice = parseOverridePrice(errorLog, getCellValue(cells, row, 2), item, row);
        quantity = parseQuantity(errorLog, getCellValue(cells, row, 3), row);
        output = new RequestItem() { Id = 0, Item = item, OverridePrice = overridePrice, Quantity = quantity, Request = null };

        return output;
    }
    private Item parseItemByCode(string fieldValue, int row, ICatalogingRepo catalogingRepo, int bidId)
    {
        Item output;
        int code;

        code = 0;
        if (fieldValue.Trim() == "")
        {
            throw new ImportLineErrorException($"line skip: code blank ( line:{ row } )");
        }
        if (!int.TryParse(fieldValue, out code))
        {
            throw new ImportLineErrorException($"line skip: code invalid ( line:{ row } )");
        }
        if (requestItems.Any(q => q.Item.Code == code))
        {
            throw new ImportLineErrorException($"line skip: item code already used ( line:{ row },code:{ code } )");
        }
        Item i = catalogingRepo.GetItem_ByCode(code, bidId);
        if (i is null)
        {
            throw new ImportLineErrorException($"line skip: item code not found ( line:{ row },code:{ code } )");
        }
        output = i.ClearBid();

        return output;
    }
    private decimal parseOverridePrice(StringBuilder errorLog, string value, Item i, int row)
    {
        decimal output = 0;
        if (value is null)
        {
            return 0;
        }

        if (!decimal.TryParse(value, out output) || output < 0)
        {
            errorLog.AppendLine($"info: overrideprice invalid, defaulting to zero ( line:{ row } )");
        }
        if (output == i.Price)
        {
            output = 0;
        }

        return output;
    }
    private int parseQuantity(StringBuilder errorLog, string value, int row)
    {
        int output;

        output = 0;
        if (value is null || !int.TryParse(value, out output))
        {
            throw new ImportLineErrorException($"line skip: quantity invalid ( line:{ row } )");
        }
        else if (output == 0)
        {
            throw new ImportLineSkipException();
        }

        return output;
    }

    private string getCellValue(ExcelRange cells, int row, int col)
    {
        object cellValue;

        cellValue = cells[row, col].Value;
        if (cellValue is null)
        {
            return null;
        }
        return cellValue.ToString().Trim();
    }




    public void Dispose()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(ModernBidRequestImport));
        }
        _isDisposed = true;
    }
}
