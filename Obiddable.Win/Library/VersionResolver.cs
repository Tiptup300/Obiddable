using Obiddable.Win.Library;

namespace Obiddable.Win;
public class VersionResolver : IVersionResolver
{
   public string GetVersion()
   {
      return typeof(VersionResolver).Assembly.GetName().Version.ToString();
   }
}
