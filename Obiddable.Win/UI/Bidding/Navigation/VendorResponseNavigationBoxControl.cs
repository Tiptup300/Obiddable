using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Win.Library.UI;
using Obiddable.Win.Library.UI.Navigation;

namespace Obiddable.Win.UI.Bidding.Navigation;
public partial class VendorResponseNavigationBoxControl : BidNavigationBoxControl
{
   private readonly IRequestingRepo _requestItemsRepo = new EFRequestingRepo();
   public VendorResponseNavigationBoxControl()
   {
      InitializeComponent();
      SetClickEventOnControls(this);
      SetTitle("Vendor Responses");
      SetButtonColor(ApplicationColors.VendorResponses);
   }

   protected override void InitLabels()
   {
      var boxModel = new VendorResponseBoxModel(_bid, _requestItemsRepo);
      vendorResponsesValue.Text = boxModel.VendorResponses.ToString();
      itemResponsesValue.Text = boxModel.ItemResponses.ToString();
      noResponseItemsValue.Text = boxModel.NoResponseItems.ToString();
      EditEnabled = boxModel.CanEditVendorResponses;
   }
}
