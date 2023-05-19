using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Staging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Distribution
{
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
}
