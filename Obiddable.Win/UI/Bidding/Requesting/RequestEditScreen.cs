using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Requesting;
using Obiddable.Win.Library.UI;
using System.Data;

namespace Obiddable.Win.UI.Bidding.Requesting;
public partial class RequestEditScreen : HostScreen
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
   #region PROPERTIES
   private Requestor _requestor;
   private int _requestId;

   private List<Item> itemsToRequest;
   private List<RequestItem> allRequestItems;

   private Item selectedItem;
   private RequestItem selectedRequestItem;

   private IHostForm _hostForm;
   #endregion


   public RequestEditScreen(Request request, IHostForm hostForm)
   {
      InitializeComponent();
      topPanel.BackColor = ApplicationColors.Requesting;
      Text = "Edit Request";

      _hostForm = hostForm;
      _requestId = request.Id;
      _requestor = request.Requestor;

      LoadList();
      LoadColumnWidths();

      accountNumberComboBox.Text = request.Account_Number;
      LoadRequestorFields();
      ClearFields();

   }


   #region NAVIGATION
   private void backButton_Click(object sender, EventArgs e)
   {
      _hostForm.GoBack();
   }
   #endregion


   #region ACCOUNT CODE
   private void LoadAccountCodes()
   {
      if (_requestor is null)
         return;

      string[] accountNumbers = _requestingRepo.GetRequestAccountNumbers_ByBid(_requestor.Bid.Id).Where(x => !_requestor.Requests.Any(y => y.Account_Number == x)).ToArray();

      accountNumberComboBox.Items.AddRange(accountNumbers);
   }
   private void saveAccountNumberButton_Click(object sender, EventArgs e)
   {
      errorProvider1.Clear();
      if (!accountNumberIsValidFormat())
         return;

      _requestingRepo.UpdateRequest(new Request() { Id = _requestId, Requestor = _requestor, Account_Number = accountNumberComboBox.Text });
      RequestMessaging.Instance.ShowRequestUpdateAccountNumberSuccess();
   }
   private bool accountNumberIsValidFormat()
   {
      if (AccountNumber.IsInvalid(accountNumberComboBox.Text))
      {
         errorProvider1.SetError(accountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberInvalid());
         return false;
      }

      if (_requestingRepo.Check_RequestAccountNumberAlreadyExists_InRequestor(accountNumberComboBox.Text, _requestor.Id, _requestId))
      {
         errorProvider1.SetError(accountNumberComboBox, RequestMessaging.Instance.GetRequestAccountNumberAlreadyExistsInRequestor());
         return false;
      }

      return true;
   }
   #endregion


   #region COLUMN
   private void LoadColumnWidths()
   {
      foreach (ColumnHeader colHeader in itemsToRequestListView.Columns)
      {
         colHeader.Width = _hostForm.HeaderWidthManager.GetHeaderWidth(Text, colHeader.Index, colHeader.Width);
      }

      this.itemsToRequestListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.itemsToRequestListView_ColumnWidthChanged);
   }
   private void itemsToRequestListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
   {
      ListView lv = sender as ListView;
      var col = lv.Columns[e.ColumnIndex];

      _hostForm.HeaderWidthManager.SetHeaderWidth(this.Text, col.Index, col.Width);
   }
   #endregion


   #region FIELD POPULATION
   private void LoadRequestorFields()
   {
      requestorNameTextBox.Text = _requestor.Name;
      buildingNumberTextBox.Text = _requestor.FormattedCode;
      buildingNameTextbox.Text = _requestor.Building;

      LoadAccountCodes();
   }
   private void ClearFields()
   {
      // amount requested
      amountRequestedTextBox.Text = "";
      amountRequestedTextBox.Enabled = false;
      amountRequestedLabel.Enabled = false;

      // override
      overridePriceCheckbox.Checked = false;
      overridePriceCheckbox.Enabled = false;
      overridePriceTextBox.Text = "";
      overridePriceTextBox.Enabled = false;
      overridePriceLabel.Enabled = false;

      //buttons
      saveRecordButton.Enabled = false;
      deleteRecordButton.Enabled = false;

      //item information
      codeTextBox.Text = "";
      categoryTextBox.Text = "";
      unitTextBox.Text = "";
      substitutableTextBox.Text = "";
      priceTextBox.Text = "";
      descriptionTextBox.Text = "";

      errorProvider1.Clear();
   }
   private void LoadFields()
   {
      ClearFields();

      var i = selectedItem;
      var ri = selectedRequestItem;

      // Load Item
      if (i == null)
      {
         return;
      }
      LoadItemFields(i);
      saveRecordButton.Enabled = true;
      SetReadyForEntry();

      // Load Request Item
      if (ri == null)
      {
         return;
      }
      LoadRequestItemFields(ri);
      deleteRecordButton.Enabled = true;
   }
   private void LoadRequestItemFields(RequestItem ri)
   {
      // Load Amount Requested
      amountRequestedTextBox.Text = ri.Quantity.ToString("0.00");
      // Check for override price
      overridePriceCheckbox.Checked = ri.OverridePrice != 0;
      if (!overridePriceCheckbox.Checked)
      {
         return;
      }
      overridePriceTextBox.Text = ri.OverridePrice.ToString();
      overridePriceTextBox.Enabled = true;
      overridePriceLabel.Enabled = true;
   }
   private void LoadItemFields(Item i)
   {
      codeTextBox.Text = i.FormattedCode;
      categoryTextBox.Text = i.Category;
      unitTextBox.Text = i.Unit;
      substitutableTextBox.Text = i.Substitutable ? "YES" : "NO";
      priceTextBox.Text = i.Price.ToString("$0.00000");
      descriptionTextBox.Text = i.Description;
      amountRequestedLabel.Enabled = true;
      amountRequestedTextBox.Enabled = true;
      overridePriceCheckbox.Enabled = true;
   }
   private void UpdateTotals()
   {
      Request r = _requestingRepo.GetRequest(_requestId);

      totalQtyTextbox.Text = r.QuantitySum().ToString();
      totalPriceTextBox.Text = r.ExtendedPriceSum().ToString("$0.00");
      totalPriceWithOverrideTextBox.Text = r.ExtendedPriceWithOverridesSum().ToString("$0.00");
   }
   #endregion


   #region DATA ENTRY
   private void SetReadyForEntry()
   {
      amountRequestedTextBox.Focus();
      amountRequestedTextBox.SelectAll();
   }
   private void overridePriceCheckbox_CheckedChanged(object sender, EventArgs e)
   {
      if (overridePriceCheckbox.Checked)
      {
         overridePriceTextBox.Enabled = true;
         overridePriceLabel.Enabled = true;
      }
      else
      {
         overridePriceTextBox.Text = "";
         overridePriceTextBox.Enabled = false;
         overridePriceLabel.Enabled = false;
      }
   }
   #endregion


   #region DATA VALIDATION
   private bool requestIsValid()
   {
      errorProvider1.Clear();

      decimal amountRequested;
      if (amountRequestedTextBox.Text.Length <= 0)
      {
         errorProvider1.SetError(amountRequestedTextBox, RequestMessaging.Instance.GetRequestItemAmountRequestedCannotBeBlank());
         return false;
      }
      if (!decimal.TryParse(amountRequestedTextBox.Text, out amountRequested))
      {
         errorProvider1.SetError(amountRequestedTextBox, RequestMessaging.Instance.GetRequestItemAmountRequestedNotANumber());
         return false;
      }
      if (amountRequested < 0)
      {
         errorProvider1.SetError(amountRequestedTextBox, RequestMessaging.Instance.GetRequestItemAmountRequestedCannotBeNegative());
         return false;
      }

      if (overridePriceCheckbox.Checked)
      {
         decimal overridePrice = 0;
         if (overridePriceTextBox.Text.Length < 0)
         {
            errorProvider1.SetError(overridePriceTextBox, RequestMessaging.Instance.GetRequestItemOverridePriceCannotBeBlank());
            return false;
         }
         if (!decimal.TryParse(overridePriceTextBox.Text, out overridePrice))
         {
            errorProvider1.SetError(overridePriceTextBox, RequestMessaging.Instance.GetRequestItemOverridePricedNotANumber());
            return false;
         }
         if (overridePrice < 0)
         {
            errorProvider1.SetError(overridePriceTextBox, RequestMessaging.Instance.GetRequestItemOverridePriceCannotBeNegative());
            return false;
         }
      }

      return true;
   }
   #endregion


   #region LIST LOAD
   private void LoadList()
   {
      selectedItem = null;
      selectedRequestItem = null;

      itemsToRequest = _catalogingRepo.GetItems(_requestor.Bid.Id).OrderBy(x => x.Category).ThenBy(x => x.Code).ToList();
      allRequestItems = _requestingRepo.GetRequestItems_ByRequest(_requestId);


      itemsToRequestListView.ReplaceListViewItems(
          itemsToRequest
              .Select(x => LoadListRow(allRequestItems.FirstOrDefault(y => y.Item.Id == x.Id), x))
              .ToArray()
      );

      UpdateTotals();

      SelectList();
   }
   private void SelectList()
   {
      if (itemsToRequestListView.Items.Count > 0)
      {
         itemsToRequestListView.Items[0].Selected = true;
      }
      itemsToRequestListView.Focus();
   }
   private ListViewItem LoadListRow(RequestItem ri, Item i)
   {
      ListViewItem output;

      output = new ListViewItem();
      output.Text = i.Id.ToString();
      output.SubItems.Add(ri != null ? ri.Id.ToString() : "");
      output.SubItems.Add(i.FormattedCode);
      output.SubItems.Add(i.Description);
      output.SubItems.Add(i.Unit);
      output.SubItems.Add(i.Category);
      output.SubItems.Add(i.Price.ToString("$0.00000"));
      output.SubItems.Add(ri != null && ri.OverridePrice != 0 ? ri.OverridePrice.ToString("$0.00000") : "-");
      output.SubItems.Add(ri != null ? ri.Quantity.ToString("0") : "-");
      output.SubItems.Add(ri != null ? ri.ExtendedPrice().ToString("$0.00") : "-");
      output.SubItems.Add(ri != null && ri.OverridePrice != 0 ? ri.ExtendedPriceWithOverride().ToString("$0.00") : "-");

      output.Tag = i;
      output.SubItems[0].Tag = ri;

      if (ri != null) output.BackColor = Color.LightGoldenrodYellow;
      return output;
   }
   private void ReloadSelectedRow()
   {
      int selectedIndex = itemsToRequestListView.SelectedItems[0].Index;

      itemsToRequestListView.BeginUpdate();
      itemsToRequestListView.Items[selectedIndex] = LoadListRow(selectedRequestItem, selectedItem);
      itemsToRequestListView.Items[selectedIndex].Selected = true;
      itemsToRequestListView.EndUpdate();

      UpdateTotals();
   }
   #endregion

   #region LIST INTERACTION
   private void itemsToRequestListView_Click(object sender, EventArgs e)
   {
      if (amountRequestedTextBox.Enabled)
      {
         SetReadyForEntry();
      }
   }
   private void itemsToRequestListView_SelectedIndexChanged(object sender, EventArgs e)
   {
      if (itemsToRequestListView.SelectedItems.Count < 1)
      {
         selectedItem = null;
         selectedRequestItem = null;
      }
      else
      {
         selectedItem = itemsToRequestListView.SelectedItems[0].Tag as Item;
         selectedRequestItem = itemsToRequestListView.SelectedItems[0].SubItems[0].Tag as RequestItem;
      }

      LoadFields();

   }
   #endregion


   #region DATA OPERATIONS
   private void saveRecordButton_Click(object sender, EventArgs e)
   {
      if (!requestIsValid())
      {
         return;
      }

      RequestItem ri = generateRequestItemFromFields();

      if (selectedRequestItem != null)
      {
         ri.Id = selectedRequestItem.Id;
         ri.Request = selectedRequestItem.Request;
         _requestingRepo.UpdateRequestItem(ri);
      }
      else
      {
         _requestingRepo.AddRequestItem_ToRequest(ri, _requestId);
      }

      selectedRequestItem = _requestingRepo.GetRequestItem(ri.Id);

      ReloadSelectedRow();

      SetReadyForEntry();
   }
   private void deleteRecordButton_Click(object sender, EventArgs e)
   {
      if (_requestingRepo.Check_RequestItemLast_ForRespondedItem(selectedRequestItem.Id))
      {
         errorProvider1.SetError(deleteRecordButton, "This requested quantity has alreadby been responded to, please delete all vendor responses for this item");
         return;
      }

      _requestingRepo.DeleteRequestItem(selectedRequestItem.Id);
      selectedRequestItem = null;

      ReloadSelectedRow();

      SetReadyForEntry();
   }
   private RequestItem generateRequestItemFromFields()
   {
      RequestItem ri = new RequestItem();

      ri.Item = selectedItem;
      ri.Quantity = (int)decimal.Parse(amountRequestedTextBox.Text);

      if (overridePriceTextBox.Text.Length > 0)
      {
         ri.OverridePrice = decimal.Parse(overridePriceTextBox.Text);
      }

      return ri;
   }
   #endregion


   #region KEY INPUT
   private void RequestEditScreen_KeyDown(object sender, KeyEventArgs e)
   {
      CheckForSaveKey(e);
      CheckForDeleteKey(e);
      CheckForListNavigationKeys(e);
      CheckForEscapeKey(e);
   }
   private void CheckForSaveKey(KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Enter && saveRecordButton.Enabled)
      {
         saveRecordButton_Click(null, null);

         e.Handled = true;
         e.SuppressKeyPress = true;
      }
   }
   private void CheckForDeleteKey(KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Delete && deleteRecordButton.Enabled)
      {
         deleteRecordButton_Click(null, null);
         e.Handled = true;
         e.SuppressKeyPress = true;
      }
      if (e.KeyCode == Keys.Delete && !deleteRecordButton.Enabled)
      {
         ClearFields();
         LoadFields();
         SetReadyForEntry();

         e.Handled = true;
         e.SuppressKeyPress = true;
      }
   }
   private void CheckForListNavigationKeys(KeyEventArgs e)
   {
      if (itemsToRequestListView.SelectedItems.Count == 0)
      {
         return;
      }

      int selectedIndex = itemsToRequestListView.SelectedItems[0].Index;

      if ((e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down) && selectedIndex < itemsToRequestListView.Items.Count - 1)
      {

         itemsToRequestListView.Items[selectedIndex++].Selected = false;
         itemsToRequestListView.Items[selectedIndex].Selected = true;
         itemsToRequestListView.Items[selectedIndex].EnsureVisible();

         SetReadyForEntry();

         e.Handled = true;
         e.SuppressKeyPress = true;
      }

      if ((e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up) && selectedIndex > 0)
      {

         itemsToRequestListView.Items[selectedIndex--].Selected = false;
         itemsToRequestListView.Items[selectedIndex].Selected = true;
         itemsToRequestListView.Items[selectedIndex].EnsureVisible();

         SetReadyForEntry();

         e.Handled = true;
         e.SuppressKeyPress = true;
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
