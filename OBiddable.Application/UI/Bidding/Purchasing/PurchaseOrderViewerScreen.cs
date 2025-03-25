using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Win.Library.UI;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Purchasing;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing
{
    public partial class PurchaseOrderViewerScreen : HostScreen
    {
        private readonly IPurchasingRepo _purchasingRepo = new EFPurchasingRepo();

        private IHostForm _hostForm;
        private int _purchaseOrderId;

        public PurchaseOrderViewerScreen(IHostForm hostForm, int purchaseOrderId)
        {
            InitializeComponent();
            topPanel.BackColor = ApplicationColors.Purchasing;

            _purchaseOrderId = purchaseOrderId;

            _hostForm = hostForm;
            Text = "View Purchase Order";
            LoadColumnWidths();
        }
        private void LoadColumnWidths()
        {
            foreach(ColumnHeader colHeader in lineItemsListView.Columns)
            {
                colHeader.Width = _hostForm.HeaderWidthManager.GetHeaderWidth(Text, colHeader.Index, colHeader.Width);
            }

            this.lineItemsListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lineItemsListView_ColumnWidthChanged);
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            _hostForm.GoBack();
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            PurchaseOrder po = _purchasingRepo.GetPurchaseOrder(_purchaseOrderId);
            //ExportOperations.ExportPurchaseOrderToCSV(po);
            PurchaseOrdersExports.ExportPurchaseOrderToExcel(po);
        }
        private void LoadFields(PurchaseOrder po)
        {
            vendorNameTextBox.Text = po.Vendor;
            buildingNameTextBox.Text = po.Building;
            dateCreatedTextBox.Text = po.CreationDate.ToString();
        }
        private void LoadList(PurchaseOrder po)
        {
            lineItemsListView.BeginUpdate();

            foreach (var li in po.LineItems)
            {
                var row = new ListViewItem();

                row.Text = li.Id.ToString();
                row.SubItems.Add(li.Description);
                row.SubItems.Add(li.PartNumber);
                row.SubItems.Add(li.Unit);
                row.SubItems.Add(li.Quantity == null ? "-" : li.Quantity.ToString());
                row.SubItems.Add(li.Price.ToString("0.00000"));
                row.SubItems.Add(li.AccountNumber);
                row.SubItems.Add(li.Note);

                if(li.Quantity == null)
                {
                    row.BackColor = Color.LightPink;
                }

                lineItemsListView.Items.Add(row);
            }

            lineItemsListView.EndUpdate();
        }
        private void PurchaseOrderViewerScreen_Load(object sender, EventArgs e)
        {
            var po = _purchasingRepo.GetPurchaseOrder(_purchaseOrderId);

            if (po is null)
            {
                PurchasingMessaging.Instance.ShowPurchaseOrderFailedToLoadError();
                _hostForm.GoBack();
                return;
            }

            LoadFields(po);
            LoadList(po);

        }
        private void lineItemsListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            var col = lv.Columns[e.ColumnIndex];

            _hostForm.HeaderWidthManager.SetHeaderWidth(this.Text, col.Index, col.Width);
        }
    }
}
