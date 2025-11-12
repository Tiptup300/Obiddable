using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Library.Staging.ItemResponses;
class ItemResponseService
{
   private readonly ICatalogingRepo _catalogingRepo;
   private readonly IRespondingRepo _respondingRepo;

   public ItemResponseService(IRespondingRepo respondingRepo, ICatalogingRepo catalogingRepo)
   {
      _respondingRepo = respondingRepo;
      _catalogingRepo = catalogingRepo;
   }

   public ItemResponse GetItemResponseForItem(int itemId)
   {
      ItemResponse output;

      Item item = _catalogingRepo.GetItem(itemId);
      output = buildItemResponseFromItem(item);

      return output;
   }



   private ItemResponse buildItemResponseFromItem(Item item)
   {
      ItemResponse output;
      IEnumerable<ResponseItem> responseItems;

      responseItems = _respondingRepo.GetResponseItems_ByItem(item.Id);
      output = new ItemResponse(item, responseItems);

      return output;
   }
}
