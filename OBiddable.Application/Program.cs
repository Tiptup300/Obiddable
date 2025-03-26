using System;
using System.Configuration;
using System.Windows.Forms;
using Ccd.Bidding.Manager.Win.Library;
using Ccd.Bidding.Manager.Win.UI;
using OBiddable.Library.EF;
using OBiddable.Library.EF.Bidding.Electing;

namespace Ccd.Bidding.Manager.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            disableElectionsConversionService();
            initializeUserConfiguration();
            setDbcConnectionString();
            runApplication();
        }

        private static void disableElectionsConversionService()
        {
            ElectionsConversionService.Disabled = true;
        }

        private static void initializeUserConfiguration()
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            UserConfiguration.Instance = new UserConfiguration(myDocumentsPath + "//ccd.bm.win.config.csv");
        }

        private static void setDbcConnectionString()
        {
            string connectionString = null;

#if DEBUG
            connectionString = ConfigurationManager.ConnectionStrings["Debug"].ConnectionString;
#else
            connectionString = ConfigurationManager.ConnectionStrings["Release"].ConnectionString;
#endif

            Dbc.ConnectionString = connectionString;
        }

        private static void runApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HostForm());
        }

    }
}