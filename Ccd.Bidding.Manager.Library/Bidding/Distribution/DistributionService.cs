using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;

namespace Ccd.Bidding.Manager.Library.Bidding.Distribution;
public class DistributionService
{
   private readonly IDistributionRepo _distributionRepo;
   private readonly ILegacyElectionsRepo _legacyElectionsRepo;
   private readonly IRequestingRepo _requestingRepo;
   private readonly IRespondingRepo _respondingRepo;

   public DistributionService(IRequestingRepo requestingRepo, ILegacyElectionsRepo legacyElectionsRepo, IDistributionRepo distributionRepo, IRespondingRepo respondingRepo)
   {
      _distributionRepo = distributionRepo;
      _legacyElectionsRepo = legacyElectionsRepo;
      _requestingRepo = requestingRepo;
      _respondingRepo = respondingRepo;
   }
   public DistributedQuantity GetDistributedQuantity(Requestor requestor, Item item)
   {
      DistributedQuantity output;
      Building building;

      building = GetBuildingByRequestor(requestor);
      output = GetDistributedQuantity(building, item);

      return output;
   }

   public DistributedQuantity GetDistributedQuantity(Building building, Item item)
   {
      DistributedQuantity output;
      decimal quantity;
      ResponseItem electedResponseItem;

      electedResponseItem = _legacyElectionsRepo.GetElectedResponseItemForItem(item.Id);

      int requestedQuantity = _requestingRepo.GetItemsRequestedQuantity(item);
      decimal alternateRespondedQuantity = electedResponseItem.AlternateQuantity;

      if (electedResponseItem.IsAlternate == false)
      {
         quantity = requestedQuantity;
      }
      else if (((decimal)requestedQuantity) == alternateRespondedQuantity)
      {
         int buildingRequestedQuantity = _distributionRepo.GetRequestedQuantity(building, item);

         quantity = buildingRequestedQuantity;
      }
      else
      {
         IEnumerable<Building> allBuildingsWhoRequestedItem = _distributionRepo.GetAllBuildingsWhoRequestedItem(item);

         if (allBuildingsWhoRequestedItem.Count() == 1 && allBuildingsWhoRequestedItem.Single().Name == building.Name)
         {
            quantity = alternateRespondedQuantity;
         }
         else
         {
            // pull from database
            throw new UnmatchedQuantityWithoutDistributionException();
         }
      }
      output = new DistributedQuantity(item.Bid, building, item, quantity);

      return output;
   }

   public Building GetBuildingByRequestor(Requestor requestor)
   {
      Building output;
      IEnumerable<Requestor> requestors;
      IEnumerable<Requestor> buildingRequestors;

      requestors = _requestingRepo.GetRequestors_ByBid(requestor.Bid.Id);
      buildingRequestors = requestors
          .Where(x => x.Building == requestor.Building && requestor.Bid.Id == x.Bid.Id);
      output = new Building(requestor.Bid, requestor.Building, buildingRequestors);

      return output;
   }

   public Building GetBuilding(Bid bid, string buildingName)
   {
      Building output;
      IEnumerable<Requestor> bidRequestors;
      IEnumerable<Requestor> buildingRequestors;

      bidRequestors = _requestingRepo.GetRequestors_ByBid(bid.Id);
      buildingRequestors = bidRequestors
          .Where(x => x.Building == buildingName);
      output = new Building(bid, buildingName, buildingRequestors);

      return output;
   }

   public string[] GetRequestorsBuildingNames_Elected_ByVendorResponse(int vendorResponseId)
   {
      VendorResponse vendorResponse;
      IEnumerable<ResponseItem> electedResponseItems;
      IEnumerable<Item> electedItems;
      IEnumerable<RequestItem> bidRequestItems;
      IEnumerable<RequestItem> electedRequestItems;
      IEnumerable<Requestor> bidRequestors;
      IEnumerable<Requestor> buildingRequestors;

      vendorResponse = _respondingRepo.GetVendorResponse(vendorResponseId);
      electedResponseItems = _legacyElectionsRepo.GetResponseItems_Elected_ByVendorResponse(vendorResponseId);
      electedItems = electedResponseItems.Select(x => x.Item);
      bidRequestItems = _requestingRepo.GetRequestItems_ByBid(vendorResponse.Bid.Id);
      electedRequestItems = bidRequestItems
          .Where(requestItem => electedItems.Any(item => item.Id == requestItem.Item.Id));
      bidRequestors = _requestingRepo.GetRequestors_ByBid(vendorResponse.Bid.Id);

      buildingRequestors = bidRequestors
          .Where(x => x.Requests != null)
          .Where(requestor => electedRequestItems.Any(requestItem => requestItem.Request.Requestor.Id == requestor.Id)).ToList();

      string[] buildingNames = buildingRequestors.Select(x => x.Building).Distinct().ToArray();

      return buildingNames;

   }



   public List<ResponseItem> GetResponseItems_ByBuildingName_ByVendorResponse(string buildingName, int vendorResponseId)
   {
      List<ResponseItem> output;
      VendorResponse vendorResponse;
      IEnumerable<ResponseItem> electedResponseItemsForThisVendor;
      IEnumerable<Item> itemsRespondedByVendorResponseElected;
      IEnumerable<RequestItem> requestItemsForBuilding;
      IEnumerable<RequestItem> bidRequestItems;

      vendorResponse = _respondingRepo
          .GetVendorResponse(vendorResponseId);

      electedResponseItemsForThisVendor = _legacyElectionsRepo
          .GetResponseItems_Elected_ByVendorResponse(vendorResponseId);

      itemsRespondedByVendorResponseElected = electedResponseItemsForThisVendor
          .Select(x => x.Item);

      bidRequestItems = _requestingRepo.GetRequestItems_ByBid(vendorResponse.Bid.Id);

      requestItemsForBuilding = bidRequestItems
          .Where(y => y.Request.Requestor.Building == buildingName)
          .Where(requestItem => itemsRespondedByVendorResponseElected
              .Any(item => item.Id == requestItem.Item.Id));

      output = electedResponseItemsForThisVendor
          .Where(x => requestItemsForBuilding
          .Any(requestItem => requestItem.Item.Id == x.Item.Id)).ToList();

      return output;

   }
}
