using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Formatting;
using Ccd.Bidding.Manager.Win.Library.Operations.Bidding.Electing;
using Ccd.Bidding.Manager.Win.Library.UI;
using System.Data;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Electing;
public partial class ElectionEditScreen : HostScreen
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   private readonly ILegacyElectionsRepo _electionsRepo = new EFLegacyElectionsRepo();
   private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();
   private readonly ElectingMessaging _electingMessaging = new ElectingMessaging();

   #region PROPERTIES
   private int _itemId;
   private IHostForm _hostForm;
   private ResponseItem selectedResponse;
   #endregion

   #region INIT
   public ElectionEditScreen(int itemId, IHostForm hostForm)
   {
      InitializeComponent();
      topPanel.BackColor = ApplicationColors.Elections;
      Text = "Item Election";

      _itemId = itemId;
      _hostForm = hostForm;

      selectButton.Enabled = false;
      LoadFields();
      LoadColumnWidths();
      LoadList();
      SelectElectionReasonForEntry();
   }
   #endregion

   #region NAVIGATION
   private void backButton_Click(object sender, EventArgs e)
   {
      _hostForm.GoBack();

   }
   #endregion

   #region COLUMN
   public void LoadColumnWidths()
   {
      this.responseItemIdColumnHeader.Width = 0;
      this.vendorPartnumberColumnHeader.Width = 148;
      this.vendorNameColumnHeader.Width = 126;
      this.vendorPriceColumnHeader.Width = 144;
      this.isAlternateColumnHeader.Width = 104;
      this.alternateUnitColumnHeader.Width = 105;
      this.alternateQuantityColumnHeader.Width = 106;
      this.alternateDescriptionColumnHeader.Width = 119;
      this.fillerColHead.Width = 1;
      this.qtyColumnHeader.Width = 40;
      this.unitColumnHeader.Width = 40;
      this.priceColumnHeader.Width = 86;
      this.extendedPriceColumnHeader.Width = 133;

   }
   private void responsesToElectListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
   {
      var col = responsesToElectListView.Columns[e.ColumnIndex];

      _hostForm.HeaderWidthManager.SetHeaderWidth(this.Text, col.Index, col.Width);
   }
   #endregion

   #region FIELD POPULATION
   public void LoadFields()
   {
      Item i = _catalogingRepo.GetItem(_itemId);
      ResponseItem ri = _electionsRepo.GetElectedResponseItemForItem(_itemId);

      codeTextBox.Text = i.FormattedCode;
      unitTextBox.Text = i.Unit;
      quantityRequestedTextBox.Text = i.GetRequestedQuantity(_requestingRepo).ToString();
      estimatedPriceTextBox.Text = i.Price.ToString();
      lastOrderedPriceTextBox.Text = i.Last_Order_Price.ToString();
      descriptionTextBox.Text = i.Description;

      if (ri != null)
      {
         selectedResponse = ri;

         electionReasonTextBox.Text = ri.ElectionReason;
      }
   }
   #endregion

   #region DATA ENTRY
   private void SelectElectionReasonForEntry()
   {
      electionReasonTextBox.Focus();
      electionReasonTextBox.SelectAll();
   }
   private void electionReasonTextBox_TextChanged(object sender, EventArgs e)
   {
      selectButton.Enabled = false;
      if (!isValid())
      {
         return;
      }

      selectButton.Enabled = true;
   }
   #endregion

   #region LIST LOAD
   private void LoadList()
   {
      Item i = _catalogingRepo.GetItem(_itemId);

      List<ResponseItem> responsesToItem = _respondingRepo.GetResponseItems_ByItem(_itemId).OrderBy(x => x.GetExtendedPrice(_requestingRepo)).ToList();

      responsesToElectListView.BeginUpdate();
      responsesToElectListView.Items.Clear();

      foreach (ResponseItem ri in responsesToItem)
      {
         var row = new ListViewItem();

         row.Text = ri.GetFormattedId();
         row.SubItems.Add(ri.VendorResponse.VendorName);
         row.SubItems.Add(ri.Code);
         row.SubItems.Add(ri.Price.ToString("$0.00"));
         row.SubItems.Add(ri.IsAlternate ? "ALTERNATE" : "-");
         row.SubItems.Add(ri.IsAlternate ? ri.AlternateUnit : "-");
         row.SubItems.Add(ri.IsAlternate ? ri.AlternateQuantity.ToString() : "-");
         row.SubItems.Add(ri.IsAlternate ? ri.AlternateDescription : "-");
         row.SubItems.Add("");
         row.SubItems.Add(ri.Item.GetRequestedQuantity(_requestingRepo).ToString());
         row.SubItems.Add(ri.Item.Unit);
         row.SubItems.Add(ri.Price.ToString("$0.00000"));
         row.SubItems.Add(ri.GetExtendedPrice(_requestingRepo).ToString("$0.00"));

         row.Tag = ri;

         if (selectedResponse != null && selectedResponse.Id == ri.Id)
         {
            row.Selected = true;
            //row.BackColor = Color.Gray;
         }
         responsesToElectListView.Items.Add(row);
      }

      responsesToElectListView.EndUpdate();
   }
   #endregion

   #region LIST INTERACTION
   private void responsesToElectListView_SelectedIndexChanged(object sender, EventArgs e)
   {
      selectButton.Enabled = false;

      if (!isValid())
      {
         return;
      }
      selectButton.Enabled = true;
      SelectElectionReasonForEntry();
   }
   #endregion

   #region DATA VALIDATION
   private bool isValid()
   {
      if (responsesToElectListView.SelectedItems.Count == 0)
      {
         return false;
      }

      if (electionReasonTextBox.Text.Length > 255 || electionReasonTextBox.Text.Length == 0)
      {
         errorProvider1.SetError(electionReasonTextBox, "Election Reason must be less than 255 characaters & not blank.");
         return false;
      }
      return true;
   }
   #endregion

   #region DATA OPERATIONS
   private void selectButton_Click(object sender, EventArgs e)
   {
      if (!isValid())
      {
         return;
      }

      new ElectItemOperation().ElectResponseItem(_itemId, getSelectedResponseItemId(), electionReasonTextBox.Text);

      _hostForm.GoBack();
   }

   private int getSelectedResponseItemId()
       => ((ResponseItem)responsesToElectListView.SelectedItems[0].Tag).Id;


   private void clearButton_Click(object sender, EventArgs e)
   {
      _electionsRepo.UpdateResponseItems_ClearElections_ByItem(_itemId);
      _hostForm.GoBack();

   }
   #endregion

   #region KEYS
   private void OnKeyDown(object sender, KeyEventArgs e)
   {
      CheckForSaveKey(e);
      CheckForListNavigationKeys(e);
      CheckForEscapeKey(e);
   }
   private void CheckForSaveKey(KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Enter && selectButton.Enabled)
      {
         selectButton_Click(null, null);
      }
   }
   private void CheckForListNavigationKeys(KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
         e.Handled = true;
         e.SuppressKeyPress = true;
      }

      if (responsesToElectListView.SelectedItems.Count == 0)
         return;

      int selectedIndex = responsesToElectListView.SelectedItems[0].Index;

      if ((e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down) && selectedIndex < responsesToElectListView.Items.Count - 1)
      {
         responsesToElectListView.Items[selectedIndex++].Selected = false;
         responsesToElectListView.Items[selectedIndex].Selected = true;
         responsesToElectListView.Items[selectedIndex].EnsureVisible();

         SelectElectionReasonForEntry();
      }

      if ((e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up) && selectedIndex > 0)
      {
         responsesToElectListView.Items[selectedIndex--].Selected = false;
         responsesToElectListView.Items[selectedIndex].Selected = true;
         responsesToElectListView.Items[selectedIndex].EnsureVisible();

         SelectElectionReasonForEntry();
      }
   }
   private void CheckForEscapeKey(KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Escape)
      {
         _hostForm.GoBack();

         e.Handled = true;
         e.SuppressKeyPress = true;
      }
   }
   #endregion


}
