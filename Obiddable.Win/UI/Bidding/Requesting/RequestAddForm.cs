using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting;

namespace Obiddable.Win.UI.Bidding.Requesting;
public partial class RequestAddForm : Form
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

   public int _requestorId;

   public RequestAddForm(int requestorId)
   {
      _requestorId = requestorId;

      InitializeComponent();
      AccountNumberFormatLabel.Text = $"Format: {AccountNumber.FORMAT}";
   }

   public Request? GetRequest()
   {
      if (DataIsInvalid())
         return null;

      return new Request()
      {
         Id = 0,
         Account_Number = AccountNumberComboBox.Text,
         Requestor = _requestingRepo.GetRequestor(_requestorId),
      };
   }

   private bool DataIsInvalid()
   {
      if (AccountNumber.IsInvalid(AccountNumberComboBox.Text))
      {
         errorProvider.SetError(AccountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberInvalid());
         return true;
      }

      if (_requestingRepo.Check_RequestAccountNumberAlreadyExists_InRequestor(AccountNumberComboBox.Text, _requestorId, 0))
      {
         errorProvider.SetError(AccountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberAlreadyExistsInRequestor());
         return true;
      }

      return false;
   }

   private void SaveChangesButton_Click(object sender, EventArgs e)
   {
      if (DataIsInvalid())
         return;

      DialogResult = DialogResult.OK;
      Close();
   }

   private void CancelButton_Click(object sender, EventArgs e)
   {
      DialogResult = DialogResult.Cancel;
      Close();
   }

   private void BidEditDialog_KeyDown(object sender, KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Enter)
      {
         SaveChangesButton_Click(sender, e);
      }
      if (e.KeyCode == Keys.Escape)
      {
         CancelButton_Click(sender, e);
      }
   }

   private void RequestAddForm_Load(object sender, EventArgs e)
   {
      if (_requestingRepo.GetNewRequestAccountNumbers_ByRequestor(_requestorId) is string[] accountNumbers)
      {
         AccountNumberComboBox.Items.AddRange(accountNumbers);
      }
   }
}
