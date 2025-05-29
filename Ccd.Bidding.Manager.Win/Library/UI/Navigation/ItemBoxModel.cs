using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;

namespace Ccd.Bidding.Manager.Win.Library.UI.Navigation
{
   public class ItemBoxModel
   {
      public ItemBoxModel(Bid _bid)
      {
         ItemsCount = _bid.GetItemsCount();
         CategoriesCount = _bid.GetItemCategoriesCount();
         CanEditItems = _bid.CanEditItems();
      }

      public int ItemsCount { get; private set; }
      public int CategoriesCount { get; private set; }
      public bool CanEditItems { get; private set; }
   }
}
