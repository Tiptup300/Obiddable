using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Win.UI.Bidding;

namespace Obiddable.Win.Library.Operations.Bidding;
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
