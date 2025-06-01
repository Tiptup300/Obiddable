using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Microsoft.EntityFrameworkCore;

namespace Ccd.Bidding.Manager.Library.EF;
public class UntrackedDbc : Dbc
{
   public List<Bid> GetUntrackedBids()
   {
      return getUntrackedBidIds()
          .Select(bidId => GetUntrackedBid(bidId))
          .ToList();
   }
   private List<int> getUntrackedBidIds()
   {
      return this.Bids
          .AsNoTracking()
          .Select(bid => bid.Id)
          .ToList();
   }
   public Bid GetUntrackedBid(int bidId)
   {
      Bid output;

      output = getUntrackedBidBase(bidId);
      output.Items = GetUntrackedItems(bidId);
      output.Requestors = getUntrackedRequestors(bidId);
      output.VendorResponses = getUntrackedVendorResponses(bidId);
      output.SetPurchaseOrders(getUntrackedPurchaseOrders(bidId));

      return output;
   }
   private Bid getUntrackedBidBase(int bidId)
   {
      return this.Bids
          .AsNoTracking()
          .Where(x => x.Id == bidId)
          .Single();
   }


   public List<Item> GetUntrackedItems(int bidId)
   {
      return getUntrackedItemIds(bidId)
          .Select(itemId => GetUntrackedItem(itemId))
          .ToList();
   }

   private List<int> getUntrackedItemIds(int bidId)
   {
      return this.Items
          .AsNoTracking()
          .Include(item => item.Bid)
          .Where(item => item.Bid.Id == bidId)
          .Select(item => item.Id)
          .ToList();
   }
   public Item GetUntrackedItem(int itemId)
   {
      return this.Items
          .AsNoTracking()
          .Where(x => x.Id == itemId)
          .Include(x => x.Bid)
          .Single();
   }

   private List<Requestor> getUntrackedRequestors(int bidId)
   {
      return this.Requestors
          .AsNoTracking()
          .Include(x => x.Bid)
          .Include(x => x.Requests)
          .ThenInclude(x => x.RequestItems)
          .ThenInclude(x => x.Item)
          .Where(x => x.Bid.Id == bidId)
          .ToList();
   }

   private List<VendorResponse> getUntrackedVendorResponses(int bidId)
   {
      return this.VendorResponses
          .AsNoTracking()
          .Include(x => x.Bid)
          .Include(x => x.ResponseItems)
          .ThenInclude(x => x.Item)
          .Where(x => x.Bid.Id == bidId)
          .ToList();
   }

   private List<PurchaseOrder> getUntrackedPurchaseOrders(int bidId)
   {
      return this.PurchaseOrders
          .AsNoTracking()
          .Include(x => x.Bid)
          .Include(x => x.LineItems)
          .Where(x => x.Bid.Id == bidId)
          .ToList();
   }
}
