using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables;
public abstract class TableHtmlReportBuilder
{
   private const int SafeLinesPerPage = 57;
   private const int LinesPerPage = 60;
   private int _lineCount;
   private int _pageCount;
   private StringBuilder _out;
   private Table _table;
   protected TableHtmlReportBuilder(Table table)
   {
      _out = new StringBuilder();
      _table = table;

      resetLineCount();
      resetPageCount();
   }
   private void resetLineCount() => _lineCount = 0;
   private void resetPageCount() => _pageCount = 1;


   protected void IncrementLineCount(int amount)
   {
      _lineCount += amount;
      _out.Append($"<!-- +{amount} = {_lineCount} -->");
   }
   protected void PrintSpacerRow()
   {
      _out.AppendLine($"<tr><td class='spacerRow' colspan='{_table.Headers.Count}'>&nbsp;</td></tr>");
      IncrementLineCount(1);
   }


   protected void PrintCoverPage()
   {
      if (_table.CoverPage is EmptyCoverPage)
      {
         return;
      }
      writeCoverPage(_table.CoverPage.Lines);
      printPageBreak();
   }
   private void writeCoverPage(IEnumerable<string> coverPageLines)
   {
      _out.Append($"<pre>");
      _out.Append(coverPageLines);
      _out.Append($"</pre>");
   }


   protected void PrintRow(Row row)
   {
      int rowLineHeight;

      rowLineHeight = row.LineHeight;
      if (willPageBreak(rowLineHeight))
      {
         printPageBreak();
      }
   }

   private bool willPageBreak(int rowLineHeight)
       => _lineCount + rowLineHeight > SafeLinesPerPage;

   private void printPageBreak()
   {
      int characterRowWidth = 156;
      string paddedBreakHeader;
      string fullHeaderLine;

      paddedBreakHeader = padLeftHeaderLine(_table.PageBreakHeader.Line, characterRowWidth);
      fullHeaderLine = buildHeaderLine(paddedBreakHeader);
      writePageBreakHeader(fullHeaderLine);
      incrementPageCount(1);
      resetLineCount();
      IncrementLineCount(2);
   }
   private string padLeftHeaderLine(string headerLine, int characterRowWidth)
   {
      string output;
      int headerLineWidth;

      headerLineWidth = headerLine.Length;
      if (headerLineWidth > characterRowWidth)
      {
         throw new Exception($"Page Break Header Line Cannot Exceed Width Of {characterRowWidth} characters.");
      }
      output = headerLine.PadRight(characterRowWidth, ' ');

      return output;
   }
   private string buildHeaderLine(string paddedBreakHeader)
       => $"{paddedBreakHeader}Page  {_pageCount++.ToString("00")}";
   private void writePageBreakHeader(string fullHeaderLine)
   {
      _out.Append("<pre style='page-break-before:always;'>");
      _out.AppendLine(fullHeaderLine);
      _out.AppendLine("");
      _out.Append("</pre>");
   }
   private void incrementPageCount(int amount)
       => _pageCount += amount;


   protected void StartTable()
   {
      writeTableStart();
      printHeaders();
      writeBodyStart();
      PrintSpacerRow();
   }
   private void writeTableStart()
       => _out.Append("<table>");
   private void printHeaders()
   {
      writeHeaders(_table.Headers.Headers);
      IncrementLineCount(_table.Headers.LineHeight);
   }
   private void writeHeaders(IEnumerable<Header> headers)
   {
      _out.AppendLine($" <thead>");
      _out.AppendLine($"     <tr>");
      foreach (Header header in headers)
      {
         _out.AppendLine($"         <th class='{header.Class}'>{header.Title}</th>");
      }
      _out.AppendLine($"     </tr>");
      _out.AppendLine($" </thead>");
   }
   private void writeBodyStart()
       => _out.Append("<tbody>");
}
