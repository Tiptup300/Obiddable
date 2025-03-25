using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
    public class RequestorMessaging : MessagingService
    {
        public static RequestorMessaging Instance = new RequestorMessaging();

        #region REQUESTOR MAINTENANCE
        // clear requestors request
        public bool ConfirmRequestorClearRequests()
        {
            string message = "Are you sure you would like to clear this requestors' requests? All requests for this user will be deleted.\r\n" +
                "THIS CANNOT BE UNDONE.";
            string caption = "Clear Requests";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        // import
        public void ShowRequestorImportSuccess(List<Requestor> requestors)
        {
            string message =
                $"The requestors import completed successfully.\r\n" +
                $"{ requestors.Count } requestors were Added.";
            string caption = "Import Successful";
            ShowSuccess(message, caption);
        }
        // export all requestors 
        public void ShowRequestorExportAllExcelsSuccess()
        {
            string message = "All requestors were successfully exported.";
            string caption = "Export Successful";
            ShowSuccess(message, caption);
        }
        // add
        public void ShowRequestorAddSuccess()
        {
            string message = "The requestor was successfully added.";
            string caption = "Add Successful";
            ShowSuccess(message, caption);
        }
        // edit
        public void ShowRequestorEditSuccess()
        {
            string message = "The requestor was successfully edited.";
            string caption = "Edit Successful";
            ShowSuccess(message, caption);
        }
        // delete
        public bool ConfirmRequestorDelete(Requestor requestor)
        {
            string message =
                "Would you like to delete this requestor?\r\n" +
                "THIS CANNOT BE UNDONE.";
            string caption = "Delete requestor?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowRequestorDelete_RequestorNotBlankError()
        {

            string message = "Requestor cannot be deleted if they have requests. Please delete all requests for this requestor before deleting.";
            string caption = "Delete Failed";
            ShowError(message, caption);
        }
        public void ShowRequestorDeleteSuccess()
        {
            string message = "The requestor was successfully deleted.";
            string caption = "Delete Successful";
            ShowSuccess(message, caption);
        }
        #endregion


        #region ADD/EDIT REQUESTOR
        // requestor code
        public string GetRequestorCodeCannotBeBlankError()
        {
            return FieldCannotBeBlankError("Requestor Code");
        }
        public string GetRequestorCodeCannotTooLongError()
        {
            return FieldCannotHaveALengthGreaterThanValueError("Requestor Code", 255);
        }
        public string GetRequestorCodeValueInvalidError()
        {
            return FieldMustBeBetweenTwoValuesError("Requestor Code", 1, 999999);
        }
        public string GetRequestorCodeAlreadyExistsWithinBidError()
        {
            string message = "Requestor Code already exists within this bid.";
            return message;
        }
        // name
        public string GetRequestorNameCannotBeBlankError()
        {
            string message = FieldCannotBeBlankError("Name");
            return message;
        }
        public string GetRequestorNameCannotBeTooLongError()
        {
            string message = FieldCannotHaveALengthGreaterThanValueError("Name", 255);
            return message;
        }
        // building name
        public string GetRequestorBuildingNameCannotBeBlankError()
        {
            string message = FieldCannotBeBlankError("Building Name");
            return message;
        }
        public string GetRequestorBuildingNameCannotBeTooLongError()
        {
            string message = FieldCannotHaveALengthGreaterThanValueError("Building Name", 255);
            return message;
        }
        // password
        public string GetRequestorPasswordCannotBeBlankError()
        {
            string message = FieldCannotBeBlankError("Password");
            return message;
        }
        public string GetRequestorPasswordCannotBeTooLongError()
        {
            string message = FieldCannotHaveALengthGreaterThanValueError("Password", 255);
            return message;
        }
        // amount budgeted
        public string GetAmountBudgettedInvalid()
        {
            string message = "Amount Budgeted is invalid";
            return message;
        }
        #endregion
    }
}
