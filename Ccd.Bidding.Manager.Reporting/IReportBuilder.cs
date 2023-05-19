using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting
{
    public interface IReportBuilder<TObject>
    {
        IReportFile BuildReport(TObject reportObject);
    }
}
