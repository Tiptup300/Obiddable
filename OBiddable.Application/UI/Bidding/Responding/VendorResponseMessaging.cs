using Ccd.Bidding.Manager.Win.Library.UI;
using OBiddable.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Responding
{
    public class VendorResponseMessaging : MessagingService
    {
        public static VendorResponseMessaging Instance = new VendorResponseMessaging();
        #region VENDOR RESPONSE
        public string GetVendorResponseVendorNameCannotBeBlank()
        {
            string message = FieldCannotBeBlankError("Vendor Name");
            return message;
        }
        public string GetVendorResponseVendorNameCannotBeTooLong()
        {
            string message = FieldCannotHaveALengthGreaterThanValueError("Vendor Name", 255);
            return message;
        }
        public string GetVendorResponseVendorNameCannotAlreadyExist()
        {
            string message = "Vendor Name already exists within this bid.";
            return message;
        }

        public void ShowVendorResponseVendorNameUpdateSuccess()
        {
            string message = "Vendor Name Successfully Updated";
            string caption = "Update Successful";
            ShowSuccess(message, caption);
        }
        // import
        public void ShowResponseItemsImportSuccess(List<ResponseItem> responseItems)
        {
            string message =
                $"The vendor response import completed successfully.\r\n" +
                $"{ responseItems.Count } response items were Added.";
            string caption = "Import Successful";
            ShowSuccess(message, caption);
        }

        public void ShowVendorResponseAddSuccess(VendorResponse vr)
        {
            string message = "The vendor response was successfully added.";
            string caption = "Add Successful";
            ShowSuccess(message, caption);
        }

        public bool ConfirmVendorResponseDelete(VendorResponse vr)
        {
            string message = "Would you like to delete this vendor response? This cannot be undone.";
            string caption = "Delete Vendor Response?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowVendorResponseDelete_NotBlankError()
        {
            string message = "Unable to remove vendor response. Response Items are still on the response. Please clear response before deleting. (Actions > Selected > Clear Response Items)";
            string caption = "Delete Failed";
            ShowError(message, caption);
        }
        public void ShowVendorResponseDeleteSuccess(VendorResponse vr)
        {
            string message = "The vendor response was successfully deleted.";
            string caption = "Delete Successful";
            ShowSuccess(message, caption);
        }

        public bool ConfirmVendorResponseClearResponseItems(VendorResponse vr)
        {
            string message = "Are you sure you would like to clear all response items for this vendor response? This cannot be undone.";
            string caption = "Clear Vendor Response?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowVendorResponseClearResponseItemsSuccess(VendorResponse vr)
        {
            string message = "The vendor response was successfully cleared.";
            string caption = "Clear Successful";
            ShowSuccess(message, caption);
        }

        public void ShowVendorResponseHasUnrequestedItems()
        {
            string message = "This vendor response contains responses for items that are not currently requested, please confirm the integrity of the database before continuing.\r\rAll invalid response items are marked in red.";
            string caption = "Invalid Vendor Response Items";
            ShowNotice(message, caption);
        }

        public void ShowVendorResponseGenerateBlankSuccess()
        {
            string message = "The Blank Vendor Response generated successfully.";
            string caption = "Generation Successful";
            ShowSuccess(message, caption);
        }
        public void ShowVendorResponseExportSuccess()
        {
            string message = "The Vendor Response exported successfully.";
            string caption = "Export Successful";
            ShowSuccess(message, caption);
        }
        #endregion
    }
}
