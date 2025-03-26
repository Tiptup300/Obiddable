using OBiddable.Library.Bidding.Cataloging;
using System.Text;

namespace OBiddable.Library.Conversions.Bidding.Cataloging;

public class ItemsConversions
{
    public static ItemsConversions Instance = new ItemsConversions();
    private const string _itemsCSVHeader = "code,category,description,substitutable,price,unit,lastorderprice";

    public string GenerateBlankItemsImportTemplate()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_itemsCSVHeader);

        return sb.ToString();
    }
    public IEnumerable<Item> ConvertCSVToItems(string[] fileData, out string error)
    {
        List<Item> output;
        StringBuilder errorLog;

        errorLog = new StringBuilder();
        if (doesHeaderNotMatch(fileData[0], _itemsCSVHeader))
        {
            errorLog.AppendLine($"fatal error: file header does not match");
            error = errorLog.ToString();
            return null;
        }

        output = fileData
            .ToList()
            .Skip(1)
            .Select((row, i) => parseItemRow(errorLog, row, i))
            .Where(x => x is null == false)
            .ToList();

        error = errorLog.ToString();
        return output;
    }
    public string ConvertItemsToCSV(int bidId, ICatalogingRepo catalogingRepo)
    {
        string output;
        IEnumerable<Item> items;

        items = catalogingRepo.GetItems(bidId);
        output = ConvertItemsToCsv(items);

        return output;
    }
    public string ConvertItemsToCsv(IEnumerable<Item> items)
    {
        string output;
        string[] lines;
        StringBuilder sb;

        sb = new StringBuilder();
        sb.AppendLine(_itemsCSVHeader);
        lines = printCsvItemRows(items);
        lines.ToList()
            .ForEach(x => sb.AppendLine(x));
        output = sb.ToString();

        return output;
    }


    private bool doesHeaderNotMatch(string fileHeaderLine, string itemsCsvHeader)
        => fileHeaderLine.ToLower().Trim() != itemsCsvHeader;

    private Item parseItemRow(StringBuilder err, string dataRow, int lineNumber)
    {
        Item output;
        string[] fields;

        if (dataRow.Trim() == "")
        {
            err.AppendLine($"line skip: line blank ( line:{ lineNumber } )");
            return null;
        }
        fields = dataRow.ParseCSVRow();
        output = parseItem(err, fields, lineNumber);

        return output;
    }
    private Item parseItem(StringBuilder err, string[] fields, int lineNumber)
    {
        Item output;
        int code;
        string category;
        string description;
        bool substitutable;
        decimal price;
        string unit;
        decimal lastOrderPrice;

        try
        {
            code = parseCode(fields, lineNumber);
            category = parseCategory(err, fields, lineNumber);
            description = parseDescription(fields, lineNumber);
            substitutable = parseSubtitutable(fields);
            unit = parseUnit(err, fields, lineNumber);
            lastOrderPrice = parseLastOrderPrice(fields, lineNumber);
            price = parsePrice(fields, lineNumber);

            output = new Item(null, null, code, category, description, substitutable, unit, lastOrderPrice, price);
        }
        catch (ImportLineErrorException ex)
        {
            err.AppendLine(ex.Message);
            output = null;
        }

        return output;
    }
    private int parseCode(string[] codeField, int lineNumber)
    {
        int code = 0;
        if (!int.TryParse(codeField[0], out code))
        {
            throw new ImportLineErrorException($"line skip: item code invalid ( line:{ lineNumber } )");
        }
        if (code <= 0 || code > 999999)
        {
            throw new ImportLineErrorException($"line skip: item code invalid ( line:{ lineNumber } )");
        }

        return code;
    }
    private string parseCategory(StringBuilder err, string[] fields, int lineNumber)
    {

        // category
        string category = fields[1];
        if (category.Length > 255)
        {
            err.AppendLine($"info: category string too long, truncated ( line:{ lineNumber } )");
            category = category.Substring(0, 255);
        }

        return category;
    }
    private string parseDescription(string[] fields, int lineNumber)
    {

        // description
        string description = fields[2].Replace("|", "\r\n");
        if (description.Length == 0)
        {
            throw new ImportLineErrorException($"line skip: item description is blank ( line:{ lineNumber } )");
        }

        return description;
    }
    private bool parseSubtitutable(string[] fields)
    {

        // subable
        bool substitutable = false;
        bool.TryParse(fields[3], out substitutable);
        return substitutable;
    }
    private string parseUnit(StringBuilder err, string[] fields, int lineNumber)
    {

        // unit
        string unit = fields[5];
        if (unit.Length == 0)
        {
            throw new ImportLineErrorException($"info: unit string blank ( line:{ lineNumber } )");
        }
        if (unit.Length > 255)
        {
            err.AppendLine($"info: unit string too long, truncated ( line:{ lineNumber } )");
            unit = unit.Substring(0, 255);
        }

        return unit;
    }
    private decimal parseLastOrderPrice(string[] fields, int lineNumber)
    {
        decimal lastOrderPrice;

        lastOrderPrice = 0;
        if (!decimal.TryParse(fields[6], out lastOrderPrice))
        {
            throw new ImportLineErrorException($"line skip: item lastOrderPrice invalid ( line:{ lineNumber } )");
        }
        if (lastOrderPrice < 0)
        {
            throw new ImportLineErrorException($"line skip: last order price cannot be negative ( line:{ lineNumber } )");
        }

        return lastOrderPrice;
    }
    private decimal parsePrice(string[] fields, int lineNumber)
    {
        decimal price;

        price = 0;
        if (!decimal.TryParse(fields[4], out price))
        {
            throw new ImportLineErrorException($"line skip: item price invalid ( line:{ lineNumber } )");
        }
        if (price < 0)
        {
            throw new ImportLineErrorException($"line skip: item price cannot be negative ( line:{ lineNumber } )");
        }

        return price;
    }


    private string[] printCsvItemRows(IEnumerable<Item> items)
    {
        return items
            .ToList()
            .Select(i =>
                $"{ i.Code }," +
                $"{ i.Category.strip().surround() }," +
                $"{ i.Description.Replace("\r\n", "|").strip().surround() }," +
                $"{ i.Substitutable }," +
                $"{ i.Price.ToString("0.0000") }," +
                $"{ i.Unit.strip().surround() }," +
                $"{ i.Last_Order_Price.ToString("0.0000") }")
            .ToArray();
    }
}
