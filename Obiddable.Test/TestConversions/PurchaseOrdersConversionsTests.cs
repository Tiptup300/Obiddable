using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Library.Conversions.Bidding.Purchasing;

namespace Obiddable.Test.TestConversions;
public class PurchaseOrdersConversionsTests
{
   [Fact]
   public void CanConvertPurchaseOrderToCsv()
   {
      PurchaseOrder purchaseOrder = new PurchaseOrder(null,
          new LineItem[]
          {
                 new LineItem(null, "", "", "", 0, null, "", "", 1, 1),
                 new LineItem(null, "", "", "", 0, null, "", "", 1, 2),
          },
          null,
          null,
          DateTime.Now);

      PurchaseOrdersConversions purchaseOrdersConversions = new PurchaseOrdersConversions();

      string actual = purchaseOrdersConversions.ConvertPurchaseOrderToCsv(purchaseOrder);
      string expected = "lineNumber,description,partNumber,unit,quantity,unitPrice,tax,freight,account,warehouseItemNumber,grantProject,note\r\n" +
          "1,\"\",\"\",\"\",,0.0000,0,0,\"\",,,\"\"\r\n" +
          "2,\"\",\"\",\"\",,0.0000,0,0,\"\",,,\"\"";

      Assert.Equal(expected, actual);
   }
}
