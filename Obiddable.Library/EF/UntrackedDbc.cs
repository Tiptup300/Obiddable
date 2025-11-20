using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF;
/// <summary>
/// The purpose of this class is to sort of be an adapter or decorator of the
/// main one Dbc, but this one does everything using GetUntracked. I believe if
/// I just had this one then any migrations would not work. So I have to have both.
/// 
/// But at the same time, I usually reasonable the code where I'm assuming it's untracked.
/// I believe I can merge them later on, for now this adds complexity where I have to
/// specify the correct Dbc
/// </summary>
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
      output.PurchaseOrders = getUntrackedPurchaseOrders(bidId);

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
