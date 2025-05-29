using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting;
using Ccd.Bidding.Manager.Reporting.Bidding;
using Ccd.Bidding.Manager.Reporting.Bidding.Cataloging;
using Ccd.Bidding.Manager.Reporting.Bidding.Electings;
using Ccd.Bidding.Manager.Reporting.Bidding.Requesting;
using Ccd.Bidding.Manager.Reporting.Bidding.VendorResponses;
using Ccd.Bidding.Manager.Win.Library.IO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.Library.UI.Reporting
{
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
         setTitle();
      }

      private void setTitle()
      {
         titleLabel.Text = _bid.Name;
      }

      private void SetReportMenuItemsToDropDown()
      {
         reportsDropdown.DropDownItems.Clear();
         ToolStripMenuItem[] reportMenuItems = getReportMenuItems();
         reportsDropdown.DropDownItems.AddRange(reportMenuItems);
      }

      private ToolStripMenuItem[] getReportMenuItems()
      {
         ToolStripMenuItem[] output = new ToolStripMenuItem[]
         {
                headerMenuItem("Item Reports"),
                reportMenuItem("Bid Items List Report", typeof(ItemsListReportBuilder)),

                headerMenuItem("Bid Request Reports"),
                reportMenuItem("Bid Requestors' Requested Quantities Report", typeof(RequestorQuantitiesReport)),
                reportMenuItem("Bid Requests Detail Report", typeof(RequestsDetailReportBuilder)),
                reportMenuItem("Bid Requests Summary Report", typeof(RequestsSummaryReportBuilder)),
                reportMenuItem("Price Override Report", typeof(PriceOverrideReportBuilder)),
                reportMenuItem("Expenditures by Requestor Report", typeof(ExpendituresByRequestorsReportBuilder)),

                headerMenuItem("Election Process Reports"),
                reportMenuItem("Election Confirmation Sheet Report", typeof(ElectionConfirmationSheetReportBuilder)),
                reportMenuItem("Elected Quantities Discrepancy Report", typeof(ElectedQuantitiesDiscrepancyReport)),
                reportMenuItem("Bid Tally Report", typeof(TallyReportBuilder)),

                headerMenuItem("Vendor Response Reports"),
                reportMenuItem("Vendor Specifications Report", typeof(VendorSpecificationsReportBuilder)),
                reportMenuItem("Vendor Detail Report", typeof(VendorDetailReportBuilder)),
                reportMenuItem("Vendor Detail Report (Elected Only)", typeof(ElectedOnlyVendorDetailReportBuilder)),
                reportMenuItem("Vendor Summary Report", typeof(VendorSummaryReportBuilder)),
                reportMenuItem("No Response Items Report", typeof(NoResponseItemsReportBuilder)),

                headerMenuItem("Totals Reports"),
                reportMenuItem("Bid Summary Report", typeof(SummaryReportBuilder)),
                reportMenuItem("Detailed Distribution Report", typeof(DetailedDistributionReportBuilder))
         };

         return output;
      }
      private ToolStripMenuItem reportMenuItem(string text, Type reportType)
      {
         ToolStripMenuItem output;

         output = new ToolStripMenuItem() { Text = text, Tag = reportType };
         output.Click += ReportMenuItem_Click;

         return output;
      }

      private ToolStripMenuItem headerMenuItem(string text)
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

         checkIfBidHasUnmatchedElectedQuantities();

         runReport(reportType, _bid);
      }

      /// <summary>
      /// This is an implementation in Reports ToolStrip to just check to see if teh bid has any 
      /// unamatched elected quantities since some of the reports will show bad data.
      /// 
      /// This should actually be fixed per report, but that's not doable at this point.
      /// </summary>
      private void checkIfBidHasUnmatchedElectedQuantities()
      {
         if (_bid.HasUnmatchedQuantities(new EFRequestingRepo(), new EFLegacyElectionsRepo()))
         {
            MessageBox.Show($"Bid has mismatched quantities, reports may show incorrectly.{Environment.NewLine}" +
                $"Run Elected Quantities Discrepancy Report to find issue.");
         }
      }

      private void runReport(Type reportType, Bid bid)
      {
         var reportBuilder = getReportBuilder(reportType);
         FileHelpers.SaveReport(reportBuilder.BuildReport(bid), UserConfiguration.Instance.SupressFileLocationSelectDialog);
      }

      private IReportBuilder<Bid> getReportBuilder(Type reportType)
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
}
