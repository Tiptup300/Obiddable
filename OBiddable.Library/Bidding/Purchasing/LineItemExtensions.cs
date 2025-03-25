using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
    public static class LineItemExtensions
    {
        public static decimal GetRoundedExtendedPrice(this LineItem lineItem)
            => Math.Round(lineItem.Quantity.Value * lineItem.Price, 2);
    }
}
