using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.UI.Navigation
{
    public class PurchaseOrderBoxModel
    {
        public PurchaseOrderBoxModel(Bid bid)
        {
            PurchaseOrders = bid.GetPurchaseOrdersCount();
            PurchasedItems = bid.GetPurchaseOrdersItemsCount();
            TotalPrice = bid.GetPurchaseOrdersTotalPriceSum();
            CanEditPurchaseOrders = bid.CanEditPurchaseOrders();
        }
        public int PurchaseOrders { get; private set; }
        public int PurchasedItems { get; private set; }
        public decimal TotalPrice { get; private set; }
        public bool CanEditPurchaseOrders { get; private set; }
    }
}
