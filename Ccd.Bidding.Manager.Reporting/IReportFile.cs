using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting
{
    public interface IReportFile
    {
        string Data { get; set; }
        DateTime TimeStamp { get; set; }
        string FileName { get; set; }
    }
}
