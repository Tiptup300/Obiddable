using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Win.Library.Operations;
using Ccd.Bidding.Manager.Win.UI.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding
{
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
}
