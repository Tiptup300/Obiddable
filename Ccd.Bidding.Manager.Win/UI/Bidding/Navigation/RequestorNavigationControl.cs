using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.UI.Navigation;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
   public partial class RequestorNavigationControl : BidNavigationBoxControl
   {

      public RequestorNavigationControl()
      {
         InitializeComponent();
         SetClickEventOnControls(this);
         SetTitle("Requesting");
         SetButtonColor(ApplicationColors.Requesting);
      }

      protected override void InitLabels()
      {
         var boxModel = new RequestorBoxModel(_bid);
         requestsValue.Text = boxModel.Requests.ToString();
         requestorsValue.Text = boxModel.Requestors.ToString();
         estimatedPriceValue.Text = boxModel.EstimatedPrice.ToString("C");
         estimatedPriceWithOverridesValue.Text = boxModel.EstimatedPriceWithOverrides.ToString("C");
         EditEnabled = boxModel.CanEditRequestors;
      }
   }
}
