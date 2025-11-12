using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Cataloging;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Obiddable.Library.Conversions.Excel;
public class ExcelRequestExport : BaseFillableExcelItemsExport
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();

   Requestor _requestor;

   public const int FIRST_ITEM_ROW = 6;
   public const string DEFAULT_WORK_SHEET_NAME = "Request";

   public ExcelRequestExport(Requestor requestor)
   {
      _bid = requestor.Bid;
      _requestor = requestor;
      items = _catalogingRepo.GetItems(_bid.Id)
          .OrderBy(x => x.Code).ToList();

      PrintedColumns = 7;
      DisplayedColumns = 8;
      FirstItemRow = FIRST_ITEM_ROW;
      WorkSheetName = DEFAULT_WORK_SHEET_NAME;
      Orientation = eOrientation.Portrait;
      Password = requestor.Password;
   }
   public override void SetHeader(ExcelWorksheet ws)
   {
      ws.HeaderFooter.OddHeader.LeftAlignedText = $"{_bid} ";
      ws.HeaderFooter.OddHeader.CenteredText = $"HOLLIDAYSBURG AREA SCHOOL DISTRICT\r\n{_bid.Name}\r\nBid Request";
      ws.HeaderFooter.OddHeader.RightAlignedText = $"{_requestor.Name}";
   }

   public override void SetColumns(ExcelWorksheet ws)
   {
      int col = 1;
      setColumn(ws, col++, "ITEM\r\nCODE", 8);
      setColumn(ws, col++, "DESCRIPTION", 44);
      setColumn(ws, col++, "CATEGORY", 15);
      setColumn(ws, col++, "PRICE", 12);
      setColumn(ws, col++, "UNIT", 8);
      setColumn(ws, col++, "QTY", 9);
      setColumn(ws, col++, "EXT\r\nPRICE", 15);
      setColumn(ws, col++, "", 8);
      setColumn(ws, col++, "ORIG\r\nPRICE", 12);

      ws.Row(1).Height = 39;
   }
   public override void SetSummaryLines(ExcelWorksheet ws)
   {
      var summaryLineLabel = setSummaryLineHeader(ws, 3, 2, 7, " BID REQUEST SUMMARY");

      var bidRequestTotalLabel = setSummaryLineLabel(ws, 4, 2, 6, "BID REQUEST GRAND TOTAL");
      var bidRequestTotalField = setSummaryLineField(ws, 4, 7, $"IF(COUNT(G6:G{lastItemRow})=COUNT(F6:F{lastItemRow}),SUM(G6:G{lastItemRow}),\"(ERROR)\")");

      var invalidCF = bidRequestTotalField.ConditionalFormatting.AddExpression();
      invalidCF.Formula = $"IF(COUNT(G6:G{lastItemRow})=COUNT(F6:F{lastItemRow}),FALSE,TRUE)";
      invalidCF.Style.Fill.BackgroundColor.Color = Color.IndianRed;
      invalidCF.Style.Font.Color.Color = Color.DarkRed;

      var correctCF = bidRequestTotalField.ConditionalFormatting.AddExpression();
      correctCF.Formula = $"IF(AND(COUNT(G6:G{lastItemRow})=COUNT(F6:F{lastItemRow}),SUM(G6:G{lastItemRow})>0),TRUE,FALSE)";
      correctCF.Style.Fill.BackgroundColor.Color = Color.LightGoldenrodYellow;
      correctCF.Style.Font.Color.Color = Color.Black;

      var summaryBottomLine = ws.Cells[5, 1, 5, 7];
      summaryBottomLine.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
   }
   public override void SetTopInputs(ExcelWorksheet ws)
   {
      // TODO - implement requestor budgeted total along with check on if its hitting it
      return;
   }
   public override void SetItems(ExcelWorksheet ws)
   {
      int row = FirstItemRow;
      foreach (Item i in items)
      {
         var itemCodeField = ws.Cells[row, 1];
         var itemDescriptionField = ws.Cells[row, 2];
         var itemCategoryField = ws.Cells[row, 3];
         var itemEstimatedPriceField = ws.Cells[row, 4];
         var itemUnitField = ws.Cells[row, 5];
         var itemRequestedQuantityField = ws.Cells[row, 6];
         var requestExtendedPriceField = ws.Cells[row, 7];
         var blankField = ws.Cells[row, 8];
         var itemOriginalPriceField = ws.Cells[row, 9];


         // Item Code
         itemCodeField.Value = i.FormattedCode;
         itemCodeField.Top().Left();
         itemCodeField.LockField();

         // Item Description
         itemDescriptionField.Value = i.Description.Trim() + (!i.Substitutable ? $"\r\nNO SUBSTITUTIONS" : "");
         itemDescriptionField.Top().Left().WrapText();
         itemDescriptionField.LockField();

         // Item Category
         itemCategoryField.Value = i.Category;
         itemCategoryField.Top().Left().WrapText();
         itemCategoryField.LockField();

         // Estimated Price
         if (i.Price > 0)
         {
            itemEstimatedPriceField.Value = i.Price;
         }
         itemEstimatedPriceField.Top().Right();
         itemEstimatedPriceField.Format("0.0000");
         itemEstimatedPriceField.UnlockField();

         var itemEstimatedPriceFieldCF = itemEstimatedPriceField.ConditionalFormatting.AddExpression();
         itemEstimatedPriceFieldCF.Formula = $"{itemEstimatedPriceField}<>{itemOriginalPriceField}";
         itemEstimatedPriceFieldCF.Style.Fill.BackgroundColor.Color = Color.LightGoldenrodYellow;
         itemEstimatedPriceFieldCF.Style.Font.Color.Color = Color.Black;

         // Item Unit
         itemUnitField.Value = i.Unit;
         itemUnitField.Top().Left();
         itemUnitField.LockField();

         // Item Quantity 
         itemRequestedQuantityField.Value = null;
         itemRequestedQuantityField.Top().Right();
         itemRequestedQuantityField.Format("0.00");
         itemRequestedQuantityField.UnlockField();

         // Entended Price
         requestExtendedPriceField.Formula = $"IF(NOT(ISBLANK({itemRequestedQuantityField})),IF(NOT(ISERR({itemRequestedQuantityField}+1)), IF({itemRequestedQuantityField}>0,IF({itemEstimatedPriceField.Address}*{itemRequestedQuantityField.Address}<>0,{itemEstimatedPriceField.Address}*{itemRequestedQuantityField.Address},\"(INVALID PRICE)\"),\"(INVALID QTY)\"), \"(INVALID QTY)\"),\"\")";
         requestExtendedPriceField.Top().Right(); // $"IF(AND(,),,IF(x,TRUE,FALSE))
         requestExtendedPriceField.Format("0.0000");
         requestExtendedPriceField.LockField();

         // blank
         blankField.LockField();

         // Original Price
         if (i.Price > 0)
         {
            itemOriginalPriceField.Value = i.Price;
         }
         itemOriginalPriceField.Top().Right();
         itemOriginalPriceField.Format("0.0000");
         itemOriginalPriceField.LockField();

         // data validations
         var priceDataValidation = itemEstimatedPriceField.DataValidation.AddCustomDataValidation();
         priceDataValidation.Formula.ExcelFormula = $"({itemEstimatedPriceField}*{itemRequestedQuantityField})>0";
         priceDataValidation.ShowErrorMessage = true;
         priceDataValidation.Error = "Extended Price cannot zero, if the price is blank please estimate a price.";
         priceDataValidation.ErrorStyle = ExcelDataValidationWarningStyle.warning;

         var qtyDataValidationqty = itemRequestedQuantityField.DataValidation.AddCustomDataValidation();
         qtyDataValidationqty.Formula.ExcelFormula = $"({itemEstimatedPriceField}*{itemRequestedQuantityField})>0";
         qtyDataValidationqty.ShowErrorMessage = true;
         qtyDataValidationqty.Error = "Extended Price cannot zero, if the price is blank please estimate a price.";
         qtyDataValidationqty.ErrorStyle = ExcelDataValidationWarningStyle.warning;

         // conditional formatting

         setInvalidQtyConditionalFormatt(ws, itemRequestedQuantityField, itemRequestedQuantityField, itemEstimatedPriceField);
         setCorrectQtyConditionalFormatt(ws, itemRequestedQuantityField, itemRequestedQuantityField, itemEstimatedPriceField);

         setInvalidQtyConditionalFormatt(ws, requestExtendedPriceField, itemRequestedQuantityField, itemEstimatedPriceField);
         setCorrectQtyConditionalFormatt(ws, requestExtendedPriceField, itemRequestedQuantityField, itemEstimatedPriceField);

         row++;
      }
   }

   private void setCorrectQtyConditionalFormatt(ExcelWorksheet ws, ExcelRange c, ExcelRange qtyField, ExcelRange estimatedPriceField)
   {
      var cf = c.ConditionalFormatting.AddExpression();
      cf.Formula = $"IF(NOT(ISBLANK({qtyField})),IF(NOT(ISERR({qtyField}+1)), IF({qtyField}>0,IF({estimatedPriceField.Address}*{qtyField.Address}<>0,TRUE,FALSE),FALSE), FALSE),FALSE)";
      cf.Style.Fill.BackgroundColor.Color = Color.LightGoldenrodYellow;
      cf.Style.Font.Color.Color = Color.Black;
   }

   private void setInvalidQtyConditionalFormatt(ExcelWorksheet ws, ExcelRange c, ExcelRange qtyField, ExcelRange estimatedPriceField)
   {
      var cf = c.ConditionalFormatting.AddExpression();
      cf.Formula = $"IF(NOT(ISBLANK({qtyField})),IF(NOT(ISERR({qtyField}+1)), IF({qtyField}>0,IF({estimatedPriceField.Address}*{qtyField.Address}<>0,FALSE,TRUE),TRUE), TRUE),FALSE)";
      cf.Style.Fill.BackgroundColor.Color = Color.IndianRed;
      cf.Style.Font.Color.Color = Color.DarkRed;
   }
}
