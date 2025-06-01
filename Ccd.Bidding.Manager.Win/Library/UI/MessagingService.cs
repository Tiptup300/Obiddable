namespace Ccd.Bidding.Manager.Win.Library.UI;
public class MessagingService
{
   protected string FieldCannotBeBlankError(string field)
       => $"{field} cannot be blank.";

   protected string FieldCannotBeNegative(string field)
       => $"{field} cannot be a negative number.";

   protected string FieldMustBeValidDecimalValue(string field)
       => $"{field} must be a valid decimal Value.";

   protected string FieldCannotHaveALengthGreaterThanValueError(string field, int maxLength)
       => $"{field} cannot have a length greater than {maxLength} characters.";

   protected string FieldMustBeBetweenTwoValuesError(string field, int min, int max)
       => $"{field} must be a valid number between {min} & {max}";


   protected void ShowError(string message, string caption)
   {
      MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
   protected void ShowNotice(string message, string caption)
   {
      MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
   }
   protected void ShowSuccess(string message, string caption)
   {
      MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
   }
   protected DialogResult ShowRetryCancelError(string message, string caption)
   {
      return MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
   }
   protected DialogResult ShowYesNoConfirmation(string message, string caption)
   {
      return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
   }
}
