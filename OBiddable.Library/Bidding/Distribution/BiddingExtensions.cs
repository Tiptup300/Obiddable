using OBiddable.Library.Bidding.Electing;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.Bidding.Distribution;

public static class BiddingExtensions
{
    public static bool HasUnmatchedQuantities(this Bid bid, IRequestingRepo requestingRepo, ILegacyElectionsRepo electionsRepo)
    {
        return electionsRepo.GetElectedResponseItemsByBid(bid.Id)
            .Any(responseItem => responseItem.IsMismatchedQuantity(requestingRepo));
    }
}
