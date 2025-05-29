using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI.Bidding;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
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
}