using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Bidding.Requesting.Extensions;
using OBiddable.Library.Bidding.Responding;

namespace OBiddable.Library.Bidding.Distribution;

public static class RequestingExtensions
{

    public static bool IsMismatchedQuantity(this ResponseItem responseItem, IRequestingRepo requestingRepo)
    {
        decimal requestedQuantity;
        decimal alternateQuantity;

        if (responseItem.IsAlternate == false)
        {
            return false;
        }
        requestedQuantity = responseItem.Item.GetRequestedQuantity(requestingRepo);
        alternateQuantity = responseItem.AlternateQuantity;

        return requestedQuantity != alternateQuantity;
    }
}
