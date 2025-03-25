using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class PageBreakHeader
    {
        public string Line { get; private set; }

        public PageBreakHeader(string line)
        {
            Line = line;
        }
    }
}
