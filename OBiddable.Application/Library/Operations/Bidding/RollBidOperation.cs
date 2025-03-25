using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Win.UI.Bidding;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
    public class RollBidOperation : BidDataOperation
    {
        private readonly IBiddingOperations _biddingOperations = new EFBiddingOperations();

        public RollBidOperation(Bid bid) : base(bid) { }

        public override bool Confirm()
        {
            return BiddingMessaging.Instance.ConfirmBidRoll();
        }

        protected override void RunDataOperation()
        {
            Bid newBid = _biddingOperations.RollBid(_bid.Id);
            if (newBid is null)
            {
                BiddingMessaging.Instance.ShowBidRollFailedError();
                return;
            }
            BiddingMessaging.Instance.ShowBidRollSuccess(newBid.Items.Count, newBid.Requestors.Count, newBid.VendorResponses.Count);

            var reportBuilder = new RollReportBuilder();
            FileHelpers.SaveReport(reportBuilder.BuildReport(newBid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
        }
    }
}
