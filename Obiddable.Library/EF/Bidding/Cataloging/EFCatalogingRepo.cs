using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Validations.Bidding.Cataloging;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF.Bidding.Cataloging;
public class EFCatalogingRepo : ICatalogingRepo
{
   private readonly EFCatalogingValidation _validation = new EFCatalogingValidation();

   public void AddItem(Item item, int bidId)
   {
      Bid bid;

      using (var dbc = new Dbc())
      {
         _validation.Validate_AddItem_ToBid(dbc, item, bidId);
         bid = getTrackedBid(dbc, bidId);
         bid.Items.Add(item);
         dbc.SaveChanges();
      }
   }
   public Item GetItem(int itemId)
   {
      Item output;

      using (var untrackedDbc = new UntrackedDbc())
      {
         output = untrackedDbc.GetUntrackedItem(itemId);
      }

      return output;
   }
   public IEnumerable<Item> GetItems(int bidId)
   {
      IEnumerable<Item> output;

      using (var untrackedDbc = new UntrackedDbc())
      {
         output = untrackedDbc.GetUntrackedItems(bidId);
      }

      return output;
   }
   public void UpdateItem(Item newItem)
   {
      Item originalItem;

      using (var dbc = new Dbc())
      {
         _validation.Validate_UpdateItem(dbc, newItem);
         originalItem = getTrackedItem(dbc, newItem.Id);
         updateItem(originalItem, newItem);

         dbc.SaveChanges();
      }
   }

   private static void updateItem(Item originalItem, Item newItem)
   {
      originalItem.Code = newItem.Code;
      originalItem.Category = newItem.Category;
      originalItem.Description = newItem.Description;
      originalItem.Substitutable = newItem.Substitutable;
      originalItem.Unit = newItem.Unit;
      originalItem.Last_Order_Price = newItem.Last_Order_Price;
      originalItem.Price = newItem.Price;
   }

   public void DeleteItem(int itemId)
   {
      Item itemToDelete;

      using (var dbc = new Dbc())
      {
         _validation.Validate_DeleteItem(dbc, itemId);
         itemToDelete = getTrackedItem(dbc, itemId);
         dbc.Remove(itemToDelete);
         dbc.SaveChanges();
      }
   }

   public static Bid getTrackedBid(Dbc dbc, int bidId)
   {
      return dbc.Bids
          .Where(x => x.Id == bidId)
          .Include(a => a.Items)
          .Single();
   }
   private static Item getTrackedItem(Dbc dbc, int itemId)
   {
      return dbc.Items
          .Where(x => x.Id == itemId)
          .Include(x => x.Bid)
          .Single();
   }
}
