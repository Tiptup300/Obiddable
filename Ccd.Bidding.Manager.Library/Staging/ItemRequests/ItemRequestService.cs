using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Staging.ItemRequests;

namespace Ccd.Bidding.Manager.Library.Staging;
public class ItemRequestService
{
   private readonly IRequestingRepo _requestingRepo;
   private readonly ICatalogingRepo _catalogingRepo;

   public ItemRequestService(IRequestingRepo requestingRepo, ICatalogingRepo catalogingRepo)
   {
      _requestingRepo = requestingRepo;
      _catalogingRepo = catalogingRepo;
   }
   public ItemRequest GetItemRequestForItem(int itemId)
   {
      ItemRequest output;

      Item item = _catalogingRepo.GetItem(itemId);
      output = buildItemRequestFromItem(item);

      return output;
   }

   public IEnumerable<ItemRequest> GetItemRequestsForBid(int bidId)
   {
      IEnumerable<ItemRequest> output;
      IEnumerable<Item> bidItems;

      bidItems = _catalogingRepo.GetItems(bidId);
      output = bidItems.Select(item => buildItemRequestFromItem(item));

      return output;
   }

   public IEnumerable<ItemRequest> GetItemRequestsForRequestor(int requestorId)
   {
      IEnumerable<ItemRequest> output;
      IEnumerable<RequestItem> requestorRequestItems;

      requestorRequestItems = _requestingRepo.GetRequestItems_ByRequestor(requestorId);
      output = requestorRequestItems.Select(requestItem => buildItemRequestFromItem(requestItem.Item));

      return output;
   }

   public IEnumerable<ItemRequest> GetItemRequestsForBuilding(int bidId, string buildingName)
   {
      IEnumerable<ItemRequest> output;
      IEnumerable<Requestor> requestors;
      IEnumerable<RequestItem> buildingRequestItems;

      requestors = _requestingRepo.GetRequestors_ByBuildingName(bidId, buildingName);
      buildingRequestItems = requestors.SelectMany(requestor => _requestingRepo.GetRequestItems_ByRequestor(requestor.Id));
      output = buildingRequestItems.Select(requestItem => buildItemRequestFromItem(requestItem.Item));

      return output;
   }

   private ItemRequest buildItemRequestFromItem(Item item)
   {
      ItemRequest output;
      IEnumerable<RequestItem> requestItems;

      requestItems = _requestingRepo.GetRequestItems_ByItem(item.Id);
      output = new ItemRequest(item, requestItems);

      return output;
   }
}
