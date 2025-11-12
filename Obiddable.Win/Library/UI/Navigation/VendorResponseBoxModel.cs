using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Win.Library.UI.Navigation;
class VendorResponseBoxModel
{
   public VendorResponseBoxModel(Bid bid, IRequestingRepo repo)
   {
      VendorResponses = bid.GetVendorResponsesCount();
      ItemResponses = bid.GetVendorResponsesItemResponsesCount();
      NoResponseItems = bid.GetNoResponseItemsCount(repo);
      CanEditVendorResponses = bid.CanEditVendorResponses();
   }

   public int VendorResponses { get; private set; }
   public int ItemResponses { get; private set; }
   public int NoResponseItems { get; private set; }
   public bool CanEditVendorResponses { get; private set; }
}
