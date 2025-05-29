using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.RequestItems
{
   internal class RequestItemsRepo
   {
      private readonly RequestItemsValidation _requestItemsValidation = new RequestItemsValidation();

      public void AddRequestItem_ToRequest(RequestItem requestItem, int requestId)
      {
         using (var dbc = new Dbc())
         {
            _requestItemsValidation.Validate_AddRequestItem_ToRequest(dbc, requestItem, requestId);

            Request request = dbc.Requests
                .Where(x => x.Id == requestId)
                .Include(x => x.RequestItems)
                .Single();

            request.RequestItems.Add(requestItem);
            dbc.SaveChanges();
         }
      }
      public void UpdateRequestItem(RequestItem requestItem)
      {
         using (var dbc = new Dbc())
         {
            _requestItemsValidation.Validate_UpdateRequestItem(dbc, requestItem);

            var r = dbc.RequestItems.Include(x => x.Item).SingleOrDefault(x => x.Id == requestItem.Id);

            if (r is null)
               return;

            //r.Item = v.Item;
            r.Quantity = requestItem.Quantity;
            r.OverridePrice = requestItem.OverridePrice;

            dbc.SaveChanges();

         }
      }
      public void DeleteRequestItem(int requestItemId)
      {
         using (var dbc = new Dbc())
         {
            _requestItemsValidation.Validate_DeleteRequestItem(dbc, requestItemId);

            var r = dbc.RequestItems.SingleOrDefault(x => x.Id == requestItemId);

            if (r is null)
               return;
            dbc.Remove(r);
            dbc.SaveChanges();
         }
      }
      public void DeleteRequestItems_ByRequest(int requestId)
      {
         using (var dbc = new Dbc())
         {
            _requestItemsValidation.Validate_DeleteRequestItems_ByRequest(dbc, requestId);

            Request request = dbc.Requests
                .Where(x => x.Id == requestId)
                .Include(a => a.RequestItems)
                .Single();

            request.RequestItems.ForEach(x => dbc.Remove(x));

            dbc.SaveChanges();
         }
      }
      public void DeleteRequestItems_ByBid(int bidId)
      {
         using (var dbc = new Dbc())
         {
            _requestItemsValidation.Validate_DeleteRequestItems_ByBid(dbc, bidId);

            var requestItems = dbc.RequestItems.Include(x => x.Request).ThenInclude(x => x.Requestor).ThenInclude(x => x.Bid).Where(x => x.Request.Requestor.Bid.Id == bidId).ToList();
            requestItems.ForEach(x => dbc.Remove(x));
            dbc.SaveChanges();
         }
      }

      public RequestItem GetRequestItem(int requestItemId)
      {
         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .SingleOrDefault(ri => ri.Id == requestItemId);
         }

      }
      public List<RequestItem> GetRequestItems_ByBid(int bidId)
      {
         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .Where(x => x.Request.Requestor.Bid.Id == bidId)
                .ToList();
         }
      }
      public List<RequestItem> GetRequestItems_ByItem(int itemId)
      {
         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .Where(x => x.Item.Id == itemId)
                .ToList();
         }
      }
      public List<RequestItem> GetRequestItems_ByRequestor_ByItem(int requestorId, int itemId)
      {
         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .Where(ri => ri.Request.Requestor.Id == requestorId)
                .Where(x => x.Item.Id == itemId)
                .ToList();
         }
      }
      public List<RequestItem> GetRequestItems_ByRequest(int requestId)
      {

         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .Where(ri => ri.Request.Id == requestId)
                .ToList();
         }
      }
      public List<RequestItem> GetRequestItems_ByRequestor(int requestorId)
      {

         using (var dbc = new Dbc())
         {
            return dbc.RequestItems
                .Include(x => x.Item)
                .Include(x => x.Request)
                .ThenInclude(x => x.Requestor)
                .ThenInclude(x => x.Bid)
                .Where(ri => ri.Request.Requestor.Id == requestorId)
                .ToList();
         }
      }
   }
}
