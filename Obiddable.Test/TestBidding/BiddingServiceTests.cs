using Obiddable.Library.Bidding;
using Obiddable.Test.MockBids;
using Obiddable.Test.Mocking;

namespace Obiddable.Test.Bidding;
public class BiddingServiceTests
{
   private Mocker _mocker;

   [Fact]
   public void CanCheckNameAlreadyExists()
   {
      _mocker = new Mocker(new TheNewBidMock());

      Bid bid = _mocker.GetBiddingRepo().GetBid(74);
      Library.Bidding.BiddingService biddingService = _mocker.GetBiddingService();

      Assert.False(biddingService.BidNameExists("THE NEW BID", 74));
      Assert.True(biddingService.BidNameExists("THE NEW BID", 100));
      Assert.False(biddingService.BidNameExists("THE FUN BID", 74));
      Assert.False(biddingService.BidNameExists("THE FUN BID", 100));
   }
}
