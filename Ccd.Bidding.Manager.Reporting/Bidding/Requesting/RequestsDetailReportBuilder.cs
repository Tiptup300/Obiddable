using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Html;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.Requesting
{
   public class RequestsDetailReportBuilder : BidHtmlReportBuilder
   {
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      private readonly ILegacyElectionsRepo _electionsRepo;

      protected override string Title => "Bid Request Detail Report";
      protected override string StyleName => "Reports.BidRequestDetail.css";
      protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;


      public RequestsDetailReportBuilder() : base()
      {
         _electionsRepo = new EFLegacyElectionsRepo();
      }

      public override string GenerateTableData(Bid Bid)
      {
         StringBuilder t = new StringBuilder();

         t.AppendLine($"<table>");

         // Headers
         t.AppendLine($" <thead>");
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <th class='itemCode'>Item<br/>Code</th>");
         t.AppendLine($"         <th class='itemDescription'>Item<br />Description</th>");
         t.AppendLine($"         <th class='unitPrice'>Est<br/>Unit<br/>Price</th>");
         t.AppendLine($"         <th class='unitPrice'>Est<br/>Override<br/>Price</th>");
         t.AppendLine($"         <th class='unit'>Unit</th>");
         t.AppendLine($"         <th class='quantity'>QTY<br/>Req</th>");
         t.AppendLine($"         <th class='extensionPrice'>Ext Est<br/>Price</th>");
         t.AppendLine($"         <th class='extensionPrice'>Ext Est<br/>Price<br />With<br/>Override</th>");
         t.AppendLine($"         <th class='unitPrice'>Elected<br/>Price</th>");
         t.AppendLine($"         <th class='unitPrice'>Ext<br/>Elected<br/>Price</th>");
         t.AppendLine($"     </tr>");
         t.AppendLine($" </thead>");

         // Body

         var requestors = _requestingRepo.GetRequestors_ByBid(Bid.Id).OrderBy(x => x.Code).ToList();

         decimal bidQuantityRequestedSum = 0, bidExtensionPriceSum = 0, bidExtensionPriceSumWithOverride = 0, bidItemsCountSum = 0, bidActualPriceSum = 0;
         for (int requestorIndex = 0; requestorIndex < requestors.Count; requestorIndex++)
         {
            Requestor requestor = requestors[requestorIndex];

            var requests = _requestingRepo.GetRequests_ByRequestor(requestor.Id).OrderBy(x => x.Account_Number).ToList();
            for (int requestIndex = 0; requestIndex < requests.Count; requestIndex++)
            {
               Request request = requests[requestIndex];

               t.AppendLine($" <tbody>");
               t.AppendLine($" <tr class='newRequest'>");
               t.AppendLine($"     <td class='label' colspan='10'>Requestor: {request.Requestor.FormattedCode} - {request.Requestor.Name} - {request.Account_Number}</td>");
               t.AppendLine($" </tr>");

               t.AppendLine($" <tr class='newRequest-spacer'><td>&nbsp;</td></tr>");

               decimal requestQuantityRequestedSum = 0, requestExtensionPriceSum = 0, requestExtensionPriceSumWithOverride = 0, requestItemsCountSum = 0, requestActualPriceSum = 0;

               var requestItems = _requestingRepo.GetRequestItems_ByRequest(request.Id).OrderBy(x => x.Item.Code).ToList();
               for (int requestItemIndex = 0; requestItemIndex < requestItems.Count; requestItemIndex++)
               {
                  RequestItem ri = requestItems[requestItemIndex];
                  ResponseItem electedResponseItem = _electionsRepo.GetElectedResponseItemForItem(ri.Item.Id);

                  t.AppendLine($" <tr class='requestItem'>");
                  t.AppendLine($"     <td class='itemCode'>{ri.Item.FormattedCode}</td>");
                  t.AppendLine($"     <td class='itemDescription'><span class='clip'>{ri.Item.Description.Replace($"\r\n", " ")}</span></td>");
                  t.AppendLine($"     <td class='unitPrice'>{ri.Item.Price.ToString("0.0000")}</td>");
                  t.AppendLine($"     <td class='unitPrice'>{(ri.IsPriceOverridden() ? ri.OverridePrice.ToString("0.0000") : "")}</td>");
                  t.AppendLine($"     <td class='unit'><span class='clip'>{ri.Item.Unit}</span></td>");
                  t.AppendLine($"     <td class='quantity'>{ri.Quantity}</td>");
                  t.AppendLine($"     <td class='extensionPrice'>{ri.ExtendedPrice().ToString("0.00")}</td>");
                  t.AppendLine($"     <td class='extensionPrice'>{ri.ExtendedPriceWithOverride().ToString("0.00")}</td>");
                  t.AppendLine($"     <td class='unitPrice'>{(electedResponseItem != null ? electedResponseItem.Price.ToString("0.0000") : "")}</td>");
                  t.AppendLine($"     <td class='extensionPrice'>{(electedResponseItem != null ? (electedResponseItem.Price * ri.Quantity).ToString("0.00") : "")}</td>");
                  t.AppendLine($" </tr>");

                  requestQuantityRequestedSum += ri.Quantity;
                  requestExtensionPriceSum += ri.ExtendedPrice();
                  requestExtensionPriceSumWithOverride += ri.ExtendedPriceWithOverride();
                  requestActualPriceSum += electedResponseItem != null ? electedResponseItem.Price * ri.Quantity : 0;
                  requestItemsCountSum++;
               }

               t.AppendLine($" <tr class='requestTotal'>");
               t.AppendLine($"     <td class='' colspan='1'></td>");
               t.AppendLine($"     <td class='label' colspan='4'>{requestItemsCountSum} Item{(requestItemsCountSum == 1 ? "" : "s")} Requested</td>");
               t.AppendLine($"     <td class='quantity'>{requestQuantityRequestedSum}</td>");
               t.AppendLine($"     <td class='extensionPrice'>{requestExtensionPriceSum.ToString("0.00")}</td>");
               t.AppendLine($"     <td class='extensionPrice'>{requestExtensionPriceSumWithOverride.ToString("0.00")}</td>");
               t.AppendLine($"     <td>&nbsp;</td>");
               t.AppendLine($"     <td class='extensionPrice'>{requestActualPriceSum.ToString("0.00")}</td>");
               t.AppendLine($" </tr>");

               t.AppendLine($" </tbody>");

               bidQuantityRequestedSum += requestQuantityRequestedSum;
               bidExtensionPriceSum += requestExtensionPriceSumWithOverride;
               bidExtensionPriceSumWithOverride += requestExtensionPriceSumWithOverride;
               bidActualPriceSum += requestActualPriceSum;
               bidItemsCountSum += requestItemsCountSum;
            }


         }

         t.AppendLine($" <tbody>");
         t.AppendLine($" <tr class='bidTotal'>");
         t.AppendLine($"     <td class='label' colspan='5'>Bid Total: {bidItemsCountSum} Items Requested</td>");
         t.AppendLine($"     <td class='quantity'>{bidQuantityRequestedSum}</td>");
         t.AppendLine($"     <td class='extensionPrice'>{bidExtensionPriceSum.ToString("0.00")}</td>");
         t.AppendLine($"     <td class='extensionPrice'>{bidExtensionPriceSumWithOverride.ToString("0.00")}</td>");
         t.AppendLine($"     <td>&nbsp;</td>");
         t.AppendLine($"     <td class='extensionPrice'>{bidActualPriceSum.ToString("0.00")}</td>");
         t.AppendLine($" </tr>");

         t.AppendLine("  </tbody>");
         t.AppendLine("</table>");

         return t.ToString();
      }
   }
}
