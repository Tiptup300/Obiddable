using System.Configuration;
using Obiddable.Library.EF;
using Obiddable.Library.EF.Bidding.Electing;
using Obiddable.Win.Library;
using Obiddable.Win.UI;

namespace Obiddable.Win;

static class Program
{
   /// <summary>
   /// The main entry point for the application.
   /// </summary>
   [STAThread]
   static void Main()
   {
      var appDataPath = Path.Combine(
         Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
         typeof(Program).Assembly.GetName().Name!
      );
      if (!Directory.Exists(appDataPath))
      {
         Directory.CreateDirectory(appDataPath);
      }
      var configurationFilePath = Path.Combine(appDataPath, "config.csv");
      var databaseFilePath = Path.Combine(appDataPath, "database.sqlite");

      ElectionsConversionService.Disabled = true;

      UserConfiguration.Instance = new UserConfiguration(configurationFilePath);
      UserConfiguration.Instance.SetEpplusLicense();

      Dbc.ConnectionString = $"Data Source={databaseFilePath}";
      using (var context = new Dbc())
      {
         context.Database.EnsureCreated();
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new HostForm());
   }
}
