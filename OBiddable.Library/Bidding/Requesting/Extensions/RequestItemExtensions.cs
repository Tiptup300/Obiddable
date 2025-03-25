using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions
{
    public static class RequestItemExtensions
    {
        public static bool IsPriceOverridden(this RequestItem requestItem)
            => requestItem.OverridePrice != 0;

        public static decimal ExtendedPrice(this RequestItem requestItem)
            => Math.Round(requestItem.Item.Price * requestItem.Quantity, 2);

        public static decimal ExtendedPriceWithOverride(this RequestItem requestItem)
        {
            decimal price;
            decimal roundedPrice;

            price = requestItem.Item.Price;
            if (requestItem.IsPriceOverridden())
            {
                price = requestItem.OverridePrice;
            }
            roundedPrice = Math.Round(price * requestItem.Quantity, 2);
            return roundedPrice;
        }
    }
}
