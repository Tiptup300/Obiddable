using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Test.Repos;
public class MockRespondingRepo : IRespondingRepo
{
   private readonly MockData _mockData;

   public MockRespondingRepo(MockData mockData)
   {
      _mockData = mockData;
   }

   public List<Item> GetItems_Responded_ByBid(int bidId)
       => throw new NotImplementedException();

   public ResponseItem GetResponseItem(int responseItemId)
       => _mockData.GetResponseItem(responseItemId);

   public List<ResponseItem> GetResponseItems_ByBid(int bidId)
       => _mockData.ResponseItems.Where(x => x.VendorResponse.Bid.Id == bidId).ToList();



   public List<ResponseItem> GetResponseItems_ByItem(int itemId)
       => _mockData.ResponseItems.Where(x => x.Item.Id == itemId).ToList();

   public List<ResponseItem> GetResponseItems_ByVendorResponse(int vendorResponseId)
       => _mockData.ResponseItems.Where(x => x.VendorResponse.Id == vendorResponseId).ToList();

   public VendorResponse GetVendorResponse(int vendorResponseId)
       => _mockData.GetVendorResponse(vendorResponseId);

   public List<VendorResponse> GetVendorResponses_ByBid(int bidId)
       => _mockData.VendorResponses.Where(x => x.Bid.Id == bidId).ToList();

   public bool Check_ItemResponded(int itemId)
   {
      throw new NotImplementedException();
   }

   public bool Check_ResponseItemIsLowestBid(int vendorResponseId, IRequestingRepo requestingRepo)
   {
      throw new NotImplementedException();
   }

   public bool Check_VendorResponseVendorNameAlreadyExists_InBid(string text, int bidId, int vendorResponseId)
   {
      throw new NotImplementedException();
   }


   public void AddResponseItem_ToVendorResponse(ResponseItem obj, int vendorResponseId)
       => throw new NotImplementedException();

   public void AddVendorResponse_ToBid(VendorResponse obj, int bidId)
       => throw new NotImplementedException();

   public void DeleteResponseItem(int responseItemId)
       => throw new NotImplementedException();

   public void DeleteResponseItems_ByBid(int bidId)
       => throw new NotImplementedException();

   public void DeleteResponseItems_ByVendorResponse(int vendorResponseId)
       => throw new NotImplementedException();

   public void DeleteVendorResponse(int vendorResponseId)
       => throw new NotImplementedException();

   public void DeleteVendorResponses_ByBid(int bidId)
       => throw new NotImplementedException();

   public void UpdateResponseItem(ResponseItem obj)
       => throw new NotImplementedException();

   public void UpdateVendorResponse(VendorResponse obj)
       => throw new NotImplementedException();
}
