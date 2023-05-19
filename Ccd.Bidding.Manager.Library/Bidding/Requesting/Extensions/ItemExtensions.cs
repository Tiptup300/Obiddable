using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions
{
    public static class ItemExtensions
    {
        public static IEnumerable<Item> RequestedOnly(this IEnumerable<Item> items, IRequestingRepo repo)
            => items.Where(x => x.IsRequested(repo));

        public static bool IsRequested(this Item item, IRequestingRepo repo)
        {
            bool output;
            int requestedQuantity;

            requestedQuantity = item.GetRequestedQuantity(repo);
            output = requestedQuantity > 0;

            return output;
        }

        public static int GetRequestedQuantity(this Item item, IRequestingRepo requestItemsRepo)
            => requestItemsRepo.GetItemsRequestedQuantity(item);
    }
}
