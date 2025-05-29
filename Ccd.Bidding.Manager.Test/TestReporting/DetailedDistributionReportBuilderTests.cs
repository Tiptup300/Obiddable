using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Reporting.Html;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;
using Xunit;

namespace Ccd.Bidding.Manager.Test.Reporting
{
   public class DetailedDistributionReportBuilderTests
   {
      [Fact]
      public void DetailedDistributionReportWorks()
      {
         Mocker mocker = new Mocker(new TheNewBidMock());
         string outputHtml;

         outputHtml = buildDetailedDistributionReportBuilder(mocker)
             .GenerateTableData(mocker.GetBiddingRepo().GetBid(74))
             .CollapseSpaces();

         Assert.True(outputHtml.Length > 0);
         Assert.Equal(
             "<table> <thead> <tr> <th class='itemCode'>Item<br />Code</th> <th class='itemDescription'>Item Description</th> <th class='vendorName'>Vendor Name</th> <th class='requestorName'>Issued To</th> <th class='quantity'>Quantity</th> <th class='unit'>Unit</th> <th class='extension'>Extension<br/>Price</th> </tr> </thead> <tr> <td class='itemCode' rowspan='2'>003100</td> <td class='itemDescription' rowspan='2'>Ammonium Dichromate</td> <td class='vendorName' rowspan='2'><span class='clip'>Thompsons Pharmacy</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>1.00</td> <td class='unit'>EACH</td> <td class='extension'>2.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>2.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='2'>004900</td> <td class='itemDescription' rowspan='2'>Bacillus Subtilis</td> <td class='vendorName' rowspan='2'><span class='clip'>Horvak Chemical Supply</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>1.00</td> <td class='unit'>EACH</td> <td class='extension'>1.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>1.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='2'>006400</td> <td class='itemDescription' rowspan='2'>Barium Nitrate</td> <td class='vendorName' rowspan='2'><span class='clip'>Horvak Chemical Supply</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>1.00</td> <td class='unit'>EACH</td> <td class='extension'>3.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>3.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='2'>009000</td> <td class='itemDescription' rowspan='2'>Benedict's Solution</td> <td class='vendorName' rowspan='2'><span class='clip'>Thompsons Pharmacy</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>9.00</td> <td class='unit'>EACH</td> <td class='extension'>9.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>9.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr><td class='category-row' colspan='7'>Acid Rain</td></tr> <tr><td class='spacerRow' colspan='7'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='4'>001800</td> <td class='itemDescription' rowspan='4'>Acid Rain Bio Kit</td> <td class='vendorName' rowspan='4'><span class='clip'>Horvak Chemical Supply</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class='RequestorRow'> <td class='requestorName'><span class='clip'>Todd Russell</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class=' lastRequestorRow '> <td class='requestorName'><span class='clip'>Jill Hileman</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>3.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='4'>001900</td> <td class='itemDescription' rowspan='4'>Acid Rain Bio Kit Refill</td> <td class='vendorName' rowspan='4'><span class='clip'>Horvak Chemical Supply</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class='RequestorRow'> <td class='requestorName'><span class='clip'>Todd Russell</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class=' lastRequestorRow '> <td class='requestorName'><span class='clip'>Jill Hileman</span></td> <td class='quantity'>1.00</td> <td class='unit'>KIT</td> <td class='extension'>1.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>3.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> <tr><td class='category-row' colspan='7'>Container</td></tr> <tr><td class='spacerRow' colspan='7'>&nbsp;</td></tr> <tr> <td class='itemCode' rowspan='2'>007900</td> <td class='itemDescription' rowspan='2'>Beaker</td> <td class='vendorName' rowspan='2'><span class='clip'>Horvak Chemical Supply</span></td> <td class='requestorName'><span class='clip'>John Yogus</span></td> <td class='quantity'>3.00</td> <td class='unit'>PKG</td> <td class='extension'>3.00</td> </tr> <tr class='subtotalRow'> <th class='extension' colspan='5'>3.00</th> </tr> <tr><td class='spacerRow' colspan='8'>&nbsp;</td></tr> </tbody> </table>"
             , outputHtml);
      }

      private DetailedDistributionReportBuilder buildDetailedDistributionReportBuilder(Mocker mocker)
      {
         return new DetailedDistributionReportBuilder(
             mocker.GetRequestingRepo(),
             mocker.GetLegacyElectionsRepo());
      }
   }
}
