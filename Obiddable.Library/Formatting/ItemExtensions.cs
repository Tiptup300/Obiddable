using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;

namespace Obiddable.Library.Formatting;
public static class ItemExtensions
{
   public static string GetFormattedId(this Item item)
       => item.Id.ToString();

   public static string GetFormattedCode(this Item item)
       => item.FormattedCode;

   public static string GetFormattedRequestedQuantity(this Item item, IRequestingRepo repo)
       => item.GetRequestedQuantity(repo).ToString("0.00");
}
