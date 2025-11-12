using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding;
public class TallyReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

   protected override string Title => "Bid Tally Report";
   protected override string StyleName => "Reports.BidTally.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public TallyReportBuilder() : base()
   {
   }
   public override string GenerateTableData(Bid Bid)
   {
      StringBuilder t = new StringBuilder();


      t.AppendLine($"<table>");

      // Headers
      t.AppendLine($" <thead>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th class='itemCode'>Item<br />Code</th>");
      t.AppendLine($"         <th class='itemDescription'>Item<br />Description</th>");
      t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
      t.AppendLine($"         <th class='quantityResponded' colspan='2'>QTY&nbsp;</th>");
      t.AppendLine($"         <th class='unit'>Unit</th>");
      t.AppendLine($"         <th class='unitPrice'>Unit Price</th>");
      t.AppendLine($"         <th class='extendedPrice'>Ext<br/>Price</th>");
      t.AppendLine($"         <th class='alternate'>Alternate</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($" </thead>");

      // Body
      t.AppendLine($" <tbody>");
      int TotalCount_Items = 0;
      List<Item> items = _requestingRepo.GetItems_Requested_ByBid(Bid.Id);
      foreach (var category in items.OrderBy(x => x.Category).GroupBy(x => x.Category).ToList())
      {
         if (category.Key != "")
         {
            t.AppendLine($"<tr><td class='category-row' colspan='9'>{category.Key}</td></tr>");
            t.AppendLine("<tr><td class='spacerRow' colspan='9'>&nbsp;</td></tr>");
         }

         foreach (Item i in category.OrderBy(x => x.Code))
         {
            List<ResponseItem> responseItems = _respondingRepo.GetResponseItems_ByItem(i.Id).OrderBy(x => x.GetExtendedPrice(_requestingRepo)).ToList();

            if (responseItems.Count == 0)
            {
               continue;
            }

            t.AppendLine($"<tr class='responseRow'>");
            t.AppendLine($"  <td class='itemCode' rowspan='{Math.Max(responseItems.Count, 1).ToString()}'><span class='clip'>{i.FormattedCode}</span></td>");
            t.AppendLine($"  <td class='itemDescription' rowspan='{Math.Max(responseItems.Count, 1).ToString()}'>{i.Description.Trim().Replace("\r\n", "<br />")}</td>");


            for (int responseIndex = 0; responseIndex < responseItems.Count; responseIndex++)
            {
               ResponseItem ri = responseItems[responseIndex];

               string electedClass = ri.Elected ? " electedResponse " : "";
               string rowClass = responseIndex == responseItems.Count - 1 ? " lastResponseRow " : "responseRow";
               string boldClass = ri.IsAlternate ? " bold " : "";

               if (responseIndex > 0)
               {
                  t.AppendLine($"<tr class='{rowClass}'>");
               }

               t.AppendLine($"     <td class='{electedClass} vendorName ' ><span class='clip'>{ri.VendorResponse.VendorName}</span></td>");
               t.AppendLine($"     <td class='{electedClass} quantityResponded {boldClass}' >{ri.Get_Quantity(_requestingRepo).ToString("0.00")}</td>");
               t.AppendLine($"     <td class='{electedClass} alt {boldClass}'  ><span class='clip'>{(ri.IsAlternate ? "*" : "")}</span></td>");
               t.AppendLine($"     <td class='{electedClass} unit'  ><span class='clip'>{(ri.IsAlternate ? ri.AlternateUnit : ri.Item.Unit)}</span></td>");
               t.AppendLine($"     <td class='{electedClass} unitPrice' >{ri.Price.ToString("0.0000")}</td>");
               t.AppendLine($"     <td class='{electedClass} extendedPrice' >{ri.GetExtendedPrice(_requestingRepo).ToString("$0.00")}</td>");
               t.AppendLine($"     <td class='{electedClass} alternate' ><span class='clip'>{(ri.IsAlternate ? ri.AlternateDescription : "")}</span></td>");
               t.AppendLine($"</tr>");
            }
            switch (responseItems.Count)
            {
               case 1:
                  t.AppendLine($"</tr>");
                  break;
            }

            t.AppendLine($"<tr><td class='spacerRow' colspan='9'>&nbsp;</td></tr>");

            TotalCount_Items++;

         }
      }

      t.AppendLine($"         <tr class='final-totals'>");
      t.AppendLine($"             <th colspan='9'>Total Items: {TotalCount_Items.ToString("0")}</th>");
      t.AppendLine($"         </tr>");

      t.AppendLine("      </tbody>");
      t.AppendLine("  </table>");

      return t.ToString();
   }
}
