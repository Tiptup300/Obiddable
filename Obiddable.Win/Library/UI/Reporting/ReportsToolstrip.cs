using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Distribution;
using Obiddable.Library.EF.Bidding.Electing;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Reporting;
using Obiddable.Reporting.Bidding;
using Obiddable.Reporting.Bidding.Cataloging;
using Obiddable.Reporting.Bidding.Electings;
using Obiddable.Reporting.Bidding.Requesting;
using Obiddable.Reporting.Bidding.VendorResponses;
using Obiddable.Win.Library.IO;

namespace Obiddable.Win.Library.UI.Reporting;
public partial class ReportsToolstrip : UserControl
{
   private Bid _bid { get; set; }

   public ReportsToolstrip()
   {
      InitializeComponent();
      SetReportMenuItemsToDropDown();
   }

   public void SetBid(Bid bid)
   {
      _bid = bid;
      SetTitle();
   }

   private void SetTitle()
   {
      titleLabel.Text = _bid.Name;
   }

   private void SetReportMenuItemsToDropDown()
   {
      reportsDropdown.DropDownItems.Clear();
      ToolStripMenuItem[] reportMenuItems = GetReportMenuItems();
      reportsDropdown.DropDownItems.AddRange(reportMenuItems);
   }

   private ToolStripMenuItem[] GetReportMenuItems()
   {
      ToolStripMenuItem[] output = new ToolStripMenuItem[]
      {
             HeaderMenuItem("Item Reports"),
             ReportMenuItem("Bid Items List Report", typeof(ItemsListReportBuilder)),

             HeaderMenuItem("Bid Request Reports"),
             ReportMenuItem("Bid Requestors Requested Quantities Report", typeof(RequestorQuantitiesReport)),
             ReportMenuItem("Bid Requests Detail Report", typeof(RequestsDetailReportBuilder)),
             ReportMenuItem("Bid Requests Summary Report", typeof(RequestsSummaryReportBuilder)),
             ReportMenuItem("Price Override Report", typeof(PriceOverrideReportBuilder)),
             ReportMenuItem("Expenditures by Requestor Report", typeof(ExpendituresByRequestorsReportBuilder)),

             HeaderMenuItem("Election Process Reports"),
             ReportMenuItem("Election Confirmation Sheet Report", typeof(ElectionConfirmationSheetReportBuilder)),
             ReportMenuItem("Elected Quantities Discrepancy Report", typeof(ElectedQuantitiesDiscrepancyReport)),
             ReportMenuItem("Bid Tally Report", typeof(TallyReportBuilder)),

             HeaderMenuItem("Vendor Response Reports"),
             ReportMenuItem("Vendor Specifications Report", typeof(VendorSpecificationsReportBuilder)),
             ReportMenuItem("Vendor Detail Report", typeof(VendorDetailReportBuilder)),
             ReportMenuItem("Vendor Detail Report (Elected Only)", typeof(ElectedOnlyVendorDetailReportBuilder)),
             ReportMenuItem("Vendor Summary Report", typeof(VendorSummaryReportBuilder)),
             ReportMenuItem("No Response Items Report", typeof(NoResponseItemsReportBuilder)),

             HeaderMenuItem("Totals Reports"),
             ReportMenuItem("Bid Summary Report", typeof(SummaryReportBuilder)),
             ReportMenuItem("Detailed Distribution Report", typeof(DetailedDistributionReportBuilder))
      };

      return output;
   }
   private ToolStripMenuItem ReportMenuItem(string text, Type reportType)
   {
      ToolStripMenuItem output;

      output = new ToolStripMenuItem() { Text = text, Tag = reportType };
      output.Click += ReportMenuItem_Click;

      return output;
   }

   private ToolStripMenuItem HeaderMenuItem(string text)
   {
      ToolStripMenuItem output;

      output = new ToolStripMenuItem() { Text = $"-{text}-", ForeColor = SystemColors.ControlDarkDark, Enabled = false };

      return output;
   }

   private void ReportMenuItem_Click(object sender, EventArgs e)
   {
      if (_bid == null)
      {
         return;
      }
      var reportType = (Type)((ToolStripMenuItem)sender).Tag;

      CheckIfBidHasUnmatchedElectedQuantities();

      RunReport(reportType, _bid);
   }

   /// <summary>
   /// This is an implementation in Reports ToolStrip to just check to see if teh bid has any 
   /// unamatched elected quantities since some of the reports will show bad data.
   /// 
   /// This should actually be fixed per report, but that's not doable at this point.
   /// </summary>
   private void CheckIfBidHasUnmatchedElectedQuantities()
   {
      if (_bid.HasUnmatchedQuantities(new EFRequestingRepo(), new EFLegacyElectionsRepo()))
      {
         MessageBox.Show($"Bid has mismatched quantities, reports may show incorrectly.{Environment.NewLine}" +
             $"Run Elected Quantities Discrepancy Report to find issue.");
      }
   }

   private void RunReport(Type reportType, Bid bid)
   {
      var reportBuilder = GetReportBuilder(reportType);
      FileHelpers.SaveReport(reportBuilder.BuildReport(bid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
   }

   private IReportBuilder<Bid> GetReportBuilder(Type reportType)
   {
      IReportBuilder<Bid> output;

      if (reportType is null)
      {
         throw new Exception("Type must be set on reportType");
      }
      output = (IReportBuilder<Bid>)Activator.CreateInstance(reportType);

      return output;
   }
}
