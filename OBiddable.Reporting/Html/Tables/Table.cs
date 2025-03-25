using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class Table
    {
        public CoverPage CoverPage { get; private set; }
        public PageBreakHeader PageBreakHeader { get; private set; }
        public TableHeaders Headers { get; private set; }
    }
}
