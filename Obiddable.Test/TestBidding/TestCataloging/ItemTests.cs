using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Test.MockBids;
using Obiddable.Test.Repos;

namespace Obiddable.Test;
public class ItemTests
{
   private ICatalogingRepo buildCatalogingRepo()
   {
      ICatalogingRepo output;

      MockData mockData = new MockData(new TwoItemsMock());
      output = new MockCatalogingRepo(mockData);

      return output;
   }

   [Fact]
   public void BuildItem()
   {
      Bid bid = new Bid() { Id = 1, Name = "Test" };
      Item item = new Item(1, bid, 111, "Things", "Widget", false, "Each", 0, 0);

      Assert.True(true);
   }

   [Fact]
   public void GetItem()
   {
      ICatalogingRepo catalogingRepo = buildCatalogingRepo();
      Item item = catalogingRepo.GetItem(1);

      Assert.True(item.Id == 1);
      Assert.True(item.Bid.Id == 1);
      Assert.True(item.Code == 111);
      Assert.True(item.Category == "Things");
      Assert.True(item.Description == "Widget");
      Assert.True(item.Substitutable == false);
      Assert.True(item.Unit == "Each");
      Assert.True(item.Price == 20M);
      Assert.True(item.Last_Order_Price == 10M);
   }

   [Fact]
   public void CanAddItem()
   {
      ICatalogingRepo catalogingRepo = buildCatalogingRepo();
      Item item = new Item(null, null, 333, "Things", "Widget", false, "Each", 0, 0);

      catalogingRepo.AddItem(item, 1);


   }

   [Fact]
   public void DoesHypenatedItemCodeWork()
   {
      Item longItem = new Item(null, null, 123456, null, null, null, null, null, null);
      Item shortItem = new Item(null, null, 1, null, null, null, null, null, null);

      Assert.Equal("1234-56", longItem.HyphenatedFormattedCode);
      Assert.Equal("0000-01", shortItem.HyphenatedFormattedCode);
   }
}
