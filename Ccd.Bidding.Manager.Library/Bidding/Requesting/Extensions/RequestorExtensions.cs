using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions
{
   public static class RequestorExtensions
   {
      public static decimal TotalPrice(this Requestor requestor)
          => requestor.Requests.Select(x => x.ExtendedPriceSum()).Sum();

      public static decimal TotalPriceWithOverride(this Requestor requestor)
          => requestor.Requests.Select(x => x.ExtendedPriceWithOverridesSum()).Sum();

      public static int RequestItemsCount(this Requestor requestor)
          => requestor.Requests.Select(x => x.RequestItems.Count).Sum();

      public static decimal QuantitySum(this Requestor requestor)
          => requestor.Requests.Select(x => x.QuantitySum()).Sum();
   }
}
