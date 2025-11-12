using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.Staging;

namespace Obiddable.Library.EF.Bidding.Distribution;
public class EFDistributionRepo : IDistributionRepo
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   public void AddDistributedQuantity(DistributedQuantity distributedQuantity)
   {
      throw new NotImplementedException();
   }

   private Building getBuilding(Dbc dbc, DistributedQuantity distributedQuantity)
   {

      throw new NotImplementedException();
   }

   public Building GetBuildingByRequestor(Requestor requestor)
   {
      //IEnumerable<Requestor> buildingRequestors;

      //buildingRequestors = 

      // return new Building(requestor.Bid, requestor.Building);
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

   public DistributedQuantity GetDistributedQuantity(Building building, Item item)
   {
      throw new NotImplementedException();
   }

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

   public int GetRequestedQuantity(Building building, Item item)
   {
      throw new NotImplementedException();
   }

   public IEnumerable<Building> GetAllBuildingsWhoRequestedItem(Item item)
   {
      throw new NotImplementedException();
   }
}
