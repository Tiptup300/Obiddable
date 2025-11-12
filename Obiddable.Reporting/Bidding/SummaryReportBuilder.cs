using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Distribution;
using Obiddable.Library.EF.Bidding.Electing;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding;
public class SummaryReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo;
   private readonly IRespondingRepo _respondingRepo;
   private readonly DistributionService _distributionService;

   protected override string Title => "Bid Summary Report";
   protected override string StyleName => "Reports.BidSummary.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Portrait;

   public SummaryReportBuilder()
   {
      _respondingRepo = new EFRespondingRepo();
      _requestingRepo = new EFRequestingRepo();
      _distributionService = new DistributionService(new EFRequestingRepo(), new EFLegacyElectionsRepo(), new EFDistributionRepo(), new EFRespondingRepo());
   }

   public SummaryReportBuilder(IRequestingRepo requestingRepo, IRespondingRepo respondingRepo, DistributionService distributionService) : base()
   {
      _respondingRepo = respondingRepo;
      _requestingRepo = requestingRepo;
      _distributionService = distributionService;
   }

   public override string GenerateTableData(Bid bid)
   {
      StringBuilder t = new StringBuilder();

      printTableStart(t);
      printHeaders(t);
      printTableBodyStart(t);

      decimal bidTotal_extensionPrice = 0;
      int bidTotal_responsesCount = 0;

      List<VendorResponse> vendorResponses = _respondingRepo.GetVendorResponses_ByBid(bid.Id).OrderBy(x => x.VendorName).ToList();
      foreach (var v in vendorResponses)
      {
         int vendorTotal_responsesCount = 0, vendorTotal_rowCount = 0;
         decimal vendorTotal_extensionPrice = 0;


         StringBuilder vRow = new StringBuilder();

         string[] buildingNames = _distributionService.GetRequestorsBuildingNames_Elected_ByVendorResponse(v.Id).OrderBy(x => x).ToArray();


         for (int x = 0; x < buildingNames.Length; x++)
         {
            var b = buildingNames[x];
            Building building = _distributionService.GetBuilding(bid, b);


            StringBuilder bRow = new StringBuilder();

            int buildingTotal_responseCount = 0; decimal buildingTotal_extensionPrice = 0;


            List<ResponseItem> responseItems = _distributionService.GetResponseItems_ByBuildingName_ByVendorResponse(b, v.Id).OrderBy(q => q.Item.Code).ToList();
            foreach (var ri in responseItems)
            {
               if (x > 0)
               {
                  bRow.AppendLine("<tr>");
               }

               int itemCode;
               decimal requestedQuantity;
               string unit;
               decimal price;
               decimal extension;
               string altDescription;

               itemCode = ri.Item.Code;
               requestedQuantity = building.GetRequestedQuantity(ri.Item.Id);
               unit = (ri.IsAlternate ? ri.AlternateUnit : ri.Item.Unit);
               price = ri.Price;
               extension = requestedQuantity * ri.Price;
               altDescription = (ri.IsAlternate ? ri.AlternateDescription : "");

               bRow.AppendLine($"  <td class='itemCode'>{itemCode.ToString("000000")}</td>");
               bRow.AppendLine($"  <td class='quantity'>{requestedQuantity.ToString("0.00")}</td>");
               bRow.AppendLine($"  <td class='unit'>{unit}</td>");
               bRow.AppendLine($"  <td class='price'>{price.ToString("0.0000")}</td>");
               bRow.AppendLine($"  <td class='extension'>{extension.ToString("0.00")}</td>");
               bRow.AppendLine($"  <td class='alternateShipTo'>{altDescription}</td>");
               bRow.AppendLine($"</tr>");

               vendorTotal_rowCount++;
               buildingTotal_responseCount++;
               buildingTotal_extensionPrice += extension;
            }
            // print building subtotal

            bRow.AppendLine($"<tr class='{(x == buildingNames.Length - 1 ? "buildingSummaryRow-last" : "")} buildingSummaryRow'>");
            bRow.AppendLine($"  <td class='buildingSummaryRow-label' colspan='3'>Building Total:</td>");
            bRow.AppendLine($"  <td class='count' colspan='1'>{buildingTotal_responseCount.ToString("0")}</td>");
            bRow.AppendLine($"  <td class='extension' colspan='1'>{buildingTotal_extensionPrice.ToString("0.00")}</td>");
            bRow.AppendLine($"  <td class='alternateShipTo' colspan='1'>{b}</td>");
            bRow.AppendLine("</tr>");
            vendorTotal_rowCount++;

            vRow.AppendLine(bRow.ToString());

            vendorTotal_responsesCount += buildingTotal_responseCount;
            vendorTotal_extensionPrice += buildingTotal_extensionPrice;
         }


         vRow.AppendLine($"<tr class='vendorResponseSummaryRow'>");
         vRow.AppendLine($"  <td class='vendorResponseSummaryRow-label' colspan='3'>Vendor Total:</td>");
         vRow.AppendLine($"  <td class='count' colspan='1'>{vendorTotal_responsesCount.ToString("0")}</td>");
         vRow.AppendLine($"  <td class='extension' colspan='1'>{vendorTotal_extensionPrice.ToString("0.00")}</td>");
         vRow.AppendLine($"</tr>");
         vendorTotal_rowCount++;

         if (vendorTotal_responsesCount > 0)
         {
            t.AppendLine($"<tr class='vendorResponse-firstResponseItem-row'>");
            t.AppendLine($"  <td class='vendorName' rowspan='{Math.Max(vendorTotal_rowCount, 1).ToString()}'>{v.VendorName}</td>");
            t.AppendLine(vRow.ToString());
         }
         bidTotal_extensionPrice += vendorTotal_extensionPrice;
         bidTotal_responsesCount += vendorTotal_responsesCount;
      }

      t.AppendLine($"<tr class='finalBidSummaryRow'>");
      t.AppendLine($"  <td colspan='1'>&nbsp;</td>");
      t.AppendLine($"  <td class='finalBidSummaryRow-label' colspan='3'>Bid Total:</td>");
      t.AppendLine($"  <td class='count' colspan='1'>{bidTotal_responsesCount.ToString("0")}</td>");
      t.AppendLine($"  <td class='extension' colspan='1'>{bidTotal_extensionPrice.ToString("0.00")}</td>");
      t.AppendLine($"</tr>");

      t.AppendLine("      </tbody>");
      t.AppendLine("  </table>");

      return t.ToString();
   }

   private static void printTableBodyStart(StringBuilder t)
   {
      t.AppendLine($" <tbody>");
   }

   private static void printTableStart(StringBuilder t)
   {
      t.AppendLine($"<table>");
   }

   private static void printHeaders(StringBuilder t)
   {
      t.AppendLine($" <thead>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
      t.AppendLine($"         <th class='itemCode'>Item Code</th>");
      t.AppendLine($"         <th class='quantity'>QTY</th>");
      t.AppendLine($"         <th class='unit'></th>");
      t.AppendLine($"         <th class='price'>Price</th>");
      t.AppendLine($"         <th class='extension'>Ext</th>");
      t.AppendLine($"         <th class='alternateShipTo'>Alternate/Building</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($" </thead>");
   }
}
