using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.Bidding.IO;
using Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
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
}
