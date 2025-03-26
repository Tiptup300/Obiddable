using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.UI.Navigation;
using OBiddable.Library.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
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
}
