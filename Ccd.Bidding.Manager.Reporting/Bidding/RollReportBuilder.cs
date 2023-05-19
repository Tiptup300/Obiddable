using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Reporting;
using Ccd.Bidding.Manager.Reporting.Bidding.Cataloging;
using Ccd.Bidding.Manager.Reporting.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses;
using Ccd.Bidding.Manager.Reporting.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Bidding
{
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
}
