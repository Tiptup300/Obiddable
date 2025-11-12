using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.Staging;
using Obiddable.Test.Repos;

namespace Obiddable.Test;
public class MockDistributionRepo : IDistributionRepo
{
   private readonly MockData _data;
   private readonly MockRequestingRepo _requestingRepo;
   private readonly MockLegacyElectionsRepo _legacyElectionsRepo;

   public MockDistributionRepo(MockData data)
   {
      _data = data;
      _requestingRepo = new MockRequestingRepo(_data);
      _legacyElectionsRepo = new MockLegacyElectionsRepo(_data);
   }

   public void AddDistributedQuantity(DistributedQuantity distributedQuantity)
   {
      throw new NotImplementedException();
   }

   public BuildingDistribution GetBuildingDistribution(Building building)
   {
      throw new NotImplementedException();
   }

   public IEnumerable<BuildingDistribution> GetBuildingDistributionsByBidId(Bid bid)
   {
      throw new NotImplementedException();
   }

   public int GetRequestedQuantity(Building building, Item item)
   {
      return _data.Requestors
          .Where(x => x.Building == building.Name)
          .SelectMany(x => x.Requests)
          .SelectMany(x => x.RequestItems)
          .Where(x => x.Item.Id == item.Id)
          .Select(x => x.Quantity)
          .Sum();
   }

   private DistributedQuantity getDistributedQuantity(Building building, Item item)
   {
      DistributedQuantity output;
      decimal quantity;

      // return only the sumed quantity of that building 
      quantity = building.Requestors
          .SelectMany(x => x.Requests)
          .SelectMany(x => x.RequestItems)
          .Where(x => x.Item.Id == item.Id)
          .Sum(x => x.Quantity);
      output = new DistributedQuantity(item.Bid, building, item, quantity);

      return output;
   }

   public IEnumerable<Building> GetAllBuildingsWhoRequestedItem(Item item)
   {
      IEnumerable<Building> output;
      IEnumerable<Building> bidBuildings;

      bidBuildings = getAllBuildingsInBid(item.Bid);
      output = bidBuildings
          .Where(building =>
          {
             return building.Requestors
                    .SelectMany(x => x.Requests)
                    .SelectMany(x => x.RequestItems)
                    .Any(x => x.Item.Id == item.Id);
          });

      return output;
   }

   private IEnumerable<Building> getAllBuildingsInBid(Bid bid)
   {
      IEnumerable<Building> output;

      output = _data.Requestors
          .Where(x => x.Bid.Id == bid.Id)
          .Select(x => x.Building)
          .Distinct()
          .Select(x => getBuilding(x, bid));

      return output;
   }

   private Building getBuilding(string buildingName, Bid bid)
   {
      IEnumerable<Requestor> buildingRequestors;

      buildingRequestors = _data.Requestors
          .Where(x => x.Building == buildingName);

      return new Building(bid, buildingName, buildingRequestors);
   }

   private ResponseItem getElectedResponseItem(Item item)
       => _data.ResponseItems
           .Single(x => x.Elected && x.Item.Id == item.Id);



   public IEnumerable<ItemElection> GetElectedItemsByBidId(Bid bid)
   {
      throw new NotImplementedException();
   }

   public void RemoveDistributedQuantity(Building building, Item item)
   {
      throw new NotImplementedException();
   }

   public void UpdateDistributedQuantity(DistributedQuantity distributedQuantity)
   {
      throw new NotImplementedException();
   }

   public DistributedQuantity GetDistributedQuantity(Building building, Item item)
   {
      DistributedQuantity output;

      ResponseItem electedResponseItem;

      electedResponseItem = _legacyElectionsRepo.GetElectedResponseItemForItem(item.Id);

      int requestedQuantity = _requestingRepo.GetItemsRequestedQuantity(item);
      decimal respondedQuantity = electedResponseItem.AlternateQuantity;

      if (((decimal)requestedQuantity) == respondedQuantity)
      {
         int buildingRequestedQuantity = GetRequestedQuantity(building, item);

         output = new DistributedQuantity(item.Bid, building, item, buildingRequestedQuantity);
      }
      else
      {
         IEnumerable<Building> allBuildingsWhoRequestedItem = GetAllBuildingsWhoRequestedItem(item);

         if (allBuildingsWhoRequestedItem.Count() == 1 && allBuildingsWhoRequestedItem.Single().Name == building.Name)
         {
            output = new DistributedQuantity(item.Bid, building, item, respondedQuantity);
         }
         else
         {
            // pull from database
            throw new UnmatchedQuantityWithoutDistributionException();
         }
      }

      return output;
   }
}
