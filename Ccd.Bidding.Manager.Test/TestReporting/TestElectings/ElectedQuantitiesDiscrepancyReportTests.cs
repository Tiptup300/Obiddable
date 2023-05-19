using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Reporting.Bidding.Electings;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;
using Ccd.Bidding.Manager.Test.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ccd.Bidding.Manager.Test.Reporting.Electings
{
    public class ElectedQuantitiesDiscrepancyReportTests
    {
        [Fact]
        public void DoesGenerateTableDataWork()
        {
            Mocker _ = new Mocker(new DiscrepancyMock());

            ElectedQuantitiesDiscrepancyReport report = new ElectedQuantitiesDiscrepancyReport(_.GetRequestingRepo(),
                _.GetLegacyElectionsRepo());

            string output = report.GenerateTableData(_.GetBiddingRepo().GetBid(1));

            Assert.True(output.Length > 0);
            Assert.Equal(" <table>     <thead>         <tr>             <th class='itemCode'>Item<br />Code</th>             <th class='itemDescription'>Item<br />Description</th>             <th class='itemRequestedQuantity'>Requested Quantity</th>             <th class='itemRequestedUnit'>&nbsp;</th>             <th class='electedVendor'>Elected Vendor</th>             <th class='vendorAlternateQuantity'>Vendor Alternate Quantity</th>             <th class='vendorAlternateUnit'>&nbsp;</th>         </tr>     </thead>     <tbody>          <tr>             <td class='itemCode'>001800</td>             <td class='itemDescription'>Acid Rain Bio Kit</td>             <td class='itemRequestedQuantity'>12</td>             <td class='itemRequestedUnit'>EACH</td>             <td class='electedVendor'>Horvak Chemical Supply</td>             <td class='vendorAlternateQuantity'>1</td>             <td class='vendorAlternateUnit'>DOZEN</td>         </tr>          <tr>             <td colspan='5' class='itemCode'>&nbsp;</td>             <td class=''>Total Discrepancies:</td>             <td class=''>1</td>         </tr>      </tbody>  </table>", output);

        }

        private class DiscrepancyMock : IMockBidBuilder
        {
            public Bid BuildBid()
            {
                Bid output;

                output = new Bid() { Id = 1 };
                output.Items = new List<Item>()
                {
                    new Item(1, output, 001800, "Acid Rain", "Acid Rain Bio Kit", false, "EACH", 0, 0),
                    new Item(2, output, 002400, "Other Item", "Item No Two", false, "EACH", 0, 0)
                };
                output.Requestors = new List<Requestor>()
                {
                    buildRequestor(output)
                };
                output.VendorResponses = new List<VendorResponse>()
                {
                    buildVendorResponse(output)
                };

                return output;
            }

            private Requestor buildRequestor(Bid bid)
            {
                Requestor output;

                output = new Requestor() { Id = 374, Bid = bid, Name = "John Yogus", Building = "HAJH", Code = 23 };
                output.Requests.Add(buildRequest(output));

                return output;
            }

            private Request buildRequest(Requestor requestor)
            {
                Request output;

                output = new Request() { Id = 375, Account_Number = "10.1110.610.000.30.31.12.0020", Requestor = requestor };
                output.RequestItems = new List<RequestItem>()
                {
                    new RequestItem() { Id = 1078, Item = requestor.Bid.Items[0], Quantity = 12, Request = output  },
                    new RequestItem() { Id = 1078, Item = requestor.Bid.Items[1], Quantity = 12, Request = output  }
                };

                return output;
            }


            private VendorResponse buildVendorResponse(Bid bid)
            {
                VendorResponse output;

                output = new VendorResponse() { Id = 89, Bid = bid, VendorName = "Horvak Chemical Supply" };
                output.ResponseItems = new List<ResponseItem>()
                {
                    new ResponseItem(847, bid.Items[0], "1", 1M, 1, "DOZEN", true, "alt desc", true, "its elected"),
                    new ResponseItem(849, bid.Items[1], "1", 1M, 0, null, false, null, true, "its elected")
                };

                output.ResponseItems.ForEach(x => x.VendorResponse = output);

                return output;
            }
        }

    }
}
