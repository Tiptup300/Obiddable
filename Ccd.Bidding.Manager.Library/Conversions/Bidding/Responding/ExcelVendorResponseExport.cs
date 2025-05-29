using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Conversions.Excel;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Conversions.Bidding.Responding
{
   public class ExcelVendorResponseExport : BaseFillableExcelItemsExport
   {
      public const int FIRST_ITEM_ROW = 12;
      public const string WORK_SHEET_NAME = "VendorResponse";

      private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
      private readonly IRequestingRepo _requestItemsRepo = new EFRequestingRepo();

      public ExcelVendorResponseExport(Bid bid)
      {
         _bid = bid;

         items = getRequestedItemsOrderedByCode(_bid);
         PrintedColumns = 13;
         DisplayedColumns = 13;
         FirstItemRow = FIRST_ITEM_ROW;
         WorkSheetName = WORK_SHEET_NAME;
         Orientation = eOrientation.Landscape;
      }

      private List<Item> getRequestedItemsOrderedByCode(Bid bid)
          => _catalogingRepo.GetItems(bid.Id)
              .RequestedOnly(_requestItemsRepo)
              .OrderBy(x => x.Code)
              .ToList();

      #region PRINT
      public override void SetHeader(ExcelWorksheet ws)
      {
         ws.HeaderFooter.OddHeader.LeftAlignedText = $"{_bid} ";
         ws.HeaderFooter.OddHeader.CenteredText = $"HOLLIDAYSBURG AREA SCHOOL DISTRICT\r\n{_bid.Name}\r\nVendor Response";
         ws.HeaderFooter.OddHeader.RightAlignedText = $"";
      }
      public override void SetColumns(ExcelWorksheet ws)
      {
         int col = 1;
         // set columns
         setColumn(ws, col++, "ITEM\r\nCODE", 8);
         setColumn(ws, col++, "DESCRIPTION", 44);
         setColumn(ws, col++, "VENDOR\r\nPARTNO", 18);
         setColumn(ws, col++, "QTY", 8);
         setColumn(ws, col++, "UNIT", 7);
         setColumn(ws, col++, "UNIT\r\nPRICE", 11);
         setColumn(ws, col++, "EXT\r\nPRICE", 17);
         setColumn(ws, col++, "IS\r\nALT", 0);
         setColumn(ws, col++, "ALT\r\nDESCRIPTION", 33);
         setColumn(ws, col++, "ALT\r\nQTY", 6);
         setColumn(ws, col++, "ALT\r\nUNIT", 9);
         setColumn(ws, col++, "ALT UNIT\r\nPRICE", 11);
         setColumn(ws, col++, "ALT EXT\r\nPRICE", 17);

         ws.Row(1).Height = 39;
         //ws.Column(4).BorderRight(ExcelBorderStyle.Thick);
      }
      public override void SetSummaryLines(ExcelWorksheet ws)
      {
         // summary line
         var summaryLineLabel = setSummaryLineHeader(ws, 7, 2, 7, " VENDOR RESPONSE SUMMARY");
         // non-alt
         var nonAltTotalLabel = setSummaryLineLabel(ws, 8, 2, 6, "NON-ALT TOTAL: ");
         var nonAltTotalField = setSummaryLineField(ws, 8, 7, $"SUM(G{FirstItemRow}:G{lastItemRow})");
         // alt
         var altTotalLabel = setSummaryLineLabel(ws, 9, 2, 6, "ALT TOTAL: ");
         var altTotalField = setSummaryLineField(ws, 9, 7, $"SUM(M{FirstItemRow}:M{lastItemRow})");
         // grand
         var grantTotalLabel = setSummaryLineLabel(ws, 10, 2, 6, "GRAND TOTAL: ");
         var grantTotalField = setSummaryLineField(ws, 10, 7, $"{nonAltTotalField.Address}+{altTotalField.Address}");

         var summaryBottomLine = ws.Cells[11, 1, 11, 13];
         summaryBottomLine.BorderBottom(ExcelBorderStyle.Thick);
      }
      public override void SetTopInputs(ExcelWorksheet ws)
      {
         var vendorNameLabel = setTopInputLabel(ws, 3, 2, "VENDOR NAME: ");
         var vendorNameField = setTopInputField(ws, 3, 3, 7);

         var bidTotalLabel = setTopInputLabel(ws, 5, 2, "BID TOTAL: ");
         var bidTotalField = setTopInputField(ws, 5, 3, 7);
      }
      public override void SetItems(ExcelWorksheet ws)
      {
         int row = FirstItemRow;
         foreach (Item i in items)
         {
            var codeField = ws.Cells[row, 1];
            var descField = ws.Cells[row, 2];
            var vendorPartNumberField = ws.Cells[row, 3];
            var qtyField = ws.Cells[row, 4];
            var unitField = ws.Cells[row, 5];
            var priceField = ws.Cells[row, 6];
            var extendedPriceField = ws.Cells[row, 7];
            var isAltField = ws.Cells[row, 8];
            var altDescriptionField = ws.Cells[row, 9];
            var altQuantityField = ws.Cells[row, 10];
            var altUnitField = ws.Cells[row, 11];
            var altPriceField = ws.Cells[row, 12];
            var altExtensionPriceField = ws.Cells[row, 13];

            var altFields = ws.Cells[row, 8, row, 13];
            var allFields = ws.Cells[row, 1, row, 13];

            //item code
            codeField.Value = i.FormattedCode;
            codeField.Top().Left();
            codeField.LockField();

            // description
            descField.Value = i.Description.Trim() + (!i.Substitutable ? $"\r\nNO SUBSTITUTIONS" : "");
            descField.Top().Left().WrapText();
            descField.LockField();

            // qty requested
            qtyField.Value = i.GetRequestedQuantity(_requestItemsRepo);
            qtyField.Top().Right();
            qtyField.LockField();

            // unit
            unitField.Value = i.Unit;
            unitField.Top().Left();
            unitField.LockField();

            // vendorPartNumber
            vendorPartNumberField.Value = null;
            vendorPartNumberField.Top().Left();
            vendorPartNumberField.UnlockField();
            vendorPartNumberField.MustBeStringUnderLength(255);

            // priceToEnter
            priceField.Value = null;
            priceField.Top().Right().Format("0.0000");
            priceField.UnlockField();
            priceField.MustBePositiveDecimal();
            setPriceErrorConditionalFormatting(priceField, priceField, isAltField);
            setPriceCompleteConditionalFormatting(priceField, priceField, isAltField);

            // extendedPriceField
            extendedPriceField.Formula = $"IF({isAltField.Address}=TRUE,IF(NOT(ISBLANK({priceField.Address})),\"(ERR: CLEAR ALT >>>)\",\"\"),IF({priceField.Address}=\"\",\"\",{priceField.Address}*{qtyField.Address}))";
            extendedPriceField.Top().Right().Bold();
            extendedPriceField.Format("0.00");
            extendedPriceField.LockField();
            setPriceErrorConditionalFormatting(extendedPriceField, priceField, isAltField);

            // Is Alt Indicator
            isAltField.Formula = $"IF(NOT(AND(ISBLANK({altDescriptionField.Address}),ISBLANK({altQuantityField.Address}),ISBLANK({altPriceField.Address}),ISBLANK({altUnitField.Address}))),TRUE,\"\")";
            isAltField.Top().Center();
            isAltField.LockField();
            setAltErrorConditionalFormatting(isAltField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            // Alt Description
            altDescriptionField.Value = null;
            altDescriptionField.Top().Left().WrapText();
            altDescriptionField.UnlockField();
            altDescriptionField.MustBeStringUnderLength(255);
            setAltCompleteConditionalFormatting(altDescriptionField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);
            setAltErrorConditionalFormatting(altDescriptionField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            // Alt Quantity
            altQuantityField.Value = null;
            altQuantityField.Top().Right();
            altQuantityField.Format("0.00");
            altQuantityField.UnlockField();
            altQuantityField.MustBePositiveDecimal();
            setAltCompleteConditionalFormatting(altQuantityField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);
            setAltErrorConditionalFormatting(altQuantityField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            // Alt Price
            altPriceField.Value = null;
            altPriceField.Top().Right();
            altPriceField.Format("0.0000");
            altPriceField.UnlockField();
            altPriceField.MustBePositiveDecimal();
            setAltCompleteConditionalFormatting(altPriceField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);
            setAltErrorConditionalFormatting(altPriceField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            // Alt Unit
            altUnitField.Value = null;
            altUnitField.Top().Left();
            altUnitField.UnlockField();
            altUnitField.MustBeStringUnderLength(255);
            setAltCompleteConditionalFormatting(altUnitField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);
            setAltErrorConditionalFormatting(altUnitField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            // Alt Extended Price
            altExtensionPriceField.Formula = $"" +
                $"IF(" +
                    $"{isAltField.Address}=TRUE," +
                    $"IF(" +
                         $"ISBLANK({priceField.Address})," +
                        $"IF( " +
                            $"OR(ISBLANK({altDescriptionField.Address}),ISBLANK({altQuantityField.Address}),ISBLANK({altPriceField.Address}),ISBLANK({altUnitField.Address}))," +
                            $"\"(<<< INCOMPLETE)\"," +
                            $"{altQuantityField.Address}*{altPriceField.Address}" +
                        $")," +
                        $"\"(<<< CLEAR ALT)\"" +
                    $")," +
                    $"\"\"" +
                $")";
            altExtensionPriceField.Top().Right().Bold();
            altExtensionPriceField.Format("0.00");
            altExtensionPriceField.LockField();
            setAltErrorConditionalFormatting(altExtensionPriceField, isAltField, altDescriptionField, altQuantityField, altPriceField, altUnitField, priceField);

            row++;
         }
      }
      private void setPriceErrorConditionalFormatting(ExcelRange c, ExcelRange priceField, ExcelRange isAltField)
      {
         var errorConditionalFormatting = c.ConditionalFormatting.AddExpression();
         errorConditionalFormatting.Formula = $"AND({isAltField.Address}=TRUE,NOT(ISBLANK({priceField.Address})))";
         errorConditionalFormatting.Style.Fill.BackgroundColor.Color = Color.IndianRed;
         errorConditionalFormatting.Style.Font.Color.Color = Color.DarkRed;
      }
      private void setPriceCompleteConditionalFormatting(ExcelRange c, ExcelRange priceField, ExcelRange isAltField)
      {

         var completeConditionalFormatting = c.ConditionalFormatting.AddExpression();
         completeConditionalFormatting.Formula = $"NOT(OR({priceField.Address}=FALSE,ISBLANK({priceField.Address}),{priceField.Address}=\"\"))";
         completeConditionalFormatting.Style.Fill.BackgroundColor.Color = Color.LightGoldenrodYellow;
         completeConditionalFormatting.Style.Font.Color.Color = Color.Black;
      }
      private void setAltCompleteConditionalFormatting(ExcelRange c, ExcelRange isAltField, ExcelRange altDescriptionField, ExcelRange altQuantityField, ExcelRange altPriceField, ExcelRange altUnitField, ExcelRange priceField)
      {
         var completeConditionalFormatting = c.ConditionalFormatting.AddExpression();
         completeConditionalFormatting.Formula = $"" +
                 $"IF(" +
                     $"{isAltField.Address}=TRUE," +
                     $"IF(" +
                          $"ISBLANK({priceField.Address})," +
                         $"IF( " +
                             $"OR(ISBLANK({altDescriptionField.Address}),ISBLANK({altQuantityField.Address}),ISBLANK({altPriceField.Address}),ISBLANK({altUnitField.Address}))," +
                             $"FALSE," +
                             $"TRUE" +
                         $")," +
                         $"FALSE" +
                     $")," +
                     $"FALSE" +
                 $")";
         completeConditionalFormatting.Style.Fill.BackgroundColor.Color = Color.LightGoldenrodYellow;
      }
      private void setAltErrorConditionalFormatting(ExcelRange c, ExcelRange isAltField, ExcelRange altDescriptionField, ExcelRange altQuantityField, ExcelRange altPriceField, ExcelRange altUnitField, ExcelRange priceField)
      {
         var errorConditionalFormatting = c.ConditionalFormatting.AddExpression();
         errorConditionalFormatting.Formula = $"" +
                 $"IF(" +
                     $"{isAltField.Address}=TRUE," +
                     $"IF(" +
                          $"ISBLANK({priceField.Address})," +
                         $"IF( " +
                             $"OR(ISBLANK({altDescriptionField.Address}),ISBLANK({altQuantityField.Address}),ISBLANK({altPriceField.Address}),ISBLANK({altUnitField.Address}))," +
                             $"TRUE," +
                             $"FALSE" +
                         $")," +
                         $"TRUE" +
                     $")," +
                     $"FALSE" +
                 $")";


         errorConditionalFormatting.Style.Fill.BackgroundColor.Color = Color.IndianRed;
         errorConditionalFormatting.Style.Font.Color.Color = Color.DarkRed;
      }
      #endregion
   }

}
