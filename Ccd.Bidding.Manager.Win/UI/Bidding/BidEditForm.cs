using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using System;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding
{
   public partial class BidEditForm : Form
   {
      private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
      private readonly BiddingService _biddingService = new BiddingService(new EFBiddingRepo());

      private int _bidId;

      public BidEditForm()
      {
         InitializeComponent();
      }

      public BidEditForm(Bid bid)
      {
         InitializeComponent();
         Text = "Edit Bid";

         _bidId = bid.Id;
         nameTextBox.Text = bid.Name;
      }

      #region GET OBJECT METHOD
      public Bid GetBid()
      {
         if (dataIsValid())
            return new Bid()
            {
               Id = _bidId,
               Name = nameTextBox.Text
            };
         else
            return null;
      }
      #endregion

      #region DATA VALIDATION METHOD
      private bool dataIsValid()
      {
         if (nameTextBox.Text.Length == 0)
         {
            errorProvider1.SetError(nameTextBox, BiddingMessaging.Instance.GetBidNameCannotBeBlank());
            return false;
         }
         if (nameTextBox.Text.Length > 100)
         {
            errorProvider1.SetError(nameTextBox, BiddingMessaging.Instance.GetBidNameCannotBeTooLong());
            return false;
         }

         if (_biddingService.BidNameExists(nameTextBox.Text, _bidId))
         {
            errorProvider1.SetError(nameTextBox, BiddingMessaging.Instance.GetBidNameCannotAlreadyExist());
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

      private void BidEditDialog_KeyDown(object sender, KeyEventArgs e)
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
