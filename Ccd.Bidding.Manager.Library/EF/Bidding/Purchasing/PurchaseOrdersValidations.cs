using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.EF;
using Ccd.Bidding.Manager.Library.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Purchasing
{
    public static class PurchaseOrdersValidations
    {
        public static void Validate_AddPurchaseOrder_ToBid(this Dbc dbc, PurchaseOrder purchaseOrder, int bidId)
        {
            purchaseOrder.Validate();
        }
        public static void Validate_DeletePurchaseOrder(this Dbc dbc, int purchaseOrderId)
        {
            var purchaseOrder = dbc.PurchaseOrders.AsNoTracking().Include(x => x.LineItems).Single(x => x.Id == purchaseOrderId);

            if (purchaseOrder.LineItems.Count > 0)
            {
                throw new DataValidationException("PurchaseOrder has LineItems");
            }
        }
        public static void Validate_DeletePurchaseOrders_ByBid(this Dbc dbc, int bidId)
        {
            var purchaseOrders = dbc.PurchaseOrders.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();
            purchaseOrders.ForEach(x => dbc.Validate_DeletePurchaseOrder(x.Id));
        }
    }
}
