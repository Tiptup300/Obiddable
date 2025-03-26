using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.UI.Bidding;
using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
    public class ClearBidsRequestorsOperation : BidDataOperation
    {
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
        public ClearBidsRequestorsOperation(Bid bid) : base(bid) { }

        public override bool Confirm()
        {
            return BiddingMessaging.Instance.ConfirmBidClearVendorResponses(_bid.VendorResponses.Count);
        }

        protected override void RunDataOperation()
        {
            _requestingRepo.DeleteRequestors_ByBid(_bid.Id);
            BiddingMessaging.Instance.ShowBidClearRequestorsSuccess();
        }
    }
}
