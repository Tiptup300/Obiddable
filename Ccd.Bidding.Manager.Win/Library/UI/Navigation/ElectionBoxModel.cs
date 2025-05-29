using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.UI.Navigation
{
   public class ElectionBoxModel
   {
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      public ElectionBoxModel(Bid bid, IRequestingRepo repo)
      {
         ElectedItems = bid.GetElectedItemsCount();
         UnelectedItems = bid.GetUnelectedItemsCount(repo);
         ElectedTotalPrice = bid.GetElectedTotalPriceSum(_requestingRepo);
         CanEditElections = bid.CanEditElections();
      }

      public int ElectedItems { get; private set; }
      public int UnelectedItems { get; private set; }
      public decimal ElectedTotalPrice { get; private set; }
      public bool CanEditElections { get; private set; }
   }
}
