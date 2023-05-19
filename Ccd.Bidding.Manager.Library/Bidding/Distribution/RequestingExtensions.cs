using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Distribution
{
    public static class RequestingExtensions
    {

        public static bool IsMismatchedQuantity(this ResponseItem responseItem, IRequestingRepo requestingRepo)
        {
            bool output;
            decimal requestedQuantity;
            decimal alternateQuantity;

            if (responseItem.IsAlternate == false)
            {
                return false;
            }
            requestedQuantity = (decimal)responseItem.Item.GetRequestedQuantity(requestingRepo);
            alternateQuantity = responseItem.AlternateQuantity;

            return requestedQuantity != alternateQuantity; ;
        }
    }
}
