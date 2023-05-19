using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding
{
    public class EFBiddingValidation
    {
        public void ValidateAddBid(Dbc dbc, Bid bid)
        {
            bid.Validate();

            if (dbc.Bids.AsNoTracking().Any(x => x.Name == bid.Name))
            {
                throw new DataValidationException("Name already exists");
            }
        }
        public void ValidateUpdateBid(Dbc dbc, Bid bid)
        {
            bid.Validate();

            if (dbc.Bids.AsNoTracking().Where(x => x.Id != bid.Id).Any(x => x.Name == bid.Name))
            {
                throw new DataValidationException("Name already exists");
            }

        }
        public void ValidateDeleteBid(Dbc dbc, int bidId)
        {
            Bid bid = dbc.Bids.AsNoTracking().Single(x => x.Id == bidId);
            bid.Items = dbc.Items.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bid.Id).ToList();
            bid.Requestors = dbc.Requestors.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bid.Id).ToList();
            bid.VendorResponses = dbc.VendorResponses.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bid.Id).ToList();
            bid.SetPurchaseOrders(dbc.PurchaseOrders.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bid.Id).ToList());
            if (bid.Items.Count > 0)
            {
                throw new DataValidationException("Bid cannot be deleted with items in it.");
            }

            if (bid.Requestors.Count > 0)
            {
                throw new DataValidationException("Bid cannot be deleted with requestors in it.");
            }

            if (bid.VendorResponses.Count > 0)
            {
                throw new DataValidationException("Bid cannot be deleted with vendor responses in it.");
            }

            if (bid.PurchaseOrders.Count > 0)
            {
                throw new DataValidationException("Bid cannot be deleted with purchase orders in it.");
            }
        }
    }
}
