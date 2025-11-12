using Obiddable.Win.Library.UI;

namespace Obiddable.Win.UI.Bidding.Cataloging;
public class CatalogingMessaging : MessagingService
{
   public static CatalogingMessaging Instance = new CatalogingMessaging();


   #region ITEM MAINTENANCE
   // mass reset prices
   public bool ConfirmItemMassResetToLastOrdered()
   {
      string message = "Are you sure you would like to reset all the items prices to their last ordered price?";
      string caption = "Reset Item Prices?";
      return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
   }
   // import
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
