using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library
{
    public class UrlOpener
    {
        public void OpenUrl(string url)
        {
            Process.Start(url);
        }
    }
}
