using Obiddable.Library.Bidding;

namespace Obiddable.Test.Repos;
public class MockBiddingRepo : IBiddingRepo
{
   private readonly MockData _data;

   public MockBiddingRepo(MockData data)
   {
      _data = data;
   }
   public Bid GetBid(int bidId)
       => _data.GetBid(bidId);

   public List<Bid> GetBids()
       => _data.Bids.ToList();


   public void AddBid(Bid newBid)
       => _data.Bids.Add(newBid);
   public void DeleteBid(int bidId)
       => _data.Bids.Remove(_data.Bids.Single(bid => bid.Id == bidId));

   public void UpdateBid(Bid obj)
   {
      DeleteBid(obj.Id);
      AddBid(obj);
   }
}
