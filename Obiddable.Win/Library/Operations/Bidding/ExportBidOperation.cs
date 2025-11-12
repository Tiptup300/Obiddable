using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Win.Library.Bidding.IO;
using Obiddable.Win.UI.Bidding.Requesting;

namespace Obiddable.Win.Library.Operations.Bidding;
public class ExportBidOperation : BidDataOperation
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   private readonly RequestMessaging _requestMessaging = new RequestMessaging();
   public ExportBidOperation(Bid bid) : base(bid) { }

   public override bool Confirm()
   {
      return true;
   }

   protected override void RunDataOperation()
   {
      BidsExports.ExportBid(_bid, _respondingRepo, _catalogingRepo, _requestingRepo, _requestMessaging);
   }
}
