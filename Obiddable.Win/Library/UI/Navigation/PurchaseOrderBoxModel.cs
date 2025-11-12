using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Purchasing;

namespace Obiddable.Win.Library.UI.Navigation;
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
