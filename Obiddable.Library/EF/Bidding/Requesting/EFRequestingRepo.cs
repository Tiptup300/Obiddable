using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting.Cataloging;
using Obiddable.Library.EF.Bidding.Requesting.RequestItems;
using Obiddable.Library.EF.Bidding.Requesting.Requestors;
using Obiddable.Library.EF.Bidding.Requesting.Requests;

namespace Obiddable.Library.EF.Bidding.Requesting;
public class EFRequestingRepo : IRequestingRepo
{
   private readonly RequestorsRepo _requestorsRepo = new RequestorsRepo();
   private readonly RequestsRepo _requestsRepo = new RequestsRepo();
   private readonly RequestItemsRepo _requestItemsRepo = new RequestItemsRepo();
   private readonly RequestingCatalogingRepo _requestingCatalogingRepo = new RequestingCatalogingRepo();

   #region Requests
   public void AddRequest_ToRequestor(Request obj, int requestorId)
       => _requestsRepo.AddRequest_ToRequestor(obj, requestorId);
   public void UpdateRequest(Request obj)
       => _requestsRepo.UpdateRequest(obj);
   public void DeleteRequest(int requestId)
       => _requestsRepo.DeleteRequest(requestId);
   public void ClearRequests_ByRequestor(int requestorId)
       => _requestsRepo.ClearRequests_ByRequestor(requestorId);
   public void DeleteRequests_ByBid(int bidId)
       => _requestsRepo.DeleteRequests_ByBid(bidId);

   public Request GetRequest(int requestId)
       => _requestsRepo.GetRequest(requestId);
   public List<Request> GetRequests_ByRequestor(int requestorId)
       => _requestsRepo.GetRequests_ByRequestor(requestorId);
   public string[] GetRequestAccountNumbers_ByBid(int bidId)
       => _requestsRepo.GetRequestAccoutNumbers_ByBid(bidId);


   public string[]? GetNewRequestAccountNumbers_ByRequestor(int requestorId)
   {
      if (_requestorsRepo.GetRequestor(requestorId) is not Requestor requestor)
         return null;

      return GetRequestAccountNumbers_ByBid(requestor.Bid.Id)
         .Where(x => !requestor.Requests.Any(y => y.Account_Number == x))
         .ToArray();
   }

   public bool Check_RequestAccountNumberAlreadyExists_InRequestor(string accountNumber, int requestorId, int requestId)
       => _requestsRepo.Check_RequestAccountNumberAlreadyExists_InRequestor(accountNumber, requestorId, requestId);

   #endregion

   #region Request Items

   public void AddRequestItem_ToRequest(RequestItem requestItem, int requestId)
       => _requestItemsRepo.AddRequestItem_ToRequest(requestItem, requestId);
   public void UpdateRequestItem(RequestItem requestItem)
       => _requestItemsRepo.UpdateRequestItem(requestItem);
   public void DeleteRequestItem(int requestItemId)
       => _requestItemsRepo.DeleteRequestItem(requestItemId);
   public void DeleteRequestItems_ByRequest(int requestId)
       => _requestItemsRepo.DeleteRequestItems_ByRequest(requestId);
   public void DeleteRequestItems_ByBid(int bidId)
       => _requestItemsRepo.DeleteRequestItems_ByBid(bidId);
   public RequestItem GetRequestItem(int requestItemId)
       => _requestItemsRepo.GetRequestItem(requestItemId);
   public List<RequestItem> GetRequestItems_ByBid(int bidId)
       => _requestItemsRepo.GetRequestItems_ByBid(bidId);
   public List<RequestItem> GetRequestItems_ByItem(int itemId)
       => _requestItemsRepo.GetRequestItems_ByItem(itemId);
   public List<RequestItem> GetRequestItems_ByRequestor_ByItem(int requestorId, int itemId)
       => _requestItemsRepo.GetRequestItems_ByRequestor_ByItem(requestorId, itemId);
   public List<RequestItem> GetRequestItems_ByRequest(int requestId)
       => _requestItemsRepo.GetRequestItems_ByRequest(requestId);
   public List<RequestItem> GetRequestItems_ByRequestor(int requestorId)
       => _requestItemsRepo.GetRequestItems_ByRequestor(requestorId);

   #endregion

   #region Cataloging
   public bool Check_ItemRequested(int itemId)
       => _requestingCatalogingRepo.Check_ItemRequested(itemId);
   public List<Item> GetItems_Requested_ByBid(int bidId)
       => _requestingCatalogingRepo.GetItems_Requested_ByBid(bidId);
   public int GetItemsRequestedQuantity(Item item)
       => _requestingCatalogingRepo.GetItemsRequestedQuantity(item);
   public int Get_Item_RequestedQuantity(int itemId)
       => _requestingCatalogingRepo.Get_Item_RequestedQuantity(itemId);
   public bool Check_RequestItemLast_ForRespondedItem(int requestItemId)
       => _requestingCatalogingRepo.Check_RequestItemLast_ForRespondedItem(requestItemId);

   #endregion

   #region Requestors

   public void AddRequestor_ToBid(Requestor obj, int bidId)
       => _requestorsRepo.AddRequestor_ToBid(obj, bidId);
   public void UpdateRequestor(Requestor obj)
       => _requestorsRepo.UpdateRequestor(obj);
   public void DeleteRequestor(int requestorId)
       => _requestorsRepo.DeleteRequestor(requestorId);
   public void DeleteRequestors_ByBid(int bidId)
       => _requestorsRepo.DeleteRequestors_ByBid(bidId);

   public Requestor GetRequestor(int requestorId)
       => _requestorsRepo.GetRequestor(requestorId);
   public List<Requestor> GetRequestors_ByBid(int bidId)
       => _requestorsRepo.GetRequestors_ByBid(bidId);
   public List<Requestor> GetRequestors_ByBuildingName(int bidId, string buildingName)
       => _requestorsRepo.GetRequestors_ByBuildingName(bidId, buildingName);
   public string[] GetRequestorsBuildingNames_ByBid(int bidId)
       => _requestorsRepo.GetRequestorsBuildingNames_ByBid(bidId);

   #endregion
}
