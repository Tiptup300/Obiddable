using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Responding
{
   public class FutureResponseItemsRepo
   {
      public void AddResponseItemToVendorResponse(ResponseItem responseItem, VendorResponse vendorResponse)
      {
         VendorResponse trackedVendorResponse;

         using (var dbc = new Dbc())
         {
            ResponseItemsValidations.Validate_AddResponseItem_ToVendorResponse(dbc, responseItem, vendorResponse.Id);
            trackedVendorResponse = getTrackedVendorResponse(dbc, vendorResponse);
            trackedVendorResponse.ResponseItems.Add(responseItem);
            dbc.SaveChanges();
         }
      }


      public void UpdateResponseItem(ResponseItem responseItem)
      {
         ResponseItem trackedResponseItem;

         using (var dbc = new Dbc())
         {
            ResponseItemsValidations.Validate_UpdateResponseItem(dbc, responseItem);
            trackedResponseItem = getTrackedResponseItem(dbc, responseItem);
            copyResponseItemValues(responseItem, trackedResponseItem);
            dbc.SaveChanges();
         }
      }
      private void copyResponseItemValues(ResponseItem o, ResponseItem n)
      {
         n.Code = o.Code;
         n.Price = o.Price;
         n.AlternateQuantity = o.AlternateQuantity;
         n.AlternateUnit = o.AlternateUnit;
         n.IsAlternate = o.IsAlternate;
         n.AlternateDescription = o.AlternateDescription;
         n.Elected = o.Elected;
         n.ElectionReason = o.ElectionReason;
      }


      public void DeleteResponseItem(ResponseItem responseItem)
      {
         ResponseItem trackedResponseItem;

         using (var dbc = new Dbc())
         {
            ResponseItemsValidations.Validate_DeleteResponseItem(dbc, responseItem.Id);
            trackedResponseItem = getTrackedResponseItem(dbc, responseItem);
            dbc.Remove(trackedResponseItem);
            dbc.SaveChanges();
         }
      }


      public void DeleteAllResponseItemsForVendorResponse(VendorResponse vendorResponse)
      {
         VendorResponse trackedVendorResponse;

         using (var dbc = new Dbc())
         {
            ResponseItemsValidations.Validate_DeleteResponseItems_ByVendorResponse(dbc, vendorResponse.Id);
            trackedVendorResponse = getTrackedVendorResponse(dbc, vendorResponse);
            dbc.RemoveRange(trackedVendorResponse.ResponseItems);
            dbc.SaveChanges();
         }
      }


      public void DeleteAllResponseItemsForBid(Bid bid)
      {
         IEnumerable<ResponseItem> trackedResponseItems;

         using (var dbc = new Dbc())
         {
            ResponseItemsValidations.Validate_DeleteResponseItems_ByBid(dbc, bid.Id);
            trackedResponseItems = getTrackedResponseItemsForBid(dbc, bid);
            dbc.RemoveRange(trackedResponseItems);
            dbc.SaveChanges();
         }
      }
      private static IEnumerable<ResponseItem> getTrackedResponseItemsForBid(Dbc dbc, Bid bid)
      {
         return dbc.ResponseItems
             .Include(x => x.VendorResponse)
             .ThenInclude(x => x.Bid)
             .Where(x => x.VendorResponse.Bid.Id == bid.Id);
      }

      public ResponseItem GetResponseItem(int responseItemId)
      {
         ResponseItem output;

         using (var dbc = new Dbc())
         {
            output = getUntrackedReponseItemById(dbc, responseItemId);
         }

         return output;
      }
      private static ResponseItem getUntrackedReponseItemById(Dbc dbc, int responseItemId)
      {
         return dbc.ResponseItems
             .Where(x => x.Id == responseItemId)
             .Include(x => x.VendorResponse)
             .ThenInclude(x => x.Bid)
             .Include(x => x.Item)
             .AsNoTracking()
             .Single();
      }

      public IEnumerable<ResponseItem> GetResponseItemsForBid(Bid bid)
      {
         IEnumerable<ResponseItem> output;

         using (var dbc = new Dbc())
         {
            output = getUntrackedResponseItemsForBid(dbc, bid);
         }

         return output;
      }
      private static IEnumerable<ResponseItem> getUntrackedResponseItemsForBid(Dbc dbc, Bid bid)
      {
         return dbc.ResponseItems
             .Include(x => x.VendorResponse)
             .ThenInclude(x => x.Bid)
             .Where(x => x.VendorResponse.Bid.Id == bid.Id)
             .AsNoTracking();
      }


      public IEnumerable<ResponseItem> GetResponseItemsForItem(Item item)
      {
         IEnumerable<ResponseItem> output;

         using (var dbc = new Dbc())
         {
            output = getUntrackedResponseItemsForItem(dbc, item);
         }

         return output;
      }
      private IEnumerable<ResponseItem> getUntrackedResponseItemsForItem(Dbc dbc, Item item)
      {
         IEnumerable<ResponseItem> output;
         IEnumerable<ResponseItem> trackedResponseItemsForBid;

         trackedResponseItemsForBid = getTrackedResponseItemsForBid(dbc, item.Bid);
         output = trackedResponseItemsForBid.Where(x => x.Item.Id == item.Id);

         return output;
      }

      public IEnumerable<ResponseItem> GetResponseItemsForVendorResponse(VendorResponse vendorResponse)
      {
         throw new NotImplementedException();
      }

      private static VendorResponse getTrackedVendorResponse(Dbc dbc, VendorResponse vendorResponse)
      {
         return dbc.VendorResponses
             .Where(x => x.Id == vendorResponse.Id)
             .Include(x => x.ResponseItems)
             .Single();
      }
      private static ResponseItem getTrackedResponseItem(Dbc dbc, ResponseItem responseItem)
      {
         return dbc.ResponseItems
             .Include(x => x.Item)
             .Single(x => x.Id == responseItem.Id);
      }

   }
}
