using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding.Requesting;
public class RequestorsListReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

   protected override string Title => "Bid Requestors List Report";
   protected override string StyleName => "Reports.BidRoll.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public RequestorsListReportBuilder()
   {
   }

   public override string GenerateTableData(Bid bid)
   {
      StringBuilder t = new StringBuilder();
      List<Requestor> requestors = _requestingRepo.GetRequestors_ByBid(bid.Id);
      GenerateRequestorsTable(t, requestors);
      return t.ToString();
   }

   private void GenerateRequestorsTable(StringBuilder t, List<Requestor> requestors)
   {
      t.AppendLine($"<table>");
      t.AppendLine($" <thead>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th colspan='4'>Requestors/Requests</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th class='requestorCode'>Code</th>");
      t.AppendLine($"         <th class='requestorName'>Name</th>");
      t.AppendLine($"         <th class='requestorBuilding'>Building</th>");
      t.AppendLine($"         <th class='requestAccountNumber'>Account Number</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($" </thead>");


      t.AppendLine($" <tbody>");
      foreach (Requestor rqstr in requestors.OrderBy(x => x.Code).ToList())
      {
         foreach (Request r in rqstr.Requests)
         {

            t.AppendLine($"     <tr>");
            t.AppendLine($"         <td class='requestorCode'>{rqstr.FormattedCode}</td>");
            t.AppendLine($"         <td class='requestorName'>{rqstr.Name}</td>");
            t.AppendLine($"         <td class='requestorBuilding'>{rqstr.Building}</td>");
            t.AppendLine($"         <td class='requestAccountNumber'>{r.Account_Number}</td>");
            t.AppendLine($"     </tr>");

         }

      }
      t.AppendLine($" </tbody>");
      t.AppendLine($"</table>");
   }
}
