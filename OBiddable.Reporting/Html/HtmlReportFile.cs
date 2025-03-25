using Ccd.Bidding.Manager.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html
{
    public class HtmlReportFile : IReportFile
    {
        public string FileName { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
