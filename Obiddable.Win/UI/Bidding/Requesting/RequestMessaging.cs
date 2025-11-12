using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Win.Library.UI;

namespace Obiddable.Win.UI.Bidding.Requesting;
public class RequestMessaging : MessagingService
{
   public static RequestMessaging Instance = new RequestMessaging();


   #region REQUEST MAINTEANCE
   public void ShowRequestExportSuccess()
   {
      string message = "The request export completed successfully.";
      string caption = "Export Successful";
      ShowSuccess(message, caption);
   }
   public void ShowRequestImportSuccess(Request r)
   {
      string message =
          $"The request import completed successfully.\r\n" +
          $"{r.RequestItems.Count} request items were Added.";
      string caption = "Import Successful";
      ShowSuccess(message, caption);
   }
   public bool ConfirmRequestClearRequestItems(Request r)
   {
      string message = $"" +
          $"Are you sure you would like to clear this request of all it's request items?\r\n" +
          $"\r\n" +
          $"Request Items: {r.RequestItems.Count}\r\n" +
          $"Extended Price: {r.ExtendedPriceSum().ToString("0.00")}\r\n" +
          $"Extended Price (with Overrides): {r.ExtendedPriceWithOverridesSum().ToString("0.00")}\r\n" +
          $"Quantity Sum: {r.QuantitySum()}";
      string caption = "Clear Request?";
      return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
   }
   public void ShowRequestClearRequestItemsSuccess(Request r)
   {
      string message = $"Request {r.Account_Number} successfully cleared of request items.";
      string caption = "Clear Successful";
      ShowSuccess(message, caption);
   }
   public void ShowRequestAddSuccess()
   {
      string message = "The request was successfully added.";
      string caption = "Add Successful";
      ShowSuccess(message, caption);
   }
   public void ShowRequestEditSuccess()
   {
      string message = "The request was successfully edited.";
      string caption = "Edit Successful";
      ShowSuccess(message, caption);
   }
   public bool ConfirmRequestDelete(Request r)
   {
      string message = $"Are you sure you would like to delete this request? This cannot be undone.\r\n" +
          $"\r\n" +
          $"Request Items: {r.RequestItems.Count}\r\n" +
          $"Extended Price: {r.ExtendedPriceSum().ToString("0.00")}\r\n" +
          $"Extended Price (with Overrides): {r.ExtendedPriceWithOverridesSum().ToString("0.00")}\r\n" +
          $"Quantity Sum: {r.QuantitySum()}";
      string caption = "Delete Request?";
      return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
   }
   public void ShowRequestDeleteSuccess()
   {
      string message = "The request was successfully deleted.";
      string caption = "Delete Successful";
      ShowSuccess(message, caption);
   }
   public void ShowRequestDelete_NotBlankError()
   {

      string message = "Unable to remove request. RequestItems are still on the request. Please clear request before deleting.";
      string caption = "Delete Failed";
      ShowError(message, caption);
   }
   #endregion


   #region ADD/EDIT REQUEST
   // account number
   public void ShowRequestUpdateAccountNumberSuccess()
   {
      string message = "Account Number successfully updated.";
      string caption = "Update Successful";
      ShowSuccess(message, caption);
   }
   public string GetRequestAccountNumberAlreadyExistsInRequestor()
   {
      string message = "Account Number already exists for this requestor.";
      return message;
   }
   public string GetRequestAccountNumberInvalid()
   {
      string message = "Account Number is in an invalid format.";
      return message;
   }
   // amount requested
   public string GetRequestItemAmountRequestedCannotBeBlank()
   {
      string message = FieldCannotBeBlankError("Amount Requested");
      return message;
   }
   public string GetRequestItemAmountRequestedNotANumber()
   {
      string message = FieldMustBeValidDecimalValue("Amount Requested");
      return message;
   }
   public string GetRequestItemAmountRequestedCannotBeNegative()
   {
      string message = FieldCannotBeNegative("Amount Requested");
      return message;
   }
   // override price
   public string GetRequestItemOverridePriceCannotBeBlank()
   {
      string message = FieldCannotBeBlankError("Override Price");
      return message;
   }
   public string GetRequestItemOverridePricedNotANumber()
   {
      string message = FieldMustBeValidDecimalValue("Override Price");
      return message;
   }
   public string GetRequestItemOverridePriceCannotBeNegative()
   {
      string message = FieldCannotBeNegative("Override Price");
      return message;
   }

   public void ShowRequestExportNoRequestItemsError()
   {
      string message = "Cannot export request as no request items are on the request.";
      string caption = "Cannot Export Request";
      ShowError(message, caption);
   }
   #endregion
}
