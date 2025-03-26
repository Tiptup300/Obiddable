using OBiddable.Library.Bidding.Responding;

namespace OBiddable.Library.Formatting;

public static class ResponseItemExtensions
{
    public static string GetFormattedId(this ResponseItem responseItem) => responseItem.Id.ToString();
    public static string GetFormattedIsAlternate(this ResponseItem responseItem) => responseItem.IsAlternate ? "YES" : "NO";
    public static string GetFormattedPrice(this ResponseItem responseItem) => responseItem.Price.ToString("$0.00");
}
