using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding.Requesting
{
    public class ExpendituresByRequestorsReportBuilder : BidHtmlReportBuilder
    {
        private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
        private readonly ILegacyElectionsRepo _electionsRepo = new EFLegacyElectionsRepo();


        protected override string Title => "Expenditures by Requestor Report";
        protected override string StyleName => "Reports.ExpendituresByRequestors.css";
        protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

        public ExpendituresByRequestorsReportBuilder() : base()
        {
        }

        public override string GenerateTableData(Bid Bid)
        {
            StringBuilder t = new StringBuilder();
            List<Requestor> requestors = _requestingRepo.GetRequestors_ByBid(Bid.Id).OrderBy(x => x.Code).ToList();
            printTableStart(t);
            printHeaders(t);
            printTableBodyStart(t);

            decimal TotalCount_RequestItems = 0, TotalSum_Quantity = 0, TotalSum_TotalPrice = 0, TotalSum_TotalPriceWithOverride = 0, bidSumActualSumExtendedPrice = 0;

            foreach (var rqtr in requestors)
            {
                decimal requestSumActualSumExtendedPrice = 0;

                t.AppendLine($"     <tr>");
                t.AppendLine($"         <td class='buildingNumber' rowspan='{ Math.Max(rqtr.Requests.Count, 1).ToString()  }'>{ rqtr.FormattedCode }</td>");
                t.AppendLine($"         <td class='requestorName' rowspan='{  Math.Max(rqtr.Requests.Count, 1).ToString() }'>{ rqtr.Name }</td>");

                foreach (var req in rqtr.Requests.OrderBy(x => x.Account_Number).ToList())
                {
                    decimal actualSumExtendedPrice = req.ElectedExtendedPrice(_electionsRepo);
                    t.AppendLine($"     <td class='accountNumber'>{ req.Account_Number }</td>");
                    t.AppendLine($"     <td class='count'>{ req.RequestItems.Count.ToString() }</td>");
                    t.AppendLine($"     <td class='qty'>{ req.QuantitySum().ToString("0.00") }</td>");
                    t.AppendLine($"     <td class='price'>{ req.ExtendedPriceSum().ToString("0.00") }</td>");
                    t.AppendLine($"     <td class='price'>{ req.ExtendedPriceWithOverridesSum().ToString("0.00") }</td>");
                    t.AppendLine($"     <td class='price'>{ actualSumExtendedPrice.ToString("0.00") }</td>");
                    t.AppendLine($" </tr>");

                    requestSumActualSumExtendedPrice += actualSumExtendedPrice;
                }

                switch (rqtr.Requests.Count)
                {
                    case 0:
                        t.AppendLine($" <td colspan='6' style='text-align:right;'>(No Requests)</td>");
                        t.AppendLine($"</tr>");
                        t.AppendLine($"<tr class='noResponseSpacer'><td colspan='8'>&nbsp;</td></tr>");
                        continue;
                    case 1:
                        t.AppendLine($"</tr>");
                        break;
                }
                t.AppendLine($"<tr class='spacer-row'><td colspan='8'>&nbsp;</td></tr>");

                t.AppendLine($"     <tr class='requestor-total'>");
                t.AppendLine($"         <th>&nbsp;</th>");
                t.AppendLine($"         <th colspan='2' class='total-label'>Total: { rqtr.Name }</th>");
                t.AppendLine($"         <th class='count'>{ rqtr.RequestItemsCount().ToString() }</th>");
                t.AppendLine($"         <th class='qty'>{ rqtr.QuantitySum().ToString() }</th>");
                t.AppendLine($"         <th class='price'>{ rqtr.TotalPrice().ToString("$0.00") }</th>");
                t.AppendLine($"         <th class='price'>{ rqtr.TotalPriceWithOverride().ToString("$0.00") }</th>");
                t.AppendLine($"         <th class='price'>{ requestSumActualSumExtendedPrice.ToString("$0.00") }</th>");
                t.AppendLine($"     </tr>");

                TotalCount_RequestItems += rqtr.RequestItemsCount();
                TotalSum_Quantity += rqtr.QuantitySum();
                TotalSum_TotalPrice += rqtr.TotalPrice();
                TotalSum_TotalPriceWithOverride += rqtr.TotalPriceWithOverride();
                bidSumActualSumExtendedPrice += requestSumActualSumExtendedPrice;
            }
            printTotalsRow(Bid, t, TotalCount_RequestItems, TotalSum_Quantity, TotalSum_TotalPrice, TotalSum_TotalPriceWithOverride, bidSumActualSumExtendedPrice);
            printTableBodyEnd(t);
            printTableEnd(t);

            return t.ToString();
        }

        private static void printTableEnd(StringBuilder t)
        {
            t.AppendLine("  </table>");
        }

        private static void printTableBodyEnd(StringBuilder t)
        {
            t.AppendLine("      </tbody>");
        }

        private static void printTotalsRow(Bid Bid, StringBuilder t, decimal TotalCount_RequestItems, decimal TotalSum_Quantity, decimal TotalSum_TotalPrice, decimal TotalSum_TotalPriceWithOverride, decimal bidSumActualSumExtendedPrice)
        {
            t.AppendLine($"         <tr class='final-totals'>");
            t.AppendLine($"             <th class='total-label' colspan='3'>Total: { Bid.ToString() }</th>");
            t.AppendLine($"             <th class='count'>{ TotalCount_RequestItems.ToString() }</th>");
            t.AppendLine($"             <th class='qty'>{ TotalSum_Quantity.ToString() }</th>");
            t.AppendLine($"             <th class='price'>{ TotalSum_TotalPrice.ToString("$0.00") }</th>");
            t.AppendLine($"             <th class='price'>{ TotalSum_TotalPriceWithOverride.ToString("$0.00") }</th>");
            t.AppendLine($"             <th class='price'>{ bidSumActualSumExtendedPrice.ToString("$0.00") }</th>");
            t.AppendLine($"         </tr>");
        }

        private static void printTableBodyStart(StringBuilder t)
        {
            t.AppendLine($"     <tbody>");
        }

        private static void printTableStart(StringBuilder t)
        {
            t.AppendLine($" <table>");
        }

        private static void printHeaders(StringBuilder t)
        {
            t.AppendLine($"     <thead>");
            t.AppendLine($"         <tr>");
            t.AppendLine($"             <th class='buildingNumber'>Requestor<br/>Code</th>");
            t.AppendLine($"             <th class='requestorName'>Requestor<br/>Name</th>");
            t.AppendLine($"             <th class='accountNumber'>Account Number</th>");
            t.AppendLine($"             <th class='count'>Items<br/> Requested</th>");
            t.AppendLine($"             <th class='qty'>Quantity<br />Sum</th>");
            t.AppendLine($"             <th class='price'>Total<br/>Est<br/> Price</th>");
            t.AppendLine($"             <th class='price'>Total<br/>Est<br/>Price<br/>With<br/> Overrides</th>");
            t.AppendLine($"             <th class='price'>Total<br/>Elected<br/> Price</th>");
            t.AppendLine($"         </tr>");
            t.AppendLine($"     </thead>");
        }

    }
}
