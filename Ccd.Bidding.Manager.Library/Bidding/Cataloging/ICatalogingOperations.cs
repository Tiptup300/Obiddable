namespace Ccd.Bidding.Manager.Library.Bidding.Cataloging
{
   public interface ICatalogingOperations
   {
      void UpdateItems_MassPriceChange_ByBid(int bidId, decimal multiplier);
      void UpdateItems_MassPriceReset_ByBid(int bidId);
   }
}