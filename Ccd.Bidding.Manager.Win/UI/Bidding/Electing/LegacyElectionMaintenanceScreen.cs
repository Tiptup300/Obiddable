using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Formatting;
using Ccd.Bidding.Manager.Win.Library.IO.Bidding.Electing;
using Ccd.Bidding.Manager.Win.Library.Operations.Bidding.Electing;
using Ccd.Bidding.Manager.Win.Library.UI;
using System.Data;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Electing;
public class LegacyElectionMaintenanceScreen : MaintenanceScreen
{
   private readonly IBiddingRepo _biddingRepo = new EFBiddingRepo();
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly ILegacyElectionsRepo _legacyElectionsRepo = new EFLegacyElectionsRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   private readonly ElectionsImports _electionsImports = new ElectionsImports();

   private Bid _bid;
   private List<Item> itemsToElect;
   private List<ResponseItem> allBidsResponseItems;

   private ToolStripTextBox itemsTotalTextBox;
   private ToolStripTextBox electedItemsTotalTextBox;

   public LegacyElectionMaintenanceScreen(IHostForm hostForm, int bidId) : base(hostForm)
   {
      _bid = _biddingRepo.GetBid(bidId);

      addButton.Enabled = false;
      addButton.Visible = false;

      deleteButton.Enabled = false;
      deleteButton.Visible = false;
   }

   #region INIT METHODS
   private void IntializeTotalsTextBoxes()
   {
      itemsTotalTextBox = new ToolStripTextBox();
      itemsTotalTextBox.ReadOnly = true;
      itemsTotalTextBox.BorderStyle = BorderStyle.FixedSingle;

      electedItemsTotalTextBox = new ToolStripTextBox();
      electedItemsTotalTextBox.ReadOnly = true;
      electedItemsTotalTextBox.BorderStyle = BorderStyle.FixedSingle;

      toolStrip1.Items.Add(itemsTotalTextBox);
      toolStrip1.Items.Add(electedItemsTotalTextBox);
   }
   protected override void InitializeTitles()
   {
      titleLabel.Text = "Election Maintenance";
      Text = "Election Maintenance";
      subtitleLabel.Text = $"{_bid.Id}-{_bid.Name}";
      topPanel.BackColor = ApplicationColors.Elections;
   }
   #endregion

   #region ACTIONS
   protected override void InitializeActionsMenu(IActionMenu actionMenu)
   {
      var importElectionsActionMenuItem = new ToolStripMenuItem() { Text = "Import Elections from CSV" };
      importElectionsActionMenuItem.Click += ImportElectionsActionMenuItem_Click;

      var exportElectionsActionMenuItem = new ToolStripMenuItem() { Text = "Export All Elections to CSV" };
      exportElectionsActionMenuItem.Click += ExportElectionsActionMenuItem_Click; ;

      var clearAllElectionsActionMenuItem = new ToolStripMenuItem() { Text = "Clear All Elections", };
      clearAllElectionsActionMenuItem.Click += clearAllElectionsActionMenuItem_Click;

      var runLowBidActionMenuItem = new ToolStripMenuItem() { Text = "Run Low Bid On All Items" };
      runLowBidActionMenuItem.Click += RunLowBidActionMenuItem_Click;

      var runLowBidUnelectedOnlyActionMenuItem = new ToolStripMenuItem() { Text = "Run Low Bid On Unelected Items" };
      runLowBidUnelectedOnlyActionMenuItem.Click += RunLowBidUnelectedOnlyActionMenuItem_Click; ;

      actionsMenu.DropDownItems.AddRange(new ToolStripItem[] {
             runLowBidActionMenuItem,
             runLowBidUnelectedOnlyActionMenuItem,
             clearAllElectionsActionMenuItem,
             new ToolStripSeparator(),
             importElectionsActionMenuItem,
             exportElectionsActionMenuItem,
             new ToolStripSeparator(),
             LoadSelectedItemActionMenuItems(),
         });

   }

   private void ExportElectionsActionMenuItem_Click(object sender, EventArgs e)
   {
      ElectionsExports.ExportElectionsToCSV(_bid);
   }

   private void ImportElectionsActionMenuItem_Click(object sender, EventArgs e)
   {
      _electionsImports.ImportElectionsFromCSV(_bid);
      RefreshList();
   }

   private ToolStripMenuItem LoadSelectedItemActionMenuItems()
   {
      var selectedItemActionMenuItem = new ToolStripMenuItem() { Text = "Selected" };

      var clearItemElectionMenuItem = new ToolStripMenuItem() { Text = "Clear Election" };
      clearItemElectionMenuItem.Click += ClearItemElectionMenuItem_Click; ;
      selectedItemActionMenuItem.DropDownItems.Add(clearItemElectionMenuItem);

      return selectedItemActionMenuItem;
   }
   private void ClearItemElectionMenuItem_Click(object sender, EventArgs e)
   {
      if (SelectedItem == null)
      {
         return;
      }
      Item item = _catalogingRepo.GetItem(SelectedItemTag);
      if (item == null)
      {
         return;
      }

      _legacyElectionsRepo.UpdateResponseItems_ClearElections_ByItem(item.Id);

      RefreshList();
   }
   private void clearAllElectionsActionMenuItem_Click(object sender, EventArgs e)
   {
      if (ElectingMessaging.Instance.ConfirmElectionClearAll() == false)
      {
         return;
      }
      _legacyElectionsRepo.UpdateResponseItems_ClearElections_ByBid(_bid.Id);

      RefreshList();
   }
   #endregion

   #region BUTTON METHODS

   protected override void AddButtonClicked()
   {
      //throw new NotImplementedException();
   }
   protected override void DeleteButtonClicked()
   {
      //throw new NotImplementedException();
   }
   protected override void EditButtonClicked()
   {
      if (SelectedItem == null)
      {
         return;
      }
      Item item = _catalogingRepo.GetItem(SelectedItemTag);
      if (item == null)
      {
         return;
      }

      ElectionEditScreen f = new ElectionEditScreen(item.Id, _hostForm);
      _hostForm.GoForward(f);

   }
   #endregion

   #region LIST METHODS
   protected override void InitializeColumns()
   {
      listViewMain.Columns.AddRange(
          new ColumnHeader[] {
                 new ColumnHeader() { Text = "Item Id",           Width = 0 },
                 new ColumnHeader() { Text = "Elected Response Id",           Width = 0  },
                 new ColumnHeader() { Text = "Code",         Width = 61 },
                 new ColumnHeader() { Text = "Description",      Width = 547 },
                 new ColumnHeader() { Text = "Unit",    Width = 72 },
                 new ColumnHeader() { Text = "Category",    Width = 168},
                 new ColumnHeader() { Text = "Quantity Requested", Width = 128, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Number Of Responses",    Width = 159, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Vendor Elected",    Width =266 },
                 new ColumnHeader() { Text = "Alternate",    Width = 72 },
                 new ColumnHeader() { Text = "Vendor Price",    Width = 91, TextAlign = HorizontalAlignment.Right  },
                 new ColumnHeader() { Text = "Election Reason", Width = 150 }
          }
      );

      IntializeTotalsTextBoxes();
   }
   protected override void RefreshList()
   {
      listViewMain.BeginUpdate();
      listViewMain.Items.Clear();

      //find all items that are both requested and responded to along with getting information on whether it's elected, which is stored in responses, so just look at all responses
      int itemsTotal, electedItemsTotal;
      itemsToElect = _respondingRepo.GetItems_Responded_ByBid(_bid.Id).OrderBy(x => x.Code).ToList();
      allBidsResponseItems = _respondingRepo.GetResponseItems_ByBid(_bid.Id);

      itemsTotal = 0;
      electedItemsTotal = 0;
      foreach (Item i in itemsToElect)
      {
         var row = new ListViewItem();

         List<ResponseItem> responseItemsForThisItem = allBidsResponseItems.Where(x => x.Item.Id == i.Id).ToList();
         ResponseItem electedResponseItem = responseItemsForThisItem.FirstOrDefault(y => y.Elected);

         row.Text = i.GetFormattedId();
         row.SubItems.Add(electedResponseItem != null ? electedResponseItem.Id.ToString() : "");
         row.SubItems.Add(i.FormattedCode);
         row.SubItems.Add(i.Description);
         row.SubItems.Add(i.Unit);
         row.SubItems.Add(i.Category);
         row.SubItems.Add(i.GetFormattedRequestedQuantity(_requestingRepo));
         row.SubItems.Add(responseItemsForThisItem.Count.ToString());
         row.SubItems.Add(electedResponseItem != null ? electedResponseItem.VendorResponse.VendorName : "-");
         row.SubItems.Add(electedResponseItem != null ? electedResponseItem.IsAlternate ? "YES" : "NO" : "-");
         row.SubItems.Add(electedResponseItem != null ? electedResponseItem.Price.ToString("$0.00") : "-");
         row.SubItems.Add(electedResponseItem != null ? electedResponseItem.ElectionReason : "-");

         row.BackColor = electedResponseItem != null ? Color.White : Color.LightGray;
         row.Tag = i.Id;

         listViewMain.Items.Add(row);

         itemsTotal++;
         electedItemsTotal += electedResponseItem != null ? 1 : 0;
      }

      listViewMain.EndUpdate();

      UpdateTotalsTextBoxes(itemsTotal, electedItemsTotal);

      ReselectItem();
   }

   private void UpdateTotalsTextBoxes(int itemsTotal, int electedItemsTotal)
   {
      itemsTotalTextBox.Text = $"{itemsTotal} Items";
      electedItemsTotalTextBox.Text = $"{electedItemsTotal} Elected Items";
   }
   protected override void ListViewDoubleClicked()
   {
      EditButtonClicked();
   }
   #endregion

   #region ACTIONS MENU METHODS
   private void RunLowBidActionMenuItem_Click(object sender, EventArgs e)
   {
      if (ElectingMessaging.Instance.ConfirmElectionRunLowBid() == false)
      {
         return;
      }

      RunLowBid(_respondingRepo.GetItems_Responded_ByBid(_bid.Id));
      RefreshList();
   }
   private void RunLowBidUnelectedOnlyActionMenuItem_Click(object sender, EventArgs e)
   {
      if (ElectingMessaging.Instance.ConfirmElectionRunUnelectedLowBid() == false)
      {
         return;
      }

      RunLowBid(_legacyElectionsRepo.GetItems_Responded_NotElected_ByBid(_bid.Id));
      RefreshList();
   }
   private void RunLowBid(List<Item> items)
   {
      int itemsElected = 0, lowBidAlreadyElected = 0, noResponses = 0;

      foreach (Item i in items)
      {
         ResponseItem cheapestReponseItem = allBidsResponseItems
             .Where(x => x.Item.Id == i.Id)
             .OrderBy(x => x.GetExtendedPrice(_requestingRepo))
             .FirstOrDefault();

         var ri = _legacyElectionsRepo.GetElectedResponseItemForItem(i.Id);

         if (ri != null && cheapestReponseItem.Id == ri.Id)
         {
            lowBidAlreadyElected++;
            continue;
         }

         if (cheapestReponseItem == null)
         {
            noResponses++;
            continue;
         }

         itemsElected++;

         new ElectItemOperation().ElectResponseItem(i.Id, cheapestReponseItem.Id, $"Low Bid ({DateTime.Now.ToString("yyyy-MM-dd")})");
      }
      ElectingMessaging.Instance.ShowElectionRunLowBidSuccess(itemsElected, lowBidAlreadyElected, noResponses);

      RefreshList();
   }
   #endregion

}
