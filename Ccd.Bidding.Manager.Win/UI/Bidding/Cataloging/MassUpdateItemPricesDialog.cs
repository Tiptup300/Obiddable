namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
   public partial class MassUpdateItemPricesDialog : Form
   {
      public decimal Multiplier = 1;

      public MassUpdateItemPricesDialog()
      {
         InitializeComponent();
      }

      private void RunMassUpdateButton_Click(object sender, EventArgs e)
      {
         if (!decimal.TryParse(itemPriceMultiplierTextBox.Text, out var multiplier) || multiplier <= 0)
         {
            return;
         }

         Multiplier = Math.Round(multiplier, 4);
         UpdateTextBox();

         DialogResult = DialogResult.OK;
         Close();
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      private void MassUpdateItemPricesForm_Load(object sender, EventArgs e)
      {
         UpdateTextBox();
      }

      private void UpdateTextBox()
         => itemPriceMultiplierTextBox.Text = Multiplier.ToString("0.0000");
   }
}
