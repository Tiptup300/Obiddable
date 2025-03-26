using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI.Bidding;
using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Responding;

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