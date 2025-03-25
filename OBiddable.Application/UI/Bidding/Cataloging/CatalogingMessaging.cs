using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    public class CatalogingMessaging : MessagingService
    {
        public static CatalogingMessaging Instance = new CatalogingMessaging();


        #region ITEM MAINTENANCE
        // mass reset prices
        public bool ConfirmItemMassResetPrices()
        {
            string message = "Are you sure you would like to reset all the items prices to their last ordered price?";
            string caption = "Reset Item Prices?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowItemMassResetPricesSuccess()
        {
            string message = "The prices were successfully reset.";
            string caption = "Price Reset Successful";
            ShowSuccess(message, caption);
        }
        // mass update prices
        public bool ConfirmItemMassUpdatePrices(string itemPriceMultiplier)
        {
            string message = $"Are you sure you would like to use { itemPriceMultiplier } as the multiplier?";
            string caption = "Correct Price Multipler?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowItemMassUpdatePricesSuccess()
        {
            string message = "The prices were successfully updated.";
            string caption = "Price Update Successful";
            ShowSuccess(message, caption);
        }
        // import
        public void ShowItemImportSuccess(int itemsCount)
        {
            string message =
                $"The items import completed successfully.\r\n" +
                $"{ itemsCount } items were Added.";
            string caption = "Import Successful";
            ShowSuccess(message, caption);
        }
        public void ShowItemAddSuccess()
        {
            string message = "The item was successfully added.";
            string caption = "Add Successful";
            ShowSuccess(message, caption);
        }
        public void ShowItemEditSuccess()
        {
            string message = "The item was successfully edited.";
            string caption = "Edit Successful";
            ShowSuccess(message, caption);
        }
        public bool ConfirmItemDelete()
        {
            string message = "Would you like to delete this item? This cannot be undone.";
            string caption = "Delete Item?";
            return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
        }
        public void ShowItemDeleteSuccess()
        {
            string message = "The item was successfully deleted.";
            string caption = "Delete Successful";
            ShowSuccess(message, caption);
        }
        public void ShowItemDelete_ItemRequestedError()
        {
            string message = "Requests have been made on this item, please delete the requested items before you can delete this item.";
            string caption = "Delete Failed";
            ShowError(message, caption);
        }
        public void ShowItemDelete_ItemRespondedError()
        {
            string message = "Responses have been made on this item, please delete the responded items before you can delete this item.";
            string caption = "Delete Failed";
            ShowError(message, caption);
        }
        #endregion


        #region ADD/EDIT ITEM
        // item code
        public string GetItemCodeCannotBeBlank()
        {
            return FieldCannotBeBlankError("Item Code");
        }
        public string GetItemCodeCannotTooLong()
        {
            return FieldCannotHaveALengthGreaterThanValueError("Item Code", 255);
        }
        public string GetItemCodeValueInvalid()
        {
            return FieldMustBeBetweenTwoValuesError("Item Code", 1, 999999);
        }
        public string GetItemCodeAlreadyExistsWithinBid()
        {
            string message = "Item Code already exists within this bid.";
            return message;
        }
        // unit
        public string GetItemUnitCannotBeBlank()
        {
            return FieldCannotBeBlankError("Unit");
        }
        public string GetItemUnitTooLong()
        {
            return FieldCannotHaveALengthGreaterThanValueError("Unit", 255);
        }
        // category
        public string GetItemCategoryTooLong()
        {
            return FieldCannotHaveALengthGreaterThanValueError("Category", 255);
        }
        // estimated price
        public string GetItemEstimatedPriceNotANumber()
        {
            return FieldMustBeValidDecimalValue("Estimated Price");
        }
        #endregion
    }
}
