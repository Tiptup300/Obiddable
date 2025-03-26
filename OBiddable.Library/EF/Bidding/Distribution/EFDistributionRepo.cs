using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Distribution;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Staging;
using OBiddable.Library.Staging.ItemElections;

namespace OBiddable.Library.EF.Bidding.Distribution;

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
