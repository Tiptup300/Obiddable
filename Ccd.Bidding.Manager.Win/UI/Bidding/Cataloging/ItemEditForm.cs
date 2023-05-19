using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    public partial class ItemEditForm : Form
    {
        private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
        private readonly CatalogingService _catalogingService = new CatalogingService(new EFCatalogingRepo());

        private Bid _bid;
        private int _itemId;


        public ItemEditForm(Bid bid)
        {
            InitializeComponent();
            _bid = bid;

            LoadCategories();
        }

        public ItemEditForm(Item item) : this(item.Bid)
        {
            Text = "Edit Item";

            _itemId = item.Id;
            codeTextBox.Text = item.FormattedCode;
            unitDescriptionTextBox.Text = item.Unit;
            categoryComboBox.Text = item.Category;
            substitutableCheckBox.Checked = item.Substitutable;
            descriptionTextBox.Text = item.Description;

            estimatedPriceTextBox.Text = item.Price.ToString("0.0000");
            lastOrderPriceTextBox.Text = item.Last_Order_Price.ToString("0.0000");

        }

        private void LoadCategories() => categoryComboBox.Items.AddRange(_catalogingService.GetItemCategories_ByBid(_bid.Id));

        #region GET OBJECT METHOD

        public Item GetItem()
        {
            Item output;
            int id;
            Bid bid;
            int code;
            string category;
            string description;
            bool substitutable;
            string unit;
            decimal lastOrderPrice;
            decimal price;

            if (dataIsValid() == false)
            {
                return null;
            }
            id = _itemId;
            bid = _bid;
            code = int.Parse(codeTextBox.Text);
            category = categoryComboBox.Text;
            description = descriptionTextBox.Text;
            substitutable = substitutableCheckBox.Checked;
            unit = unitDescriptionTextBox.Text;
            lastOrderPrice = string.IsNullOrEmpty(lastOrderPriceTextBox.Text) ? 0 : decimal.Parse(lastOrderPriceTextBox.Text);
            price = string.IsNullOrEmpty(estimatedPriceTextBox.Text) ? 0 : decimal.Parse(estimatedPriceTextBox.Text);
            output = new Item(id, bid, code, category, description, substitutable, unit, lastOrderPrice, price);

            return output;
        }

        #endregion

        #region DATA VALIDATION METHOD

        private bool dataIsValid()
        {
            // codeTextBox
            if (codeTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(codeTextBox, CatalogingMessaging.Instance.GetItemCodeCannotBeBlank());
                return false;
            }
            if (codeTextBox.Text.Length > 255)
            {
                errorProvider1.SetError(codeTextBox, CatalogingMessaging.Instance.GetItemCodeCannotTooLong());
                return false;
            }
            int code = 0;
            if (!int.TryParse(codeTextBox.Text, out code) || code < 1 || code > 999999)
            {
                errorProvider1.SetError(codeTextBox, CatalogingMessaging.Instance.GetItemCodeValueInvalid());
                return false;
            }
            if (_catalogingService.ItemCodeExistsInBid(code, _bid.Id,_itemId))
            {
                errorProvider1.SetError(codeTextBox, CatalogingMessaging.Instance.GetItemCodeAlreadyExistsWithinBid());
                return false;
            }
            // unitDescriptionTextBox
            if (unitDescriptionTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(unitDescriptionTextBox, CatalogingMessaging.Instance.GetItemUnitCannotBeBlank());
                return false;
            }
            if (unitDescriptionTextBox.Text.Length > 255)
            {
                errorProvider1.SetError(unitDescriptionTextBox, CatalogingMessaging.Instance.GetItemUnitTooLong());
                return false;
            }
            // categoryComboBox
            if ( categoryComboBox.Text.Length > 255)
            {
                errorProvider1.SetError(categoryComboBox, CatalogingMessaging.Instance.GetItemCategoryTooLong());
                return false;
            }
            // estimatedPriceTextbox
            if(estimatedPriceTextBox.Text.Length > 0 && !decimal.TryParse(estimatedPriceTextBox.Text,out decimal num))
            {
                errorProvider1.SetError(estimatedPriceTextBox, CatalogingMessaging.Instance.GetItemEstimatedPriceNotANumber());
                return false;
            }

            if(descriptionTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(descriptionTextBox, "Description Length Is Invalid");
                return false;
            }

            //if(substitutableCheckBox.Checked && bmRepo.Check_ItemHasAlternateResponded(_itemId,_bid.Id))
            //{
            //    errorProvider1.SetError(substitutableCheckBox, "Cannot set item to substitutable if there are vendor responses for this item with alternates.");
            //    return false;
            //}

            return true;
        }

        #endregion

        #region BUTTON EVENTS

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataIsValid())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        #endregion

        private void ItemEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !descriptionTextBox.Focused)
            {
                toolStripButton2_Click(sender, e);
            }

            if(e.KeyCode == Keys.Escape)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
