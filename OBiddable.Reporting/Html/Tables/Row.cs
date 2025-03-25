using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class Row
    {
        public Row(string html, int lineHeight)
        {
            Html = html;
            LineHeight = lineHeight;
        }

        public string Html { get; private set; }
        public int LineHeight { get; private set; }
    }
}
