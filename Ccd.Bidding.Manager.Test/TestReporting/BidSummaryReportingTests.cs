using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Reporting.Html;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ccd.Bidding.Manager.Test.Reporting
{
    public class BidSummaryReportingTests
    {

        [Fact]
        public void BidSummaryReportWorks()
        {
            Mocker mocker = new Mocker(new TheNewBidMock());
            string outputHtml;

            outputHtml = buildSummaryReportBuilder(mocker)
                .GenerateTableData(mocker.GetBiddingRepo().GetBid(74))
                .CollapseSpaces();

            Assert.True(outputHtml.Length > 0);
            Assert.Contains($"<tr class=' buildingSummaryRow'> <td class='buildingSummaryRow-label' colspan='3'>Building Total:</td> <td class='count' colspan='1'>5</td> <td class='extension' colspan='1'>11.00</td> <td class='alternateShipTo' colspan='1'>HAJH</td></tr>", outputHtml);
            Assert.Contains($"<tr class='buildingSummaryRow-last buildingSummaryRow'> <td class='buildingSummaryRow-label' colspan='3'>Building Total:</td> <td class='count' colspan='1'>2</td> <td class='extension' colspan='1'>2.00</td> <td class='alternateShipTo' colspan='1'>HASH</td></tr>", outputHtml);
            Assert.Contains($"<tr class='vendorResponseSummaryRow'> <td class='vendorResponseSummaryRow-label' colspan='3'>Vendor Total:</td> <td class='count' colspan='1'>7</td> <td class='extension' colspan='1'>13.00</td></tr>", outputHtml);
            Assert.Contains($"<tr class='buildingSummaryRow-last buildingSummaryRow'> <td class='buildingSummaryRow-label' colspan='3'>Building Total:</td> <td class='count' colspan='1'>2</td> <td class='extension' colspan='1'>11.00</td> <td class='alternateShipTo' colspan='1'>HAJH</td></tr>", outputHtml);
            Assert.Contains($"<tr class='vendorResponseSummaryRow'> <td class='vendorResponseSummaryRow-label' colspan='3'>Vendor Total:</td> <td class='count' colspan='1'>2</td> <td class='extension' colspan='1'>11.00</td></tr>", outputHtml);
            Assert.Contains($"<tr class='finalBidSummaryRow'> <td colspan='1'>&nbsp;</td> <td class='finalBidSummaryRow-label' colspan='3'>Bid Total:</td> <td class='count' colspan='1'>9</td> <td class='extension' colspan='1'>24.00</td></tr>", outputHtml);
        }

        [Fact] 
        public void BidSummaryReportFileWorks()
        {
            Mocker mocker = new Mocker(new TheNewBidMock());
            HtmlReportFile htmlReportFile;

            htmlReportFile = (HtmlReportFile)buildSummaryReportBuilder(mocker)
                .BuildReport(mocker.GetBiddingRepo().GetBid(74));
            Assert.Equal(DateTime.Now.Date, htmlReportFile.TimeStamp.Date);
            Assert.Contains("--bid-summary-report--B000074.html", htmlReportFile.FileName);
        }

        private SummaryReportBuilder buildSummaryReportBuilder(Mocker mocker)
        {
            return new SummaryReportBuilder(
                mocker.GetRequestingRepo(),
                mocker.GetRespondingRepo(),
                mocker.GetDistributionService());
        }
    }
}
