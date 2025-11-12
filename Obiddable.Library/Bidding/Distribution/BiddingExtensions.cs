using Obiddable.Library.Bidding.Electing;
using Obiddable.Library.Bidding.Requesting;

namespace Obiddable.Library.Bidding.Distribution;
public static class BiddingExtensions
{
   public static bool HasUnmatchedQuantities(this Bid bid, IRequestingRepo requestingRepo, ILegacyElectionsRepo electionsRepo)
   {
      return electionsRepo.GetElectedResponseItemsByBid(bid.Id)
          .Any(responseItem => responseItem.IsMismatchedQuantity(requestingRepo));
   }
}
