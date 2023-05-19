using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
    public class Header
    {
        public string Title { get; private set; }
        public string Class { get; private set; }


        public Header(string title, string @class)
        {
            Title = title;
            Class = @class;
        }

    }
}
