using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;

namespace Ccd.Bidding.Manager.Test.Repos;
public class MockCatalogingRepo : ICatalogingRepo
{
   private readonly MockData _data;

   public MockCatalogingRepo(MockData mockData)
   {
      _data = mockData;
   }

   public void AddItem(Item item, int bidId)
   {
      Bid bid;

      bid = _data.GetBid(bidId);
      _data.Items.Add(item.ChangeBid(bid));
   }
   public Item GetItem(int itemId)
       => _data.GetItem(itemId);
   public IEnumerable<Item> GetItems(int bidId)
       => _data.Items
       .Where(item => item.Bid.Id == bidId)
       .ToList();
   public void UpdateItem(Item newVersion)
   {
      Item oldItem = _data.GetItem(newVersion.Id);
      Item updatedItemToAdd = oldItem.UpdateItem(newVersion);

      _data.Items.Remove(oldItem);
      _data.Items.Add(updatedItemToAdd);
   }
   public void DeleteItem(int itemId)
   {
      Item item = _data.GetItem(itemId);
      _data.Items.Remove(item);
   }
}
