using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Staging
{
   public class ItemResponse
   {
      private Item _item;
      public Item Item
      {
         get => _item;
         private set
         {
            if (value is null)
            {
               throw new ArgumentException("Item Cannot Be Null.");
            }
            _item = value;
         }
      }


      private IEnumerable<ResponseItem> _responseItems;
      public IEnumerable<ResponseItem> ResponseItems
      {
         get => _responseItems;
         private set
         {
            if (value is null)
            {
               throw new ArgumentException("Response Items Cannot Be Null.");
            }
            if (value.Count() == 0)
            {
               throw new ArgumentException("Response Items Cannot Be Empty.");
            }
            if (isAnyRequestedItemsNotItem(value))
            {
               throw new ArgumentException("RequestItems's Item Id Must Mastch That Of The RequestedItem");
            }
            _responseItems = value;
         }
      }
      private bool isAnyRequestedItemsNotItem(IEnumerable<ResponseItem> responseItems)
          => responseItems.Any(x => x.Item.Id != Item.Id);


      public int Responses => ResponseItems.Count();


      public ItemResponse(Item item, IEnumerable<ResponseItem> responseItems)
      {
         Item = item;
         ResponseItems = responseItems;
      }
   }
}
