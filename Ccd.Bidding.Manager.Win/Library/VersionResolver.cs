using Ccd.Bidding.Manager.Win.Library;

namespace Ccd.Bidding.Manager.Win
{
   public class VersionResolver : IVersionResolver
   {
      public string GetVersion()
      {
         return typeof(VersionResolver).Assembly.GetName().Version.ToString();
      }
   }
}
