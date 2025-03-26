using System.Text.RegularExpressions;

namespace OBiddable.Library.Conversions;

public static class ConversionsExtensions
{
    public static string strip(this string str)
    {
        return str.Replace('"', '\'').Replace('\n', ' ').Replace('\r', ' ').Replace("\\\"", "[DOUBLE-QUOTE]");
    }
    public static string surround(this string str)
    {
        return "\"" + str + "\"";
    }
    public static string[] ParseCSVRow(this string csvrow)
    {
        //Define pattern
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        string[] results = CSVParser.Split(csvrow);

        for (int x = 0; x < results.Length; x++)
        {
            results[x] = results[x].Replace("[DOUBLE-QUOTE]", "\"");
        }

        //Separating columns to array
        return results.ToList().Select(x => x.removeApostrophes()).ToArray();
    }
    private static string removeApostrophes(this string str)
    {
        if (str.Length < 2)
        {
            return str;
        }

        if (str[0] == '"' && str[str.Length - 1] == '"')
        {
            return str.Substring(1, str.Length - 2);
        }

        return str;
    }
}
