using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Responding
{
   public static class BiddingExtensions
   {
      public static bool CanEditVendorResponses(this Bid bid)
      {
         if (bid.GetRequestorsCount() > 0 && bid.GetRequestsCount() > 0)
         {
            return true;
         }
         if (bid.GetVendorResponsesCount() > 0)
         {
            return true;
         }
         return false;
      }
      public static int GetVendorResponsesCount(this Bid bid)
          => bid.VendorResponses.Count();
      public static int GetVendorResponsesItemResponsesCount(this Bid bid)
          => bid.VendorResponses.Sum(x => x.ResponseItems.Count());
      public static int GetNoResponseItemsCount(this Bid bid, IRequestingRepo repo)
          => bid.GetRequestedItemsCount(repo) - bid.GetRespondedToItemsCount();
      public static int GetRespondedToItemsCount(this Bid bid)
      {
         var responseItems = bid.VendorResponses.SelectMany(x => x.ResponseItems);
         return bid.Items.Where(x => responseItems.Any(y => y.Item.Id == x.Id)).Count();
      }
   }
}
