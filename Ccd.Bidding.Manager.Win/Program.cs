using System.Configuration;
using Ccd.Bidding.Manager.Library.EF;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Win.Library;
using Ccd.Bidding.Manager.Win.UI;

namespace Ccd.Bidding.Manager.Win;

static class Program
{
   /// <summary>
   /// The main entry point for the application.
   /// </summary>
   [STAThread]
   static void Main()
   {
      DisableElectionsConversionService();
      InitializeUserConfiguration();
      SetDbcConnectionString();
      RunApplication();

      static void DisableElectionsConversionService()
      {
         ElectionsConversionService.Disabled = true;
      }
      static void InitializeUserConfiguration()
      {
         var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         UserConfiguration.Instance = new UserConfiguration(
            myDocumentsPath + "//ccd.bm.win.config.csv"
         );
         UserConfiguration.Instance.SetEpplusLicense();
      }
      static void SetDbcConnectionString()
      {
         string connectionString = null;

#if DEBUG
         connectionString = ConfigurationManager.ConnectionStrings["Debug"].ConnectionString;
#else
         connectionString = ConfigurationManager.ConnectionStrings["Release"].ConnectionString;
#endif

         Dbc.ConnectionString = connectionString;
      }
      static void RunApplication()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new HostForm());
      }
   }
}
