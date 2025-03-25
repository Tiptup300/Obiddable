using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
    public static class RequestingExtensions
    {
        public static decimal ElectedExtendedPrice(this RequestItem requestItem, ILegacyElectionsRepo electionsRepo)
        {
            decimal output;
            ResponseItem electedResponseItem;

            electedResponseItem = electionsRepo.GetElectedResponseItemForItem(requestItem.Item.Id);
            if (electedResponseItem is null)
            {
                throw new RequestItemNotElectedException();
            }
            output = electedResponseItem.Price * requestItem.Quantity;

            return output;
        }

        public static decimal ElectedExtendedPrice(this Request request, ILegacyElectionsRepo electionsRepo)
        {
            decimal output;
            decimal requestItemPrice;

            output = 0;
            foreach (var requestItem in request.RequestItems)
            {
                try
                {
                    requestItemPrice = requestItem.ElectedExtendedPrice(electionsRepo);
                    output += requestItemPrice;
                }
                catch (RequestItemNotElectedException) { }
            }

            return output;
        }
    }
}
