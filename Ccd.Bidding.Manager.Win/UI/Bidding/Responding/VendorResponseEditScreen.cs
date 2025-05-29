using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Requesting.Extensions;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Responding
{
   public partial class VendorResponseEditScreen : HostScreen
   {
      private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
      private readonly IRequestingRepo _requestingRepo = new EFRequestingRepo();
      private readonly IRespondingRepo _respondingRepo = new EFRespondingRepo();

      #region PROPERTIES
      private Bid _bid;
      private int _vendorResponseId;

      private List<Item> itemsToRespond;
      private List<ResponseItem> allVendorResponsesResponseItems;

      private IHostForm _hostForm;

      private Item selectedItem;
      private ResponseItem selectedResponseItem;
      #endregion


      public VendorResponseEditScreen(VendorResponse vendorResponse, IHostForm hostForm)
      {
         InitializeComponent();
         topPanel.BackColor = ApplicationColors.VendorResponses;
         Text = "Edit Vendor";

         _hostForm = hostForm;
         _vendorResponseId = vendorResponse.Id;
         _bid = vendorResponse.Bid;

         vendorNameTextBox.Text = vendorResponse.VendorName;
         LoadList();
         LoadColumnWidths();

         ClearFields();
      }


      #region NAVIGATION 
      private void backButton_Click(object sender, EventArgs e)
      {
         _hostForm.GoBack();
      }
      #endregion


      #region VENDOR NAME 
      private void saveVendorNameButton_Click(object sender, EventArgs e)
      {
         if (!vendorNameIsValid())
            return;

         _respondingRepo.UpdateVendorResponse(new VendorResponse() { Id = _vendorResponseId, Bid = _bid, VendorName = vendorNameTextBox.Text });
         VendorResponseMessaging.Instance.ShowVendorResponseVendorNameUpdateSuccess();
      }
      private bool vendorNameIsValid()
      {
         errorProvider1.Clear();

         if (vendorNameTextBox.Text.Length == 0)
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotBeBlank());
            return false;
         }
         if (vendorNameTextBox.Text.Length > 255)
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotBeTooLong());

            return false;
         }

         if (_respondingRepo.Check_VendorResponseVendorNameAlreadyExists_InBid(vendorNameTextBox.Text, _bid.Id, _vendorResponseId))
         {
            errorProvider1.SetError(vendorNameTextBox, VendorResponseMessaging.Instance.GetVendorResponseVendorNameCannotAlreadyExist());
            return false;
         }

         return true;
      }
      #endregion


      #region COLUMN
      private void LoadColumnWidths()
      {
         foreach (ColumnHeader colHeader in itemsToRespondListView.Columns)
         {
            colHeader.Width = _hostForm.HeaderWidthManager.GetHeaderWidth(Text, colHeader.Index, colHeader.Width);
         }

         this.itemsToRespondListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.itemsToRespondListView_ColumnWidthChanged);
      }
      private void itemsToRespondListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
      {
         ListView lv = sender as ListView;
         var col = lv.Columns[e.ColumnIndex];

         _hostForm.HeaderWidthManager.SetHeaderWidth(this.Text, col.Index, col.Width);
      }
      #endregion


      #region FIELD POPULATION
      private void ClearFields()
      {
         // vendor price
         vendorPriceTextBox.Text = "";
         vendorPriceTextBox.Enabled = false;
         vendorPriceLabel.Enabled = false;

         quantityRequestedLabel.Enabled = false;
         extendedPriceLabel.Enabled = false;

         // vendor part number
         vendorPartNumberTextBox.Text = "";
         vendorPartNumberTextBox.Enabled = false;
         vendorPartNumberLabel.Enabled = false;

         //buttons
         saveRecordButton.Enabled = false;
         deleteRecordButton.Enabled = false;

         // alt fields
         isAlternateCheckbox.Checked = false;
         isAlternateCheckbox.Enabled = false;
         alternateUnitTextBox.Text = "";
         alternateUnitTextBox.Enabled = false;
         alternateUnitLabel.Enabled = false;
         alternateQuantityTextBox.Text = "";
         alternateQuantityTextBox.Enabled = false;
         alternateQuantityLabel.Enabled = false;
         alternateDescriptionTextBox.Text = "";
         alternateDescriptionTextBox.Enabled = false;
         alternateDescriptionLabel.Enabled = false;

         // item information
         descriptionTextBox.Text = "";
         codeTextBox.Text = "";
         quantityRequestedTextBox.Text = "";
         unitTextBox.Text = "";
         substitutableTextBox.Text = "";

         // add alt
         addAlternateButton.Enabled = false;

         // clear errors
         errorProvider1.Clear();
      }
      private void LoadFields()
      {
         ClearFields();

         var i = selectedItem;
         var ri = selectedResponseItem;

         // Load Item
         if (i == null)
         {
            return;
         }
         LoadItemFields(i);
         saveRecordButton.Enabled = true;
         SetReadyForEntry();

         // Load Response Item
         if (ri == null)
         {
            return;
         }
         LoadResponseItemFields(ri);
         deleteRecordButton.Enabled = true;
         addAlternateButton.Enabled = true;

      }
      private void LoadItemFields(Item i)
      {
         descriptionTextBox.Text = i.Description;
         codeTextBox.Text = i.FormattedCode;
         quantityRequestedTextBox.Text = i.GetRequestedQuantity(_requestingRepo).ToString();
         unitTextBox.Text = i.Unit;
         substitutableTextBox.Text = i.Substitutable ? "ALLOWED" : "NO SUBSTITUTIONS";

         vendorPartNumberLabel.Enabled = true;
         vendorPartNumberTextBox.Enabled = true;
         vendorPriceLabel.Enabled = true;
         vendorPriceTextBox.Enabled = true;
         quantityRequestedLabel.Enabled = true;

         isAlternateCheckbox.Enabled = true;
         //isAlternateCheckbox.Enabled = i.Substitutable;
      }
      private void LoadResponseItemFields(ResponseItem ri)
      {
         // Vendor Price
         vendorPriceTextBox.Text = ri.Price.ToString("0.00000");
         //Vendor Part Number
         vendorPartNumberTextBox.Text = ri.Code;

         // Load Alternate Fields
         isAlternateCheckbox.Checked = ri.IsAlternate;
         if (!ri.IsAlternate)
         {
            return;
         }
         // Alt Unit
         alternateUnitLabel.Enabled = true;
         alternateUnitTextBox.Text = ri.AlternateUnit;
         alternateUnitTextBox.Enabled = true;
         // Alt Quantity
         alternateQuantityLabel.Enabled = true;
         alternateQuantityTextBox.Text = ri.AlternateQuantity.ToString("0.00");
         alternateQuantityTextBox.Enabled = true;
         // Alt Description
         alternateDescriptionLabel.Enabled = true;
         alternateDescriptionTextBox.Text = ri.AlternateDescription;
         alternateDescriptionTextBox.Enabled = true;
      }
      private void UpdateTotals()
      {
         VendorResponse vr = _respondingRepo.GetVendorResponse(_vendorResponseId);
         itemsRequestedTextBox.Text = itemsToRespond.Count.ToString();
         itemsRespondedTextBox.Text = vr.ResponseItems.Count.ToString();
         totalVendorPriceTextBox.Text = vr.GetGetSum_TotalPrice(_requestingRepo).ToString("$0.00");
      }
      #endregion


      #region DATA ENTRY
      private void SetReadyForEntry()
      {
         vendorPriceTextBox.Focus();
         vendorPriceTextBox.SelectAll();
      }
      private void AlternateCheckboxSwitched(object sender, EventArgs e)
      {
         if (isAlternateCheckbox.Checked)
         {
            alternateUnitTextBox.Enabled = true;
            alternateUnitLabel.Enabled = true;

            alternateQuantityTextBox.Enabled = true;
            alternateQuantityLabel.Enabled = true;

            alternateDescriptionTextBox.Enabled = true;
            alternateDescriptionLabel.Enabled = true;
         }
         else
         {
            alternateUnitTextBox.Text = "";
            alternateUnitTextBox.Enabled = false;
            alternateUnitLabel.Enabled = false;

            alternateQuantityTextBox.Text = "";
            alternateQuantityTextBox.Enabled = false;
            alternateQuantityLabel.Enabled = false;

            alternateDescriptionTextBox.Text = "";
            alternateDescriptionTextBox.Enabled = false;
            alternateDescriptionLabel.Enabled = false;
         }
         ExtendedPriceChanged(sender, e);
      }
      private void ExtendedPriceChanged(object sender, EventArgs e)
      {
         extendedPriceLabel.Enabled = false;
         vendorExtendedPriceTextBox.Text = "-";

         if (selectedItem == null)
         {
            return;
         }

         decimal respondedPrice;
         decimal quantity = selectedItem.GetRequestedQuantity(_requestingRepo);

         if (!decimal.TryParse(vendorPriceTextBox.Text, out respondedPrice))
         {
            return;
         }

         if (isAlternateCheckbox.Checked)
         {
            decimal altQuantity = 0;
            if (!decimal.TryParse(alternateQuantityTextBox.Text, out altQuantity))
            {
               return;
            }
            quantity = altQuantity;
         }

         extendedPriceLabel.Enabled = true;
         vendorExtendedPriceTextBox.Text = (respondedPrice * quantity).ToString("0.00");
      }
      #endregion


      #region LIST LOAD
      private void LoadList()
      {
         selectedItem = null;
         selectedResponseItem = null;

         itemsToRespond = _requestingRepo.GetItems_Requested_ByBid(_bid.Id)
             .OrderBy(item => item.Category)
             .ThenBy(x => x.Code)
             .ToList();

         allVendorResponsesResponseItems = _respondingRepo.GetResponseItems_ByVendorResponse(_vendorResponseId);

         itemsToRespondListView.BeginUpdate();
         itemsToRespondListView.Items.Clear();

         foreach (Item i in itemsToRespond)
         {
            List<ResponseItem> ris = allVendorResponsesResponseItems.Where(x => x.Item.Id == i.Id).ToList();

            foreach (ResponseItem ri in ris)
            {
               ListViewItem row = loadListRow(ri, i);
               itemsToRespondListView.Items.Add(row);
            }

            if (ris.Count == 0)
            {
               ListViewItem row = loadListRow(null, i);
               itemsToRespondListView.Items.Add(row);
            }
         }

         AddNonRequestedItemsToList(itemsToRespondListView, itemsToRespond, allVendorResponsesResponseItems);

         itemsToRespondListView.EndUpdate();
         UpdateTotals();

         SelectList();
      }
      private ListViewItem loadListRow(ResponseItem ri, Item i)
      {
         var row = new ListViewItem();

         row.Text = i.Id.ToString();
         row.SubItems.Add(ri != null ? ri.Id.ToString() : "");
         row.SubItems.Add(i.FormattedCode);
         row.SubItems.Add(i.Description);
         row.SubItems.Add(i.Unit);
         row.SubItems.Add(i.Category);
         row.SubItems.Add(i.Substitutable.ToString());
         row.SubItems.Add(i.GetRequestedQuantity(_requestingRepo).ToString());
         row.SubItems.Add(ri != null ? ri.Code : "");
         row.SubItems.Add(ri != null ? ri.IsAlternate.ToString() : "-");
         row.SubItems.Add(ri != null ? ri.Price.ToString("$0.00") : "-");
         row.SubItems.Add(ri != null ? (ri.Price * ri.Get_Quantity(_requestingRepo)).ToString("$0.00") : "-");

         row.Tag = i;
         row.SubItems[0].Tag = ri;

         if (ri != null) row.BackColor = Color.LightGoldenrodYellow;

         return row;
      }
      private void SelectList()
      {
         if (itemsToRespondListView.Items.Count > 0)
         {
            itemsToRespondListView.Items[0].Selected = true;
         }
         itemsToRespondListView.Focus();
      }
      private void AddNonRequestedItemsToList(ListView lv, List<Item> items, List<ResponseItem> responseItems)
      {
         List<ResponseItem> remainingResponseItems = responseItems.Where(ri => !items.Any(i => i.Id == ri.Item.Id)).ToList();

         foreach (ResponseItem ri in remainingResponseItems)
         {
            ListViewItem row = loadListRow(ri, ri.Item);
            row.BackColor = Color.Red;
            lv.Items.Add(row);
         }

         if (remainingResponseItems.Count > 0)
         {
            VendorResponseMessaging.Instance.ShowVendorResponseHasUnrequestedItems();
         }
      }
      private void ReloadSelectedRow()
      {
         int selectedIndex = itemsToRespondListView.SelectedItems[0].Index;

         itemsToRespondListView.BeginUpdate();
         itemsToRespondListView.Items[selectedIndex] = loadListRow(selectedResponseItem, selectedItem);
         itemsToRespondListView.Items[selectedIndex].Selected = true;
         itemsToRespondListView.EndUpdate();
      }
      private void ClearListSelections()
      {
         foreach (ListViewItem i in itemsToRespondListView.SelectedItems)
         {
            i.Selected = false;
         }
      }
      #endregion


      #region LIST INTERACTION
      private void itemsToRespondListView_Click(object sender, EventArgs e)
      {
         if (vendorPriceTextBox.Enabled)
         {
            SetReadyForEntry();
         }
      }
      private void itemsToRespondListView_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (itemsToRespondListView.SelectedItems.Count == 0)
         {
            selectedItem = null;
            selectedResponseItem = null;
         }
         else
         {
            selectedItem = itemsToRespondListView.SelectedItems[0].Tag as Item;
            selectedResponseItem = itemsToRespondListView.SelectedItems[0].SubItems[0].Tag as ResponseItem;
         }

         LoadFields();
      }
      #endregion


      #region DATA VALIDATION
      private bool responseIsValid()
      {
         errorProvider1.Clear();

         decimal vendorPriceTextBoxValue;
         if (vendorPriceTextBox.Text.Length <= 0 || !decimal.TryParse(vendorPriceTextBox.Text, out vendorPriceTextBoxValue) || vendorPriceTextBoxValue <= 0)
         {
            errorProvider1.SetError(vendorPriceTextBox, "Vendor Price Is Not Valid");
            return false;
         }

         if (vendorPartNumberTextBox.Text.Length > 255)
         {
            errorProvider1.SetError(vendorPartNumberTextBox, "Vendor Part Number Is Not Valid");
            return false;
         }

         if (isAlternateCheckbox.Checked)
         {
            if (alternateUnitTextBox.Text.Length == 0 || alternateUnitTextBox.Text.Length > 255)
            {
               errorProvider1.SetError(alternateUnitTextBox, "Alternate Unit Is Not Valid");
               return false;
            }

            decimal vendorAlternativeQuantityTextboxValue = 0;
            if (alternateQuantityTextBox.Text.Length <= 0 || !decimal.TryParse(alternateQuantityTextBox.Text, out vendorAlternativeQuantityTextboxValue) || vendorAlternativeQuantityTextboxValue <= 0)
            {
               errorProvider1.SetError(alternateQuantityTextBox, "Alternate Quantity Is Not Valid");
               return false;
            }

            if (alternateDescriptionTextBox.Text.Length > 255 || alternateDescriptionTextBox.Text.Length == 0)
            {
               errorProvider1.SetError(alternateDescriptionTextBox, "Alternate Description Is Not Valid");
               return false;
            }
         }

         return true;
      }
      #endregion


      #region DATA OPERATIONS
      private void saveRecordButton_Click(object sender, EventArgs e)
      {
         if (!responseIsValid())
         {
            return;
         }

         ResponseItem ri = generateResponseItemFromFields();

         if (selectedResponseItem != null)
         {
            ri.Id = selectedResponseItem.Id;
            ri.Elected = selectedResponseItem.Elected;
            if (ri.Elected)
            {
               ri.ElectionReason = selectedResponseItem.ElectionReason;
            }
            else
            {
               ri.ElectionReason = null;
            }
            ri.VendorResponse = selectedResponseItem.VendorResponse;

            _respondingRepo.UpdateResponseItem(ri);
         }
         else
         {
            _respondingRepo.AddResponseItem_ToVendorResponse(ri, _vendorResponseId);
         }

         selectedResponseItem = _respondingRepo.GetResponseItem(ri.Id);

         ReloadSelectedRow();
         UpdateTotals();

         SetReadyForEntry();
      }
      private void deleteRecordButton_Click(object sender, EventArgs e)
      {
         //if(selectedResponseItem.Elected)
         //{
         //    MessageBox.Show("Vendor Response cannot be removed because it is currently the elected response for this item. Please clear elections on this item before removing.", "Vendor Response Elected");
         //    return;
         //}
         _respondingRepo.DeleteResponseItem(selectedResponseItem.Id);
         selectedResponseItem = null;



         ReloadSelectedRow();
         UpdateTotals();

         RemoveHangingAlternateFromListView(selectedItem);

         SetReadyForEntry();
      }

      /// <summary>
      /// Removes all extra listviewitems on the list for an item that haven't been been requested.
      /// </summary>
      /// <param name="item"></param>
      private void RemoveHangingAlternateFromListView(Item item)
      {
         var listItems = itemsToRespondListView.Items.Cast<ListViewItem>();

         var responsesForItem = listItems
             .Where(x => x.Tag == item)
             .ToList();

         var blankResponsesForItem = responsesForItem.Where(x => x.SubItems[0].Tag == null).ToList();

         if (responsesForItem.Count > 1 && blankResponsesForItem.Count > 0)
         {
            itemsToRespondListView.Items.RemoveAt(blankResponsesForItem[0].Index);
         }
      }

      private ResponseItem generateResponseItemFromFields()
      {
         Item item;
         string code;
         decimal price;
         decimal alternateQuantity;
         string alternateUnit;
         bool isAlternate;
         string alternateDescription;
         bool isElected;
         string electionReason;

         ResponseItem ri;

         item = _catalogingRepo.GetItem(selectedItem.Id);
         price = decimal.Parse(vendorPriceTextBox.Text);
         code = vendorPartNumberTextBox.Text;
         isAlternate = isAlternateCheckbox.Checked;
         if (isAlternateCheckbox.Checked)
         {
            alternateUnit = alternateUnitTextBox.Text;
            alternateQuantity = decimal.Parse(alternateQuantityTextBox.Text);
            alternateDescription = alternateDescriptionTextBox.Text;
         }
         else
         {
            alternateUnit = null;
            alternateQuantity = 0;
            alternateDescription = null;
         }
         isElected = false;
         electionReason = null;
         ri = new ResponseItem(
             null,
             item,
             code,
             price,
             alternateQuantity,
             alternateUnit,
             isAlternate,
             alternateDescription,
             isElected,
             electionReason
             );

         return ri;
      }
      #endregion


      #region KEY INPUT METHODS
      private void VendorResponseEditScreen_KeyDown(object sender, KeyEventArgs e)
      {
         CheckForSaveKey(e);
         CheckForDeleteKey(e);
         CheckForListNavigationKeys(e);
         CheckForExitKey(e);
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
         if (itemsToRespondListView.SelectedItems.Count == 0)
            return;

         int selectedIndex = itemsToRespondListView.SelectedItems[0].Index;

         if ((e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down) && selectedIndex < itemsToRespondListView.Items.Count - 1)
         {
            itemsToRespondListView.Items[selectedIndex++].Selected = false;
            itemsToRespondListView.Items[selectedIndex].Selected = true;
            itemsToRespondListView.Items[selectedIndex].EnsureVisible();

            SetReadyForEntry();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }

         if ((e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up) && selectedIndex > 0)
         {
            itemsToRespondListView.Items[selectedIndex--].Selected = false;
            itemsToRespondListView.Items[selectedIndex].Selected = true;
            itemsToRespondListView.Items[selectedIndex].EnsureVisible();

            SetReadyForEntry();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForExitKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Escape)
         {
            _hostForm.GoBack();
            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }

      #endregion

      #region ADD ALTERNATE BUTTON
      private void addAlternateButton_Click(object sender, EventArgs e)
      {
         if (selectedItem == null)
         {
            return;
         }

         var row = loadListRow(null, selectedItem);
         int nextRowIndex = itemsToRespondListView.SelectedIndices[0] + 1;

         itemsToRespondListView.Items.Insert(nextRowIndex, row);

         ClearListSelections();
         row.Selected = true;

         selectedItem = itemsToRespondListView.SelectedItems[0].Tag as Item;
         selectedResponseItem = itemsToRespondListView.SelectedItems[0].SubItems[0].Tag as ResponseItem;

         ReloadSelectedRow();
         LoadFields();
      }
      #endregion
   }
}
