using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.UI.Navigation;
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
}
