using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using System;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Responding
{
   public partial class VendorResponseAddForm : Form
   {
      private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

      public int _bidId;

      public VendorResponseAddForm(int bidId)
      {
         InitializeComponent();
         _bidId = bidId;
      }
      #region GET OBJECT METHOD
      public VendorResponse GetVendorResponse()
      {
         if (dataIsValid())
            return new VendorResponse()
            {
               Id = 0,
               VendorName = vendorNameTextBox.Text,
               Bid = _biddingRepo.GetBid(_bidId)
            };
         else
            return null;
      }
      #endregion

      #region DATA VALIDATION METHOD
      private bool dataIsValid()
      {
         if (vendorNameTextBox.Text.Length == 0)
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotBeBlank());
            return false;
         }
         if (vendorNameTextBox.Text.Length > 255)
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotBeTooLong());
            return false;
         }

         if (_respondingRepo.Check_VendorResponseVendorNameAlreadyExists_InBid(vendorNameTextBox.Text, _bidId, 0))
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotAlreadyExist());
            return false;
         }

         return true;
      }
      #endregion

      #region BUTTON EVENTS
      private void savechangesButton_Click(object sender, EventArgs e)
      {
         if (dataIsValid())
         {
            DialogResult = DialogResult.OK;
            Close();
         }
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }
      #endregion

      private void VendorResponseAddForm_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            savechangesButton_Click(sender, e);
         }
         if (e.KeyCode == Keys.Escape)
         {
            toolStripButton1_Click(sender, e);
         }

      }
   }
}
