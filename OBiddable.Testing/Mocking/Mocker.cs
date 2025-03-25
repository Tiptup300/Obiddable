using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Test.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Test.Mocking
{
    public class Mocker
    {
        private readonly MockData _mockData;
        public Mocker(IMockBidBuilder mockBidBuilder)
        {
            _mockData = new MockData(mockBidBuilder);
        }


        public IBiddingRepo GetBiddingRepo() => new MockBiddingRepo(_mockData);
        public ICatalogingRepo GetCatalogingRepo() => new MockCatalogingRepo(_mockData);
        public IDistributionRepo GetDistributionRepo() => new MockDistributionRepo(_mockData);
        public IRequestingRepo GetRequestingRepo() => new MockRequestingRepo(_mockData);
        public IRespondingRepo GetRespondingRepo() => new MockRespondingRepo(_mockData);
        public ILegacyElectionsRepo GetLegacyElectionsRepo() => new MockLegacyElectionsRepo(_mockData);

        public BiddingService GetBiddingService() => new BiddingService(GetBiddingRepo());
        public CatalogingService GetCatalogingService() => new CatalogingService(GetCatalogingRepo());
        public DistributionService GetDistributionService() => new DistributionService(GetRequestingRepo(), GetLegacyElectionsRepo(), GetDistributionRepo(), GetRespondingRepo());
    }
}
