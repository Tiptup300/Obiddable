using Ccd.Bidding.Manager.Win.Library.UI;

namespace Ccd.Bidding.Manager.Win.UI;
public class FilesMessaging : MessagingService
{
   public static FilesMessaging Instance = new FilesMessaging();
   public bool ConfirmRetryFileLocked(string fileName)
   {
      string message = $"The selected file \"{new FileInfo(fileName).Name}\" is currently open in another application or you do not have access to this file.";
      string caption = "File Locked";
      return ShowRetryCancelError(message, caption) == DialogResult.Retry;
   }
   public void ShowFileCantBeLocatedError(string fileName)
   {
      string message = $"The selected file \"{new FileInfo(fileName).Name}\" could not be located.";
      string caption = "Missing File";
      ShowError(message, caption);
   }
}
