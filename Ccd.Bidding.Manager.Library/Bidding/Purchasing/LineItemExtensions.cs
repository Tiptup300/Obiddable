using System;

namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
   public static class LineItemExtensions
   {
      public static decimal GetRoundedExtendedPrice(this LineItem lineItem)
          => Math.Round(lineItem.Quantity.Value * lineItem.Price, 2);
   }
}
