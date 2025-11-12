using Obiddable.Library.Bidding.Requesting;
using Obiddable.Win.Library.UI;

namespace Obiddable.Win.UI.Bidding.Requesting;
public class RequestorMessaging : MessagingService
{
   public static RequestorMessaging Instance = new RequestorMessaging();

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
          $"{requestors.Count} requestors were Added.";
      string caption = "Import Successful";
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

   public void ShowExportBlankRequestToExcelForAllRequestors_FailedError(Exception ex)
   {
      string message = $"Failed to export request files for requestors. See error message: {ex.Message}";
      string caption = "Export Failed";
      ShowError(message, caption);
   }

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
   public string GetAmountBudgetedInvalid()
   {
      string message = "Amount Budgeted is invalid";
      return message;
   }
}
