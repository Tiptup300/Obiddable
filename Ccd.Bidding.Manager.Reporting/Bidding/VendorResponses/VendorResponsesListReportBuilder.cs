using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses
{
   public class VendorResponsesListReportBuilder : BidHtmlReportBuilder
   {
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

      protected override string Title => "Bid Vendor Responses List Report";
      protected override string StyleName => "Reports.BidRoll.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

      public override string GenerateTableData(Bid bid)
      {
         StringBuilder t = new StringBuilder();
         List<VendorResponse> vendorResponses = _respondingRepo.GetVendorResponses_ByBid(bid.Id);
         GenerateVendorResponsesTable(t, vendorResponses);
         return t.ToString();
      }
      private void GenerateVendorResponsesTable(StringBuilder t, List<VendorResponse> vendorResponses)
      {
         t.AppendLine($"<table>");
         t.AppendLine($" <thead>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th colspan='1'>Vendor Responses</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($" </thead>");


         t.AppendLine($" <tbody>");
         foreach (VendorResponse v in vendorResponses.OrderBy(x => x.VendorName).ToList())
         {
            t.AppendLine($"     <tr>");
            t.AppendLine($"         <td class='vendorName'>{v.VendorName}</td>");
            t.AppendLine($"     </tr>");
         }
         t.AppendLine($" </tbody>");
         t.AppendLine($"</table>");
      }

   }
}
