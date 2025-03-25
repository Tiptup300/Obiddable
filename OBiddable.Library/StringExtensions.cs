using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library
{
    public static class StringExtensions
    {
        public static string Join(this IEnumerable<string> values, string separator)
        {
            return String.Join(separator, values);
        }

        public static string JoinAsLines(this IEnumerable<string> values)
        {
            return values.Join(Environment.NewLine);
        }
    }
}
