using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Test.Repos
{
   public class MockLegacyElectionsRepo : ILegacyElectionsRepo
   {
      private readonly MockData _data;

      public MockLegacyElectionsRepo(MockData data)
      {
         _data = data;
      }

      public List<Item> GetItems_Responded_Elected_ByBid(int bidId)
      {
         return _data.ResponseItems
             .Where(responseItem => responseItem.Elected)
             .Select(responseItem => responseItem.Item)
             .ToList();
      }

      public List<Item> GetItems_Responded_NotElected_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public List<ResponseItem> GetResponseItems_Elected_ByVendorResponse(int vendorResponseId)
      {
         return _data.ResponseItems
             .Where(x => x.VendorResponse.Id == vendorResponseId)
             .Where(x => x.Elected)
             .ToList();
      }

      public ResponseItem GetElectedResponseItemForItem(int itemId)
      {
         return _data.ResponseItems
             .Single(x => x.Elected && x.Item.Id == itemId);
      }

      public void UpdateResponseItems_ClearElections_ByBid(int bidId)
      {
         throw new NotImplementedException();
      }

      public void UpdateResponseItems_ClearElections_ByItem(int itemId)
      {
         throw new NotImplementedException();
      }

      public void UpdateResponseItem_Elect(int itemId, int responseItemId, string reasonElected)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ResponseItem> GetElectedResponseItemsByBid(int bidId)
      {
         return _data.ResponseItems
             .Where(requestItem => requestItem.Elected);
      }
   }
}
