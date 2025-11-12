using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Test.Repos;

namespace Obiddable.Test.MockBids;
public class TheNewBidMock : IMockBidBuilder
{
   public Bid BuildBid()
   {
      Bid bid;

      bid = new Bid() { Id = 74, Name = "THE NEW BID" };
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
             new Item(24197, bid, 001800, "Acid Rain", "Acid Rain Bio Kit", false, "KIT", 0, 0),
             new Item(24198, bid, 001900, "Acid Rain", "Acid Rain Bio Kit Refill", false, "KIT", 0, 0),
             new Item(24203, bid, 003100, "", "Ammonium Dichromate", false, "EACH", 0, 0),
             new Item(24206, bid, 004900, "", "Bacillus Subtilis", false, "EACH", 0, 0),
             new Item(24221, bid, 006400, "", "Barium Nitrate", false, "EACH", 0, 0),
             new Item(24214, bid, 007900, "Container", "Beaker", false, "PKG", 0, 0),
             new Item(24217, bid, 009000, "", "Benedict's Solution", false, "EACH", 0, 0)
         };
   }

   private List<Requestor> buildRequestors(Bid bid)
   {
      return new List<Requestor>()
         {
             buildJohn(bid),
             buildTodd(bid),
             buildJill(bid)
         };
   }

   private Requestor buildJohn(Bid bid)
   {
      Requestor output;
      Request request;

      output = new Requestor() { Id = 374, Bid = bid, Name = "John Yogus", Building = "HAJH", Code = 23 };
      request = new Request() { Id = 375, Account_Number = "10.1110.610.000.30.31.12.0020", Requestor = output };
      request.RequestItems = new List<RequestItem>()
         {
             new RequestItem() { Id = 1078, Item = bid.Items[0], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1085, Item = bid.Items[1], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1080, Item = bid.Items[2], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1081, Item = bid.Items[3], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1082, Item = bid.Items[4], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1083, Item = bid.Items[5], Quantity = 3, Request = request  },
             new RequestItem() { Id = 1084, Item = bid.Items[6], Quantity = 9, Request = request  }
         };
      output.Requests = new List<Request>() { request };

      return output;
   }

   private Requestor buildTodd(Bid bid)
   {
      Requestor output;
      Request request;

      output = new Requestor() { Id = 375, Bid = bid, Name = "Todd Russell", Building = "HAJH", Code = 24 };
      request = new Request() { Id = 376, Account_Number = "10.1110.762.000.30.31.12.0000", Requestor = output };
      request.RequestItems = new List<RequestItem>()
         {
             new RequestItem() { Id = 1086, Item = bid.Items[0], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1087, Item = bid.Items[1], Quantity = 1, Request = request  },
         };
      output.Requests = new List<Request>() { request };

      return output;
   }

   private Requestor buildJill(Bid bid)
   {
      Requestor output;
      Request request;

      output = new Requestor() { Id = 377, Bid = bid, Name = "Jill Hileman", Building = "HASH", Code = 26 };
      request = new Request() { Id = 377, Account_Number = "10.1110.762.000.30.31.12.0000", Requestor = output };
      request.RequestItems = new List<RequestItem>()
         {
             new RequestItem() { Id = 1088, Item = bid.Items[0], Quantity = 1, Request = request  },
             new RequestItem() { Id = 1089, Item = bid.Items[1], Quantity = 1, Request = request  },

         };
      output.Requests = new List<Request>() { request };

      return output;
   }

   private List<VendorResponse> buildVendorResponses(Bid bid)
   {
      return new List<VendorResponse>()
         {
             buildHorvak(bid),
             buildThompsons(bid)
         };
   }

   private VendorResponse buildHorvak(Bid bid)
   {
      VendorResponse output;

      output = new VendorResponse() { Id = 89, Bid = bid, VendorName = "Horvak Chemical Supply" };
      output.ResponseItems = new List<ResponseItem>()
         {
             new ResponseItem(847, bid.Items[0], "1", 1M, 0, null, false, null, false, null),
             new ResponseItem(848, bid.Items[1], "2", 1M, 0, null, false, null, false, null),
             new ResponseItem(849, bid.Items[2], "3", 1M, 0, null, false, null, false, null),
             new ResponseItem(850, bid.Items[3], "4", 1M, 0, null, false, null, false, null),
             new ResponseItem(851, bid.Items[4], "5", 3M, 0, null, false, null, false, null),
             new ResponseItem(852, bid.Items[5], "6", 1M, 0, null, false, null, false, null),
             new ResponseItem(853, bid.Items[6], "7", 1M, 0, null, false, null, false, null)
         };

      output.ResponseItems.ForEach(x => x.VendorResponse = output);

      return output;
   }

   private VendorResponse buildThompsons(Bid bid)
   {
      VendorResponse output;

      output = new VendorResponse() { Id = 88, Bid = bid, VendorName = "Thompsons Pharmacy" };
      output.ResponseItems = new List<ResponseItem>()
         {
             new ResponseItem(841, bid.Items[0], "", 1.5M, 0, null, false, null, false, null),
             new ResponseItem(842, bid.Items[1], "", 3M, 0, null, false, null, false, null),
             new ResponseItem(843, bid.Items[2], "", 2M, 0, null, false, null, false, null),
             new ResponseItem(844, bid.Items[4], "", 1M, 0, null, false, null, false, null),
             new ResponseItem(846, bid.Items[4], "", 20M, 0, "EA", true, "sams club", false, null),
             new ResponseItem(845, bid.Items[6], "", 1M, 0, "PACK", false, "super", false, null)
         };
      output.ResponseItems.ForEach(x => x.VendorResponse = output);

      return output;
   }
   private void markElections(Bid bid)
   {
      IEnumerable<ResponseItem> responseItems;

      responseItems = bid.VendorResponses.SelectMany(x => x.ResponseItems);
      electResponseItemById(responseItems, 847, "Low Bid (2021-02-03)");
      electResponseItemById(responseItems, 848, "Low Bid (2021-02-03)");
      electResponseItemById(responseItems, 843, "because");
      electResponseItemById(responseItems, 850, "Low Bid (2021-02-03)");
      electResponseItemById(responseItems, 851, "Sam's Club Barium Nitrate is no good according to John Yogus");
      electResponseItemById(responseItems, 852, "Low Bid (2021-02-03)");
      electResponseItemById(responseItems, 845, "Low Bid (2021-02-03)");
   }

   private void electResponseItemById(IEnumerable<ResponseItem> responseItems, int id, string reason)
   {
      ResponseItem electedResponseItem;

      electedResponseItem = responseItems.Single(x => x.Id == id);
      electedResponseItem.Elected = true;
      electedResponseItem.ElectionReason = reason;
   }
}
