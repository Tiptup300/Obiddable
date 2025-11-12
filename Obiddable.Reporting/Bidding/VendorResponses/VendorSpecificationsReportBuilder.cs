using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding.VendorResponses;
public class VendorSpecificationsReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();

   private int _lines = 0;
   private int pageNumber = 1;
   private int safeLinesPerPage = 60;
   private int linesPerPage = 60;

   private int ColumnCount = 6;

   protected override string Title => "Vendor Specifications";
   protected override string StyleName => "Reports.VendorSpecifications.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public VendorSpecificationsReportBuilder() : base()
   {
   }

   #region REPORTING
   public override string GenerateTableData(Bid Bid)
   {
      StringBuilder t = new StringBuilder();
      List<Requestor> requestors = _requestingRepo.GetRequestors_ByBid(Bid.Id).Where(x => x.QuantitySum() > 0).ToList();
      List<Item> items = _requestingRepo.GetItems_Requested_ByBid(Bid.Id);

      PrintCoverPage(t);
      PageBreak(t);
      StartTable(t);
      foreach (var category in items.OrderBy(x => x.Category).GroupBy(x => x.Category).ToList())
      {
         var categoryItems = category.OrderBy(x => x.Code);

         if (category.Key != "")
         {
            // see if we're already half way through the page before starting next category
            CheckAheadForPageBreak(t, linesPerPage / 2);
            PrintColumnHeaderRow(t, category.Key);
            PrintSpacerRow(t);
         }
         foreach (Item i in categoryItems)
         {
            CheckAheadForPageBreak(t, SplitStringToLines(i.Description.Trim().Replace("\r\n", "<br />") + (!i.Substitutable ? $"<br /><b>NO SUBSTITUTIONS</b>" : "")).Length + 1 + 1 + 2);
            PrintItemInformationRow(t, i);
            PrintSpacerRow(t);
            PrintAlternateInformationRow(t);
            PrintSpacerRow(t);
         }
      }
      PrintSpacerRow(t);
      PrintTotalRow(t, items);
      PrintSpacerRow(t);
      EndTable(t);

      return t.ToString();
   }
   #endregion

   #region STRUCTURE
   private void StartTable(StringBuilder t)
   {
      t.Append("<table>");
      PrintHeaders(t);
      t.Append("<tbody>");
      PrintSpacerRow(t);
   }
   private void PrintHeaders(StringBuilder t)
   {
      t.AppendLine($" <thead>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th class='itemCode'>Item<br/>Code</th>");
      t.AppendLine($"         <th class='itemDescription'>Item Description</th>");
      t.AppendLine($"         <th class='totalQuantity'>Quantity</th>");
      t.AppendLine($"         <th class='unitPrice'>Unit<br />Price</th>");
      t.AppendLine($"         <th class='unit'>&nbsp;</th>");
      t.AppendLine($"         <th class='extension'>Ext<br/>Price</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($" </thead>");
      AddLines(t, 3);
   }
   private void PrintSpacerRow(StringBuilder t)
   {
      t.AppendLine($"<tr><td class='spacerRow' colspan='{ColumnCount}'>&nbsp;</td></tr>");
      AddLines(t, 1);
   }
   private void EndTable(StringBuilder t)
   {

      t.AppendLine("</tbody>");
      t.AppendLine("</table>");
   }
   #endregion

   #region PAGEBREAKS
   private void PageBreak(StringBuilder t)
   {
      t.Append("<pre style='page-break-before:always;'>");
      t.AppendLine($"Vendor Name: _______________________                                                                                                          Page  {pageNumber++.ToString("00")}");
      t.AppendLine("");
      t.Append("</pre>");
      _lines = 2;
   }
   private void CheckAheadForPageBreak(StringBuilder t, int lines)
   {
      if (_lines + lines > safeLinesPerPage)
      {
         EndTable(t);
         PageBreak(t);
         StartTable(t);
      }
   }
   private void AddLines(StringBuilder t, int lines)
   {
      _lines += lines;
      t.Append($"<!-- +{lines} = {_lines} -->");
   }
   #endregion

   #region REPORT SPECIFIC
   private void PrintCoverPage(StringBuilder t)
   {
      t.Append($"<pre>");
      //_____________0        1        2        3        4        5        6        7        8        9       10       11       12       13       14       15       16     ");
      //_____________012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . .  COMPANY: _________________________     :: BID TOTAL: ______________________________________  ::  ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . .  ADDRESS: _________________________                                                               ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . .  . . . .  _________________________                                                               ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . .  . . . .  _________________________                                                               ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . .  TELEPHONE: _________________________                                                               ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . . . .  FAX: _________________________                                                               ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . . .  EMAIL: _________________________                                                               ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . .  VENDOR BID REFERENCE #: _________________________      :: SIGNATURE: ______________________________________  ::  ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . .  PRINTED NAME: _________________________      ::      DATE: ______________________________________  ::  ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"  . .  QUESTIONS CONCERNING THIS BID SHOULD BE ADDRESSED TO: _________________________                                                                ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . . . . . . . .  ( NAME, PHONE, & EMAIL  )                                                                ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"  . PURCHASE ORDERS SHOULD BE (PLEASE CHECK): ☐  MAILED TO: _________________________                                                                ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . ☐ EMAILED TO: _________________________                                                                ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . .   ☐   FAXED TO: _________________________                                                                ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"  . . . .  BID TABS SHOULD BE (PLEASE CHECK): ☐  MAILED TO: _________________________                                                                ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . . . ☐ EMAILED TO: _________________________                                                                ");
      t.AppendLine($"  . .                                                                                                                                                 ");
      t.AppendLine($"  . . . . . . . . . . . . . . . . . . . . .   ☐   FAXED TO: _________________________                                                                ");
      t.Append($"</pre>");

      //

   }
   private void PrintColumnHeaderRow(StringBuilder t, string categoryKey)
   {
      t.AppendLine($"<tr><td class='category-row' colspan='{ColumnCount}'>{categoryKey}</td></tr>");
      AddLines(t, 3);
   }
   private void PrintItemInformationRow(StringBuilder t, Item i)
   {
      // item description along with NO SUB message
      string descriptionText = i.Description.Trim().Replace("\r\n", "<br />") + (!i.Substitutable ? $"<br /><b>NO SUBSTITUTIONS</b>" : "");
      string[] descriptionLines = SplitStringToLines(descriptionText);

      t.AppendLine($"<tr class='itemInformationRow'>");
      t.AppendLine($"     <td class='itemCode'>{i.FormattedCode}</td>");
      t.AppendLine($"     <td class='itemDescription'><span class='wrap'>{string.Join("<br />", descriptionLines)}</span></td>");
      t.AppendLine($"     <td class='totalQuantity'>{i.GetRequestedQuantity(_requestingRepo).ToString("0.00")}</td>");
      t.AppendLine($"     <td class='unitPrice' colspan='1'>{new string('_', 8)}</td>");
      t.AppendLine($"     <td class='unit' colspan='1'>{i.Unit}</td>");
      t.AppendLine($"     <td class='extension' colspan='1'>{new string('_', 8)}</td>");
      t.AppendLine($"</tr>");

      AddLines(t, descriptionLines.Length);
   }
   private void PrintAlternateInformationRow(StringBuilder t)
   {
      t.AppendLine($" <tr>");
      t.AppendLine($"     <td class='alternateInformation' colspan='{ColumnCount}'>");
      t.AppendLine($"         <span class='leftAlternate'>Alternate: {new string('_', 70)}</span>");
      t.AppendLine($"         <span class='rightAlternate'>(Quantity/Unit Price/Unit/Ext): {new string('_', 8)} {new string('_', 8)} {new string('_', 6)} {new string('_', 8)}</span>");
      t.AppendLine($"     </td>");
      t.AppendLine($" </tr>");
      AddLines(t, 2);
   }
   private void PrintTotalRow(StringBuilder t, List<Item> items)
   {
      t.AppendLine($" <tr class='final-total'>");
      t.AppendLine($"     <td colspan='{ColumnCount}'>Total Number of Items: {items.Count}</td>");
      t.AppendLine($" </tr>");
      AddLines(t, 2);
   }
   #endregion
}
