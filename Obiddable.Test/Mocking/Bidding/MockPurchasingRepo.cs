using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Test.Repos;

namespace Obiddable.Test.Mocking.Bidding;
public class MockPurchasingRepo : IPurchasingRepo
{
   private readonly MockData _mockData;

   public MockPurchasingRepo(MockData mockData)
   {
      _mockData = mockData;
   }
   public void AddPurchaseOrder_ToBid(PurchaseOrder obj, int bidId)
   {
      throw new NotImplementedException();
   }

   public void DeleteLineItems_ByBid(int bidId)
   {
      throw new NotImplementedException();
   }

   public void DeletePurchaseOrder(int purchaseOrderId)
   {
      throw new NotImplementedException();
   }

   public void DeletePurchaseOrders_ByBid(int bidId)
   {
      throw new NotImplementedException();
   }

   public PurchaseOrder GetPurchaseOrder(int purchaseOrderId)
   {
      throw new NotImplementedException();
   }

   public List<PurchaseOrder> GetPurchaseOrders_ByBid(int bidId)
   {
      throw new NotImplementedException();
   }
}
