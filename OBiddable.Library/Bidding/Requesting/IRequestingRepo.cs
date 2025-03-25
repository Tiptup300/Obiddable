using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting
{
    public interface IRequestingRepo
    {
        #region Requestors
        void AddRequestor_ToBid(Requestor obj, int bidId);
        Requestor GetRequestor(int requestorId);
        List<Requestor> GetRequestors_ByBid(int bidId);
        void UpdateRequestor(Requestor obj);
        void DeleteRequestor(int requestorId);
        #endregion

        #region Requests
        Request GetRequest(int requestId);
        //IEnumerable<Request> GetRequests(int bidId);
        void UpdateRequest(Request obj);
        void DeleteRequest(int requestId);
        #endregion

        #region Request Items
        RequestItem GetRequestItem(int requestItemId);
        List<RequestItem> GetRequestItems_ByBid(int bidId);
        void UpdateRequestItem(RequestItem obj);
        void DeleteRequestItem(int requestItemId);
        #endregion


        void AddRequest_ToRequestor(Request obj, int requestorId);
        void AddRequestItem_ToRequest(RequestItem obj, int requestId);
        void ClearRequests_ByRequestor(int requestorId);
        void DeleteRequests_ByBid(int bidId);
        string[] GetRequestAccoutNumbers_ByBid(int bidId);
        bool Check_RequestAccountNumberAlreadyExists_InRequestor(string accountNumber, int requestorId, int requestId);
        List<Request> GetRequests_ByRequestor(int requestorId);

        List<RequestItem> GetRequestItems_ByItem(int itemId);
        List<RequestItem> GetRequestItems_ByRequest(int requestId);
        List<RequestItem> GetRequestItems_ByRequestor(int requestorId);
        List<RequestItem> GetRequestItems_ByRequestor_ByItem(int requestorId, int itemId);
        bool Check_RequestItemLast_ForRespondedItem(int requestItemId);
        void DeleteRequestItems_ByRequest(int requestId);
        void DeleteRequestItems_ByBid(int bidId);

        void DeleteRequestors_ByBid(int bidId);
        string[] GetRequestorsBuildingNames_ByBid(int bidId);
        List<Requestor> GetRequestors_ByBuildingName(int bidId, string buildingName);

        bool Check_ItemRequested(int itemId);
        List<Item> GetItems_Requested_ByBid(int bidId);
        int Get_Item_RequestedQuantity(int itemId);
        int GetItemsRequestedQuantity(Item item);
    }
}