using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses
{
   public class VendorSummaryReportBuilder : BidHtmlReportBuilder
   {
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

      protected override string Title => "Vendor Summary Report";
      protected override string StyleName => "Reports.VendorSummary.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Portrait;

      public VendorSummaryReportBuilder() : base()
      {

      }

      public override string GenerateTableData(Bid Bid)
      {
         StringBuilder t = new StringBuilder();

         t.AppendLine($"<table>");

         // Headers
         t.AppendLine($" <thead>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
         t.AppendLine($"         <th class='responseItems'>Response<br/> Items</th>");
         t.AppendLine($"         <th class='quantitySum'>Quantity<br/>Sum</th>");
         t.AppendLine($"         <th class='extension'>Total<br/> Extension</th>");
         t.AppendLine($"         <th class='responseItems'>Elected<br/> Response<br/> Items</th>");
         t.AppendLine($"         <th class='quantitySum'>Elected<br/> Quantity<br/> Sum</th>");
         t.AppendLine($"         <th class='extension'>Elected<br/> Total<br/> Extension</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($" </thead>");

         // Body
         t.AppendLine($" <tbody>");

         List<VendorResponse> vendorResponses = _respondingRepo.GetVendorResponses_ByBid(Bid.Id).OrderBy(x => x.VendorName).ToList();

         decimal TotalCount_ResponseItems = 0, TotalSum_Quantity = 0, TotalSum_TotalPrice = 0, TotalCount_Elected = 0, TotalSum_ElectedQuantity = 0, TotalSum_ElectedTotalPrice = 0;

         foreach (var vr in vendorResponses)
         {
            t.AppendLine($" <tr>");
            t.AppendLine($"     <td class='vendorName'>{vr.VendorName}</td>");
            t.AppendLine($"     <td class='responseItems'>{vr.ResponseItems.Count.ToString("0")}</td>");
            t.AppendLine($"     <td class='quantitySum'>{vr.GetGetSum_Quantity(_requestingRepo).ToString("0")}</td>");
            t.AppendLine($"     <td class='extension'>{vr.GetGetSum_TotalPrice(_requestingRepo).ToString("$0.00")}</td>");
            t.AppendLine($"     <td class='responseItems'>{vr.GetCount_Elected.ToString("0")}</td>");
            t.AppendLine($"     <td class='quantitySum'>{vr.GetGetSum_ElectedQuantity(_requestingRepo).ToString("0")}</td>");
            t.AppendLine($"     <td class='extension'>{vr.GetGetSum_ElectedTotalPrice(_requestingRepo).ToString("$0.00")}</td>");
            t.AppendLine($" </tr>");

            TotalCount_ResponseItems += vr.ResponseItems.Count;
            TotalSum_Quantity += vr.GetGetSum_Quantity(_requestingRepo);
            TotalSum_TotalPrice += vr.GetGetSum_TotalPrice(_requestingRepo);

            TotalCount_Elected += vr.GetCount_Elected;
            TotalSum_ElectedQuantity += vr.GetGetSum_ElectedQuantity(_requestingRepo);
            TotalSum_ElectedTotalPrice += vr.GetGetSum_ElectedTotalPrice(_requestingRepo);
         }
         t.AppendLine($"     <tr class='final-totals'>");
         t.AppendLine($"         <th class='final-totals-label'>Total: Bid {Bid.ToString()}</th>");
         t.AppendLine($"         <th class='responseItems'>{TotalCount_ResponseItems.ToString("0")}</th>");
         t.AppendLine($"         <th class='quantitySum'>{TotalSum_Quantity.ToString("0")}</th>");
         t.AppendLine($"         <th class='extension'>{TotalSum_TotalPrice.ToString("$0.00")}</th>");
         t.AppendLine($"         <th class='responseItems'>{TotalCount_Elected.ToString("0")}</th>");
         t.AppendLine($"         <th class='quantitySum'>{TotalSum_ElectedQuantity.ToString("0")}</th>");
         t.AppendLine($"         <th class='extension'>{TotalSum_ElectedTotalPrice.ToString("$0.00")}</th>");
         t.AppendLine($"     </tr>");

         t.AppendLine("  </tbody>");
         t.AppendLine("</table>");

         return t.ToString();
      }
   }
}
