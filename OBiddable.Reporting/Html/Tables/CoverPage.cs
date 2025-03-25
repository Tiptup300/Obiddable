using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class CoverPage : IHeightElement
    {
        public static CoverPage Empty = new EmptyCoverPage();
        public IEnumerable<string> Lines { get; private set; }

        public int LineHeight => Lines.Count();

        public CoverPage(IEnumerable<string> lines)
        {
            Lines = lines;
        }
    }
}
