using Obiddable.Win.Library.UI.ListViews;
using System;
using System.Windows.Forms;

namespace Obiddable.Win.UI.Bidding.Responding
{
    partial class VendorResponseEditScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vendorNameTextBox = new System.Windows.Forms.TextBox();
            this.vendorNameLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.itemsToRespondListView = new SortableListView();
            this.itemIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorResponseIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qtyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorpartnumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alternateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorExtPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.quantityRequestedLabel = new System.Windows.Forms.Label();
            this.quantityRequestedTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.vendorPriceLabel = new System.Windows.Forms.Label();
            this.vendorPriceTextBox = new System.Windows.Forms.TextBox();
            this.vendorPartNumberLabel = new System.Windows.Forms.Label();
            this.vendorPartNumberTextBox = new System.Windows.Forms.TextBox();
            this.isAlternateCheckbox = new System.Windows.Forms.CheckBox();
            this.alternateUnitLabel = new System.Windows.Forms.Label();
            this.alternateUnitTextBox = new System.Windows.Forms.TextBox();
            this.alternateQuantityLabel = new System.Windows.Forms.Label();
            this.alternateQuantityTextBox = new System.Windows.Forms.TextBox();
            this.alternateDescriptionLabel = new System.Windows.Forms.Label();
            this.alternateDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.itemInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.substitutableTextBox = new System.Windows.Forms.TextBox();
            this.substitutableLabel = new System.Windows.Forms.Label();
            this.saveVendorNameButton = new System.Windows.Forms.Button();
            this.vendorResponseItemGroupBox = new System.Windows.Forms.GroupBox();
            this.extendedPriceLabel = new System.Windows.Forms.Label();
            this.vendorExtendedPriceTextBox = new System.Windows.Forms.TextBox();
            this.deleteRecordButton = new System.Windows.Forms.Button();
            this.saveRecordButton = new System.Windows.Forms.Button();
            this.itemsRespondedLabel = new System.Windows.Forms.Label();
            this.itemsRespondedTextBox = new System.Windows.Forms.TextBox();
            this.itemsRequestedLabel = new System.Windows.Forms.Label();
            this.itemsRequestedTextBox = new System.Windows.Forms.TextBox();
            this.totalVendorPriceLabel = new System.Windows.Forms.Label();
            this.totalVendorPriceTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.addAlternateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.itemInformationGroupBox.SuspendLayout();
            this.vendorResponseItemGroupBox.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vendorNameTextBox
            // 
            this.vendorNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vendorNameTextBox.Location = new System.Drawing.Point(117, 88);
            this.vendorNameTextBox.Name = "vendorNameTextBox";
            this.vendorNameTextBox.Size = new System.Drawing.Size(842, 23);
            this.vendorNameTextBox.TabIndex = 1;
            // 
            // vendorNameLabel
            // 
            this.vendorNameLabel.AutoSize = true;
            this.vendorNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorNameLabel.Location = new System.Drawing.Point(15, 91);
            this.vendorNameLabel.Name = "vendorNameLabel";
            this.vendorNameLabel.Size = new System.Drawing.Size(81, 13);
            this.vendorNameLabel.TabIndex = 5;
            this.vendorNameLabel.Text = "Vendor Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // itemsToRespondListView
            // 
            this.itemsToRespondListView.AllowColumnReorder = true;
            this.itemsToRespondListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsToRespondListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemIdColumnHeader,
            this.vendorResponseIdColumnHeader,
            this.codeColumnHeader,
            this.descriptionColumnHeader,
            this.unitColumnHeader,
            this.categoryColumnHeader,
            this.subColumnHeader,
            this.qtyColumnHeader,
            this.vendorpartnumberColumnHeader,
            this.alternateColumnHeader,
            this.vendorPriceColumnHeader,
            this.vendorExtPriceColumnHeader});
            this.itemsToRespondListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.itemsToRespondListView.FullRowSelect = true;
            this.itemsToRespondListView.GridLines = true;
            this.itemsToRespondListView.HideSelection = false;
            this.itemsToRespondListView.Location = new System.Drawing.Point(19, 119);
            this.itemsToRespondListView.Margin = new System.Windows.Forms.Padding(2);
            this.itemsToRespondListView.Name = "itemsToRespondListView";
            this.itemsToRespondListView.Size = new System.Drawing.Size(1101, 93);
            this.itemsToRespondListView.TabIndex = 0;
            this.itemsToRespondListView.UseCompatibleStateImageBehavior = false;
            this.itemsToRespondListView.View = System.Windows.Forms.View.Details;
            this.itemsToRespondListView.SelectedIndexChanged += new System.EventHandler(this.itemsToRespondListView_SelectedIndexChanged);
            this.itemsToRespondListView.Click += new System.EventHandler(this.itemsToRespondListView_Click);
            // 
            // itemIdColumnHeader
            // 
            this.itemIdColumnHeader.Text = "itemId";
            this.itemIdColumnHeader.Width = 0;
            // 
            // vendorResponseIdColumnHeader
            // 
            this.vendorResponseIdColumnHeader.Text = "responseId";
            this.vendorResponseIdColumnHeader.Width = 0;
            // 
            // codeColumnHeader
            // 
            this.codeColumnHeader.Text = "Code";
            this.codeColumnHeader.Width = 81;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 574;
            // 
            // unitColumnHeader
            // 
            this.unitColumnHeader.Text = "Unit";
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 178;
            // 
            // subColumnHeader
            // 
            this.subColumnHeader.Text = "Substituable";
            this.subColumnHeader.Width = 84;
            // 
            // qtyColumnHeader
            // 
            this.qtyColumnHeader.Text = "Quantity Requested";
            this.qtyColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyColumnHeader.Width = 117;
            // 
            // vendorpartnumberColumnHeader
            // 
            this.vendorpartnumberColumnHeader.Text = "Vendor Part Number";
            this.vendorpartnumberColumnHeader.Width = 126;
            // 
            // alternateColumnHeader
            // 
            this.alternateColumnHeader.Text = "Alternate";
            this.alternateColumnHeader.Width = 107;
            // 
            // vendorPriceColumnHeader
            // 
            this.vendorPriceColumnHeader.Text = "Response Price";
            this.vendorPriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vendorPriceColumnHeader.Width = 98;
            // 
            // vendorExtPriceColumnHeader
            // 
            this.vendorExtPriceColumnHeader.Text = "Extended Response Price";
            this.vendorExtPriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.codeLabel.Location = new System.Drawing.Point(3, 106);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(37, 13);
            this.codeLabel.TabIndex = 10;
            this.codeLabel.Text = "Code:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.codeTextBox.Location = new System.Drawing.Point(7, 124);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(154, 23);
            this.codeTextBox.TabIndex = 17;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.unitLabel.Location = new System.Drawing.Point(166, 106);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(32, 13);
            this.unitLabel.TabIndex = 12;
            this.unitLabel.Text = "Unit:";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.unitTextBox.Location = new System.Drawing.Point(169, 124);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.ReadOnly = true;
            this.unitTextBox.Size = new System.Drawing.Size(65, 23);
            this.unitTextBox.TabIndex = 18;
            // 
            // quantityRequestedLabel
            // 
            this.quantityRequestedLabel.AutoSize = true;
            this.quantityRequestedLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityRequestedLabel.Location = new System.Drawing.Point(94, 20);
            this.quantityRequestedLabel.Name = "quantityRequestedLabel";
            this.quantityRequestedLabel.Size = new System.Drawing.Size(54, 13);
            this.quantityRequestedLabel.TabIndex = 14;
            this.quantityRequestedLabel.Text = "QTY Req:";
            // 
            // quantityRequestedTextBox
            // 
            this.quantityRequestedTextBox.Enabled = false;
            this.quantityRequestedTextBox.Location = new System.Drawing.Point(98, 38);
            this.quantityRequestedTextBox.Name = "quantityRequestedTextBox";
            this.quantityRequestedTextBox.ReadOnly = true;
            this.quantityRequestedTextBox.Size = new System.Drawing.Size(66, 23);
            this.quantityRequestedTextBox.TabIndex = 4;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descriptionTextBox.Location = new System.Drawing.Point(7, 36);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(1092, 67);
            this.descriptionTextBox.TabIndex = 16;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 17);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(66, 13);
            this.descriptionLabel.TabIndex = 16;
            this.descriptionLabel.Text = "Description";
            // 
            // vendorPriceLabel
            // 
            this.vendorPriceLabel.AutoSize = true;
            this.vendorPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorPriceLabel.Location = new System.Drawing.Point(7, 20);
            this.vendorPriceLabel.Name = "vendorPriceLabel";
            this.vendorPriceLabel.Size = new System.Drawing.Size(60, 13);
            this.vendorPriceLabel.TabIndex = 18;
            this.vendorPriceLabel.Text = "Unit Price:";
            // 
            // vendorPriceTextBox
            // 
            this.vendorPriceTextBox.Location = new System.Drawing.Point(7, 38);
            this.vendorPriceTextBox.Name = "vendorPriceTextBox";
            this.vendorPriceTextBox.Size = new System.Drawing.Size(83, 23);
            this.vendorPriceTextBox.TabIndex = 3;
            this.vendorPriceTextBox.TextChanged += new System.EventHandler(this.ExtendedPriceChanged);
            this.vendorPriceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // vendorPartNumberLabel
            // 
            this.vendorPartNumberLabel.AutoSize = true;
            this.vendorPartNumberLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorPartNumberLabel.Location = new System.Drawing.Point(7, 69);
            this.vendorPartNumberLabel.Name = "vendorPartNumberLabel";
            this.vendorPartNumberLabel.Size = new System.Drawing.Size(117, 13);
            this.vendorPartNumberLabel.TabIndex = 20;
            this.vendorPartNumberLabel.Text = "Vendor Part Number:";
            // 
            // vendorPartNumberTextBox
            // 
            this.vendorPartNumberTextBox.Location = new System.Drawing.Point(7, 88);
            this.vendorPartNumberTextBox.Name = "vendorPartNumberTextBox";
            this.vendorPartNumberTextBox.Size = new System.Drawing.Size(249, 23);
            this.vendorPartNumberTextBox.TabIndex = 6;
            this.vendorPartNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // isAlternateCheckbox
            // 
            this.isAlternateCheckbox.AutoSize = true;
            this.isAlternateCheckbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.isAlternateCheckbox.Location = new System.Drawing.Point(73, 119);
            this.isAlternateCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.isAlternateCheckbox.Name = "isAlternateCheckbox";
            this.isAlternateCheckbox.Size = new System.Drawing.Size(85, 17);
            this.isAlternateCheckbox.TabIndex = 7;
            this.isAlternateCheckbox.Text = "Is Alternate";
            this.isAlternateCheckbox.UseVisualStyleBackColor = true;
            this.isAlternateCheckbox.CheckedChanged += new System.EventHandler(this.AlternateCheckboxSwitched);
            // 
            // alternateUnitLabel
            // 
            this.alternateUnitLabel.AutoSize = true;
            this.alternateUnitLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternateUnitLabel.Location = new System.Drawing.Point(562, 20);
            this.alternateUnitLabel.Name = "alternateUnitLabel";
            this.alternateUnitLabel.Size = new System.Drawing.Size(50, 13);
            this.alternateUnitLabel.TabIndex = 22;
            this.alternateUnitLabel.Text = "Alt Unit:";
            // 
            // alternateUnitTextBox
            // 
            this.alternateUnitTextBox.Enabled = false;
            this.alternateUnitTextBox.Location = new System.Drawing.Point(628, 16);
            this.alternateUnitTextBox.Name = "alternateUnitTextBox";
            this.alternateUnitTextBox.Size = new System.Drawing.Size(157, 23);
            this.alternateUnitTextBox.TabIndex = 11;
            this.alternateUnitTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // alternateQuantityLabel
            // 
            this.alternateQuantityLabel.AutoSize = true;
            this.alternateQuantityLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternateQuantityLabel.Location = new System.Drawing.Point(339, 20);
            this.alternateQuantityLabel.Name = "alternateQuantityLabel";
            this.alternateQuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.alternateQuantityLabel.TabIndex = 24;
            this.alternateQuantityLabel.Text = "Alt QTY:";
            // 
            // alternateQuantityTextBox
            // 
            this.alternateQuantityTextBox.Enabled = false;
            this.alternateQuantityTextBox.Location = new System.Drawing.Point(404, 16);
            this.alternateQuantityTextBox.Name = "alternateQuantityTextBox";
            this.alternateQuantityTextBox.Size = new System.Drawing.Size(154, 23);
            this.alternateQuantityTextBox.TabIndex = 10;
            this.alternateQuantityTextBox.TextChanged += new System.EventHandler(this.ExtendedPriceChanged);
            this.alternateQuantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // alternateDescriptionLabel
            // 
            this.alternateDescriptionLabel.AutoSize = true;
            this.alternateDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternateDescriptionLabel.Location = new System.Drawing.Point(295, 48);
            this.alternateDescriptionLabel.Name = "alternateDescriptionLabel";
            this.alternateDescriptionLabel.Size = new System.Drawing.Size(87, 13);
            this.alternateDescriptionLabel.TabIndex = 26;
            this.alternateDescriptionLabel.Text = "Alt Description:";
            // 
            // alternateDescriptionTextBox
            // 
            this.alternateDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alternateDescriptionTextBox.Enabled = false;
            this.alternateDescriptionTextBox.Location = new System.Drawing.Point(404, 48);
            this.alternateDescriptionTextBox.Multiline = true;
            this.alternateDescriptionTextBox.Name = "alternateDescriptionTextBox";
            this.alternateDescriptionTextBox.Size = new System.Drawing.Size(380, 88);
            this.alternateDescriptionTextBox.TabIndex = 12;
            this.alternateDescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // itemInformationGroupBox
            // 
            this.itemInformationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemInformationGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.itemInformationGroupBox.Controls.Add(this.substitutableTextBox);
            this.itemInformationGroupBox.Controls.Add(this.substitutableLabel);
            this.itemInformationGroupBox.Controls.Add(this.descriptionTextBox);
            this.itemInformationGroupBox.Controls.Add(this.codeTextBox);
            this.itemInformationGroupBox.Controls.Add(this.descriptionLabel);
            this.itemInformationGroupBox.Controls.Add(this.codeLabel);
            this.itemInformationGroupBox.Controls.Add(this.unitTextBox);
            this.itemInformationGroupBox.Controls.Add(this.unitLabel);
            this.itemInformationGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemInformationGroupBox.Location = new System.Drawing.Point(13, 419);
            this.itemInformationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.itemInformationGroupBox.Name = "itemInformationGroupBox";
            this.itemInformationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.itemInformationGroupBox.Size = new System.Drawing.Size(1108, 158);
            this.itemInformationGroupBox.TabIndex = 17;
            this.itemInformationGroupBox.TabStop = false;
            this.itemInformationGroupBox.Text = "Item Information";
            // 
            // substitutableTextBox
            // 
            this.substitutableTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.substitutableTextBox.Location = new System.Drawing.Point(241, 124);
            this.substitutableTextBox.Name = "substitutableTextBox";
            this.substitutableTextBox.ReadOnly = true;
            this.substitutableTextBox.Size = new System.Drawing.Size(263, 23);
            this.substitutableTextBox.TabIndex = 19;
            // 
            // substitutableLabel
            // 
            this.substitutableLabel.AutoSize = true;
            this.substitutableLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.substitutableLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.substitutableLabel.Location = new System.Drawing.Point(238, 106);
            this.substitutableLabel.Name = "substitutableLabel";
            this.substitutableLabel.Size = new System.Drawing.Size(75, 13);
            this.substitutableLabel.TabIndex = 18;
            this.substitutableLabel.Text = "Substituable:";
            // 
            // saveVendorNameButton
            // 
            this.saveVendorNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveVendorNameButton.Location = new System.Drawing.Point(965, 85);
            this.saveVendorNameButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveVendorNameButton.Name = "saveVendorNameButton";
            this.saveVendorNameButton.Size = new System.Drawing.Size(155, 25);
            this.saveVendorNameButton.TabIndex = 1;
            this.saveVendorNameButton.Text = "Save Vendor Name";
            this.saveVendorNameButton.UseVisualStyleBackColor = true;
            this.saveVendorNameButton.Click += new System.EventHandler(this.saveVendorNameButton_Click);
            // 
            // vendorResponseItemGroupBox
            // 
            this.vendorResponseItemGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vendorResponseItemGroupBox.Controls.Add(this.addAlternateButton);
            this.vendorResponseItemGroupBox.Controls.Add(this.extendedPriceLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.vendorExtendedPriceTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateUnitLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.isAlternateCheckbox);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateDescriptionLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateUnitTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateDescriptionTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.quantityRequestedLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateQuantityLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.alternateQuantityTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.quantityRequestedTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.vendorPriceLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.vendorPriceTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.deleteRecordButton);
            this.vendorResponseItemGroupBox.Controls.Add(this.vendorPartNumberTextBox);
            this.vendorResponseItemGroupBox.Controls.Add(this.vendorPartNumberLabel);
            this.vendorResponseItemGroupBox.Controls.Add(this.saveRecordButton);
            this.vendorResponseItemGroupBox.Location = new System.Drawing.Point(19, 217);
            this.vendorResponseItemGroupBox.Name = "vendorResponseItemGroupBox";
            this.vendorResponseItemGroupBox.Size = new System.Drawing.Size(811, 193);
            this.vendorResponseItemGroupBox.TabIndex = 30;
            this.vendorResponseItemGroupBox.TabStop = false;
            // 
            // extendedPriceLabel
            // 
            this.extendedPriceLabel.AutoSize = true;
            this.extendedPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedPriceLabel.Location = new System.Drawing.Point(168, 20);
            this.extendedPriceLabel.Name = "extendedPriceLabel";
            this.extendedPriceLabel.Size = new System.Drawing.Size(87, 13);
            this.extendedPriceLabel.TabIndex = 34;
            this.extendedPriceLabel.Text = "Extended Price:";
            // 
            // vendorExtendedPriceTextBox
            // 
            this.vendorExtendedPriceTextBox.Enabled = false;
            this.vendorExtendedPriceTextBox.Location = new System.Drawing.Point(171, 38);
            this.vendorExtendedPriceTextBox.Name = "vendorExtendedPriceTextBox";
            this.vendorExtendedPriceTextBox.ReadOnly = true;
            this.vendorExtendedPriceTextBox.Size = new System.Drawing.Size(84, 23);
            this.vendorExtendedPriceTextBox.TabIndex = 5;
            // 
            // deleteRecordButton
            // 
            this.deleteRecordButton.Location = new System.Drawing.Point(128, 150);
            this.deleteRecordButton.Name = "deleteRecordButton";
            this.deleteRecordButton.Size = new System.Drawing.Size(127, 27);
            this.deleteRecordButton.TabIndex = 9;
            this.deleteRecordButton.Text = "Delete Record";
            this.deleteRecordButton.UseVisualStyleBackColor = true;
            this.deleteRecordButton.Click += new System.EventHandler(this.deleteRecordButton_Click);
            // 
            // saveRecordButton
            // 
            this.saveRecordButton.Location = new System.Drawing.Point(6, 150);
            this.saveRecordButton.Name = "saveRecordButton";
            this.saveRecordButton.Size = new System.Drawing.Size(115, 27);
            this.saveRecordButton.TabIndex = 8;
            this.saveRecordButton.Text = "Save Record";
            this.saveRecordButton.UseVisualStyleBackColor = true;
            this.saveRecordButton.Click += new System.EventHandler(this.saveRecordButton_Click);
            this.saveRecordButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseEditScreen_KeyDown);
            // 
            // itemsRespondedLabel
            // 
            this.itemsRespondedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsRespondedLabel.AutoSize = true;
            this.itemsRespondedLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsRespondedLabel.Location = new System.Drawing.Point(839, 253);
            this.itemsRespondedLabel.Name = "itemsRespondedLabel";
            this.itemsRespondedLabel.Size = new System.Drawing.Size(100, 13);
            this.itemsRespondedLabel.TabIndex = 28;
            this.itemsRespondedLabel.Text = "Items Responded:";
            this.itemsRespondedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemsRespondedTextBox
            // 
            this.itemsRespondedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsRespondedTextBox.Enabled = false;
            this.itemsRespondedTextBox.Location = new System.Drawing.Point(966, 249);
            this.itemsRespondedTextBox.Name = "itemsRespondedTextBox";
            this.itemsRespondedTextBox.Size = new System.Drawing.Size(154, 23);
            this.itemsRespondedTextBox.TabIndex = 14;
            // 
            // itemsRequestedLabel
            // 
            this.itemsRequestedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsRequestedLabel.AutoSize = true;
            this.itemsRequestedLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsRequestedLabel.Location = new System.Drawing.Point(839, 221);
            this.itemsRequestedLabel.Name = "itemsRequestedLabel";
            this.itemsRequestedLabel.Size = new System.Drawing.Size(96, 13);
            this.itemsRequestedLabel.TabIndex = 34;
            this.itemsRequestedLabel.Text = "Items Requested:";
            this.itemsRequestedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemsRequestedTextBox
            // 
            this.itemsRequestedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsRequestedTextBox.Enabled = false;
            this.itemsRequestedTextBox.Location = new System.Drawing.Point(966, 217);
            this.itemsRequestedTextBox.Name = "itemsRequestedTextBox";
            this.itemsRequestedTextBox.Size = new System.Drawing.Size(154, 23);
            this.itemsRequestedTextBox.TabIndex = 13;
            // 
            // totalVendorPriceLabel
            // 
            this.totalVendorPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalVendorPriceLabel.AutoSize = true;
            this.totalVendorPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVendorPriceLabel.Location = new System.Drawing.Point(839, 285);
            this.totalVendorPriceLabel.Name = "totalVendorPriceLabel";
            this.totalVendorPriceLabel.Size = new System.Drawing.Size(103, 13);
            this.totalVendorPriceLabel.TabIndex = 36;
            this.totalVendorPriceLabel.Text = "Total Vendor Price:";
            this.totalVendorPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalVendorPriceTextBox
            // 
            this.totalVendorPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalVendorPriceTextBox.Enabled = false;
            this.totalVendorPriceTextBox.Location = new System.Drawing.Point(966, 282);
            this.totalVendorPriceTextBox.Name = "totalVendorPriceTextBox";
            this.totalVendorPriceTextBox.Size = new System.Drawing.Size(154, 23);
            this.totalVendorPriceTextBox.TabIndex = 15;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backButton.FlatAppearance.BorderSize = 2;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(1016, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(112, 64);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 9);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(379, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Edit Vendor Response";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(115)))), ((int)(((byte)(153)))));
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1131, 71);
            this.topPanel.TabIndex = 45;
            // 
            // addAlternateButton
            // 
            this.addAlternateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAlternateButton.Location = new System.Drawing.Point(684, 142);
            this.addAlternateButton.Name = "addAlternateButton";
            this.addAlternateButton.Size = new System.Drawing.Size(100, 27);
            this.addAlternateButton.TabIndex = 35;
            this.addAlternateButton.Text = "Add Alternate";
            this.addAlternateButton.UseVisualStyleBackColor = true;
            this.addAlternateButton.Click += new System.EventHandler(this.addAlternateButton_Click);
            // 
            // VendorResponseEditScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.totalVendorPriceLabel);
            this.Controls.Add(this.totalVendorPriceTextBox);
            this.Controls.Add(this.itemsRequestedLabel);
            this.Controls.Add(this.itemsRequestedTextBox);
            this.Controls.Add(this.itemsRespondedLabel);
            this.Controls.Add(this.vendorResponseItemGroupBox);
            this.Controls.Add(this.itemsRespondedTextBox);
            this.Controls.Add(this.itemInformationGroupBox);
            this.Controls.Add(this.saveVendorNameButton);
            this.Controls.Add(this.itemsToRespondListView);
            this.Controls.Add(this.vendorNameLabel);
            this.Controls.Add(this.vendorNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "VendorResponseEditScreen";
            this.Size = new System.Drawing.Size(1131, 587);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.itemInformationGroupBox.ResumeLayout(false);
            this.itemInformationGroupBox.PerformLayout();
            this.vendorResponseItemGroupBox.ResumeLayout(false);
            this.vendorResponseItemGroupBox.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox vendorNameTextBox;
        private System.Windows.Forms.Label vendorNameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label vendorPartNumberLabel;
        public System.Windows.Forms.TextBox vendorPartNumberTextBox;
        private System.Windows.Forms.Label vendorPriceLabel;
        private SortableListView itemsToRespondListView;
        public System.Windows.Forms.TextBox vendorPriceTextBox;
        private System.Windows.Forms.CheckBox isAlternateCheckbox;
        private System.Windows.Forms.Label alternateDescriptionLabel;
        public System.Windows.Forms.TextBox alternateDescriptionTextBox;
        private System.Windows.Forms.Label alternateQuantityLabel;
        public System.Windows.Forms.TextBox alternateQuantityTextBox;
        private System.Windows.Forms.Label alternateUnitLabel;
        public System.Windows.Forms.TextBox alternateUnitTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label quantityRequestedLabel;
        public System.Windows.Forms.TextBox quantityRequestedTextBox;
        private System.Windows.Forms.Label unitLabel;
        public System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label codeLabel;
        public System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.GroupBox itemInformationGroupBox;
        private System.Windows.Forms.Button saveVendorNameButton;
        private System.Windows.Forms.ColumnHeader itemIdColumnHeader;
        private System.Windows.Forms.ColumnHeader vendorResponseIdColumnHeader;
        private System.Windows.Forms.ColumnHeader codeColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader qtyColumnHeader;
        private System.Windows.Forms.ColumnHeader unitColumnHeader;
        private System.Windows.Forms.ColumnHeader categoryColumnHeader;
        private System.Windows.Forms.ColumnHeader subColumnHeader;
        private System.Windows.Forms.ColumnHeader vendorPriceColumnHeader;
        private System.Windows.Forms.ColumnHeader vendorpartnumberColumnHeader;
        private System.Windows.Forms.ColumnHeader alternateColumnHeader;
        private System.Windows.Forms.Label totalVendorPriceLabel;
        public System.Windows.Forms.TextBox totalVendorPriceTextBox;
        private System.Windows.Forms.Label itemsRequestedLabel;
        public System.Windows.Forms.TextBox itemsRequestedTextBox;
        private System.Windows.Forms.Label itemsRespondedLabel;
        private System.Windows.Forms.GroupBox vendorResponseItemGroupBox;
        public System.Windows.Forms.TextBox itemsRespondedTextBox;
        private System.Windows.Forms.Button deleteRecordButton;
        public System.Windows.Forms.TextBox substitutableTextBox;
        private System.Windows.Forms.Label substitutableLabel;
        private System.Windows.Forms.Button saveRecordButton;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Button backButton;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.TextBox vendorExtendedPriceTextBox;
        private System.Windows.Forms.Label extendedPriceLabel;
        private ColumnHeader vendorExtPriceColumnHeader;
        private Button addAlternateButton;
    }
}