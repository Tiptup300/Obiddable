using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Win.Library.UI;
using Obiddable.Win.Library.UI.Navigation;

namespace Obiddable.Win.UI.Bidding.Navigation;
public partial class ElectionNavigationBoxControl : BidNavigationBoxControl
{
   private readonly IRequestingRepo _requestItemsRepo = new EFRequestingRepo();
   public ElectionNavigationBoxControl()
   {
      InitializeComponent();
      SetClickEventOnControls(this);
      SetTitle("Elections");
      SetButtonColor(ApplicationColors.Elections);
   }

   protected override void InitLabels()
   {
      var boxModel = new ElectionBoxModel(_bid, _requestItemsRepo);
      electedItemsValue.Text = boxModel.ElectedItems.ToString();
      unelectedItemsValue.Text = boxModel.UnelectedItems.ToString();
      electedTotalPriceValue.Text = boxModel.ElectedTotalPrice.ToString("C");
      EditEnabled = boxModel.CanEditElections;
   }
}
