using Obiddable.Win.Library.UI;
using Obiddable.Win.Library.UI.Navigation;

namespace Obiddable.Win.UI.Bidding.Navigation;
public partial class PurchaseOrderNavigationBoxControl : BidNavigationBoxControl
{
   public PurchaseOrderNavigationBoxControl()
   {
      InitializeComponent();
      SetClickEventOnControls(this);
      SetTitle("Purchasing");
      SetButtonColor(ApplicationColors.Purchasing);
   }

   protected override void InitLabels()
   {
      var boxModel = new PurchaseOrderBoxModel(_bid);
      purchaseOrdersValue.Text = boxModel.PurchaseOrders.ToString();
      purchasedItemsValue.Text = boxModel.PurchasedItems.ToString();
      totalPriceValue.Text = boxModel.TotalPrice.ToString("C");
      EditEnabled = boxModel.CanEditPurchaseOrders;
   }
}
