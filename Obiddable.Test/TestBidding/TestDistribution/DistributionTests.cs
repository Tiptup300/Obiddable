using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Test.MockBids;
using Obiddable.Test.Mocking;

namespace Obiddable.Test;
public class DistributionTests
{
   [Fact]
   public void CanGetDistributedQuantityNonAlternate()
   {
      DistributedQuantity distributedQuantity;
      Mocker mocker;
      IRequestingRepo requestingRepo;
      ICatalogingRepo catalogingRepo;
      DistributionService distributionService;
      Requestor john;
      Item beaker;

      mocker = new Mocker(new TheNewBidMock());
      distributionService = mocker.GetDistributionService();
      requestingRepo = mocker.GetRequestingRepo();
      catalogingRepo = mocker.GetCatalogingRepo();
      john = requestingRepo.GetRequestor(374);
      beaker = catalogingRepo.GetItem(24214);
      distributedQuantity = distributionService.GetDistributedQuantity(john, beaker);

      Assert.Equal(3, distributedQuantity.Quantity);
      Assert.Equal(74, distributedQuantity.Bid.Id);
      Assert.Equal("HAJH", distributedQuantity.Building.Name);
      Assert.Equal(24214, distributedQuantity.Item.Id);
   }

   [Fact]
   public void CanGetBuildingByRequestor()
   {
      Building building;
      Mocker mocker;
      IRequestingRepo requestingRepo;
      DistributionService distributionService;
      Requestor john;

      mocker = new Mocker(new TheNewBidMock());
      distributionService = mocker.GetDistributionService();
      requestingRepo = mocker.GetRequestingRepo();

      john = requestingRepo.GetRequestor(374);
      building = distributionService.GetBuildingByRequestor(john);

      Assert.Equal(74, building.Bid.Id);
      Assert.Equal("HAJH", building.Name);
      Assert.Equal(2, building.Requestors.Count());
      Assert.Contains(john, building.Requestors);
   }

   [Fact]
   public void CanGetBuilding()
   {
      Building building;
      Bid bid;
      Mocker mocker;
      DistributionService distributionService;

      mocker = new Mocker(new TheNewBidMock());
      distributionService = mocker.GetDistributionService();
      bid = mocker.GetBiddingRepo().GetBid(74);
      building = distributionService.GetBuilding(bid, "HAJH");

      Assert.Equal(74, building.Bid.Id);
      Assert.Equal("HAJH", building.Name);
      Assert.Equal(2, building.Requestors.Count());
      Assert.Contains("John Yogus", building.Requestors.Select(x => x.Name));
      Assert.Contains("Todd Russell", building.Requestors.Select(x => x.Name));
   }

   [Fact]
   public void CanBuildingGetRequestedQuantity()
   {
      Mocker mocker = new Mocker(new TheNewBidMock());
      DistributionService distributionService = mocker.GetDistributionService();
      Bid bid = mocker.GetBiddingRepo().GetBid(74);
      Building building = distributionService.GetBuilding(bid, "HAJH");


      Assert.Equal(2, building.GetRequestedQuantity(24197));
      Assert.Equal(2, building.GetRequestedQuantity(24198));
   }

   [Fact]
   public void CanGetRequestorsBuildingNames_Elected_ByVendorResponse()
   {
      string[] buildings;
      Mocker mocker = new Mocker(new TheNewBidMock()); ;
      DistributionService distributionService = mocker.GetDistributionService();

      buildings = distributionService.GetRequestorsBuildingNames_Elected_ByVendorResponse(89);

      Assert.Equal(2, buildings.Count());
      Assert.Contains("HASH", buildings);
      Assert.Contains("HAJH", buildings);
   }

   [Fact]
   public void CanGetResponseItems_ByBuildingName_ByVendorResponse()
   {
      IEnumerable<ResponseItem> responseItems;
      IEnumerable<int> responseItemsIds;
      Mocker mocker = new Mocker(new TheNewBidMock()); ;
      DistributionService distributionService = mocker.GetDistributionService();

      responseItems = distributionService.GetResponseItems_ByBuildingName_ByVendorResponse("HAJH", 88);
      responseItemsIds = responseItems.Select(x => x.Id);

      Assert.Equal(2, responseItems.Count());
      Assert.Contains(845, responseItemsIds);
      Assert.Contains(843, responseItemsIds);
   }
}
