using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Purchasing;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF.Bidding.Purchasing;
public class EFPurchasingRepo : IPurchasingRepo
{

   public void AddPurchaseOrder_ToBid(PurchaseOrder obj, int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_AddPurchaseOrder_ToBid(obj, bidId);

         Bid bid = dbc.Bids
             .Where(x => x.Id == bidId)
             .Include(a => a.PurchaseOrders).ThenInclude(x => x.LineItems)
             .Single();

         bid.PurchaseOrders.Add(obj);
         dbc.SaveChanges();
      }
   }
   public void DeletePurchaseOrder(int purchaseOrderId)
   {
      using (var dbc = new Dbc())
      {
         var po = dbc.PurchaseOrders
             .Include(x => x.LineItems)
             .Include(x => x.Bid)
             .SingleOrDefault(x => x.Id == purchaseOrderId);

         if (po is null)
            return;

         dbc.LineItems.RemoveRange(po.LineItems);
         dbc.PurchaseOrders.Remove(po);

         dbc.SaveChanges();
      }
   }
   public void DeletePurchaseOrders_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeletePurchaseOrders_ByBid(bidId);

         Bid bid = dbc.Bids
             .Where(x => x.Id == bidId)
             .Include(x => x.PurchaseOrders)
             .Single();
         bid.PurchaseOrders.ForEach(x => dbc.Remove(x));
         dbc.SaveChanges();
      }
   }
   // gets
   public PurchaseOrder GetPurchaseOrder(int purchaseOrderId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.PurchaseOrders
             .Where(x => x.Id == purchaseOrderId)
             .Include(x => x.Bid)
             .Include(x => x.LineItems)
             .Single();
      }
   }
   public List<PurchaseOrder> GetPurchaseOrders_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.PurchaseOrders
             .Include(x => x.Bid)
             .Include(x => x.LineItems)
             .Where(x => x.Bid.Id == bidId)
             .ToList();
      }
   }
   public void DeleteLineItems_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteLineItems_ByBid(bidId);

         Bid bid = dbc.Bids
             .Where(x => x.Id == bidId)
             .Include(x => x.PurchaseOrders).ThenInclude(x => x.LineItems)
             .Single();
         bid.PurchaseOrders.ForEach(x => x.LineItems.ForEach(y => dbc.Remove(y)));
         dbc.SaveChanges();
      }
   }
}
