using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding
{
   public interface IBiddingRepo
   {
      void AddBid(Bid obj);
      Bid GetBid(int bidId);
      List<Bid> GetBids();
      void UpdateBid(Bid obj);
      void DeleteBid(int bidId);
   }
}