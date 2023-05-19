using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class TableHeaders : IHeightElement
    {
        public int LineHeight { get; private set; }
        public IEnumerable<Header> Headers { get; private set; }

        public int Count { get => Headers.Count(); }

        public TableHeaders(int lineHeight, IEnumerable<Header> headers)
        {
            LineHeight = lineHeight;
            Headers = headers;
        }
    }
}
