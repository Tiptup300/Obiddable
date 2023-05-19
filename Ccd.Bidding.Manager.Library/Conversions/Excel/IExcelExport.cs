using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Conversions.Excel
{
    public interface IExcelExport
    {
        MemoryStream Generate();
    }
}
