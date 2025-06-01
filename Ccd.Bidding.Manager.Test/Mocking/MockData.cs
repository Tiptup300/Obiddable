using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;

namespace Ccd.Bidding.Manager.Test.Repos;
public class MockData
{
   public List<Bid> Bids = new List<Bid>();
   public List<Item> Items;

   public List<Requestor> Requestors;
   public List<Request> Requests;
   public List<RequestItem> RequestItems;

   public List<VendorResponse> VendorResponses;
   public List<ResponseItem> ResponseItems;

   public List<PurchaseOrder> PurchaseOrders;
   public List<LineItem> LineItems;

   public MockData(IMockBidBuilder mockBidBuilder)
   {
      Bid bid = mockBidBuilder.BuildBid();
      Bids.Add(bid);
      Items = bid.Items;
      Requestors = bid.Requestors;
      Requests = bid.Requestors.SelectMany(x => x.Requests).ToList();
      RequestItems = bid.Requestors.SelectMany(x => x.Requests).SelectMany(y => y.RequestItems).ToList();
      VendorResponses = bid.VendorResponses;
      ResponseItems = bid.VendorResponses.SelectMany(x => x.ResponseItems).ToList();
      PurchaseOrders = bid.PurchaseOrders;
      LineItems = bid.PurchaseOrders.SelectMany(x => x.LineItems).ToList();
   }

   public Bid GetBid(int bidId) => Bids.Single(bid => bid.Id == bidId);
   public void AddBid(Bid bid)
   {

   }

   public Item GetItem(int itemId) => Items.Single(item => item.Id == itemId);
   public Requestor GetRequestor(int requestorId) => Requestors.Single(requestor => requestor.Id == requestorId);
   public Request GetRequest(int requestId) => Requests.Single(request => request.Id == request.Id);
   public RequestItem GetRequestItem(int requestItemId) => RequestItems.Single(requestItem => requestItem.Id == requestItemId);
   public VendorResponse GetVendorResponse(int vendorResponseId) => VendorResponses.Single(vendorResponse => vendorResponse.Id == vendorResponseId);
   public ResponseItem GetResponseItem(int responseItemId) => ResponseItems.Single(responseItem => responseItem.Id == responseItemId);
   public PurchaseOrder GetPurchaseOrder(int purchaseOrderId) => PurchaseOrders.Single(purchaseOrder => purchaseOrder.Id == purchaseOrderId);
   public LineItem GetLineItem(int lineItemId) => LineItems.Single(lineItem => lineItem.Id == lineItemId);


}