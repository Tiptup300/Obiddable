using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Win.UI.Bidding;

namespace Obiddable.Win.Library.Operations.Bidding;
public class ClearBidsVendorsOperation : BidDataOperation
{
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   private readonly BiddingMessaging _biddingMessaging = new BiddingMessaging();

   public ClearBidsVendorsOperation(Bid bid) : base(bid) { }

   public override bool Confirm()
   {
      return _biddingMessaging.ConfirmBidClearVendorResponses(_bid.VendorResponses.Count);
   }

   protected override void RunDataOperation()
   {
      _respondingRepo.DeleteVendorResponses_ByBid(_bid.Id);
      _biddingMessaging.ShowBidClearVendorResponsesSuccess();
   }
}