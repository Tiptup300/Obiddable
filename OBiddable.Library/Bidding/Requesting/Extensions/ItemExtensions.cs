using OBiddable.Library.Bidding.Cataloging;

namespace OBiddable.Library.Bidding.Requesting.Extensions;

public static class ItemExtensions
{
    public static IEnumerable<Item> RequestedOnly(this IEnumerable<Item> items, IRequestingRepo repo)
        => items.Where(x => x.IsRequested(repo));

    public static bool IsRequested(this Item item, IRequestingRepo repo)
    {
        bool output;
        int requestedQuantity;

        requestedQuantity = item.GetRequestedQuantity(repo);
        output = requestedQuantity > 0;

        return output;
    }

    public static int GetRequestedQuantity(this Item item, IRequestingRepo requestItemsRepo)
        => requestItemsRepo.GetItemsRequestedQuantity(item);
}
