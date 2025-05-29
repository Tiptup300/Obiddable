using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding.Responding
{
   public interface IRespondingRepo
   {

      #region Vendor Responses
      void AddVendorResponse_ToBid(VendorResponse obj, int bidId);
      VendorResponse GetVendorResponse(int vendorResponseId);
      List<VendorResponse> GetVendorResponses_ByBid(int bidId);
      void UpdateVendorResponse(VendorResponse obj);
      void DeleteVendorResponse(int vendorResponseId);
      #endregion

      #region ResponseItems
      void AddResponseItem_ToVendorResponse(ResponseItem obj, int vendorResponseId);
      ResponseItem GetResponseItem(int responseItemId);
      List<ResponseItem> GetResponseItems_ByBid(int bidId);
      List<ResponseItem> GetResponseItems_ByItem(int itemId);
      List<ResponseItem> GetResponseItems_ByVendorResponse(int vendorResponseId);

      void UpdateResponseItem(ResponseItem obj);
      void DeleteResponseItem(int responseItemId);
      void DeleteResponseItems_ByBid(int bidId);
      void DeleteResponseItems_ByVendorResponse(int vendorResponseId);
      bool Check_ResponseItemIsLowestBid(int vendorResponseId, IRequestingRepo requestingRepo);
      #endregion


      void DeleteVendorResponses_ByBid(int bidId);
      bool Check_VendorResponseVendorNameAlreadyExists_InBid(string text, int bidId, int vendorResponseId);
      bool Check_ItemResponded(int itemId);
      List<Item> GetItems_Responded_ByBid(int bidId);
   }
}
