namespace Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
public static class RequestExtensions
{
   public static decimal ExtendedPriceSum(this Request request)
       => request.RequestItems.Select(x => x.ExtendedPrice()).Sum();

   public static decimal ExtendedPriceWithOverridesSum(this Request request)
       => request.RequestItems.Select(x => x.ExtendedPriceWithOverride()).Sum();

   public static decimal QuantitySum(this Request request)
       => request.RequestItems.Select(x => x.Quantity).Sum();
}
