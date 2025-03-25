using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.FormulaParsing.Utilities;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;

namespace Ccd.Bidding.Manager.Library.Conversions.Excel
{
    public abstract class BaseFillableExcelItemsExport : IExcelExport
    {
        public string WorkSheetName;
        public string Title;
        public eOrientation Orientation;

        public List<Item> items;
        public Bid _bid;

        public int PrintedColumns;
        public int DisplayedColumns;
        public int FirstItemRow;
        public string Password;
        public int lastItemRow { get { return FirstItemRow + items.Count - 1; } }


        public MemoryStream Generate()
        {
            MemoryStream stream = new MemoryStream();
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(WorkSheetName);

                // sheet operations
                SetPrinterSettings(ws);
                HideExtraColumns(ws);
                LockAllCells(ws);
                SetProtection(ws);

                // printing data
                SetHeader(ws);
                PrintTopOfForm(ws);
                SetItems(ws);

                // protect, calculate, & save
                package.Workbook.Calculate();
                if (string.IsNullOrEmpty(Password))
                {
                    package.SaveAs(stream);
                }
                else
                {
                    package.SaveAs(stream, Password);
                }
            }
            return stream;
        }

        #region SHEET OPERATIONS
        private void SetPrinterSettings(ExcelWorksheet ws)
        {
            // print area
            ws.PrinterSettings.PrintArea = ws.Cells[1, 1, lastItemRow, PrintedColumns];

            // margins
            ws.PrinterSettings.HeaderMargin = 0.25M;
            ws.PrinterSettings.FooterMargin = 0.25M;
            ws.PrinterSettings.TopMargin = 1M;
            ws.PrinterSettings.LeftMargin = 0.25M;
            ws.PrinterSettings.RightMargin = 0.25M;
            ws.PrinterSettings.BottomMargin = 0.5M;

            // other page settings
            ws.PrinterSettings.FitToPage = true;
            ws.PrinterSettings.FitToWidth = 1;
            ws.PrinterSettings.FitToHeight = 0;
            ws.PrinterSettings.HorizontalCentered = true;
            ws.PrinterSettings.Orientation = Orientation;
            ws.PrinterSettings.RepeatRows = new ExcelAddress("1:1");

            // view
            ws.View.FreezePanes(2, 1);

            // header footer
            ws.HeaderFooter.ScaleWithDocument = true;
            ws.HeaderFooter.AlignWithMargins = false;
        }
        private void HideExtraColumns(ExcelWorksheet ws)
        {
            // columns
            var cols = ws.Column(DisplayedColumns + 1);
            cols.ColumnMax = 16384;
            cols.Hidden = true;
        }
        private void LockAllCells(ExcelWorksheet ws)
        {
            ws.Cells.Style.Locked = true;
        }
        private void SetProtection(ExcelWorksheet ws)
        {
            var p = ws.Protection;

            p.AllowAutoFilter = false;
            p.AllowDeleteColumns = false;
            p.AllowDeleteRows = false;
            p.AllowEditObject = false;
            p.AllowEditScenarios = false;
            p.AllowFormatCells = false;
            p.AllowFormatColumns = false;
            p.AllowFormatRows = false;
            p.AllowInsertColumns = false;
            p.AllowInsertHyperlinks = false;
            p.AllowInsertRows = false;
            p.AllowPivotTables = false;
            p.AllowSort = false;
            p.IsProtected = true;
            p.SetPassword("sb");
            p.AllowSelectLockedCells = false;
            p.AllowSelectUnlockedCells = true;
        }
        #endregion

        #region PRINT
        public abstract void SetHeader(ExcelWorksheet ws);
        private void SetFooter(ExcelWorksheet ws)
        {
            ws.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FileName;
            ws.HeaderFooter.OddFooter.CenteredText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            ws.HeaderFooter.OddFooter.RightAlignedText = string.Format("{0} {1}", ExcelHeaderFooter.CurrentDate, ExcelHeaderFooter.CurrentTime);
        }

        private void PrintTopOfForm(ExcelWorksheet ws)
        {
            SetColumns(ws);
            SetSummaryLines(ws);
            SetTopInputs(ws);
        }

        public abstract void SetColumns(ExcelWorksheet ws);
        public void setColumn(ExcelWorksheet ws, int col, string title, double width)
        {
            var c = ws.Cells[1, col];
            // set value
            c.Value = title;
            // style cell
            c.Bold().Bottom().Center().WrapText().Size(12).BorderBottom(ExcelBorderStyle.Thin);
            // column width
            ws.Column(col).Width(width);
        }

        public abstract void SetSummaryLines(ExcelWorksheet ws);
        public ExcelRange setSummaryLineHeader(ExcelWorksheet ws, int row, int colStart, int colEnd, string title)
        {
            var c = ws.Cells[row, colStart, row, colEnd];
            // set value
            c.Value = title;
            // set style
            c.Merge().Left().Middle().Size(12).BorderAroundDark(ExcelBorderStyle.Thin).Bold();
            return c;
        }
        public ExcelRange setSummaryLineLabel(ExcelWorksheet ws, int row, int colStart, int colEnd, string title)
        {
            var c = ws.Cells[row, colStart, row, colEnd];
            // set value
            c.Value = title;
            // set style
            c.Merge().Right().Middle().Size(12).BorderAroundDark(ExcelBorderStyle.Thin);
            return c;
        }
        public ExcelRange setSummaryLineField(ExcelWorksheet ws, int row, int col, string formula)
        {
            var c = ws.Cells[row, col];
            // set formula
            c.Formula = $"{ formula }";
            // set style 
            c.Format("$0.00").Right().Middle().Size(12).BorderAroundDark(ExcelBorderStyle.Thin).BackgroundFillColor(Color.White);

            return c;
        }

        public abstract void SetTopInputs(ExcelWorksheet ws);
        public object setTopInputLabel(ExcelWorksheet ws, int row, int col, string text)
        {
            var c = ws.Cells[row, col];
            // set value
            c.Value = text;
            // style cell
            c.Size(12).Right().Top();
            c.MustBeStringUnderLength(255);
            return c;
        }
        public object setTopInputField(ExcelWorksheet ws, int row, int colFrom, int colTo)
        {
            var c = ws.Cells[row, colFrom, row, colTo];
            // set value
            c.Value = "";
            // style cell
            // input
            c.UnlockField();
            c.Merge().Size(12).Left().Top().BorderAroundDark(ExcelBorderStyle.Thin).BackgroundFillColor(Color.White);
            return c;
        }

        public abstract void SetItems(ExcelWorksheet ws);

        #endregion
    }
}
