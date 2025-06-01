using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses;
public class NoResponseItemsReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   protected override string Title => "No Response Items Report";
   protected override string StyleName => "Reports.NoResponseItems.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;


   public NoResponseItemsReportBuilder() : base()
   {
   }

   public override string GenerateTableData(Bid Bid)
   {
      StringBuilder t = new StringBuilder();

      t.AppendLine($"<table>");

      t.AppendLine($" <table>");
      t.AppendLine($"     <thead>");
      t.AppendLine($"         <tr>");
      t.AppendLine($"             <th class='itemCode'>Item<br />Code</th>");
      t.AppendLine($"             <th class='itemDescription'>Item<br />Description</th>");
      t.AppendLine($"             <th class='requestorCode'>Requestor<br />Code</th>");
      t.AppendLine($"             <th class='requestorName'>Requestor<br />Name</th>");
      t.AppendLine($"             <th class='price'>Estimated<br />Price</th>");
      t.AppendLine($"             <th class='price'>Estimated<br />Extended<br />Price</th>");
      t.AppendLine($"             <th class='qty'>Quantity<br />Requested</th>");
      t.AppendLine($"             <th class='unit'>&nbsp;</th>");
      t.AppendLine($"         </tr>");
      t.AppendLine($"     </thead>");
      t.AppendLine($"     <tbody>");


      int totalcount_items = 0;
      List<Item> requestedItems = _requestingRepo.GetItems_Requested_ByBid(Bid.Id);

      List<Item> noResponseItems = requestedItems.Where(x => _respondingRepo.GetResponseItems_ByItem(x.Id).Count == 0).ToList();

      foreach (var category in noResponseItems.OrderBy(x => x.Category).GroupBy(x => x.Category).ToList())
      {
         if (category.Key != "")
         {
            t.AppendLine($"<tr><td class='category-row' colspan='8'>{category.Key}</td></tr>");
            t.AppendLine("<tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr>");
         }

         foreach (Item i in category.OrderBy(x => x.Code))
         {
            List<RequestItem> requestItems = _requestingRepo.GetRequestItems_ByItem(i.Id).OrderBy(x => x.Request.Requestor.Bid).ToList();

            if (requestItems.Count == 0)
            {
               continue;
            }

            t.AppendLine($"<tr class='requestRow'>");
            t.AppendLine($"  <td class='itemCode' rowspan='{Math.Max(requestItems.Count, 1).ToString()}'><span class='clip'>{i.FormattedCode}</span></td>");
            t.AppendLine($"  <td class='itemDescription' rowspan='{Math.Max(requestItems.Count, 1).ToString()}'>{i.Description.Trim().Replace("\r\n", "<br />")}</td>");

            int totalSum_qty = 0;
            string lastUnit = "";
            for (int requestIndex = 0; requestIndex < requestItems.Count; requestIndex++)
            {
               RequestItem ri = requestItems[requestIndex];

               string rowClass = requestIndex == requestItems.Count - 1 ? " lastRequestRow " : "requestRow";

               if (requestIndex > 0)
               {
                  t.AppendLine($"<tr class='{rowClass}'>");
               }

               t.AppendLine($"     <td class='requestorCode'><span class='clip'>{ri.Request.Requestor.FormattedCode}</span></td>");
               t.AppendLine($"     <td class='requestorName' >{ri.Request.Requestor.Name}</td>");
               t.AppendLine($"     <td class='price'>{ri.Item.Price.ToString("0.00")}</td>");
               t.AppendLine($"     <td class='price'>{ri.ExtendedPrice().ToString("0.00")}</td>");
               t.AppendLine($"     <td class='qty'>{ri.Quantity.ToString("0.00")}</td>");
               t.AppendLine($"     <td class='unit'><span class='clip'>{ri.Item.Unit}</span></td>");
               t.AppendLine($"</tr>");

               totalSum_qty += ri.Quantity;
               lastUnit = ri.Item.Unit;
            }
            switch (requestItems.Count)
            {
               case 1:
                  t.AppendLine($"</tr>");
                  break;
            }

            if (requestItems.Count > 1)
            {
               t.AppendLine($"         <tr class='requestItemTotal'>");
               t.AppendLine($"             <th colspan='6'>&nbsp;</th>");
               t.AppendLine($"             <th class='qty'>{totalSum_qty.ToString("0.00")}</th>");
               t.AppendLine($"             <th class='unit'><span class='clip'>{lastUnit}</span></th>");
               t.AppendLine($"         </tr>");
            }
            t.AppendLine($"<tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr>");

            totalcount_items++;
         }

      }

      t.AppendLine($"         <tr class='final-totals'>");
      t.AppendLine($"             <th colspan='8'>Total Items: {totalcount_items.ToString("0")}</th>");
      t.AppendLine($"         </tr>");

      t.AppendLine("      </tbody>");
      t.AppendLine("  </table>");

      return t.ToString();
   }
}
