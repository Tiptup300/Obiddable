using Obiddable.Library.Operations;

namespace Obiddable.Win.Library.Operations.UI;
public class HelpScreenShower : IOperation
{
   private readonly UserConfiguration _userConfiguration;
   private readonly UrlOpener _urlOpener;

   public HelpScreenShower(UserConfiguration userConfiguration, UrlOpener urlOpener)
   {
      _userConfiguration = userConfiguration;
      _urlOpener = urlOpener;
   }

   public void Run()
   {
      _urlOpener.OpenUrl(getHelpUrl());
   }

   private string getHelpUrl()
   {
      return _userConfiguration.HelpUrl;
   }
}
