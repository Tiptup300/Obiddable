using OBiddable.Library.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.Operations.UI
{
    public class ExportsFolderShower : IOperation
    {
        private ConfigMenuShower _configMenuShower = new ConfigMenuShower();
        public void Run()
        {
            if (UserConfiguration.Instance.DefaultExportsDirectory.Exists)
            {
                System.Diagnostics.Process.Start(UserConfiguration.Instance.DefaultExportsDirectory.FullName);
            }
            else
            {
                _configMenuShower.Run();
            }
        }
    }
}
