using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Validations.Bidding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding
{
    public class EFBiddingRepo : IBiddingRepo
    {
        private readonly EFBiddingValidation _validation = new EFBiddingValidation();

        // crud
        public void AddBid(Bid bid)
        {
            using (var dbc = new Dbc())
            {
                _validation.ValidateAddBid(dbc, bid);
                dbc.Bids.Add(bid);

                dbc.SaveChanges();
            }
        }
        public void UpdateBid(Bid bid)
        {
            using (var dbc = new Dbc())
            {
                _validation.ValidateUpdateBid(dbc, bid);
                var r = dbc.Bids.SingleOrDefault(x => x.Id == bid.Id);
                if (r is null)
                {
                    return;
                }
                r.Name = bid.Name;

                dbc.SaveChanges();
            }
        }
        public void DeleteBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                _validation.ValidateDeleteBid(dbc, bidId);

                var obj = dbc.Bids
                    .Include(x => x.PurchaseOrders)
                    .Include(x => x.VendorResponses)
                    .Include(x => x.Requestors)
                    .Include(x => x.Items)
                    .SingleOrDefault(x => x.Id == bidId);

                if (obj is null)
                    return;


                obj.PurchaseOrders.Clear();
                obj.VendorResponses.Clear();
                obj.Requestors.Clear();
                obj.Items.Clear();

                dbc.Remove(obj);
                dbc.SaveChanges();

            }
        }

        // gets
        public Bid GetBid(int bidId)
        {
            Bid output;

            using (var untrackedDbc = new UntrackedDbc())
            {
                output = untrackedDbc.GetUntrackedBid(bidId);
            }

            return output;
        }
        public List<Bid> GetBids()
        {
            List<Bid> output;

            using (var untrackedDbc = new UntrackedDbc())
            {
                output = untrackedDbc.GetUntrackedBids();
            }

            return output;
        }
    }
}
