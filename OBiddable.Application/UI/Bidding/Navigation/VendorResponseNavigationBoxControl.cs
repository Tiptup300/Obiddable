using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.UI.Navigation;
using OBiddable.Library.Bidding.Requesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
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
}
