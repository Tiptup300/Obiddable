using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Library.EF.Bidding.Responding;
using Obiddable.Library.Formatting;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding.Electings;
/// <summary>
/// sheet that very closely resembles Bid tally with room for users to add notes about what they selected, also should show full information on vendors alt description
/// </summary>
public class ElectionConfirmationSheetReportBuilder : BidHtmlReportBuilder
{
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

   private int _lines = 0;
   private int pageNumber = 1;
   private int safeLinesPerPage = 57;
   private int linesPerPage = 60;

   private int ColumnCount = 10;

   protected override string Title => "Election Confirmation Sheet";
   protected override string StyleName => "Reports.ElectionConfirmationSheet.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public ElectionConfirmationSheetReportBuilder() : base()
   {
   }

   #region REPORTING
   public override string GenerateTableData(Bid Bid)
   {
      StringBuilder t = new StringBuilder();
      List<ResponseItem> responseItems = _respondingRepo.GetResponseItems_ByBid(Bid.Id).OrderBy(x => x.Item.Code).ToList();
      List<Item> items = _requestingRepo.GetItems_Requested_ByBid(Bid.Id).Where(x => responseItems.Any(y => y.Item.Id == x.Id)).OrderBy(x => x.Code).ToList();

      PrintFirstPageNumber(t);
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
            PrintSpacerRow(t);
         }

         foreach (Item i in categoryItems)
         {
            List<ResponseItem> itemResponses = responseItems.Where(x => x.Item.Id == i.Id).OrderBy(x => x.GetExtendedPrice(_requestingRepo)).ToList();

            int rowspan = Math.Max(itemResponses.Count + itemResponses.Where(x => x.IsAlternate).Count(), 1);
            string[] descriptionLines = SplitStringToLines(i.Description.Trim().Replace("\r\n", "<br />"));


            t.AppendLine($"<tr class='responseRow'>");
            t.AppendLine($"  <td class='itemCode' rowspan='{rowspan}'><span class='clip'>{i.GetFormattedCode()}</span></td>");
            t.AppendLine($"  <td class='itemDescription' rowspan='{rowspan}'>{string.Join("<br />", descriptionLines)}</td>");

            ResponseItem electedResponseItem = null;

            for (int responseIndex = 0; responseIndex < itemResponses.Count; responseIndex++)
            {
               ResponseItem ri = itemResponses[responseIndex];

               string electedClass = "";
               if (ri.Elected)
               {
                  electedResponseItem = ri;
                  electedClass = " electedResponse ";
               }
               else
               {
                  electedResponseItem = null;
               }

               if (responseIndex > 0)
               {
                  t.AppendLine($"<tr class='responseRow'>");
               }

               t.AppendLine($"     <td class='{electedClass} vendorName ' ><span class='clip'>{ri.VendorResponse.VendorName}</span></td>");
               t.AppendLine($"     <td class='{electedClass} partNumber ' ><span class='clip'>{ri.Code}</span></td>");
               t.AppendLine($"     <td class='{electedClass} quantityResponded' >{ri.Get_Quantity(_requestingRepo).ToString("0.00")}</td>");
               t.AppendLine($"     <td class='{electedClass} alt {(ri.IsAlternate ? "bold" : "")}'  ><span class='clip'>{(ri.IsAlternate ? "*" : "")}</span></td>");
               t.AppendLine($"     <td class='{electedClass} unit'  ><span class='clip'>{(ri.IsAlternate ? ri.AlternateUnit : ri.Item.Unit)}</span></td>");
               t.AppendLine($"     <td class='{electedClass} unitPrice' >{ri.Price.ToString("0.0000")}</td>");
               t.AppendLine($"     <td class='{electedClass} extendedPrice' >{ri.GetExtendedPrice(_requestingRepo).ToString("$0.00")}</td>");
               t.AppendLine($"     <td class='checkBox' ><div>&nbsp;</div></td>");
               t.AppendLine($"</tr>");

               if (ri.IsAlternate && ri.AlternateDescription.Trim() != "")
               {
                  t.AppendLine($"<tr>");
                  t.AppendLine($"  <td colspan='8' class='{electedClass} alternateDescription'><b>*</b>{ri.AlternateDescription.Trim().Replace("\r\n", "<br />")}</td>");
                  t.AppendLine($"</tr>");
               }


            }
            switch (itemResponses.Count)
            {
               case 1:
                  t.AppendLine($"</tr>");
                  break;
            }

            PrintSpacerRow(t);
            if (electedResponseItem != null && electedResponseItem.Elected)
            {
               PrintElectionReasonRow(t, electedResponseItem.ElectionReason);
            }
            PrintReasonForChangeRow(t);
            PrintSpacerRow(t);

            AddLines(t, 23);
            CheckAheadForPageBreak(t, 0);
         }
      }
      PrintTotalsRow(t, items.Count);
      EndTable(t);

      return t.ToString();
   }

   private void PrintCoverPage(StringBuilder t)
   {
      t.Append($"<pre>");
      //_____________0        1        2        3        4        5        6        7        8        9       10       11       12       13       14       15       16     ");
      //_____________012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345679012345");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($" =================================                                                                                                                    ");
      t.AppendLine($"    ELECTION CONFIRMATION SHEET                                                                                                                       ");
      t.AppendLine($" =================================                                                                                                                    ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"    Instructions:                                                                                                                                     ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"       The lowest vendor response is reflected in bold print for each item.                                                                           ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"       For EVERY item, place a check mark in the box provided to the right of the vendor you are                                                      ");
      t.AppendLine($"       selecting including if you are selecting the highlighted lowest vendor response.                                                               ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"       - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -                                                ");
      t.AppendLine($"       -                                                                                             -                                                ");
      t.AppendLine($"       -   Please note that if you are selecting a vendor other than the highlighted lowest vendor   -                                                ");
      t.AppendLine($"       -   response, you MUST provide a detailed justification under the last vendor response in     -                                                ");
      t.AppendLine($"       -   the area marked 'Reason for Change'.                                                      -                                                ");
      t.AppendLine($"       -                                                                                             -                                                ");
      t.AppendLine($"       - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -                                                ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"                                                                                                                                                      ");
      t.AppendLine($"    Notes:                                                                                                                                            ");
      t.Append($"</pre>");
   }

   private void PrintFirstPageNumber(StringBuilder t)
   {
      t.Append("<pre>");
      t.AppendLine($"Name:_______________________________                                                                                                          Page  {pageNumber++.ToString("00")}");
      t.AppendLine("");
      t.Append("</pre>");
   }
   #endregion


   #region REPORT SPECIFIC
   private void PrintColumnHeaderRow(StringBuilder t, string categoryKey)
   {
      t.AppendLine($"<tr><td class='category-row' colspan='{ColumnCount}'>{categoryKey}</td></tr>");
      AddLines(t, 3);
   }
   private void PrintTotalsRow(StringBuilder t, int totalCount_Items)
   {
      t.AppendLine($"         <tr class='final-totals'>");
      t.AppendLine($"             <th colspan='{ColumnCount}'>Total Items: {totalCount_Items.ToString("0")}</th>");
      t.AppendLine($"         </tr>");
   }
   private void PrintReasonForChangeRow(StringBuilder t)
   {
      t.AppendLine($"<tr class='reasonForChange'><td colspan='{ColumnCount}'>Reason For Change:</td></tr>");
   }
   private void PrintElectionReasonRow(StringBuilder t, string electionReason)
   {
      t.AppendLine($"<tr class='electionReason'><td colspan='{ColumnCount}9'><span class='clip'>Election Reason: {electionReason}</span></td></tr>");
   }
   #endregion

   #region 
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
      t.AppendLine($"         <th class='itemCode'>Item<br />Code</th>");
      t.AppendLine($"         <th class='itemDescription'>Item<br />Description</th>");
      t.AppendLine($"         <th class='vendorName'>Vendor Name</th>");
      t.AppendLine($"         <th class='partNumber'>Part Number</th>");
      t.AppendLine($"         <th class='quantityResponded'>QTY</th>");
      t.AppendLine($"         <th class='alt'>&nbsp;</th>");
      t.AppendLine($"         <th class='unit'>Unit</th>");
      t.AppendLine($"         <th class='unitPrice'>Unit Price</th>");
      t.AppendLine($"         <th class='extendedPrice'>Ext<br/>Price</th>");
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
      t.AppendLine($"Name: ______________________________                                                                                                          Page  {pageNumber++.ToString("00")}");
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

}
