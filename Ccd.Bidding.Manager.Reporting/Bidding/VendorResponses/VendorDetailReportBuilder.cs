using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Reporting;
using Ccd.Bidding.Manager.Reporting.Html;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses
{
    public class VendorDetailReportBuilder : BidHtmlReportBuilder
    {
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
        private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

        protected override string Title => "Vendor Detail Report";
        protected override string StyleName => "Reports.VendorDetail.css";
        protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

        public VendorDetailReportBuilder() : base()
        {
        }

        public override string GenerateTableData(Bid Bid)
        {
            StringBuilder t = new StringBuilder();

            StartTable(t);
            var vendorResponses = _respondingRepo.GetVendorResponses_ByBid(Bid.Id);
            foreach (var vr in vendorResponses.OrderBy(x => x.VendorName).ToList())
            {
                PrintVendorResponseHeaderRow(t, vr);
                PrintSpacerRow(t);
                vr.ResponseItems
                    .OrderBy(x => x.Item.Code)
                    .ToList()
                    .ForEach(responseItem => PrintResponseItemRow(t, responseItem));
                PrintVendorResponseTotalRow(t, vr);
                PrintSpacerRow(t);
            }
            PrintBidTotalRow(t, vendorResponses);
            EndTable(t);

            return t.ToString();
        }

        private void StartTable(StringBuilder t)
        {
            t.AppendLine($"<table>");
            PrintTableHeaders(t);
            t.AppendLine($"<tbody>");
        }

        private void PrintTableHeaders(StringBuilder t)
        {
            t.AppendLine($" <thead>");
            t.AppendLine($"     <tr>");
            t.AppendLine($"         <th class='elected'></th>");
            t.AppendLine($"         <th class='itemCode'>Item<br/>Code</th>");
            t.AppendLine($"         <th class='itemDescription'>Item<br />Description</th>");
            t.AppendLine($"         <th class='unit'>Unit</th>");
            t.AppendLine($"         <th class='quantity'>Request<br />Quantity</th>");
            t.AppendLine($"         <th class='quantity'>Vendor<br />Quantity</th>");
            t.AppendLine($"         <th class='unitPrice'>Unt<br />Price</th>");
            t.AppendLine($"         <th class='extensionPrice'>Extended<br />Price</th>");
            t.AppendLine($"         <th class='vendorCode'>Vendor<br />Code</th>");
            t.AppendLine($"         <th class='altDescription'>Alternate<br />Description</th>");
            t.AppendLine($"     </tr>");
            t.AppendLine($" </thead>");
        }

        private void PrintVendorResponseHeaderRow(StringBuilder t, VendorResponse vr)
        {
            t.AppendLine($" <tr class='vendorResponseHeaderRow'>");
            t.AppendLine($"     <td class='label' colspan='10'>Vendor: { vr.VendorName }</td>");
            t.AppendLine($" </tr>");
        }

        private void PrintResponseItemRow(StringBuilder t, ResponseItem ri)
        {
            t.AppendLine($"     <tr class='responseItemRow'>");
            t.AppendLine($"         <td class='elected'><span class='clip'>{ (ri.Elected ? "&check;" : "") }</span></td>");
            t.AppendLine($"         <td class='itemCode'>{ ri.Item.FormattedCode }</td>");
            t.AppendLine($"         <td class='itemDescription'><span class='clip'>{ ri.Item.Description.Replace($"\r\n", " ") }</span></td>");
            t.AppendLine($"         <td class='unit'><span class='clip'>{ (ri.IsAlternate ? ri.AlternateUnit : ri.Item.Unit) }</span></td>");
            t.AppendLine($"         <td class='quantity'>{ ri.Item.GetRequestedQuantity(_requestingRepo).ToString("0.00") }</td>");
            t.AppendLine($"         <td class='quantity'>{ ri.Get_Quantity(_requestingRepo).ToString("0.00") }</td>");
            t.AppendLine($"         <td class='unitPrice'>{ ri.Price.ToString("0.0000") }</td>");
            t.AppendLine($"         <td class='extensionPrice'>{ ri.GetExtendedPrice(_requestingRepo).ToString("0.00") }</td>");
            t.AppendLine($"         <td class='vendorCode'><span class='clip'>{ ri.Code.Replace($"\r\n", " ") }</span></td>");
            t.AppendLine($"         <td class='altDescription'><span class='clip'>{ (ri.IsAlternate ? "&check; " + ri.AlternateDescription.Replace($"\r\n", " ") : "") }</span></td>");
            t.AppendLine($"     </tr>");
        }

        private void PrintVendorResponseTotalRow(StringBuilder t, VendorResponse vr)
        {
            t.AppendLine($"     <tr class='vendorResponseTotalRow'>");
            t.AppendLine($"         <td class='label' colspan='5'>&nbsp;</td>");
            t.AppendLine($"         <td class='quantity'>{ vr.GetGetSum_Quantity(_requestingRepo).ToString("0.00") }</td>"); // yes
            t.AppendLine($"         <td class='unitPrice'>&nbsp;</td>");
            t.AppendLine($"         <td class='extensionPrice'>{ vr.GetGetSum_TotalPrice(_requestingRepo).ToString("0.00") }</td>"); //yes
            t.AppendLine($"         <td class='vendorCode'>&nbsp;</td>");
            t.AppendLine($"         <td class='altDescription'>&nbsp;</td>");
            t.AppendLine($"     </tr>");
        }

        private void PrintBidTotalRow(StringBuilder t, List<VendorResponse> vendorResponses)
        {
            t.AppendLine($"     <tr class='vendorResponseTotalRow'>");
            t.AppendLine($"         <td class='label' colspan='5'>&nbsp;</td>");
            t.AppendLine($"         <td class='quantity'>{ vendorResponses.Sum(x => x.GetGetSum_Quantity(_requestingRepo)).ToString("0.00") }</td>"); // yes
            t.AppendLine($"         <td class='unitPrice'>&nbsp;</td>");
            t.AppendLine($"         <td class='extensionPrice'>{ vendorResponses.Sum(x => x.GetGetSum_TotalPrice(_requestingRepo)).ToString("0.00") }</td>"); //yes
            t.AppendLine($"         <td class='vendorCode'>&nbsp;</td>");
            t.AppendLine($"         <td class='altDescription'>&nbsp;</td>");
            t.AppendLine($"     </tr>");
        }

        private void PrintSpacerRow(StringBuilder t)
        {
            t.AppendLine($" <tr class='spacerRow'><td class='spacerCell'>&nbsp;</td></tr>");
        }



        private void EndTable(StringBuilder t)
        {
            t.AppendLine($"</tbody>");
            t.AppendLine($"</table>");
        }
    }
}
