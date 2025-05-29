using Ccd.Bidding.Manager.Library.Bidding.Responding;

namespace Ccd.Bidding.Manager.Library.Formatting
{
   public static class ResponseItemExtensions
   {
      public static string GetFormattedId(this ResponseItem responseItem) => responseItem.Id.ToString();
      public static string GetFormattedIsAlternate(this ResponseItem responseItem) => responseItem.IsAlternate ? "YES" : "NO";
      public static string GetFormattedPrice(this ResponseItem responseItem) => responseItem.Price.ToString("$0.00");
   }
}
