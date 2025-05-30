using Ccd.Bidding.Manager.Library.Operations;

namespace Ccd.Bidding.Manager.Win.Library.Operations.UI
{
   public class ExportsFolderShower : IOperation
   {
      private ConfigMenuShower _configMenuShower = new ConfigMenuShower();
      public void Run()
      {
         if (UserConfiguration.Instance.DefaultExportsDirectory.Exists)
         {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
               FileName = UserConfiguration.Instance.DefaultExportsDirectory.FullName,
               UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
         }
         else
         {
            _configMenuShower.Run();
         }
      }
   }
}
