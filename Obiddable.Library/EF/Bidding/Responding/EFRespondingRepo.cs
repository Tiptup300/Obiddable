using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Microsoft.EntityFrameworkCore;

namespace Obiddable.Library.EF.Bidding.Responding;
public class EFRespondingRepo : IRespondingRepo
{
   #region Vendor Responses
   public VendorResponse GetVendorResponse(int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.VendorResponses
             .Where(x => x.Id == vendorResponseId)
             .Include(x => x.Bid)
             .Include(x => x.ResponseItems)
             .ThenInclude(x => x.Item)
             .Single();
      }
   }
   public List<VendorResponse> GetVendorResponses_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.VendorResponses
             .Include(q => q.ResponseItems)
             .ThenInclude(q => q.Item)
             .Include(b => b.Bid)
             .Where(x => x.Bid.Id == bidId)
             .ToList();
      }
   }

   public void AddVendorResponse_ToBid(VendorResponse obj, int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_AddVendorResponse_ToBid(obj, bidId);

         Bid bid = dbc.Bids
             .Where(x => x.Id == bidId)
             .Include(a => a.VendorResponses)
             .Single();

         bid.VendorResponses.Add(obj);
         dbc.SaveChanges();
      }
   }
   public void UpdateVendorResponse(VendorResponse obj)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_UpdateVendorResponse(obj);

         var r = dbc.VendorResponses.SingleOrDefault(x => x.Id == obj.Id);

         if (r is null)
            return;

         r.VendorName = obj.VendorName;

         dbc.SaveChanges();

      }
   }
   public void DeleteVendorResponse(int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteVendorResponse(vendorResponseId);

         var r = dbc.VendorResponses.SingleOrDefault(x => x.Id == vendorResponseId);

         if (r is null)
            return;

         dbc.Remove(r);
         dbc.SaveChanges();
      }
   }
   public void DeleteVendorResponses_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteVendorResponses_ByBid(bidId);

         Bid bid = dbc.Bids
             .Where(x => x.Id == bidId)
             .Include(a => a.VendorResponses)
             .Single();


         bid.VendorResponses.ForEach(x => dbc.Remove(x));

         dbc.SaveChanges();
      }
   }

   public bool Check_VendorResponseVendorNameAlreadyExists_InBid(string text, int bidId, int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.VendorResponses
             .Include(x => x.Bid)
             .Where(x => x.Bid.Id == bidId)
             .Any(x => x.VendorName == text);
      }
   }
   #endregion

   #region Response Items
   public ResponseItem GetResponseItem(int responseItemId)
   {
      ResponseItem output;

      using (var dbc = new Dbc())
      {
         output = dbc.ResponseItems
             .AsNoTracking()
             .Where(x => x.Id == responseItemId)
             .Include(x => x.VendorResponse.Bid)
             .Include(x => x.VendorResponse)
             .Include(x => x.Item)
             .Single();
      }
      return output;
   }
   public List<ResponseItem> GetResponseItems_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.ResponseItems
         .Include(x => x.VendorResponse)
         .ThenInclude(x => x.Bid)
         .Include(x => x.Item)
         .Where(x => x.VendorResponse.Bid.Id == bidId)
         .ToList();
      }
   }
   public List<ResponseItem> GetResponseItems_ByItem(int itemId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.ResponseItems
             .Include(x => x.Item)
             .Include(x => x.VendorResponse)
             .ThenInclude(x => x.Bid)
             .Where(ri => ri.Item.Id == itemId)
             .ToList();
      }
   }
   public List<ResponseItem> GetResponseItems_ByVendorResponse(int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.ResponseItems
         .Include(x => x.VendorResponse)
         .Include(x => x.VendorResponse.Bid)
         .Include(x => x.Item)
         .Where(ri => ri.VendorResponse.Id == vendorResponseId)
         .ToList();
      }
   }

   public void AddResponseItem_ToVendorResponse(ResponseItem obj, int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_AddResponseItem_ToVendorResponse(obj, vendorResponseId);

         VendorResponse response = dbc.VendorResponses
             .Where(x => x.Id == vendorResponseId)
             .Include(x => x.ResponseItems)
             .Single();

         response.ResponseItems.Add(obj);
         dbc.SaveChanges();
      }
   }
   public void UpdateResponseItem(ResponseItem obj)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_UpdateResponseItem(obj);

         var r = dbc.ResponseItems.Include(x => x.Item).SingleOrDefault(x => x.Id == obj.Id);

         if (r is null)
            return;
         //r.Item = v.Item;
         r.Code = obj.Code;
         r.Price = obj.Price;
         r.AlternateQuantity = obj.AlternateQuantity;
         r.AlternateUnit = obj.AlternateUnit;
         r.IsAlternate = obj.IsAlternate;
         r.AlternateDescription = obj.AlternateDescription;
         r.Elected = obj.Elected;
         r.ElectionReason = obj.ElectionReason;

         dbc.SaveChanges();
      }
   }
   public void DeleteResponseItem(int responseItemId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteResponseItem(responseItemId);

         var r = dbc.ResponseItems.SingleOrDefault(x => x.Id == responseItemId);

         if (r is null)
            return;

         dbc.Remove(r);
         dbc.SaveChanges();
      }
   }
   public void DeleteResponseItems_ByVendorResponse(int vendorResponseId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteResponseItems_ByVendorResponse(vendorResponseId);

         VendorResponse response = dbc.VendorResponses
             .Where(x => x.Id == vendorResponseId)
             .Include(a => a.ResponseItems)
             .Single();

         response.ResponseItems.ForEach(x => dbc.Remove(x));

         dbc.SaveChanges();
      }
   }
   public void DeleteResponseItems_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         dbc.Validate_DeleteResponseItems_ByBid(bidId);

         var responseItems = dbc.ResponseItems.Include(x => x.VendorResponse).ThenInclude(x => x.Bid).Where(x => x.VendorResponse.Bid.Id == bidId).ToList();
         responseItems.ForEach(x => dbc.Remove(x));
         dbc.SaveChanges();
      }
   }


   public bool Check_ResponseItemIsLowestBid(int vendorResponseId, IRequestingRepo requestingRepo)
   {
      using (var dbc = new Dbc())
      {
         ResponseItem ri = dbc.ResponseItems.Include(x => x.Item).SingleOrDefault(x => x.Id == vendorResponseId);

         if (ri is null)
            return false;

         Item i = ri.Item;

         List<ResponseItem> responseItemsForThisItem = dbc.ResponseItems
             .Include(x => x.Item)
             .Where(x => x.Item.Id == i.Id)
             //.Where(x => !x.IsAlternate)
             .ToList();

         if (responseItemsForThisItem.Count() == 0)
            return false;

         ResponseItem lowBidResponseItem = responseItemsForThisItem.OrderBy(x => x.GetExtendedPrice(requestingRepo)).First();

         return ri.Id == lowBidResponseItem.Id;
      }
   }
   #endregion

   #region Cataloging
   public bool Check_ItemResponded(int itemId)
   {
      using (var dbc = new Dbc())
      {
         return dbc.ResponseItems.Include(x => x.Item).Any(x => x.Item.Id == itemId);

      }
   }
   public List<Item> GetItems_Responded_ByBid(int bidId)
   {
      using (var dbc = new Dbc())
      {
         List<Item> allBidItems = dbc.Items.Include(a => a.Bid).Where(b => b.Bid.Id == bidId).ToList();

         List<ResponseItem> allResponseItems = dbc.ResponseItems
             .Include(x => x.Item)
             .Include(x => x.VendorResponse)
             .ThenInclude(x => x.Bid)
             .Where(x => x.VendorResponse.Bid.Id == bidId)
             .ToList();

         return allBidItems.Where(x => allResponseItems.Any(y => y.Item.Id == x.Id)).ToList();
      }
   }

   #endregion
}
