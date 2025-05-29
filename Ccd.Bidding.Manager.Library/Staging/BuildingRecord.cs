using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Staging.ItemRequests;

namespace Ccd.Bidding.Manager.Library.Staging
{
   public class BuildingRecord
   {
      public Building Building { get; private set; }
      public ItemElection ItemElection { get; private set; }
      public ItemRequest BuildingRequest { get; private set; }
      public ItemDistribution ItemDistribution { get; private set; }


      public VendorResponse Vendor => ItemElection.Election.ElectedResponseItem.VendorResponse;
      public int ItemCode => ItemElection.Item.Code;
      public int RequestedQuantity => BuildingRequest.Quantity;
      public string ItemUnit => ItemElection.Item.Unit;
      public string ItemDescription => ItemElection.Item.Description;
      public decimal ElectedQuantity => ItemElection.Election.ElectedResponseItem.AlternateQuantity;
      public decimal DistributedQuantity => ItemDistribution.Quantity;
      public string ElectedUnit => ItemElection.Election.ElectedResponseItem.AlternateUnit;
      public decimal ElectedPrice => ItemElection.Election.ElectedResponseItem.Price;
      public decimal DistributedExtendedPrice => ElectedPrice * DistributedQuantity;
   }
}
