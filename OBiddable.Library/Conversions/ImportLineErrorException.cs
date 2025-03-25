using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Conversions
{
    public class ImportLineErrorException : Exception
    {
        public ImportLineErrorException(string message) : base(message)
        {
        }
    }
}
