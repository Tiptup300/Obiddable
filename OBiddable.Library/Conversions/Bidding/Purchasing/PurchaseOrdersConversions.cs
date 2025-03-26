using OBiddable.Library.Bidding.Purchasing;

namespace OBiddable.Library.Conversions.Bidding.Purchasing;

public class PurchaseOrdersConversions
{
    private const string _purchaseOrderCSVHeader = "lineNumber,description,partNumber,unit,quantity,unitPrice,tax,freight,account,warehouseItemNumber,grantProject,note";
    public string ConvertPurchaseOrderToCsv(PurchaseOrder po)
    {
        return po.LineItems
            .OrderBy(x => x.Description)
            .Select(writeLine())
            .Prepend(_purchaseOrderCSVHeader)
            .JoinAsLines();
    }

    private Func<LineItem, int, string> writeLine()
    {
        return (lineItem, lineIndex) =>
            $"{ lineIndex + 1 }," +
            $"{ lineItem.Description.strip().surround() }," +
            $"{ lineItem.PartNumber.strip().surround() }," +
            $"{ lineItem.Unit.strip().surround() }," +
            $"{ (lineItem.Quantity.HasValue ? lineItem.Quantity.Value.ToString("0.0000") : "") }," +
            $"{ lineItem.Price.ToString("0.0000") }," +
            $"0," +
            $"0," +
            $"{ lineItem.AccountNumber.strip().surround() }," +
            $"," +
            $"," +
            $"{ lineItem.Note.strip().surround() }";
    }
}
