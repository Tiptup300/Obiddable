using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF.Bidding.Requesting.Cataloging;
internal class RequestingCatalogingRepo
{

   public bool Check_ItemRequested(int itemId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.RequestItems.Include(x => x.Item).Any(x => x.Item.Id == itemId);

      }
   }
   public List<Item> GetItems_Requested_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         List<Item> allBidItems = dbc.Items.Include(a => a.Bid).Where(b => b.Bid.Id == bidId).ToList();

         List<RequestItem> allRequestItems = dbc.RequestItems
             .Include(x => x.Item)
             .Include(x => x.Request)
             .ThenInclude(x => x.Requestor)
             .ThenInclude(x => x.Bid)
             .Where(x => x.Request.Requestor.Bid.Id == bidId).Where(x => x.Quantity > 0).ToList();

         return allBidItems.Where(x => allRequestItems.Any(y => y.Item.Id == x.Id)).ToList();
      }
   }
   public int GetItemsRequestedQuantity(Item item)
   {
      int output;

      using (var dbc = new Dbc())
      {
         output = getItemRequestedQuantity(dbc, item.Id);
      }

      return output;
   }
   public int Get_Item_RequestedQuantity(int itemId)
   {
      using (var dbc = new Dbc())
      {
         return getItemRequestedQuantity(dbc, itemId);
      }
   }
   private int getItemRequestedQuantity(Dbc dbc, int itemId)
   {
      int output;

      output = dbc.RequestItems
          .Include(x => x.Item)
          .Where(x => x.Item.Id == itemId)
          .Select(x => x.Quantity)
          .Sum();

      return output;
   }
   public bool Check_RequestItemLast_ForRespondedItem(int requestItemId)
   {
      using (var dbc = new Dbc())
      {
         RequestItem testingRequestItem = dbc.RequestItems.Include(x => x.Item).Single(x => x.Id == requestItemId);
         Item i = testingRequestItem.Item;

         List<ResponseItem> responseItemsForThisItem = dbc.ResponseItems.Include(x => x.Item).Where(x => x.Item.Id == i.Id).ToList();

         if (responseItemsForThisItem.Count == 0)
            return false;

         List<RequestItem> requestItemsForThisItem = dbc.RequestItems.Include(x => x.Item).Where(x => x.Item.Id == i.Id).ToList();

         if (requestItemsForThisItem.Any(x => x.Id != testingRequestItem.Id))
            return false;

         return true;
      }
   }
}
