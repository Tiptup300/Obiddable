using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Test.Repos;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Test.MockBids
{
    public class UnmatchedAlternateSingleMockBidBuilder : IMockBidBuilder
    {
        public Bid BuildBid()
        {
            Bid bid;

            bid = new Bid() { Id = 74, Name = "THE NEW BID - With UnmatchedALternate" };
            bid.Items = buildItems(bid);
            bid.Requestors = buildRequestors(bid);
            bid.VendorResponses = buildVendorResponses(bid);
            markElections(bid);

            return bid;
        }


        private List<Item> buildItems(Bid bid)
        {
            return new List<Item>()
            {
                new Item(24197, bid, 001800, "", "Acid Rain Bio Kit", false, "EACH", 0, 0)
            };
        }

        private List<Requestor> buildRequestors(Bid bid)
        {
            return new List<Requestor>()
            {
                buildJohn(bid),
            };
        }

        private Requestor buildJohn(Bid bid)
        {
            Requestor output;
            Request request;

            output = new Requestor() { Id = 374, Bid = bid, Name = "John Yogus", Building = "BAJH", Code = 23 };
            request = new Request() { Id = 375, Account_Number = "99.1110.610.000.30.31.12.0020", Requestor = output };
            request.RequestItems = new List<RequestItem>()
            {
                new RequestItem() { Id = 1078, Item = bid.Items[0], Quantity = 5, Request = request  }
            };
            output.Requests = new List<Request>() { request };

            return output;
        }

        private List<VendorResponse> buildVendorResponses(Bid bid)
        {
            return new List<VendorResponse>()
            {
                buildHorvak(bid)
            };
        }

        private VendorResponse buildHorvak(Bid bid)
        {
            VendorResponse output;

            output = new VendorResponse() { Id = 89, Bid = bid, VendorName = "Horvak Chemical Supply" };
            output.ResponseItems = new List<ResponseItem>()
            {
                new ResponseItem(847,bid.Items[0], "1", 1M, 1M, "CASE", true, "sams club", false, null) 

            };
            output.ResponseItems.ForEach(x => x.VendorResponse = output);

            return output;
        }
        private void markElections(Bid bid)
        {
            IEnumerable<ResponseItem> responseItems;

            responseItems = bid.VendorResponses.SelectMany(x => x.ResponseItems);
            electResponseItemById(responseItems, 847, "The one we want");
        }

        private void electResponseItemById(IEnumerable<ResponseItem> responseItems, int id, string reason)
        {
            ResponseItem electedResponseItem;

            electedResponseItem = responseItems.Single(x => x.Id == id);
            electedResponseItem.Elected = true;
            electedResponseItem.ElectionReason = reason;
        }
    }
}
