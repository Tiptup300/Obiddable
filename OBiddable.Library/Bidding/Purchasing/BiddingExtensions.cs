using OBiddable.Library.Bidding.Electing;

namespace OBiddable.Library.Bidding.Purchasing;

public static class BiddingExtensions
{
    public static bool CanEditPurchaseOrders(this Bid bid)
    {
        if (bid.GetElectedItemsCount() > 0)
        {
            return true;
        }
        if (bid.GetPurchaseOrdersCount() > 0)
        {
            return true;
        }
        return false;
    }
    public static int GetPurchaseOrdersCount(this Bid bid) 
        => bid.PurchaseOrders.Count();
    public static int GetPurchaseOrdersItemsCount(this Bid bid) 
        => bid.PurchaseOrders.Sum(x => x.LineItems.Count());
    public static decimal GetPurchaseOrdersTotalPriceSum(this Bid bid) 
        => bid.PurchaseOrders.Sum(x => x.LineItems.Sum(y => y.GetRoundedExtendedPrice()));
}
