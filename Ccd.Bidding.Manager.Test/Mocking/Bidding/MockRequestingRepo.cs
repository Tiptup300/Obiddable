using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Test.Repos
{
   public class MockRequestingRepo : IRequestingRepo
   {
      private readonly MockData _data;

      public MockRequestingRepo(MockData data)
      {
         _data = data;
      }

      public void AddRequestItem_ToRequest(RequestItem obj, int requestId)
      {
         throw new NotImplementedException();
      }

      public void AddRequestor_ToBid(Requestor obj, int bidId)
      {
         throw new NotImplementedException();
      }

      public void AddRequest_ToRequestor(Request obj, int requestorId)
      {
         throw new NotImplementedException();
      }

      public bool Check_ItemRequested(int itemId)
      {
         throw new NotImplementedException();
      }

      public bool Check_RequestAccountNumberAlreadyExists_InRequestor(string accountNumber, int requestorId, int requestId)
      {
         throw new NotImplementedException();
      }

      public bool Check_RequestItemLast_ForRespondedItem(int requestItemId)
      {
         throw new NotImplementedException();
      }

      public void ClearRequests_ByRequestor(int requestorId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequest(int requestId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequestItem(int requestItemId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequestItems_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequestItems_ByRequest(int requestId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequestor(int requestorId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequestors_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public void DeleteRequests_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public int GetItemsRequestedQuantity(Item item)
      {
         return _data.RequestItems
             .Where(x => x.Item.Id == item.Id)
             .Select(x => x.Quantity)
             .Sum();
      }

      public List<Item> GetItems_Requested_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public Request GetRequest(int requestId)
      {
         throw new NotImplementedException();
      }

      public string[] GetRequestAccoutNumbers_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public RequestItem GetRequestItem(int requestItemId)
      {
         throw new NotImplementedException();
      }

      public List<RequestItem> GetRequestItems_ByBid(int bidId)
          => _data.RequestItems.Where(x => x.Request.Requestor.Bid.Id == bidId).ToList();

      public List<RequestItem> GetRequestItems_ByItem(int itemId)
      {
         return _data.RequestItems
             .Where(x => x.Item.Id == itemId)
             .ToList();
      }

      public List<RequestItem> GetRequestItems_ByRequest(int requestId)
      {
         return _data.RequestItems
             .Where(x => x.Request.Id == requestId)
             .ToList();
      }

      public List<RequestItem> GetRequestItems_ByRequestor(int requestorId)
      {
         throw new NotImplementedException();
      }

      public List<RequestItem> GetRequestItems_ByRequestor_ByItem(int requestorId, int itemId)
      {
         throw new NotImplementedException();
      }

      public Requestor GetRequestor(int requestorId)
      {
         return _data.Requestors
             .Single(x => x.Id == requestorId);
      }

      public string[] GetRequestorsBuildingNames_ByBid(int bidId)
      {
         return _data.Requestors
             .Where(x => x.Bid.Id == bidId)
             .Where(x => String.IsNullOrEmpty(x.Building) == false)
             .Select(x => x.Building)
             .Distinct()
             .ToArray();
      }

      public string[] GetRequestorsBuildingNames_Elected_ByVendorResponse(int vendorResponseId)
      {
         throw new NotImplementedException();
      }

      public List<Requestor> GetRequestors_ByBid(int bidId)
      {
         return _data.Requestors
             .Where(x => x.Bid.Id == bidId)
             .ToList();
      }

      public List<Requestor> GetRequestors_ByBuildingName(int bidId, string buildingName)
      {
         return _data.Requestors
             .Where(x => x.Bid.Id == bidId)
             .Where(x => x.Building == buildingName)
             .ToList();
      }

      public List<Request> GetRequests_ByRequestor(int requestorId)
      {
         return _data.Requests
             .Where(x => x.Requestor.Id == requestorId)
             .ToList();
      }

      public int Get_Item_RequestedQuantity(int itemId)
      {
         throw new NotImplementedException();
      }

      public void UpdateRequest(Request obj)
      {
         throw new NotImplementedException();
      }

      public void UpdateRequestItem(RequestItem obj)
      {
         throw new NotImplementedException();
      }

      public void UpdateRequestor(Requestor obj)
      {
         throw new NotImplementedException();
      }
   }
}
