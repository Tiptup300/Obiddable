using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
   public partial class RequestAddForm : Form
   {
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

      public int _requestorId;

      public RequestAddForm(int requestorId)
      {
         InitializeComponent();
         _requestorId = requestorId;

         LoadAccountNumbers();
      }

      private void LoadAccountNumbers()
      {
         Requestor requestor = _requestingRepo.GetRequestor(_requestorId);

         if (requestor is null)
            return;

         string[] accountNumbers = _requestingRepo.GetRequestAccoutNumbers_ByBid(requestor.Bid.Id).Where(x => !requestor.Requests.Any(y => y.Account_Number == x)).ToArray();

         accountNumberComboBox.Items.AddRange(accountNumbers);
      }

      #region GET OBJECT METHOD
      public Request GetRequest()
      {
         if (dataIsValid())
            return new Request()
            {
               Id = 0,
               Account_Number = accountNumberComboBox.Text,
               Requestor = _requestingRepo.GetRequestor(_requestorId),
            };
         else
            return null;
      }
      #endregion

      #region DATA VALIDATION METHOD
      private bool dataIsValid()
      {
         if (AccountNumber.IsInvalid(accountNumberComboBox.Text))
         {
            errorProvider1.SetError(accountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberInvalid());
            return false;
         }

         if (_requestingRepo.Check_RequestAccountNumberAlreadyExists_InRequestor(accountNumberComboBox.Text, _requestorId, 0))
         {
            errorProvider1.SetError(accountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberAlreadyExistsInRequestor());
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
