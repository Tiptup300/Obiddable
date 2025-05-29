using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding
{
   public class DetailedDistributionReportBuilder : BidHtmlReportBuilder
   {
      private readonly IRequestingRepo _requestingRepo;
      private readonly ILegacyElectionsRepo _electionsRepo;

      protected override string Title => "Detailed Distribution Report";
      protected override string StyleName => "Reports.DetailedDistribution.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;
      public DetailedDistributionReportBuilder()
          : this(new EFRequestingRepo(), new EFLegacyElectionsRepo()) { }

      public DetailedDistributionReportBuilder(IRequestingRepo requestingRepo, ILegacyElectionsRepo electionsRepo)
      {
         _requestingRepo = requestingRepo;
         _electionsRepo = electionsRepo;
      }

      public override string GenerateTableData(Bid Bid)
      {
         string output;
         List<Item> items;

         items = getElectedRespondedRequestedItems(Bid);
         output = generateTable(items);

         return output;
      }

      private List<Item> getElectedRespondedRequestedItems(Bid Bid)
      {
         return _electionsRepo.GetItems_Responded_Elected_ByBid(Bid.Id)
             .Where(x => x.GetRequestedQuantity(_requestingRepo) > 0)
             .ToList();
      }

      private string generateTable(List<Item> items)
      {
         StringBuilder sb;

         sb = new StringBuilder();
         appendTableStart(sb);
         appendTableHeaders(sb);
         foreach (var category in getItemCategories(items))
         {
            if (isCategoryNameEmpty(category))
            {
               sb.AppendLine($"     <tr><td class='category-row' colspan='7'>{category.Key}</td></tr>");
               sb.AppendLine($"     <tr><td class='spacerRow' colspan='7'>&nbsp;</td></tr>");
            }

            foreach (Item i in getCategoriesSortedItems(category))
            {
               ResponseItem responseItem = _electionsRepo.GetElectedResponseItemForItem(i.Id);
               List<RequestItem> requestItems = _requestingRepo.GetRequestItems_ByItem(i.Id)
                   .OrderBy(x => x.Item.Code)
                   .ToList();

               sb.AppendLine($"     <tr>");
               sb.AppendLine($"         <td class='itemCode' rowspan='{Math.Max(requestItems.Count + 1, 1)}'>{i.FormattedCode}</td>");
               sb.AppendLine($"         <td class='itemDescription' rowspan='{Math.Max(requestItems.Count + 1, 1)}'>{i.Description.Trim().Replace("\r\n", "<br />")}" +
                   $"{(responseItem.IsAlternate ? $"<br />(Alternate: {responseItem.Code} -- {responseItem.AlternateDescription.Replace("\r\n", "<br />")})" : "")}" +
                   $"</td>");
               sb.AppendLine($"         <td class='vendorName' rowspan='{Math.Max(requestItems.Count + 1, 1)}'><span class='clip'>{responseItem.VendorResponse.VendorName}</span></td>");


               decimal total_itemExtensionPrice = 0;

               for (int requestItemIndex = 0; requestItemIndex < requestItems.Count; requestItemIndex++)
               {
                  RequestItem requestItem = requestItems[requestItemIndex];

                  string rowClass = requestItemIndex == requestItems.Count - 1 ? " lastRequestorRow " : "RequestorRow";

                  if (requestItemIndex > 0)
                  {
                     sb.AppendLine($"     <tr class='{rowClass}'>");
                  }

                  sb.AppendLine($"         <td  class='requestorName'><span class='clip'>{requestItem.Request.Requestor.Name}</span></td>");
                  sb.AppendLine($"         <td  class='quantity'>{requestItem.Quantity.ToString("0.00")}</td>");
                  sb.AppendLine($"         <td class='unit'>{i.Unit}</td>");
                  sb.AppendLine($"         <td class='extension'>{(responseItem.Price * requestItem.Quantity).ToString("0.00")}</td>");
                  sb.AppendLine($"     </tr>");

                  total_itemExtensionPrice += responseItem.Price * requestItem.Quantity;
               }

               if (requestItems.Count > 0)
               {
                  sb.AppendLine($"         <tr class='subtotalRow'>");
                  sb.AppendLine($"             <th class='extension' colspan='5'>{total_itemExtensionPrice.ToString("0.00")}</th>");
                  sb.AppendLine($"         </tr>");
               }
               sb.AppendLine("          <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr>");
            }
         }
         sb.AppendLine("      </tbody>");
         sb.AppendLine("  </table>");

         return sb.ToString();
      }

      private static IOrderedEnumerable<Item> getCategoriesSortedItems(IGrouping<string, Item> category)
      {
         return category.OrderBy(x => x.Code);
      }

      private static List<IGrouping<string, Item>> getItemCategories(List<Item> items)
      {
         return items
             .OrderBy(x => x.Category)
             .GroupBy(x => x.Category)
             .ToList();
      }

      private static bool isCategoryNameEmpty(IGrouping<string, Item> category)
      {
         return category.Key != "";
      }

      private static void appendTableStart(StringBuilder t)
      {
         t.AppendLine($"<table>");
      }

      private static void appendTableHeaders(StringBuilder t)
      {
         t.AppendLine($" <thead>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th class='itemCode'>Item<br />Code</th>");
         t.AppendLine($"         <th class='itemDescription'>Item Description</th>");
         t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
         t.AppendLine($"         <th class='requestorName'>Issued To</th>");
         t.AppendLine($"         <th class='quantity'>Quantity</th>");
         t.AppendLine($"         <th class='unit'>Unit</th>");
         t.AppendLine($"         <th class='extension'>Extension<br/>Price</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($" </thead>");
      }
   }
}
