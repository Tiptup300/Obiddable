using System.Diagnostics;

namespace Ccd.Bidding.Manager.Win.Library
{
   public class UrlOpener
   {
      public void OpenUrl(string url)
      {
         Process.Start(url);
      }
   }
}
