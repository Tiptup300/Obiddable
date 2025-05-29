using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.UI.Navigation;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
   public partial class ItemNavigationBoxControl : BidNavigationBoxControl
   {
      public ItemNavigationBoxControl()
      {
         InitializeComponent();
         SetClickEventOnControls(this);
         SetTitle("Items");
         SetButtonColor(ApplicationColors.Items);
      }

      protected override void InitLabels()
      {
         var boxModel = new ItemBoxModel(_bid);
         itemsCount.Text = boxModel.ItemsCount.ToString();
         categoriesCount.Text = boxModel.CategoriesCount.ToString();
         EditEnabled = boxModel.CanEditItems;
      }
   }
}
