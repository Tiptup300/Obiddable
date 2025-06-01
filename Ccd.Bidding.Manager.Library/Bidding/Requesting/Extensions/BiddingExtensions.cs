namespace Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
public static class BiddingExtensions
{
   public static bool CanEditRequestors(this Bid bid)
       => true;
   public static int GetRequestorsCount(this Bid bid)
       => bid.Requestors.Count();
   public static int GetRequestsCount(this Bid bid)
       => bid.Requestors.Sum(x => x.Requests.Count());
   public static decimal GetRequestorsEstimatedPrice(this Bid bid)
       => bid.Requestors.Sum(x => x.Requests.Sum(r => r.ExtendedPriceSum()));
   public static decimal GetRequestorsEstimatedPriceWithOverrides(this Bid bid)
       => bid.Requestors.Sum(x => x.Requests.Sum(r => r.ExtendedPriceWithOverridesSum()));

}
