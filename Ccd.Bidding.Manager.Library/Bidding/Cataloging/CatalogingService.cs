namespace Ccd.Bidding.Manager.Library.Bidding.Cataloging;
public class CatalogingService
{
   private readonly ICatalogingRepo _catalogingRepo;

   public CatalogingService(ICatalogingRepo catalogingRepo)
   {
      _catalogingRepo = catalogingRepo;
   }

   public Item GetItemByCode(int itemCode, int bidId)
   {
      Item output;

      output = _catalogingRepo.GetItems(bidId)
          .Single(item => item.Code == itemCode);

      return output;
   }

   public void AddItemsToBid(IEnumerable<Item> items, int bidId)
   {
      foreach (Item item in items)
      {
         _catalogingRepo.AddItem(item, bidId);
      }
   }

   public void DeleteAllItemsFromBid(int bidId)
   {
      foreach (Item item in _catalogingRepo.GetItems(bidId))
      {
         _catalogingRepo.DeleteItem(item.Id);
      }
   }

   public string[] GetItemCategories_ByBid(int bidId)
   {
      return _catalogingRepo.GetItems(bidId)
          .Select(x => x.Category)
          .Distinct()
          .ToArray();
   }

   public bool ItemCodeExistsInBid(int itemCode, int bidId, int itemId)
   {
      return _catalogingRepo.GetItems(bidId)
              .Where(item => item.Id != itemId)
              .Any(item => item.Code == itemCode);
   }
}
