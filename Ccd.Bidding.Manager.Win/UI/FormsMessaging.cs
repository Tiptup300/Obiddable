using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.UI
{
    public class FormsMessaging : MessagingService
    {
        public static FormsMessaging Instance = new FormsMessaging();

        public void ShowImportError(string errors)
        {
            string message =
                $"Errors were found with the import:\r\n" +
                $"{ errors }";
            string caption = "Errors Found";

            ShowError(message, caption);
        }

        public void ShowExportError(string errors)
        {
            string message =
                $"Errors were found with the export:\r\n" +
                $"{ errors }";
            string caption = "Errors Found";

            ShowError(message, caption);
        }

        public void ShowImportNotCompleted()
        {
            string message = $"The import was not completed, no data was affected.";
            string caption = "Import Not Completed";
            ShowNotice(message, caption);
        }
        public void ShowImportTemplateGeneratedSuccess()
        {
            string message = "The import template was generated successfully.";
            string caption = "Import Template Generated Successful";
            ShowSuccess(message, caption);
        }
        public void ShowExportSuccess()
        {
            string message = "The export completed successfully.";
            string caption = "Export Successful";
            ShowSuccess(message, caption);
        }

        public void ShowDataValidationExceptionError(DataValidationException e)
        {
            string message =
                $"A data validation check filed during an operation on the database:\r\n" +
                $"Error Message: { e.Message }";
            string caption = "Database Error";

            ShowError(message, caption);
        }

        public void ShowDatabaseOperationError(string error)
        {
            string message =
                $"An error was encountered during an operation on the database:\r\n" +
                $"Error Message: { error }";
            string caption = "Database Error";

            ShowError(message, caption);
        }
    }
}
