using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Staging;
using OBiddable.Library.Staging.ItemElections;

namespace OBiddable.Library.Bidding.Distribution;

public interface IDistributionRepo
{
    void AddDistributedQuantity(DistributedQuantity distributedQuantity);
    void UpdateDistributedQuantity(DistributedQuantity distributedQuantity);
    void RemoveDistributedQuantity(Building building, Item item);

    BuildingDistribution GetBuildingDistribution(Building building);
    IEnumerable<BuildingDistribution> GetBuildingDistributionsByBidId(Bid bid);
    IEnumerable<ItemElection> GetElectedItemsByBidId(Bid bid);
    int GetRequestedQuantity(Building building, Item item);
    IEnumerable<Building> GetAllBuildingsWhoRequestedItem(Item item);
}
