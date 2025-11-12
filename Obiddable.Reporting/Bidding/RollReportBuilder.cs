using Obiddable.Library.Bidding;
using Obiddable.Reporting.Bidding.Cataloging;
using Obiddable.Reporting.Bidding.Requesting;
using Obiddable.Reporting.Bidding.VendorResponses;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding;
public class RollReportBuilder : BidHtmlReportBuilder
{
   // Generate report for bid roll showing all items, requestors, requests, & vendor responses.
   private ItemsListReportBuilder _bidItemsListReportBuilder = new ItemsListReportBuilder();
   private RequestorsListReportBuilder _bidRequestorsListReportBuilder = new RequestorsListReportBuilder();
   private VendorResponsesListReportBuilder _bidVendorResponsesListReportBuilder = new VendorResponsesListReportBuilder();

   protected override string Title => "Bid Roll Report";
   protected override string StyleName => "Reports.BidRoll.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public RollReportBuilder() : base()
   {
   }

   public override string GenerateTableData(Bid bid)
   {
      StringBuilder t = new StringBuilder();

      t.Append(_bidItemsListReportBuilder.GenerateTableData(bid));
      t.Append(_bidRequestorsListReportBuilder.GenerateTableData(bid));
      t.Append(_bidVendorResponsesListReportBuilder.GenerateTableData(bid));

      return t.ToString();
   }




}
