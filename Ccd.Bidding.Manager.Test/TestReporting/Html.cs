using Ccd.Bidding.Manager.Reporting.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ccd.Bidding.Manager.Test.Reporting
{
    public class Html
    {
        [Fact]
        public void TdWorks()
        {
            Td reg = new Td("Vendor Total:");
            Td classOnly = new Td("Vendor Total:", classes: "vendorResponseSummaryRow-label");
            Td full = new Td("Vendor Total:", classes: "vendorResponseSummaryRow-label", columnSpan: 3, rowSpan: 1);

            Assert.Equal("<td>Vendor Total:</td>", reg.Terminate());
            Assert.Equal("<td class='vendorResponseSummaryRow-label'>Vendor Total:</td>", classOnly.Terminate());
            Assert.Equal("<td class='vendorResponseSummaryRow-label' colspan='3' rowspan='1'>Vendor Total:</td>", full.Terminate());
        }
    }
}
