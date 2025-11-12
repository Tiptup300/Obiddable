using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Library.Bidding.Distribution;
public static class RequestingExtensions
{

   public static bool IsMismatchedQuantity(this ResponseItem responseItem, IRequestingRepo requestingRepo)
   {
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
