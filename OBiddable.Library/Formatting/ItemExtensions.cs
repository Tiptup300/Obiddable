using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Bidding.Requesting.Extensions;

namespace OBiddable.Library.Formatting;

public static class ItemExtensions
{
    public static string GetFormattedId(this Item item)
        => item.Id.ToString();

    public static string GetFormattedCode(this Item item)
        => item.FormattedCode;

    public static string GetFormattedRequestedQuantity(this Item item, IRequestingRepo repo)
        => item.GetRequestedQuantity(repo).ToString("0.00");
}
