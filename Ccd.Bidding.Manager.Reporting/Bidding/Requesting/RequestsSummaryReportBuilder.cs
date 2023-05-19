using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting;
using Ccd.Bidding.Manager.Reporting.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.Requesting
{
    public class RequestsSummaryReportBuilder : BidHtmlReportBuilder
    {
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

        protected override string Title => "Bid Request Summary Report";
        protected override string StyleName => "Reports.BidRequestSummary.css";
        protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

        public RequestsSummaryReportBuilder() : base()
        {
        }

        public override string GenerateTableData(Bid Bid)
        {
            StringBuilder t = new StringBuilder();

            t.AppendLine($"<table>");

            // Headers
            t.AppendLine($" <thead>");
            t.AppendLine($"     <tr>");
            t.AppendLine($"         <th class='buildingNumber'>Building<br/>Number</th>");
            t.AppendLine($"         <th class='requestorName'>Requestor<br/>Name</th>");
            t.AppendLine($"         <th class='buildingName'>Building<br/>Name</th>");
            t.AppendLine($"         <th class='accountNumber'>Account<br/>Number</th>");
            t.AppendLine($"         <th class='quantity'>QTY<br/>Requested</th>");
            t.AppendLine($"         <th class='quantity'>Items<br/>Requested</th>");
            t.AppendLine($"         <th class='extension'>Total<br/>Ext<br />Est<br/>Price</th>");
            t.AppendLine($"         <th class='extension'>Total<br/>Ext<br />Est<br/>Price<br/>With<br/>Overrides</th>");
            t.AppendLine($"     </tr>");
            t.AppendLine($" </thead>");

            var requestors = _requestingRepo.GetRequestors_ByBid(Bid.Id).OrderBy(x => x.Code).ToList();

            decimal bidQuantityRequestedSum = 0, bidItemsRequestedSum = 0, bidExtensionPriceSum = 0, bidExtensionPriceWithOverride = 0;
            for (int requestorIndex = 0; requestorIndex < requestors.Count; requestorIndex++)
            {
                Requestor requestor = requestors[requestorIndex];

                decimal requestorQuantityRequestedSum = 0, requestorItemsRequestedSum = 0, requestorExtensionPriceSum = 0, requestorExtensionPriceWithOverride = 0;

                var requests = _requestingRepo.GetRequests_ByRequestor(requestor.Id).OrderBy(x => x.Account_Number).ToList();
                for (int requestIndex = 0; requestIndex < requests.Count; requestIndex++)
                {
                    Request request = requests[requestIndex];

                    t.AppendLine($" <tr class='request'>");
                    if (requestIndex == 0)
                    {
                        t.AppendLine($"     <td class='buildingNumber' rowspan='{ requestor.Requests.Count }'>{ requestor.FormattedCode }</td>");
                        t.AppendLine($"     <td class='requestorName' rowspan='{ requestor.Requests.Count }'><span class='clip'>{ requestor.Name}</span></td>");
                        t.AppendLine($"     <td class='buildingName' rowspan='{ requestor.Requests.Count }'><span class='clip'>{ requestor.Building }</span></td>");
                    }
                    t.AppendLine($"     <td class='accountNumber'><span class='clip'>{ request.Account_Number }</span></td>");
                    t.AppendLine($"     <td class='quantity'><span class='clip'>{ request.QuantitySum() }</span></td>");
                    t.AppendLine($"     <td class='quantity'><span class='clip'>{ request.RequestItems.Count }</span></td>");
                    t.AppendLine($"     <td class='extension'>{ request.ExtendedPriceSum().ToString("0.00") }</td>");
                    t.AppendLine($"     <td class='extension'>{ request.ExtendedPriceWithOverridesSum().ToString("0.00") }</td>");
                    t.AppendLine($" </tr>");


                    requestorQuantityRequestedSum += request.QuantitySum();
                    requestorItemsRequestedSum += request.RequestItems.Count;
                    requestorExtensionPriceSum += request.ExtendedPriceSum();
                    requestorExtensionPriceWithOverride += request.ExtendedPriceWithOverridesSum();

                }


                t.AppendLine($" <tr class='requestTotal'>");
                if (requests.Count == 0)
                {
                    t.AppendLine($"     <td class='buildingNumber noRequests'>{ requestor.FormattedCode }</td>");
                    t.AppendLine($"     <td class='requestorName noRequests'><span class='clip'>{ requestor.Name}</span></td>");
                    t.AppendLine($"     <td class='buildingName noRequests'><span class='clip'>{ requestor.Building }</span></td>");
                    t.AppendLine($"     <td class='noRequests'>No Requests</td>");
                }
                else
                {
                    t.AppendLine($"     <td class='label' colspan='4'>&nbsp;</td>");
                }
                t.AppendLine($"     <td class='quantity'>{ requestorQuantityRequestedSum }</td>");
                t.AppendLine($"     <td class='quantity'>{ requestorItemsRequestedSum }</td>");
                t.AppendLine($"     <td class='extension'>{ requestorExtensionPriceSum.ToString("0.00") }</td>");
                t.AppendLine($"     <td class='extension'>{ requestorExtensionPriceWithOverride.ToString("0.00") }</td>");
                t.AppendLine($" </tr>");


                bidQuantityRequestedSum += requestorQuantityRequestedSum;
                bidItemsRequestedSum += requestorItemsRequestedSum;
                bidExtensionPriceSum += requestorExtensionPriceSum;
                bidExtensionPriceWithOverride += requestorExtensionPriceWithOverride;


            }

            t.AppendLine($" <tr class='bidTotal'>");
            t.AppendLine($"     <td class='label' colspan='4'>&nbsp;</td>");
            t.AppendLine($"     <td class='quantity'>{ bidQuantityRequestedSum }</td>");
            t.AppendLine($"     <td class='quantity'>{ bidItemsRequestedSum }</td>");
            t.AppendLine($"     <td class='extension'>{ bidExtensionPriceSum.ToString("0.00") }</td>");
            t.AppendLine($"     <td class='extension'>{ bidExtensionPriceWithOverride.ToString("0.00") }</td>");
            t.AppendLine($" </tr>");

            t.AppendLine("  </tbody>");
            t.AppendLine("</table>");

            return t.ToString();


        }
    }
}
