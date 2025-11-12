using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Conversions.Bidding.Cataloging;
using System.Diagnostics.CodeAnalysis;

namespace Obiddable.Test.TestConversions;
public class ItemsConversionsTests
{

   [Fact]
   public void DoesCsvImportWork()
   {
      ItemsConversions itemsConversions = new ItemsConversions();
      string expectedOutput = buildCsvData();

      Assert.Equal(expectedOutput, itemsConversions.ConvertItemsToCsv(buildItems()));
   }

   [Fact]
   public void DoesCsvExportWork()
   {
      ItemsConversions itemsConversions = new ItemsConversions();
      IEnumerable<Item> expectedOutput = buildItems();
      IEnumerable<Item> actualOutput;
      string[] inputData;
      string errorLog;

      inputData = buildCsvData().Split(Environment.NewLine);
      actualOutput = itemsConversions.ConvertCSVToItems(inputData, out errorLog); //inputData.ConvertCSVToItems(out errorLog);

      Assert.Equal(expectedOutput, actualOutput, new ItemComparer());
   }

   [Fact]
   public void CanGenerateBlankItemsImportTemplate()
   {
      ItemsConversions itemsConversions = new ItemsConversions();
      Assert.Equal($"code,category,description,substitutable,price,unit,lastorderprice{Environment.NewLine}", itemsConversions.GenerateBlankItemsImportTemplate());
   }

   public class ItemComparer : IEqualityComparer<Item>
   {
      public bool Equals(Item a, Item b)
      {
         bool output;

         output =
             a.Code == b.Code &&
             a.Category == b.Category &&
             a.Description == b.Description &&
             a.Substitutable == b.Substitutable &&
             a.Unit == b.Unit &&
             a.Last_Order_Price == b.Last_Order_Price &&
             a.Price == b.Price;

         return output;
      }

      public int GetHashCode([DisallowNull] Item item)
      {
         return item.GetHashCode();
      }
   }
   public string buildCsvData()
   {
      return $"code,category,description,substitutable,price,unit,lastorderprice{Environment.NewLine}" +
          $"20,\"Things\",\"Widget\",False,12.0000,\"EA\",10.0000{Environment.NewLine}" +
          $"30,\"Things\",\"Doodat\",True,50.0000,\"EA\",5.0000{Environment.NewLine}";
   }

   public IEnumerable<Item> buildItems()
   {
      return new List<Item>()
         {
             new Item(1, null, 20, "Things", "Widget", false, "EA", 10.0M, 12.0M),
             new Item(2, null, 30, "Things", "Doodat", true, "EA", 5M, 50M)
         };
   }
}
