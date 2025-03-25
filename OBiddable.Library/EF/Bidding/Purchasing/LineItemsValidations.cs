using Ccd.Bidding.Manager.Library.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Purchasing
{
    public static class LineItemsValidations
    {
        public static void Validate_DeleteLineItems_ByBid(this Dbc dbc, int bidId)
        {
            // no dependencies
        }
    }
}
