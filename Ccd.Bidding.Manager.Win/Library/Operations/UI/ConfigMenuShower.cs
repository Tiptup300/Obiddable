using Ccd.Bidding.Manager.Library.Operations;
using Ccd.Bidding.Manager.Win.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.Operations.UI
{
    public class ConfigMenuShower : IOperation
    {
        public void Run()
        {
            ConfigForm f = new ConfigForm();
            f.ShowDialog();
        }
    }
}
