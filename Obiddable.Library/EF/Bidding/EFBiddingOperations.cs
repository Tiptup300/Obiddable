using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Purchasing;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF.Bidding;
public class EFBiddingOperations : IBiddingOperations
{
   private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   private readonly IPurchasingRepo _purchasingRepo = new EFPurchasingRepo();

   private readonly CatalogingService _catalogingService = new CatalogingService(new EFCatalogingRepo());

   public Bid RollBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         Bid oldBid = dbc.Bids.Where(x => x.Id == bidId).Single();
         if (oldBid is null)
         {
            return null;
         }
         oldBid.SetPurchaseOrders(dbc.PurchaseOrders.Include(x => x.Bid).Where(x => x.Bid.Id == oldBid.Id).ToList());

         // Create new rolled bid with name & timestamp
         Bid newBid = new Bid();
         newBid.Name = $"{oldBid.Name} Rolled Bid {DateTime.Now.ToString("yyyy-MM-dd-HH-mm")}";
         if (newBid.Name.Length > 255)
         {
            newBid.Name = newBid.Name.Substring(0, 255);
         }
         dbc.Bids.Add(newBid);

         // copy over items from old bid
         oldBid.Items = dbc.Items.Include(x => x.Bid).Where(x => x.Bid.Id == oldBid.Id).ToList();
         newBid.Items = getRolledItems(dbc, oldBid);

         //// copy over requestors & requests from old bid
         oldBid.Requestors = dbc.Requestors.Include(x => x.Bid).Include(x => x).ThenInclude(x => x.Requests).Where(x => x.Bid.Id == oldBid.Id).ToList();
         rollRequestors_ToBid_FromBid(dbc, newBid, oldBid);

         // copy over vendorresponses
         oldBid.VendorResponses = dbc.VendorResponses.Include(x => x.Bid).Where(x => x.Bid.Id == oldBid.Id).ToList();
         rollVendorResponses_ToBid_FromBid(dbc, newBid, oldBid);

         dbc.SaveChanges();

         return newBid;
      }
   }

   private List<Item> getRolledItems(Dbc dbc, Bid oldBid)
   {
      return oldBid.Items
          .ToList()
          .Select(o => getRolledItem(o, dbc))
          .ToList();
   }


   private Item getRolledItem(Item oldItem, Dbc dbc)
   {
      Item output;
      ResponseItem electedResponseItem;

      electedResponseItem = getElectedResponseItemForItem(dbc, oldItem);
      output = new Item(
          null, null, oldItem.Code,
          oldItem.Category,
          oldItem.Description,
          oldItem.Substitutable,
          oldItem.Unit,
          isNonAlternateElectedResponseItem(electedResponseItem) ? electedResponseItem.Price : oldItem.Last_Order_Price,
          isNonAlternateElectedResponseItem(electedResponseItem) ? electedResponseItem.Price : oldItem.Price);

      return output;
   }
   private static ResponseItem getElectedResponseItemForItem(Dbc dbc, Item item)
   {
      return dbc.ResponseItems
          .Include(x => x.Item)
          .Include(x => x.VendorResponse)
          .ThenInclude(x => x.Bid)
          .Where(respItem => respItem.Item.Id == item.Id)
          .FirstOrDefault(x => x.Elected);
   }

   private static bool isNonAlternateElectedResponseItem(ResponseItem responseItem)
   {
      if (responseItem is null || responseItem.IsAlternate)
      {
         return false;
      }
      return true;
   }

   public Bid DuplicateBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         // load oldbid
         Bid oBid = getFullBid(dbc, bidId);
         if (oBid is null)
         {
            return null;
         }

         // create new bid
         Bid nBid = new Bid();
         nBid.Name = $"{oBid.Name} Copy {DateTime.Now.ToString("yyyy-MM-dd-HH-mm")}";
         if (nBid.Name.Length > 255)
         {
            nBid.Name = nBid.Name.Substring(0, 255);
         }
         dbc.Bids.Add(nBid);

         nBid.Items = copyItems(oBid);
         dbc.SaveChanges();

         nBid.Requestors = new List<Requestor>();
         foreach (Requestor oRequestor in oBid.Requestors)
         {
            Requestor nRequestor = new Requestor();
            nRequestor.Name = oRequestor.Name;
            nRequestor.Code = oRequestor.Code;
            nRequestor.Building = oRequestor.Building;
            nRequestor.Password = oRequestor.Password;
            nRequestor.AmountBudgeted = oRequestor.AmountBudgeted;
            nBid.Requestors.Add(nRequestor);
            dbc.SaveChanges();


            nRequestor.Requests = new List<Request>();
            foreach (Request oRequest in oRequestor.Requests)
            {
               Request nRequest = new Request();
               nRequest.Account_Number = oRequest.Account_Number;
               nRequestor.Requests.Add(nRequest);
               dbc.SaveChanges();

               nRequest.RequestItems = new List<RequestItem>();
               foreach (RequestItem oRequestItem in oRequest.RequestItems)
               {
                  RequestItem nRequestItem = new RequestItem();
                  nRequestItem.Item = nBid.Items.Single(x => x.Code == oRequestItem.Item.Code);
                  nRequestItem.Quantity = oRequestItem.Quantity;
                  nRequestItem.OverridePrice = oRequestItem.OverridePrice;
                  nRequest.RequestItems.Add(nRequestItem);
               }
               nRequestor.Requests.Add(nRequest);
            }
            dbc.SaveChanges();
         }

         nBid.VendorResponses = new List<VendorResponse>();
         foreach (VendorResponse oVendorResponse in oBid.VendorResponses)
         {
            VendorResponse nVendorResponse = new VendorResponse();
            nVendorResponse.VendorName = oVendorResponse.VendorName;
            nBid.VendorResponses.Add(nVendorResponse);
            dbc.SaveChanges();

            nVendorResponse.ResponseItems = new List<ResponseItem>();
            foreach (ResponseItem oResponseItem in oVendorResponse.ResponseItems)
            {
               ResponseItem nResponseItem = new ResponseItem(
                   null,
                   item: nBid.Items.Single(x => x.Code == oResponseItem.Item.Code),
                   code: oResponseItem.Code,
                   price: oResponseItem.Price,
                   alternateQuantity: oResponseItem.AlternateQuantity,
                   alternateUnit: oResponseItem.AlternateUnit,
                   isAlternate: oResponseItem.IsAlternate,
                   alternateDescription: oResponseItem.AlternateDescription,
                   isElected: oResponseItem.Elected,
                   electionReason: oResponseItem.ElectionReason
               );

               nVendorResponse.ResponseItems.Add(nResponseItem);
            }
            dbc.SaveChanges();
         }
         nBid.SetPurchaseOrders(oBid.PurchaseOrders.Select(x => x.CreateDuplicate()));

         dbc.SaveChanges();

         return nBid;
      }
   }

   private List<Item> copyItems(Bid oBid)
   {
      return oBid.Items
           .ToList()
           .Select(o => new Item(null, null, o.Code, o.Category, o.Description, o.Substitutable, o.Unit, o.Last_Order_Price, o.Price))
           .ToList();
   }

   private static Bid getFullBid(Dbc dbc, int bidId)
   {
      Bid oBid = dbc.Bids.Where(x => x.Id == bidId).Single();
      oBid.Items = dbc.Items.Include(x => x.Bid).Where(x => x.Bid.Id == oBid.Id).ToList();
      oBid.Requestors = dbc.Requestors.Include(x => x.Bid).Include(x => x).ThenInclude(x => x.Requests).ThenInclude(x => x.RequestItems).ThenInclude(x => x.Item).Where(x => x.Bid.Id == oBid.Id).ToList();
      oBid.VendorResponses = dbc.VendorResponses.Include(x => x.Bid).ThenInclude(x => x.VendorResponses).ThenInclude(x => x.ResponseItems).ThenInclude(x => x.Item).Where(x => x.Bid.Id == oBid.Id).ToList();
      oBid.SetPurchaseOrders(dbc.PurchaseOrders.Include(x => x.Bid).ThenInclude(x => x.PurchaseOrders).ThenInclude(x => x.LineItems).Where(x => x.Bid.Id == oBid.Id).ToList());

      return oBid;
   }


   private void rollRequestors_ToBid_FromBid(Dbc dbc, Bid newBid, Bid oldBid)
   {
      newBid.Requestors = new List<Requestor>();

      foreach (Requestor oldRequestor in oldBid.Requestors)
      {
         Requestor newRequestor = new Requestor();
         newRequestor.Name = oldRequestor.Name;
         newRequestor.Code = oldRequestor.Code;
         newRequestor.Building = oldRequestor.Building;
         newRequestor.Password = oldRequestor.Password;
         newRequestor.AmountBudgeted = oldRequestor.AmountBudgeted;
         newBid.Requestors.Add(newRequestor);
         dbc.SaveChanges();

         rollRequests_ToRequestor_FromRequestor(dbc, newRequestor, oldRequestor);
      }
   }
   private void rollRequests_ToRequestor_FromRequestor(Dbc dbc, Requestor newRequestor, Requestor oldRequestor)
   {
      newRequestor.Requests = new List<Request>();

      foreach (Request o in oldRequestor.Requests)
      {
         Request n = new Request();
         n.Account_Number = o.Account_Number;

         newRequestor.Requests.Add(n);
      }
   }
   private void rollVendorResponses_ToBid_FromBid(Dbc dbc, Bid newBid, Bid oldBid)
   {
      newBid.VendorResponses = new List<VendorResponse>();

      foreach (VendorResponse o in oldBid.VendorResponses)
      {
         VendorResponse n = new VendorResponse();
         n.VendorName = o.VendorName;

         newBid.VendorResponses.Add(n);
      }
   }


   public bool ClearAndDeleteBid(Bid bid)
   {
      if (bid is null)
      {
         return false;
      }
      _purchasingRepo.DeleteLineItems_ByBid(bid.Id);
      _purchasingRepo.DeletePurchaseOrders_ByBid(bid.Id);
      _respondingRepo.DeleteResponseItems_ByBid(bid.Id);
      _respondingRepo.DeleteVendorResponses_ByBid(bid.Id);
      _requestingRepo.DeleteRequestItems_ByBid(bid.Id);
      _requestingRepo.DeleteRequests_ByBid(bid.Id);
      _requestingRepo.DeleteRequestors_ByBid(bid.Id);
      _catalogingService.DeleteAllItemsFromBid(bid.Id);
      _biddingRepo.DeleteBid(bid.Id);

      return true;
   }
}
