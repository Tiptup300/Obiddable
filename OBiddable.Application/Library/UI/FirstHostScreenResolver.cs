using Ccd.Bidding.Manager.Win.Library.Bidding;
using Ccd.Bidding.Manager.Win.UI.Bidding;
using Ccd.Bidding.Manager.Win.UI.Bidding.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.Library.UI
{
    public class FirstHostScreenResolver
    {
        public HostScreen Resolve(IHostForm hostForm)
        {
            HostScreen output;

            output = new BidMaintenanceScreen(hostForm);
            if (isWorkingBidSet())
            {
                output = getWorkingBidNavigationScreen(hostForm);
            }

            return output;
        }

        private HostScreen getWorkingBidNavigationScreen(IHostForm hostForm)
        {
            HostScreen output;
            int workingBidId;

            workingBidId = UserConfiguration.Instance.WorkingBidId.Value;
            output = new BidNavigationScreen(hostForm, workingBidId);

            return output;
        }

        private bool isWorkingBidSet()
        {
            return UserConfiguration.Instance.WorkingBidId.HasValue;
        }
    }
}
