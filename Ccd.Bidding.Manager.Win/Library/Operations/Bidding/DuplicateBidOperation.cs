using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Win.UI.Bidding;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
   public class DuplicateBidOperation : BidDataOperation
   {
      private readonly IBiddingOperations _biddingOperations = new EFBiddingOperations();

      public DuplicateBidOperation(Bid bid) : base(bid)
      {
      }

      public override bool Confirm()
      {
         return BiddingMessaging.Instance.DuplicateBidConfirm(_bid);
      }

      protected override void RunDataOperation()
      {
         Bid nBid = _biddingOperations.DuplicateBid(_bid.Id);
         if (nBid is null)
         {
            BiddingMessaging.Instance.DuplicateBidError(_bid);
            return;
         }
         BiddingMessaging.Instance.DuplicateBidSuccess(nBid.Items.Count, nBid.Requestors.Count, nBid.VendorResponses.Count);

         var reportBuilder = new RollReportBuilder();
         FileHelpers.SaveReport(reportBuilder.BuildReport(nBid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
      }
   }
}
