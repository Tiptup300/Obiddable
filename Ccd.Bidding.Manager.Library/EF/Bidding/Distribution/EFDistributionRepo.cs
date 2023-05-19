using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Staging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Distribution
{
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
}
