using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.Bidding.Electing;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Test.Repos;

namespace Obiddable.Test.Mocking;
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
