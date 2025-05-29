using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
   public interface IPurchasingRepo
   {
      void AddPurchaseOrder_ToBid(PurchaseOrder obj, int bidId);
      void DeleteLineItems_ByBid(int bidId);
      void DeletePurchaseOrder(int purchaseOrderId);
      void DeletePurchaseOrders_ByBid(int bidId);
      PurchaseOrder GetPurchaseOrder(int purchaseOrderId);
      List<PurchaseOrder> GetPurchaseOrders_ByBid(int bidId);
   }
}