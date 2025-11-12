using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Electing;
using Obiddable.Library.Bidding.Electing.Elections;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Responding;

namespace Obiddable.Library.EF.Bidding.Electing;
public class ElectionsConversionService
{
   public static bool Disabled = false;

   private readonly ElectingService _electingService;

   private readonly IElectingRepo _electionsRepo = new ElectingRepo();
   private readonly ILegacyElectionsRepo _legacyElectionsRepo = new EFLegacyElectionsRepo();
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

   public ElectionsConversionService()
   {
      _electingService = new ElectingService(_electionsRepo, _catalogingRepo, new ElectionsSetFactory(new UnmarkedElectionsFactory()));
   }

   public void ElectResponseItem(int itemId, int responseItemId, string reasonElected)
   {
      if (Disabled) { return; }
      Item item;
      ElectionSet electionSet;
      ResponseItem responseItem;

      item = _catalogingRepo.GetItem(itemId);
      responseItem = _respondingRepo.GetResponseItem(responseItemId);
      electionSet = _electingService.GetElectionSetForBid(item.Bid);
      electionSet.ElectResponseItemForItem(responseItem, reasonElected);
      electionSet.SaveChangesToRepo(_electingService);
   }

   public void UnelectResponseItem(int responseItemId)
   {
      if (Disabled) { return; }
      ElectionSet electionSet;
      ResponseItem responseItem;

      responseItem = _respondingRepo.GetResponseItem(responseItemId);
      electionSet = _electingService.GetElectionSetForBid(responseItem.VendorResponse.Bid);
      electionSet.UnelectItem(responseItem.Item);
      electionSet.SaveChangesToRepo(_electingService);
   }
}
