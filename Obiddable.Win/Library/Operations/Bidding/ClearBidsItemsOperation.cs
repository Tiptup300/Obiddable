using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Win.UI.Bidding;

namespace Obiddable.Win.Library.Operations.Bidding;
public class ClearBidsItemsOperation : BidDataOperation
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly CatalogingService _catalogingService = new CatalogingService(new EFCatalogingRepo());
   public ClearBidsItemsOperation(Bid bid) : base(bid) { }

   public override bool Confirm()
   {
      return BiddingMessaging.Instance.ConfirmBidClearItems(_bid.Items.Count);
   }

   protected override void RunDataOperation()
   {
      _catalogingService.DeleteAllItemsFromBid(_bid.Id);
      BiddingMessaging.Instance.ShowBidClearItemsSuccess();
   }
}
