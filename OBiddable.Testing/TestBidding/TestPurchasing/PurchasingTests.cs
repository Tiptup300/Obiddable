using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Purchasing;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;
using Ccd.Bidding.Manager.Test.Mocking.Bidding;
using Ccd.Bidding.Manager.Test.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ccd.Bidding.Manager.Test
{
    public class PurchasingTests
    {
        [Fact]
        public void TestCreatingPurchaseOrders()
        {
            IEnumerable<PurchaseOrder> purchaseOrders = generatePurchaseOrdersWithMockData(new TheNewBidMock());
            PurchaseOrder horvakBajh = purchaseOrders.ToList()[0];
            PurchaseOrder horvakBash = purchaseOrders.ToList()[1];
            PurchaseOrder thompsonBajh = purchaseOrders.ToList()[2];

            Assert.Equal(3, purchaseOrders.Count());
            Assert.Equal(11M, horvakBajh.GetExtendedPriceSumOfLineItems());
            Assert.Equal(9M, horvakBajh.GetQuantitySumOfLineItems());
            Assert.Equal(2M, horvakBash.GetExtendedPriceSumOfLineItems());
            Assert.Equal(2M, horvakBash.GetQuantitySumOfLineItems());
            Assert.Equal(11M, thompsonBajh.GetExtendedPriceSumOfLineItems());
            Assert.Equal(10M, thompsonBajh.GetQuantitySumOfLineItems());
        }

        [Fact]
        public void TestCreatingPurchaseOrderWithUnmatchedAlternateSingleBuildings()
        {
            IEnumerable<PurchaseOrder> purchaseOrders = generatePurchaseOrdersWithMockData(new UnmatchedAlternateSingleMockBidBuilder());
            PurchaseOrder horvakBajh = purchaseOrders.ToList()[0];

            Assert.Single(purchaseOrders);
            Assert.Single(horvakBajh.LineItems);
            Assert.Equal(1,horvakBajh.LineItems[0].Quantity);
        }

        [Fact]
        public void TestCreatingPurchaseOrderWithUnmatchedAlternateMultipleBuildings()
        {
            IEnumerable<PurchaseOrder> purchaseOrders = generatePurchaseOrdersWithMockData(new UnmatchedAlternateMultipleMockBidBuilder());
            PurchaseOrder horvakBajh = purchaseOrders.ToList()[0];
            PurchaseOrder horvakBash = purchaseOrders.ToList()[1];

            Assert.Equal(2,purchaseOrders.Count());

            Assert.Single(horvakBajh.LineItems);
            Assert.Equal(-1, horvakBajh.LineItems[0].Quantity);

            Assert.Single(horvakBash.LineItems);
            Assert.Equal(-1, horvakBash.LineItems[0].Quantity);
        }

        private static IEnumerable<PurchaseOrder> generatePurchaseOrdersWithMockData(IMockBidBuilder mockBidBuilder)
        {
            IEnumerable<PurchaseOrder> output;

            Mocker mocker = new Mocker(mockBidBuilder);

            MockData mockData = new MockData(mockBidBuilder);
            Bid bid = mockData.Bids[0];
            PurchasingService purchasingOperations = new PurchasingService(
                new MockRespondingRepo(mockData),
                new MockRequestingRepo(mockData),
                new MockLegacyElectionsRepo(mockData),
                new DistributionService(
                    new MockRequestingRepo(mockData),
                    new MockLegacyElectionsRepo(mockData),
                    new MockDistributionRepo(mockData),
                    new MockRespondingRepo(mockData)),
                new MockPurchasingRepo(mockData));

            output = purchasingOperations.GeneratePurchaseOrders(bid);

            return output;
        }
    }
}
