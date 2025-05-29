using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;

namespace Ccd.Bidding.Manager.Library.Formatting
{
   public static class ItemExtensions
   {
      public static string GetFormattedId(this Item item)
          => item.Id.ToString();

      public static string GetFormattedCode(this Item item)
          => item.FormattedCode;

      public static string GetFormattedRequestedQuantity(this Item item, IRequestingRepo repo)
          => item.GetRequestedQuantity(repo).ToString("0.00");
   }
}
