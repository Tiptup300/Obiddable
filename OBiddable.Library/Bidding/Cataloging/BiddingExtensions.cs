using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Bidding.Requesting.Extensions;

namespace OBiddable.Library.Bidding.Cataloging;

public static class BiddingExtensions
{
    public static bool CanEditItems(this Bid bid)
        => true;

    public static int GetItemsCount(this Bid bid)
        => bid.Items.Count;

    public static int GetItemCategoriesCount(this Bid bid)
        => bid.Items.GroupBy(x => x.Category).Distinct().Count();

    public static int GetRequestedItemsCount(this Bid bid, IRequestingRepo repo)
        => bid.Items.Distinct().Count(x => x.GetRequestedQuantity(repo) > 0);
}
