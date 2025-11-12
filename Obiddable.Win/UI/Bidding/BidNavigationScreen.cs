using Obiddable.Library.Bidding;
using Obiddable.Library.EF.Bidding;
using Obiddable.Win.Library;
using Obiddable.Win.Library.Operations.UI;
using Obiddable.Win.Library.UI;
using Obiddable.Win.UI.Bidding.Cataloging;
using Obiddable.Win.UI.Bidding.Electing;
using Obiddable.Win.UI.Bidding.Purchasing;
using Obiddable.Win.UI.Bidding.Requesting;
using Obiddable.Win.UI.Bidding.Responding;

namespace Obiddable.Win.UI.Bidding.Navigation;
public partial class BidNavigationScreen : HostScreen
{
   private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();

   private IHostForm _hostForm;
   private Bid _bid;
   private ReportsFolderShower _reportsFolderShower = new ReportsFolderShower();
   private ExportsFolderShower _exportsFolderShower = new ExportsFolderShower();
   private HelpScreenShower _helpScreenShower = new HelpScreenShower(UserConfiguration.Instance, new UrlOpener());
   private ConfigMenuShower _configMenuShower = new ConfigMenuShower();

   public BidNavigationScreen(IHostForm hostForm, int bidId)
   {
      _hostForm = hostForm;
      InitializeComponent();
      load(bidId);
   }

   private void load(int bidId)
   {
      setBid(bidId);
      setSubTitle();
      initReportToolstrip();
      initBoxes();
   }

   private void initReportToolstrip()
   {
      reportsControl.SetBid(_bid);
   }

   private void setBid(int bidId)
   {
      _bid = _biddingRepo.GetBid(bidId);
      if (_bid is null)
      {
         MessageBox.Show("Bid #{bidId} could not be loaded. Reverting to Bid Maintenance Screen.");
         _hostForm.GoBack();
      }
   }

   private void initBoxes()
   {
      this.GetAllNestedControls()
          .OfType<BidNavigationBoxControl>()
          .ToList()
          .ForEach(x => x.SetBid(_bid));
   }

   private void setSubTitle()
   {
      string title = $"Bid: {_bid.Name}";
      this.Text = title;
   }



   private void backButton_Click(object sender, EventArgs e)
   {
      clearWorkingBid();
      _hostForm.GoBack();
   }

   private void clearWorkingBid()
   {
      UserConfiguration.Instance.WorkingBidId = null;
   }



   private void itemNavigationBoxControl1_EditClicked(object sender, EventArgs e)
       => forwardToScreen(new ItemMaintenanceScreen(_hostForm, _bid.Id));


   private void requestorsNavigationControl1_EditClicked(object sender, EventArgs e)
       => forwardToScreen(new RequestorMaintenanceScreen(_hostForm, _bid.Id));


   private void vendorResponseNavigationBoxControl1_EditClicked(object sender, EventArgs e)
       => forwardToScreen(new VendorResponseMaintenanceScreen(_hostForm, _bid.Id));


   private void electionNavigationBoxControl1_EditClicked(object sender, EventArgs e)
       => forwardToScreen(new LegacyElectionMaintenanceScreen(_hostForm, _bid.Id));


   private void purchaseOrderNavigationBoxControl1_EditClicked(object sender, EventArgs e)
       => forwardToScreen(new PurchaseOrderMaintenanceScreen(_hostForm, _bid.Id));




   private void forwardToScreen(HostScreen nextScreen)
       => _hostForm.GoForward(nextScreen);

   private void BidNavigationScreen_SizeChanged(object sender, EventArgs e)
   {
      SuspendLayout();

      int topOffset = topPanel.Height + topToolStrip.Height;
      int spaceWidth = this.ClientSize.Width;
      int spaceHeight = this.ClientSize.Height - topOffset;
      int spaceHeightHalf = spaceHeight / 2;

      int boxHeight = centeredPanel.Height;
      int boxHeightHalf = boxHeight / 2;

      int leftPos = (spaceWidth - centeredPanel.Width) / 2;
      int topPos = topOffset + spaceHeightHalf - boxHeightHalf;


      centeredPanel.Left = leftPos;
      centeredPanel.Top = topPos;
      ResumeLayout();
   }

   private void exportsButton_Click(object sender, EventArgs e) => _exportsFolderShower.Run();
   private void reportsButton_Click(object sender, EventArgs e) => _reportsFolderShower.Run();
   private void refreshButton_Click(object sender, EventArgs e) => refreshScreen();
   private void configButton_Click(object sender, EventArgs e) => _configMenuShower.Run();
   private void helpButton_Click(object sender, EventArgs e) => _helpScreenShower.Run();

   public override void Refresh()
   {
      refreshScreen();
      base.Refresh();
   }

   private void refreshScreen()
   {
      load(_bid.Id);
   }
}
