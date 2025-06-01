using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Electing;
using Ccd.Bidding.Manager.Test.MockBids;
using Ccd.Bidding.Manager.Test.Mocking;
using System.Diagnostics.CodeAnalysis;

namespace Ccd.Bidding.Manager.Test.TestConversions;
public class ElectionsConversionsTests
{
   [Fact]
   public void CanConvertCSVToElections()
   {
      Mocker mocker = new Mocker(new TheNewBidMock());

      ElectionsConversions electionsConversions = new ElectionsConversions(mocker.GetCatalogingRepo(), mocker.GetRespondingRepo());
      string error;
      List<ResponseItem> actual = electionsConversions.ConvertCSVToElections(getElectionData(), 74, out error);
      List<Item> bidItems = mocker.GetCatalogingRepo()
          .GetItems(74)
          .ToList();
      List<VendorResponse> vendorResponses = mocker.GetRespondingRepo()
          .GetVendorResponses_ByBid(74);
      IEnumerable<ResponseItem> expected = buildResponseItems(bidItems, vendorResponses);
      Assert.Equal(expected, actual, new ResponseItemComparer());
   }
   private string[] getElectionData()
   {
      return new string[]
      {
             "itemcode,vendorname,electionreason",
             "001800,Horvak Chemical Supply,because this",
             "001900,Thompsons Pharmacy,because that"
      };
   }

   private IEnumerable<ResponseItem> buildResponseItems(List<Item> items, List<VendorResponse> vendorResponses)
   {
      return new List<ResponseItem>()
         {
             new ResponseItem(null, items[0], "1", 1, 0, null, false, null, true, "because this" ) { VendorResponse = vendorResponses[0]} ,
             new ResponseItem(null, items[1], "", 3, 0, null, false, null, false, "because that" ) { VendorResponse = vendorResponses[1] }
         };
   }


   [Fact]
   public void CanConvertElectionsToCSV()
   {
      Mocker mocker = new Mocker(new TheNewBidMock());
      ElectionsConversions electionsConversions = new ElectionsConversions(null, mocker.GetRespondingRepo());
      string actual = electionsConversions.ConvertElectionsToCSV(74);
      string expected = getElectionsToCsvOutput();
      Assert.Equal(expected, actual);
   }

   private string getElectionsToCsvOutput()
   {
      return "itemcode,vendorname,electionreason\r\n" +
          "001800,Horvak Chemical Supply,Low Bid (2021-02-03)\r\n" +
          "001900,Horvak Chemical Supply,Low Bid (2021-02-03)\r\n" +
          "003100,Thompsons Pharmacy,because\r\n" +
          "004900,Horvak Chemical Supply,Low Bid (2021-02-03)\r\n" +
          "006400,Horvak Chemical Supply,Sam's Club Barium Nitrate is no good according to John Yogus\r\n" +
          "007900,Horvak Chemical Supply,Low Bid (2021-02-03)\r\n" +
          "009000,Thompsons Pharmacy,Low Bid (2021-02-03)\r\n";
   }



   private class ResponseItemComparer : IEqualityComparer<ResponseItem>
   {
      public bool Equals(ResponseItem a, ResponseItem b)
      {
         return
             a.AlternateDescription == b.AlternateDescription &&
             a.AlternateQuantity == b.AlternateQuantity &&
             a.AlternateUnit == b.AlternateUnit &&
             a.Code == b.Code &&
             a.Elected == b.Elected &&
             a.ElectionReason == b.ElectionReason &&
             a.IsAlternate == b.IsAlternate &&
             a.Item.Code == b.Item.Code &&
             a.Price == b.Price &&
             a.VendorResponse.VendorName == b.VendorResponse.VendorName;
      }

      public int GetHashCode([DisallowNull] ResponseItem responseItem)
      {
         return responseItem.GetHashCode();
      }
   }
}
