using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    public partial class MassUpdateItemPricesForm : Form
    {
        public decimal Multiplier; 
        public MassUpdateItemPricesForm()
        {
            InitializeComponent();
        }

        private void runMassUpdateButton_Click(object sender, EventArgs e)
        {
            decimal multiplier;
            if (!decimal.TryParse(itemPriceMultiplierTextBox.Text, out multiplier))
            {
                return;
            }

            Multiplier = Math.Round(multiplier, 4);
            itemPriceMultiplierTextBox.Text = Multiplier.ToString("0.0000");

            if(CatalogingMessaging.Instance.ConfirmItemMassUpdatePrices(itemPriceMultiplierTextBox.Text) == false)
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void itemPriceMultiplierTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MassUpdateItemPricesForm_Load(object sender, EventArgs e)
        {
            Multiplier = 1;
            itemPriceMultiplierTextBox.Text = "1.000";
        }
    }
}
