using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html
{
    public abstract class BidHtmlReportBuilder : HtmlReportBuilder<Bid>
    {

        public override IReportFile BuildReport(Bid bid)
        {
            if (bid == null)
            {
                return null;
            }

            Subtitle = bid.ToString();
            FileNameSubtitle = bid.ToString();

            return base.BuildReport(bid);
        }
    }
}
