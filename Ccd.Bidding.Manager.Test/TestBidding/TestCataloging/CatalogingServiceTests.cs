using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;

namespace Ccd.Bidding.Manager.Test.Bidding.Cataloging;
public class CatalogingServiceTests
{
   private Mocker _mocker;

   [Fact]
   public void CanGetItemByCode()
   {
      _mocker = new Mocker(new TheNewBidMock());

      CatalogingService catalogingService = _mocker.GetCatalogingService();

      Assert.Equal(24197, catalogingService.GetItemByCode(001800, 74).Id);
      Assert.Equal(24198, catalogingService.GetItemByCode(001900, 74).Id);
      Assert.Throws<InvalidOperationException>(() => catalogingService.GetItemByCode(999999, 74));
   }

   [Fact]
   public void CanAddItemsToBid()
   {
      _mocker = new Mocker(new TheNewBidMock());
      CatalogingService catalogingService = _mocker.GetCatalogingService();
      List<Item> itemsToAdd = new List<Item>()
         {
             new Item(null, null, 999999, "", "widget", false, "EA", 0, 0),
             new Item(null, null, 999991, "", "doodat", false, "EA", 0, 0)
         };

      catalogingService.AddItemsToBid(itemsToAdd, 74);

      IEnumerable<Item> items = _mocker.GetCatalogingRepo().GetItems(74);

      Assert.Contains(_mocker.GetCatalogingRepo().GetItems(74), x => x.Code == 999999);
      Assert.Contains(_mocker.GetCatalogingRepo().GetItems(74), x => x.Code == 999991);
   }

   [Fact]
   public void CanDeleteAllItemsFromBid()
   {
      _mocker = new Mocker(new TheNewBidMock());
      CatalogingService catalogingService = _mocker.GetCatalogingService();

      catalogingService.DeleteAllItemsFromBid(74);

      Assert.Empty(_mocker.GetCatalogingRepo().GetItems(74));
   }

   [Fact]
   public void CanGetItemCategories()
   {
      _mocker = new Mocker(new TheNewBidMock());
      CatalogingService catalogingService = _mocker.GetCatalogingService();

      Assert.Equal(3, catalogingService.GetItemCategories_ByBid(74).Length);
      Assert.Contains("Acid Rain", catalogingService.GetItemCategories_ByBid(74));
      Assert.Contains("Container", catalogingService.GetItemCategories_ByBid(74));
      Assert.Contains("", catalogingService.GetItemCategories_ByBid(74));
   }

   [Fact]
   public void CanCheckItemCodeAlreadyExists()
   {
      _mocker = new Mocker(new TheNewBidMock());
      CatalogingService catalogingService = _mocker.GetCatalogingService();

      Assert.False(catalogingService.ItemCodeExistsInBid(001800, 74, 24197));
      Assert.True(catalogingService.ItemCodeExistsInBid(001800, 74, 11111));
      Assert.False(catalogingService.ItemCodeExistsInBid(999999, 74, 24197));
      Assert.False(catalogingService.ItemCodeExistsInBid(999999, 74, 11111));
   }
}
