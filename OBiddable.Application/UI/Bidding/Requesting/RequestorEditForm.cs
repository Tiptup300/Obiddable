using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using OBiddable.Library.Bidding;
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

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
    public partial class RequestorEditForm : Form
    {
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

        private Bid _bid;
        private int _requestorId;

        public RequestorEditForm(Bid bid)
        {
            InitializeComponent();

            _bid = bid;

            LoadBuildingNames();
        }

        public RequestorEditForm(Requestor requestor) : this(requestor.Bid)
        {
            Text = "Edit Requestor";

            _requestorId = requestor.Id;
            nameTextBox.Text = requestor.Name;
            codeTextBox.Text = requestor.FormattedCode;
            passwordTextBox.Text = requestor.Password;
            buildingNameComboBox.Text = requestor.Building;
            budgtedAmountTextBox.Text = (requestor.AmountBudgeted.HasValue ? requestor.AmountBudgeted.Value.ToString("0.00") : "0.00");
        }

        private void LoadBuildingNames()
        {
            buildingNameComboBox.Items.AddRange(_requestingRepo.GetRequestorsBuildingNames_ByBid(_bid.Id));
        }

        #region GET OBJECT METHOD

        public Requestor GetRequestor()
        {
            if (dataIsValid())
            {
                int buildingNumberVal = 0;

                if(int.TryParse(codeTextBox.Text,out buildingNumberVal))
                {
                    codeTextBox.Text = buildingNumberVal.ToString("000000");
                }

                return new Requestor()
                {
                    Id = _requestorId,
                    Bid = _bid,
                    Name = nameTextBox.Text,
                    Code = int.Parse(codeTextBox.Text),
                    Building = buildingNameComboBox.Text,
                    Password = passwordTextBox.Text,
                    AmountBudgeted = decimal.Parse(budgtedAmountTextBox.Text)
                };
            }
            else
                return null;
        }

        #endregion

        #region DATA VALIDATION METHOD

        private bool dataIsValid()
        {
            errorProvider1.Clear();
            // codeTextBox
            if (codeTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(codeTextBox, RequestorMessaging.Instance.GetRequestorCodeCannotBeBlankError());
                return false;
            }
            if (codeTextBox.Text.Length > 255)
            {
                errorProvider1.SetError(codeTextBox, RequestorMessaging.Instance.GetRequestorCodeCannotTooLongError());
                return false;
            }
            int code = 0;
            if (!int.TryParse(codeTextBox.Text, out code) || code < 1 || code > 999999)
            {
                errorProvider1.SetError(codeTextBox, RequestorMessaging.Instance.GetRequestorCodeValueInvalidError());
                return false;
            }
            Requestor requestor = _requestingRepo.GetRequestors_ByBid(_bid.Id).FirstOrDefault(x => x.Code == code);
            if (requestor != null && requestor.Id != _requestorId)
            {
                errorProvider1.SetError(codeTextBox, RequestorMessaging.Instance.GetRequestorCodeAlreadyExistsWithinBidError());
                return false;
            }

            // nameTextBox
            if (nameTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(nameTextBox, RequestorMessaging.Instance.GetRequestorNameCannotBeBlankError());
                return false;
            }
            if (nameTextBox.Text.Length > 255)
            {
                errorProvider1.SetError(nameTextBox, RequestorMessaging.Instance.GetRequestorNameCannotBeTooLongError());
                return false;
            }

            // buildingNameComboBox
            if (buildingNameComboBox.Text.Length == 0)
            {
                errorProvider1.SetError(buildingNameComboBox, RequestorMessaging.Instance.GetRequestorBuildingNameCannotBeBlankError());
                return false;
            }
            if (buildingNameComboBox.Text.Length > 255)
            {
                errorProvider1.SetError(buildingNameComboBox, RequestorMessaging.Instance.GetRequestorBuildingNameCannotBeTooLongError());
                return false;
            }

            // password
            if (passwordTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(passwordTextBox, RequestorMessaging.Instance.GetRequestorPasswordCannotBeBlankError());
                return false;
            }
            if (passwordTextBox.Text.Length > 255)
            {
                errorProvider1.SetError(passwordTextBox, RequestorMessaging.Instance.GetRequestorPasswordCannotBeTooLongError());
                return false;
            }

            // amount budgetted
            decimal value = 0;
            if(decimal.TryParse(budgtedAmountTextBox.Text,out value) == false || value < 0)
            {
                errorProvider1.SetError(budgtedAmountTextBox, RequestorMessaging.Instance.GetAmountBudgettedInvalid());
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

        private void RequestorEditDialog_KeyDown(object sender, KeyEventArgs e)
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
