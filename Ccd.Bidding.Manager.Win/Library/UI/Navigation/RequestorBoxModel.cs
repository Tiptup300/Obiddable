using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;

namespace Ccd.Bidding.Manager.Win.Library.UI.Navigation
{
   public class RequestorBoxModel
   {
      public RequestorBoxModel(Bid bid)
      {
         Requests = bid.GetRequestsCount();
         Requestors = bid.GetRequestorsCount();
         EstimatedPrice = bid.GetRequestorsEstimatedPrice();
         EstimatedPriceWithOverrides = bid.GetRequestorsEstimatedPriceWithOverrides();
         CanEditRequestors = bid.CanEditRequestors();
      }

      public int Requests { get; private set; }
      public int Requestors { get; private set; }
      public decimal EstimatedPrice { get; private set; }
      public decimal EstimatedPriceWithOverrides { get; private set; }
      public bool CanEditRequestors { get; private set; }
   }
}
