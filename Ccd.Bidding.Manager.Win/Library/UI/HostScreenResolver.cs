using Ccd.Bidding.Manager.Win.UI.Bidding.Electing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.UI
{
    public class HostScreenResolver
    {
        public HostScreen Resolve<TScreen>() where TScreen : HostScreen
        {
            HostScreen output;

            output = (HostScreen)Activator.CreateInstance<TScreen>();

            return output;
        }
    }
}
