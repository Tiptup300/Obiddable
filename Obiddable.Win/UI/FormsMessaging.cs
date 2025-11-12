using Obiddable.Library.Validations;
using Obiddable.Win.Library.UI;

namespace Obiddable.Win.UI;
public class FormsMessaging : MessagingService
{
   public static FormsMessaging Instance = new FormsMessaging();

   public void ShowImportError(string errors)
   {
      string message =
          $"Errors were found with the import:\r\n" +
          $"{errors}";
      string caption = "Errors Found";

      ShowError(message, caption);
   }

   public void ShowExportError(string errors)
   {
      string message =
          $"Errors were found with the export:\r\n" +
          $"{errors}";
      string caption = "Errors Found";

      ShowError(message, caption);
   }

   public void ShowImportNotCompleted()
   {
      string message = $"The import was not completed, no data was affected.";
      string caption = "Import Not Completed";
      ShowNotice(message, caption);
   }

   public void ShowDataValidationExceptionError(DataValidationException e)
   {
      string message =
          $"A data validation check filed during an operation on the database:\r\n" +
          $"Error Message: {e.Message}";
      string caption = "Database Error";

      ShowError(message, caption);
   }

   public void ShowDatabaseOperationError(string error)
   {
      string message =
          $"An error was encountered during an operation on the database:\r\n" +
          $"Error Message: {error}";
      string caption = "Database Error";

      ShowError(message, caption);
   }
}
