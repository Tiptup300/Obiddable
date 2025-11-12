using Obiddable.Library.Bidding;
using Obiddable.Library.EF.Bidding;
using Obiddable.Reporting.Bidding;
using Obiddable.Win.Library.IO;
using Obiddable.Win.UI.Bidding;

namespace Obiddable.Win.Library.Operations.Bidding;
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
