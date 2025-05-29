using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.Electings
{
   public class ElectedQuantitiesDiscrepancyReport : BidHtmlReportBuilder
   {
      private readonly IRequestingRepo _requestingRepo;
      private readonly ILegacyElectionsRepo _legacyElectionsRepo;

      public ElectedQuantitiesDiscrepancyReport()
          : this(new EFRequestingRepo(), new EFLegacyElectionsRepo())
      {

      }

      public ElectedQuantitiesDiscrepancyReport(
          IRequestingRepo requestingRepo,
          ILegacyElectionsRepo legacyElectionsRepo)
      {
         _requestingRepo = requestingRepo;
         _legacyElectionsRepo = legacyElectionsRepo;
      }

      protected override string Title => "Elected Quantities Discrepancies Report";
      protected override string StyleName => "Reports.ElectedQuantitiesDiscrepancyReport.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Portrait;

      public override string GenerateTableData(Bid bid)
      {
         string output;
         IEnumerable<QuantityDiscrepancy> discrepancies;

         discrepancies = buildDiscrepancies(bid.Id);
         output = printReport(discrepancies);

         return output;
      }

      private string printReport(IEnumerable<QuantityDiscrepancy> discrepancies)
      {
         StringBuilder sb = new StringBuilder();
         printStart(sb);
         printDiscrepancies(sb, discrepancies);
         printTotalsLine(sb, discrepancies);
         printEnd(sb);

         return sb.ToString();
      }

      private IEnumerable<QuantityDiscrepancy> buildDiscrepancies(int bidId)
      {
         return _legacyElectionsRepo.GetElectedResponseItemsByBid(bidId)
             .Where(responseItem => responseItem.IsMismatchedQuantity(_requestingRepo))
             .Select(responseItem => new QuantityDiscrepancy(responseItem, _requestingRepo.GetItemsRequestedQuantity(responseItem.Item))); ;
      }

      private void printStart(StringBuilder sb)
      {
         sb.Append(
             $" <table>" +
             $"     <thead>" +
             $"         <tr>" +
             $"             <th class='itemCode'>Item<br />Code</th>" +
             $"             <th class='itemDescription'>Item<br />Description</th>" +
             $"             <th class='itemRequestedQuantity'>Requested Quantity</th>" +
             $"             <th class='itemRequestedUnit'>&nbsp;</th>" +
             $"             <th class='electedVendor'>Elected Vendor</th>" +
             $"             <th class='vendorAlternateQuantity'>Vendor Alternate Quantity</th>" +
             $"             <th class='vendorAlternateUnit'>&nbsp;</th>" +
             $"         </tr>" +
             $"     </thead>" +
             $"     <tbody>");
      }


      private void printDiscrepancies(StringBuilder sb, IEnumerable<QuantityDiscrepancy> discrepancies)
      {
         discrepancies.ToList()
             .ForEach(
                 discrepancy => sb.Append(
                     $"          <tr>" +
                     $"             <td class='itemCode'>{discrepancy.Item.FormattedCode}</td>" +
                     $"             <td class='itemDescription'>{discrepancy.Item.Description}</td>" +
                     $"             <td class='itemRequestedQuantity'>{discrepancy.RequestedAmount}</td>" +
                     $"             <td class='itemRequestedUnit'>{discrepancy.Item.Unit}</td>" +
                     $"             <td class='electedVendor'>{discrepancy.ElectedResponseItem.VendorResponse.VendorName}</td>" +
                     $"             <td class='vendorAlternateQuantity'>{discrepancy.AlternateQuantity}</td>" +
                     $"             <td class='vendorAlternateUnit'>{discrepancy.ElectedResponseItem.AlternateUnit}</td>" +
                     $"         </tr>"));
      }

      private void printTotalsLine(StringBuilder sb, IEnumerable<QuantityDiscrepancy> discrepancies)
      {
         sb.Append(
                     $"          <tr>" +
                     $"             <td colspan='5' class='itemCode'>&nbsp;</td>" +
                     $"             <td class=''>Total Discrepancies:</td>" +
                     $"             <td class=''>{discrepancies.Count()}</td>" +
                     $"         </tr>");
      }

      private void printEnd(StringBuilder sb)
      {
         sb.Append(
             "      </tbody>" +
             "  </table>");
      }


      private class QuantityDiscrepancy
      {
         public Item Item { get; }
         public ResponseItem ElectedResponseItem { get; }
         public int RequestedAmount { get; }
         public decimal AlternateQuantity { get; }
         public QuantityDiscrepancy(ResponseItem responseItem, int requestedAmount)
         {
            Item = responseItem.Item;
            ElectedResponseItem = responseItem;
            RequestedAmount = requestedAmount;
            AlternateQuantity = ElectedResponseItem.AlternateQuantity;
         }
      }
   }
}
