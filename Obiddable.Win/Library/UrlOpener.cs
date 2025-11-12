namespace Obiddable.Win.Library;

public class UrlOpener
{
   public void OpenUrl(string url)
   {
      var psi = new System.Diagnostics.ProcessStartInfo
      {
         FileName = url,
         UseShellExecute = true
      };
      System.Diagnostics.Process.Start(psi);
   }
}
