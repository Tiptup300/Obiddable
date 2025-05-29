using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Distribution
{
   public static class BiddingExtensions
   {
      public static bool HasUnmatchedQuantities(this Bid bid, IRequestingRepo requestingRepo, ILegacyElectionsRepo electionsRepo)
      {
         return electionsRepo.GetElectedResponseItemsByBid(bid.Id)
             .Any(responseItem => responseItem.IsMismatchedQuantity(requestingRepo));
      }
   }
}
