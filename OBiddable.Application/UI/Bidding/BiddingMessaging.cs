using Ccd.Bidding.Manager.Win.Library.UI;
using OBiddable.Library.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding
{
    public class BiddingMessaging : MessagingService
    {
        public static BiddingMessaging Instance = new BiddingMessaging();


        #region BID MAINTENANCE
        // bid roll
        public bool ConfirmBidRoll()
        {
            string message = "Are you sure you would like to roll this bid?";
            string caption = "Roll Bid?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowBidRollFailedError()
        {
            string message = "The Bid failed to roll.";
            string caption = "Bid Roll Fail";
            ShowError(message, caption);
        }
        public void ShowBidRollSuccess(int itemsCount, int requestorsCount, int vendorResponsesCount)
        {
            string message =
                $"Roll Successfully Rolled:\r\n\r\n" +
                (itemsCount > 0 ? $"{ itemsCount } Items Rolled\r\n" : "") +
                (requestorsCount > 0 ? $"{ requestorsCount } Requestors Rolled\r\n" : "") +
                (vendorResponsesCount > 0 ? $"{ vendorResponsesCount } Vendor Responses Rolled" : "");
            string caption = "Bid Roll Successful";
            ShowSuccess(message, caption);
        }
        // clear vendor responses
        public bool ConfirmBidClearVendorResponses(int vendorResponsesCount)
        {
            string message =
                $"Would you like to clear this bid's vendors? It's vendors will be completely removed. \n\n" +
                $"Vendors: { vendorResponsesCount }\n\n " +
                $"WARNING: THIS CANNOT BE UNDONE.";
            string caption = "Clear Vendor Responses?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowBidClearVendorResponsesSuccess()
        {
            string message = "The bid's Vendor Responses were successfully cleared.";
            string caption = "Clear Successful";
            ShowSuccess(message, caption);
        }
        // clear requestors
        public bool ConfirmBidClearRequestors(int requestorsCount)
        {
            string message =
                $"Would you like to clear this bid's requestors? It's requestors & requests will be completely removed. \n\n" +
                $"Vendors: { requestorsCount }\n\n " +
                $"WARNING: THIS CANNOT BE UNDONE.";
            string caption = "Clear Requestors?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowBidClearRequestorsSuccess()
        {
            string message = "The bid's requestors were successfully cleared.";
            string caption = "Clear Successful";
            ShowSuccess(message, caption);
        }
        // clear items
        public bool ConfirmBidClearItems(int itemsCount)
        {
            string message =
                $"Would you like to clear this bid's items? It's items will be completely removed. \n\n" +
                $"Vendors: { itemsCount }\n\n " +
                $"WARNING: THIS CANNOT BE UNDONE.";
            string caption = "Clear Items?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowBidClearItemsSuccess()
        {
            string message = "The bid's items were successfully cleared.";
            string caption = "Clear Successful";
            ShowSuccess(message, caption);
        }
        // add
        public void ShowBidAddSuccess()
        {
            string message = "The bid was successfully added.";
            string caption = "Add Successful";
            ShowSuccess(message, caption);
        }
        // edit
        public void ShowBidEditSuccess()
        {
            string message = "The bid was successfully edited.";
            string caption = "Edit Successful";
            ShowSuccess(message, caption);
        }
        // delete
        public bool ConfirmBidDelete(int itemsCount, int requestorsCount, int vendorResponsesCount, int purchaseOrderCount)
        {
            string message = "Would you like to delete this bid, it's items, requestors, requests, vendors, &amp; responses? This cannot be undone.\r\n" +
               $"Items: { itemsCount }\r\n" +
                $"Requestors: { requestorsCount }\r\n" +
                $"Vendor Responses: { vendorResponsesCount }\r\n" +
                $"Purchase Orders: { purchaseOrderCount }";
            string caption = "Delete Bid?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowBidDeleteSuccess()
        {
            string message = "The bid was successfully deleted.";
            string caption = "Delete Successful";
            ShowSuccess(message, caption);
        }
        public void ShowBidDeleteFailed()
        {
            string message = "The bid failed to be deleted.";
            string caption = "Delete Failure";
            ShowError(message, caption);
        }

        // duplicate bid
        public bool DuplicateBidConfirm(Bid bid)
        {
            string message = "Are you sure you would like to duplicate this bid?";
            string caption = "Duplicate Bid?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void DuplicateBidError(Bid bid)
        {
            string message = "The Bid failed to duplicate.";
            string caption = "Duplication Failed";
            ShowError(message, caption);
        }
        public void DuplicateBidSuccess(int itemsCount, int requestorsCount, int vendorResponsesCount)
        {
            string message =
                $"Bid Duplicated Successfully:\r\n\r\n" +
                (itemsCount > 0 ? $"{ itemsCount } Items Duplicated\r\n" : "") +
                (requestorsCount > 0 ? $"{ requestorsCount } Requestors Duplicated\r\n" : "") +
                (vendorResponsesCount > 0 ? $"{ vendorResponsesCount } Vendor Responses Duplicated" : "");
            string caption = "Bid Duplication Successful";
            ShowSuccess(message, caption);
        }
        #endregion


        #region ADD/EDIT BID

        public string GetBidNameCannotBeBlank()
        {
            return FieldCannotBeBlankError("Bid Name");
        }
        public string GetBidNameCannotBeTooLong()
        {
            return FieldCannotHaveALengthGreaterThanValueError("Bid Name", 255);
        }
        public string GetBidNameCannotAlreadyExist()
        {
            string message = "Bid Name already exists within this bid.";
            return message;
        }
        #endregion
    }
}
