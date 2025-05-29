using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.Requesting
{
   public class PriceOverrideReportBuilder : BidHtmlReportBuilder
   {
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      // Shows all requestItems that have override price specified.
      protected override string Title => "Price Override Report";
      protected override string StyleName => "Reports.PriceOverride.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;


      public PriceOverrideReportBuilder() : base()
      {
      }

      public override string GenerateTableData(Bid Bid)
      {
         StringBuilder t = new StringBuilder();

         t.AppendLine($"<table>");

         t.AppendLine($" <thead>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th class='requestorCode'>Requestor<br/>Code</th>");
         t.AppendLine($"         <th class='requestorName'>Requestor<br/>Name</th>");
         t.AppendLine($"         <th class='accountNumber'>Account Number</th>");
         t.AppendLine($"         <th class='itemCode'>Item<br/>Code</th>");
         t.AppendLine($"         <th class='itemDescription'>Item Description</th>");
         t.AppendLine($"         <th class='qty'>Qty</th>");
         t.AppendLine($"         <th class='price'>Estimated<br />Price</th>");
         t.AppendLine($"         <th class='price'>Override<br />Price</th>");
         t.AppendLine($"         <th class='extPrice'>Estimated<br />Price<br />Extension</th>");
         t.AppendLine($"         <th class='extPrice'>Override<br />Price<br />Extension</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($" </thead>");

         List<RequestItem> requestItems = _requestingRepo.GetRequestItems_ByBid(Bid.Id).Where(x => x.OverridePrice != 0).OrderBy(x => x.Item.Code).ToList();

         foreach (RequestItem ri in requestItems)
         {
            t.AppendLine($"     <tr>");
            t.AppendLine($"         <td class='requestorCode'>{ri.Request.Requestor.FormattedCode}</td>");
            t.AppendLine($"         <td class='requestorName'>{ri.Request.Requestor.Name}</td>");
            t.AppendLine($"         <td class='accountNumber'>{ri.Request.Account_Number}</td>");
            t.AppendLine($"         <td class='itemCode'>{ri.Item.FormattedCode}</td>");
            t.AppendLine($"         <td class='itemDescription'><span class='clip'>{ri.Item.Description}</span></td>");
            t.AppendLine($"         <td class='qty'>{ri.Quantity}</td>");
            t.AppendLine($"         <td class='price'>{ri.Item.Price}</td>");
            t.AppendLine($"         <td class='price'>{ri.OverridePrice}</td>");
            t.AppendLine($"         <td class='extPrice'>{(ri.Quantity * ri.Item.Price).ToString("0.00")}</td>");
            t.AppendLine($"         <td class='extPrice'>{(ri.Quantity * ri.OverridePrice).ToString("0.00")}</td>");
            t.AppendLine($"     </tr>");
         }

         t.AppendLine($"</table>");

         return t.ToString();
      }
   }
}
