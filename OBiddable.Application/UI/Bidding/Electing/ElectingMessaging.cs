using Ccd.Bidding.Manager.Win.Library.UI;
using OBiddable.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Electing
{
    public class ElectingMessaging : MessagingService
    {
        public static ElectingMessaging Instance = new ElectingMessaging();
        #region ELECTION
        // import
        public void ShowElectionImportSuccess(List<ResponseItem> electedResponseItems)
        {
            string message =
                $"The election import completed successfully.\r\n" +
                $"{ electedResponseItems.Count } elections updated.";
            string caption = "Import Successful";
            ShowSuccess(message, caption);
        }
        public bool ConfirmElectionClearAll()
        {
            string message = "Are you sure you would like to clear all elections for this bid?";
            string caption = "Clear Elections?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public bool ConfirmElectionRunLowBid()
        {
            string message = "Are you sure you would like to run low bid, this cannot be undone, all responses with lowest total price will be set as elected?";
            string caption = "Run Low Bid?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowElectionExportSuccess()
        {
            string message = "The election export completed successfully.";
            string caption = "Export Successful";
            ShowSuccess(message, caption);
        }
        public bool ConfirmElectionRunUnelectedLowBid()
        {
            string message = "Are you sure you would like to run low bid, this cannot be undone, all responses with lowest total price will be set as elected?";
            string caption = "Run Low Bid On Unelected?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowElectionRunLowBidSuccess(int itemsElected, int lowBidAlreadyElected, int noResponses)
        {
            string message = $"Low Bid Run Successfully, \n\n" +
                (itemsElected > 0 ? $"{ itemsElected } items affected. \n" : "") +
                (lowBidAlreadyElected > 0 ? $"{ lowBidAlreadyElected } items already low bid elected.\n" : "") +
                (noResponses > 0 ? $"{ noResponses } no responses.\n" : "");
            string caption = "Low Bid Successful";
            ShowSuccess(message, caption);
        }

        public bool ConfirmContinueIfMismatched(ResponseItem electedResponseItem, int requestedQuantity, decimal electedQuantity)
        {
            string message = $"An election is being made on a response item that has a different quantity then what was requested, are you sure you would like to continue?\n" +
                $"Item: {electedResponseItem.Item.FormattedCode}\n -- {electedResponseItem.Item.Description}" +
                $"Requested Quantity: {requestedQuantity}\n" +
                $"Elected Quantity: {electedQuantity}";
            string caption = "Quantity Mismatch";
            return (ShowYesNoConfirmation(message,caption) == DialogResult.Yes);
        }
        #endregion

    }
}
