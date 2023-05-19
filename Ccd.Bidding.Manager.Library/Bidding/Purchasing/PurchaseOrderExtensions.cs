using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
    public static class PurchaseOrderExtensions
    {
        public static decimal GetQuantitySumOfLineItems(this PurchaseOrder purchaseOrder)
            => purchaseOrder.LineItems.Sum(x => x.Quantity.Value);

        public static decimal GetExtendedPriceSumOfLineItems(this PurchaseOrder purchaseOrder)
            => purchaseOrder.LineItems.Sum(x => x.GetRoundedExtendedPrice());

    }
}
