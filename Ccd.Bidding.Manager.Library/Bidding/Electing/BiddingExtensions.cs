using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
    public static class BiddingExtensions
    {
        public static ElectionSet GetElectionSet(this Bid bid, ElectingService electionsService)
            => electionsService.GetElectionSetForBid(bid);

        public static bool CanEditElections(this Bid bid)
        {
            if (bid.GetVendorResponsesCount() > 0 && bid.GetVendorResponsesItemResponsesCount() > 0)
            {
                return true;
            }
            if (bid.GetElectedItemsCount() > 0)
            {
                return true;
            }
            return false;
        }

        public static int GetElectedItemsCount(this Bid bid) 
            => bid.VendorResponses.Sum(x => x.GetCount_Elected);

        public static decimal GetElectedTotalPriceSum(this Bid bid, IRequestingRepo requestingRepo) 
            => bid.VendorResponses.Sum(x => x.ResponseItems.Where(y => y.Elected).Sum(y => y.GetExtendedPrice(requestingRepo)));

        public static int GetUnelectedItemsCount(this Bid bid, IRequestingRepo repo)
        {
            int requestedItemsCount = bid.GetRequestedItemsCount(repo);
            int respondedToItemsCount = bid.GetRespondedToItemsCount();
            int electedItemsCount = bid.GetElectedItemsCount();

            return respondedToItemsCount - electedItemsCount;
        }
    }
}
