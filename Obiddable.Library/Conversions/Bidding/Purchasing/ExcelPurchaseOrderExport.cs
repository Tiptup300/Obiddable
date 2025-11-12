using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Library.Conversions.Excel;
using OfficeOpenXml;

namespace Obiddable.Library.Conversions.Bidding.Purchasing;
public class ExcelPurchaseOrderExport : IExcelExport
{
   private readonly PurchaseOrder _purchaseOrder;

   public ExcelPurchaseOrderExport(PurchaseOrder purchaseOrder)
   {
      _purchaseOrder = purchaseOrder;
   }

   public MemoryStream Generate()
   {
      MemoryStream stream = new MemoryStream();
      using (var package = new ExcelPackage())
      {
         ExcelWorksheet ws = package.Workbook.Worksheets.Add("Sheet1");


         // printing data
         SetColumns(ws);
         SetLineItems(ws);
         AutoFitColumns(ws);

         // protect, calculate, & save
         package.Workbook.Calculate();
         package.SaveAs(stream);
      }
      return stream;
   }

   public void SetColumns(ExcelWorksheet ws)
   {
      int col = 1;
      setColumn(ws, col++, "lineNumber");
      setColumn(ws, col++, "description");
      setColumn(ws, col++, "partNumber");
      setColumn(ws, col++, "unit");
      setColumn(ws, col++, "quantity");
      setColumn(ws, col++, "unitPrice");
      setColumn(ws, col++, "tax");
      setColumn(ws, col++, "freight");
      setColumn(ws, col++, "account");
      setColumn(ws, col++, "warehouseItemNumber");
      setColumn(ws, col++, "grantProject");

      ws.Row(1).Height = 39;
   }

   public void AutoFitColumns(ExcelWorksheet ws)
   {
      for (int x = 1; x < 12; x++)
      {
         ws.Column(x).AutoFit();
      }
   }

   public void setColumn(ExcelWorksheet ws, int col, string title)
   {
      var c = ws.Cells[1, col];
      // set value
      c.Value = title;
      // style cell
      //c.Bold().Bottom().Center().WrapText().Size(12).BorderBottom(ExcelBorderStyle.Thin);
      // column width
   }


   public void SetLineItems(ExcelWorksheet ws)
   {
      int lineItem = 1;

      int row = 2;
      foreach (LineItem li in _purchaseOrder.LineItems)
      {
         var lineNumberField = ws.Cells[row, 1];
         var descriptionField = ws.Cells[row, 2];
         var partNumberField = ws.Cells[row, 3];
         var unitField = ws.Cells[row, 4];
         var quantityField = ws.Cells[row, 5];
         var priceField = ws.Cells[row, 6];
         // filler 7
         // filler 8
         var accountNumberField = ws.Cells[row, 9];
         // filler 10
         // filler 11
         //var noteField = ws.Cells[row, 12];

         lineNumberField.Value = lineItem++;
         descriptionField.Value = li.Description;
         partNumberField.Value = li.PartNumber;
         unitField.Value = li.Unit;
         quantityField.Value = li.Quantity;
         priceField.Value = li.Price;
         accountNumberField.Value = li.AccountNumber;
         //noteField.Value = li.Note;

         row++;
      }
   }

}
