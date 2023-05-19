using Ccd.Bidding.Manager.Win.Library.UI.ListViews;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
    partial class RequestEditScreen
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
            this.accountNumberLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.deleteRecordButton = new System.Windows.Forms.Button();
            this.saveRecordButton = new System.Windows.Forms.Button();
            this.amountRequestedTextBox = new System.Windows.Forms.TextBox();
            this.amountRequestedLabel = new System.Windows.Forms.Label();
            this.overridePriceCheckbox = new System.Windows.Forms.CheckBox();
            this.overridePriceTextBox = new System.Windows.Forms.TextBox();
            this.overridePriceLabel = new System.Windows.Forms.Label();
            this.itemInformationPanel = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.substitutableTextBox = new System.Windows.Forms.TextBox();
            this.substitutableLabel = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.itemsToRequestListView = new SortableListView();
            this.itemIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.requestItemIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.overridePriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qtyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extendedPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extendedPriceWithOverrideColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveAccountNumberButton = new System.Windows.Forms.Button();
            this.totalQtyTextbox = new System.Windows.Forms.TextBox();
            this.totalQtyLabel = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalPriceWithOverrideTextBox = new System.Windows.Forms.TextBox();
            this.totalPriceWithOverrideLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.requestorNameLabel = new System.Windows.Forms.Label();
            this.requestorNameTextBox = new System.Windows.Forms.TextBox();
            this.buildingNumberTextBox = new System.Windows.Forms.TextBox();
            this.buildingNumberLabel = new System.Windows.Forms.Label();
            this.buildingNameTextbox = new System.Windows.Forms.TextBox();
            this.buildingNameLabel = new System.Windows.Forms.Label();
            this.accountNumberComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.itemInformationPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountNumberLabel
            // 
            this.accountNumberLabel.AutoSize = true;
            this.accountNumberLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountNumberLabel.Location = new System.Drawing.Point(6, 142);
            this.accountNumberLabel.Name = "accountNumberLabel";
            this.accountNumberLabel.Size = new System.Drawing.Size(99, 13);
            this.accountNumberLabel.TabIndex = 7;
            this.accountNumberLabel.Text = "Account Number:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // deleteRecordButton
            // 
            this.deleteRecordButton.Location = new System.Drawing.Point(379, 49);
            this.deleteRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteRecordButton.Name = "deleteRecordButton";
            this.deleteRecordButton.Size = new System.Drawing.Size(114, 31);
            this.deleteRecordButton.TabIndex = 34;
            this.deleteRecordButton.Text = "Delete Record";
            this.deleteRecordButton.UseVisualStyleBackColor = true;
            this.deleteRecordButton.Click += new System.EventHandler(this.deleteRecordButton_Click);
            // 
            // saveRecordButton
            // 
            this.saveRecordButton.Location = new System.Drawing.Point(379, 15);
            this.saveRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveRecordButton.Name = "saveRecordButton";
            this.saveRecordButton.Size = new System.Drawing.Size(114, 31);
            this.saveRecordButton.TabIndex = 33;
            this.saveRecordButton.Text = "Save Record";
            this.saveRecordButton.UseVisualStyleBackColor = true;
            this.saveRecordButton.Click += new System.EventHandler(this.saveRecordButton_Click);
            // 
            // amountRequestedTextBox
            // 
            this.amountRequestedTextBox.Location = new System.Drawing.Point(12, 45);
            this.amountRequestedTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.amountRequestedTextBox.Name = "amountRequestedTextBox";
            this.amountRequestedTextBox.Size = new System.Drawing.Size(187, 23);
            this.amountRequestedTextBox.TabIndex = 32;
            this.amountRequestedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RequestEditScreen_KeyDown);
            // 
            // amountRequestedLabel
            // 
            this.amountRequestedLabel.AutoSize = true;
            this.amountRequestedLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountRequestedLabel.Location = new System.Drawing.Point(8, 26);
            this.amountRequestedLabel.Name = "amountRequestedLabel";
            this.amountRequestedLabel.Size = new System.Drawing.Size(111, 13);
            this.amountRequestedLabel.TabIndex = 31;
            this.amountRequestedLabel.Text = "Amount Requested:";
            // 
            // overridePriceCheckbox
            // 
            this.overridePriceCheckbox.AutoSize = true;
            this.overridePriceCheckbox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.overridePriceCheckbox.Location = new System.Drawing.Point(10, 33);
            this.overridePriceCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.overridePriceCheckbox.Name = "overridePriceCheckbox";
            this.overridePriceCheckbox.Size = new System.Drawing.Size(15, 14);
            this.overridePriceCheckbox.TabIndex = 30;
            this.overridePriceCheckbox.UseVisualStyleBackColor = true;
            this.overridePriceCheckbox.CheckedChanged += new System.EventHandler(this.overridePriceCheckbox_CheckedChanged);
            this.overridePriceCheckbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RequestEditScreen_KeyDown);
            // 
            // overridePriceTextBox
            // 
            this.overridePriceTextBox.Location = new System.Drawing.Point(30, 27);
            this.overridePriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.overridePriceTextBox.Name = "overridePriceTextBox";
            this.overridePriceTextBox.Size = new System.Drawing.Size(122, 23);
            this.overridePriceTextBox.TabIndex = 29;
            this.overridePriceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RequestEditScreen_KeyDown);
            // 
            // overridePriceLabel
            // 
            this.overridePriceLabel.AutoSize = true;
            this.overridePriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overridePriceLabel.Location = new System.Drawing.Point(28, 9);
            this.overridePriceLabel.Name = "overridePriceLabel";
            this.overridePriceLabel.Size = new System.Drawing.Size(82, 13);
            this.overridePriceLabel.TabIndex = 28;
            this.overridePriceLabel.Text = "Override Price:";
            // 
            // itemInformationPanel
            // 
            this.itemInformationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemInformationPanel.BackColor = System.Drawing.SystemColors.Control;
            this.itemInformationPanel.Controls.Add(this.descriptionTextBox);
            this.itemInformationPanel.Controls.Add(this.descriptionLabel);
            this.itemInformationPanel.Controls.Add(this.priceTextBox);
            this.itemInformationPanel.Controls.Add(this.priceLabel);
            this.itemInformationPanel.Controls.Add(this.unitTextBox);
            this.itemInformationPanel.Controls.Add(this.unitLabel);
            this.itemInformationPanel.Controls.Add(this.substitutableTextBox);
            this.itemInformationPanel.Controls.Add(this.substitutableLabel);
            this.itemInformationPanel.Controls.Add(this.categoryTextBox);
            this.itemInformationPanel.Controls.Add(this.categoryLabel);
            this.itemInformationPanel.Controls.Add(this.codeTextBox);
            this.itemInformationPanel.Controls.Add(this.codeLabel);
            this.itemInformationPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemInformationPanel.Location = new System.Drawing.Point(9, 360);
            this.itemInformationPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.itemInformationPanel.Name = "itemInformationPanel";
            this.itemInformationPanel.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.itemInformationPanel.Size = new System.Drawing.Size(863, 173);
            this.itemInformationPanel.TabIndex = 0;
            this.itemInformationPanel.TabStop = false;
            this.itemInformationPanel.Text = "Item Information:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.descriptionTextBox.Location = new System.Drawing.Point(14, 41);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(838, 66);
            this.descriptionTextBox.TabIndex = 29;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.descriptionLabel.Location = new System.Drawing.Point(10, 22);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(69, 13);
            this.descriptionLabel.TabIndex = 28;
            this.descriptionLabel.Text = "Description:";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.priceTextBox.Location = new System.Drawing.Point(493, 130);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.Size = new System.Drawing.Size(135, 23);
            this.priceTextBox.TabIndex = 27;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.priceLabel.Location = new System.Drawing.Point(490, 111);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(32, 13);
            this.priceLabel.TabIndex = 26;
            this.priceLabel.Text = "Price";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.unitTextBox.Location = new System.Drawing.Point(286, 130);
            this.unitTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.ReadOnly = true;
            this.unitTextBox.Size = new System.Drawing.Size(96, 23);
            this.unitTextBox.TabIndex = 25;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.unitLabel.Location = new System.Drawing.Point(282, 111);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(29, 13);
            this.unitLabel.TabIndex = 24;
            this.unitLabel.Text = "Unit";
            // 
            // substitutableTextBox
            // 
            this.substitutableTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.substitutableTextBox.Location = new System.Drawing.Point(389, 130);
            this.substitutableTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.substitutableTextBox.Name = "substitutableTextBox";
            this.substitutableTextBox.ReadOnly = true;
            this.substitutableTextBox.Size = new System.Drawing.Size(96, 23);
            this.substitutableTextBox.TabIndex = 23;
            // 
            // substitutableLabel
            // 
            this.substitutableLabel.AutoSize = true;
            this.substitutableLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.substitutableLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.substitutableLabel.Location = new System.Drawing.Point(386, 111);
            this.substitutableLabel.Name = "substitutableLabel";
            this.substitutableLabel.Size = new System.Drawing.Size(76, 13);
            this.substitutableLabel.TabIndex = 22;
            this.substitutableLabel.Text = "Substitutable";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.categoryTextBox.Location = new System.Drawing.Point(119, 130);
            this.categoryTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.Size = new System.Drawing.Size(159, 23);
            this.categoryTextBox.TabIndex = 21;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.categoryLabel.Location = new System.Drawing.Point(115, 111);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(57, 13);
            this.categoryLabel.TabIndex = 20;
            this.categoryLabel.Text = "Category:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.codeTextBox.Location = new System.Drawing.Point(15, 130);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(96, 23);
            this.codeTextBox.TabIndex = 19;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.codeLabel.Location = new System.Drawing.Point(11, 111);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(37, 13);
            this.codeLabel.TabIndex = 18;
            this.codeLabel.Text = "Code:";
            // 
            // itemsToRequestListView
            // 
            this.itemsToRequestListView.AllowColumnReorder = true;
            this.itemsToRequestListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsToRequestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemIdColumnHeader,
            this.requestItemIdColumnHeader,
            this.codeColumnHeader,
            this.descriptionColumnHeader,
            this.unitColumnHeader,
            this.categoryColumnHeader,
            this.priceColumnHeader,
            this.overridePriceColumnHeader,
            this.qtyColumnHeader,
            this.extendedPriceColumnHeader,
            this.extendedPriceWithOverrideColumnHeader});
            this.itemsToRequestListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.itemsToRequestListView.FullRowSelect = true;
            this.itemsToRequestListView.GridLines = true;
            this.itemsToRequestListView.HideSelection = false;
            this.itemsToRequestListView.Location = new System.Drawing.Point(9, 169);
            this.itemsToRequestListView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.itemsToRequestListView.MultiSelect = false;
            this.itemsToRequestListView.Name = "itemsToRequestListView";
            this.itemsToRequestListView.ShowGroups = false;
            this.itemsToRequestListView.Size = new System.Drawing.Size(863, 87);
            this.itemsToRequestListView.TabIndex = 17;
            this.itemsToRequestListView.UseCompatibleStateImageBehavior = false;
            this.itemsToRequestListView.View = System.Windows.Forms.View.Details;
            this.itemsToRequestListView.SelectedIndexChanged += new System.EventHandler(this.itemsToRequestListView_SelectedIndexChanged);
            this.itemsToRequestListView.Click += new System.EventHandler(this.itemsToRequestListView_Click);
            // 
            // itemIdColumnHeader
            // 
            this.itemIdColumnHeader.Text = "itemId";
            this.itemIdColumnHeader.Width = 0;
            // 
            // requestItemIdColumnHeader
            // 
            this.requestItemIdColumnHeader.Text = "requestItemId";
            this.requestItemIdColumnHeader.Width = 0;
            // 
            // codeColumnHeader
            // 
            this.codeColumnHeader.Text = "Code";
            this.codeColumnHeader.Width = 57;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 798;
            // 
            // unitColumnHeader
            // 
            this.unitColumnHeader.Text = "Unit";
            this.unitColumnHeader.Width = 73;
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 123;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Estimated Price";
            this.priceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceColumnHeader.Width = 75;
            // 
            // overridePriceColumnHeader
            // 
            this.overridePriceColumnHeader.Text = "Override Est Price";
            this.overridePriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.overridePriceColumnHeader.Width = 91;
            // 
            // qtyColumnHeader
            // 
            this.qtyColumnHeader.Text = "Quantity Requested";
            this.qtyColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyColumnHeader.Width = 120;
            // 
            // extendedPriceColumnHeader
            // 
            this.extendedPriceColumnHeader.Text = "Extended Est Price";
            this.extendedPriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extendedPriceColumnHeader.Width = 98;
            // 
            // extendedPriceWithOverrideColumnHeader
            // 
            this.extendedPriceWithOverrideColumnHeader.Text = "Extended Est Price (with Overrides)";
            this.extendedPriceWithOverrideColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extendedPriceWithOverrideColumnHeader.Width = 174;
            // 
            // saveAccountNumberButton
            // 
            this.saveAccountNumberButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAccountNumberButton.Location = new System.Drawing.Point(708, 139);
            this.saveAccountNumberButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveAccountNumberButton.Name = "saveAccountNumberButton";
            this.saveAccountNumberButton.Size = new System.Drawing.Size(164, 26);
            this.saveAccountNumberButton.TabIndex = 35;
            this.saveAccountNumberButton.Text = "Save Account Number";
            this.saveAccountNumberButton.UseVisualStyleBackColor = true;
            this.saveAccountNumberButton.Click += new System.EventHandler(this.saveAccountNumberButton_Click);
            // 
            // totalQtyTextbox
            // 
            this.totalQtyTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalQtyTextbox.Enabled = false;
            this.totalQtyTextbox.Location = new System.Drawing.Point(708, 263);
            this.totalQtyTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.totalQtyTextbox.Name = "totalQtyTextbox";
            this.totalQtyTextbox.Size = new System.Drawing.Size(164, 23);
            this.totalQtyTextbox.TabIndex = 37;
            // 
            // totalQtyLabel
            // 
            this.totalQtyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalQtyLabel.AutoSize = true;
            this.totalQtyLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalQtyLabel.Location = new System.Drawing.Point(632, 266);
            this.totalQtyLabel.Name = "totalQtyLabel";
            this.totalQtyLabel.Size = new System.Drawing.Size(59, 13);
            this.totalQtyLabel.TabIndex = 36;
            this.totalQtyLabel.Text = "Total QTY:";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceTextBox.Enabled = false;
            this.totalPriceTextBox.Location = new System.Drawing.Point(708, 295);
            this.totalPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.Size = new System.Drawing.Size(164, 23);
            this.totalPriceTextBox.TabIndex = 39;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(631, 298);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(63, 13);
            this.totalPriceLabel.TabIndex = 38;
            this.totalPriceLabel.Text = "Total Price:";
            // 
            // totalPriceWithOverrideTextBox
            // 
            this.totalPriceWithOverrideTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceWithOverrideTextBox.Enabled = false;
            this.totalPriceWithOverrideTextBox.Location = new System.Drawing.Point(708, 327);
            this.totalPriceWithOverrideTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.totalPriceWithOverrideTextBox.Name = "totalPriceWithOverrideTextBox";
            this.totalPriceWithOverrideTextBox.Size = new System.Drawing.Size(164, 23);
            this.totalPriceWithOverrideTextBox.TabIndex = 41;
            // 
            // totalPriceWithOverrideLabel
            // 
            this.totalPriceWithOverrideLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceWithOverrideLabel.AutoSize = true;
            this.totalPriceWithOverrideLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceWithOverrideLabel.Location = new System.Drawing.Point(553, 330);
            this.totalPriceWithOverrideLabel.Name = "totalPriceWithOverrideLabel";
            this.totalPriceWithOverrideLabel.Size = new System.Drawing.Size(130, 13);
            this.totalPriceWithOverrideLabel.TabIndex = 40;
            this.totalPriceWithOverrideLabel.Text = "Total Price (w Override):";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.overridePriceTextBox);
            this.panel1.Controls.Add(this.overridePriceLabel);
            this.panel1.Controls.Add(this.overridePriceCheckbox);
            this.panel1.Location = new System.Drawing.Point(209, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 66);
            this.panel1.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.amountRequestedTextBox);
            this.groupBox1.Controls.Add(this.deleteRecordButton);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.saveRecordButton);
            this.groupBox1.Controls.Add(this.amountRequestedLabel);
            this.groupBox1.Location = new System.Drawing.Point(9, 263);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(526, 90);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Item:";
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
            this.backButton.Location = new System.Drawing.Point(771, 3);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(112, 64);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(117)))), ((int)(((byte)(135)))));
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(886, 71);
            this.topPanel.TabIndex = 44;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 9);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(226, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Edit Request";
            // 
            // requestorNameLabel
            // 
            this.requestorNameLabel.AutoSize = true;
            this.requestorNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.requestorNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestorNameLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.requestorNameLabel.Location = new System.Drawing.Point(10, 87);
            this.requestorNameLabel.Name = "requestorNameLabel";
            this.requestorNameLabel.Size = new System.Drawing.Size(97, 13);
            this.requestorNameLabel.TabIndex = 45;
            this.requestorNameLabel.Text = "Requestor Name:";
            // 
            // requestorNameTextBox
            // 
            this.requestorNameTextBox.Location = new System.Drawing.Point(9, 106);
            this.requestorNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestorNameTextBox.Name = "requestorNameTextBox";
            this.requestorNameTextBox.ReadOnly = true;
            this.requestorNameTextBox.Size = new System.Drawing.Size(257, 23);
            this.requestorNameTextBox.TabIndex = 46;
            // 
            // buildingNumberTextBox
            // 
            this.buildingNumberTextBox.Location = new System.Drawing.Point(274, 106);
            this.buildingNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buildingNumberTextBox.Name = "buildingNumberTextBox";
            this.buildingNumberTextBox.ReadOnly = true;
            this.buildingNumberTextBox.Size = new System.Drawing.Size(257, 23);
            this.buildingNumberTextBox.TabIndex = 48;
            // 
            // buildingNumberLabel
            // 
            this.buildingNumberLabel.AutoSize = true;
            this.buildingNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.buildingNumberLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingNumberLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buildingNumberLabel.Location = new System.Drawing.Point(275, 87);
            this.buildingNumberLabel.Name = "buildingNumberLabel";
            this.buildingNumberLabel.Size = new System.Drawing.Size(100, 13);
            this.buildingNumberLabel.TabIndex = 47;
            this.buildingNumberLabel.Text = "Building Number:";
            // 
            // buildingNameTextbox
            // 
            this.buildingNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildingNameTextbox.Location = new System.Drawing.Point(539, 106);
            this.buildingNameTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buildingNameTextbox.Name = "buildingNameTextbox";
            this.buildingNameTextbox.ReadOnly = true;
            this.buildingNameTextbox.Size = new System.Drawing.Size(333, 23);
            this.buildingNameTextbox.TabIndex = 50;
            // 
            // buildingNameLabel
            // 
            this.buildingNameLabel.AutoSize = true;
            this.buildingNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.buildingNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingNameLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buildingNameLabel.Location = new System.Drawing.Point(540, 87);
            this.buildingNameLabel.Name = "buildingNameLabel";
            this.buildingNameLabel.Size = new System.Drawing.Size(88, 13);
            this.buildingNameLabel.TabIndex = 49;
            this.buildingNameLabel.Text = "Building Name:";
            // 
            // accountNumberComboBox
            // 
            this.accountNumberComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountNumberComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.accountNumberComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.accountNumberComboBox.FormattingEnabled = true;
            this.accountNumberComboBox.Location = new System.Drawing.Point(128, 139);
            this.accountNumberComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.accountNumberComboBox.Name = "accountNumberComboBox";
            this.accountNumberComboBox.Size = new System.Drawing.Size(572, 23);
            this.accountNumberComboBox.TabIndex = 51;
            // 
            // RequestEditScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.accountNumberComboBox);
            this.Controls.Add(this.buildingNameTextbox);
            this.Controls.Add(this.buildingNameLabel);
            this.Controls.Add(this.buildingNumberTextBox);
            this.Controls.Add(this.buildingNumberLabel);
            this.Controls.Add(this.requestorNameTextBox);
            this.Controls.Add(this.requestorNameLabel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.totalPriceWithOverrideTextBox);
            this.Controls.Add(this.totalPriceWithOverrideLabel);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.totalQtyTextbox);
            this.Controls.Add(this.totalQtyLabel);
            this.Controls.Add(this.itemInformationPanel);
            this.Controls.Add(this.saveAccountNumberButton);
            this.Controls.Add(this.itemsToRequestListView);
            this.Controls.Add(this.accountNumberLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RequestEditScreen";
            this.Size = new System.Drawing.Size(886, 545);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RequestEditScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.itemInformationPanel.ResumeLayout(false);
            this.itemInformationPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label accountNumberLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private SortableListView itemsToRequestListView;
        private System.Windows.Forms.GroupBox itemInformationPanel;
        public System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label categoryLabel;
        public System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Button saveAccountNumberButton;
        private System.Windows.Forms.ColumnHeader itemIdColumnHeader;
        private System.Windows.Forms.ColumnHeader codeColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader qtyColumnHeader;
        private System.Windows.Forms.ColumnHeader unitColumnHeader;
        private System.Windows.Forms.ColumnHeader categoryColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ColumnHeader extendedPriceColumnHeader;
        private System.Windows.Forms.ColumnHeader extendedPriceWithOverrideColumnHeader;
        private System.Windows.Forms.Button deleteRecordButton;
        private System.Windows.Forms.Button saveRecordButton;
        public System.Windows.Forms.TextBox amountRequestedTextBox;
        private System.Windows.Forms.Label amountRequestedLabel;
        private System.Windows.Forms.CheckBox overridePriceCheckbox;
        public System.Windows.Forms.TextBox overridePriceTextBox;
        private System.Windows.Forms.Label overridePriceLabel;
        public System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label priceLabel;
        public System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label unitLabel;
        public System.Windows.Forms.TextBox substitutableTextBox;
        private System.Windows.Forms.Label substitutableLabel;
        private System.Windows.Forms.ColumnHeader requestItemIdColumnHeader;
        public System.Windows.Forms.TextBox totalPriceWithOverrideTextBox;
        private System.Windows.Forms.Label totalPriceWithOverrideLabel;
        public System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Label totalPriceLabel;
        public System.Windows.Forms.TextBox totalQtyTextbox;
        private System.Windows.Forms.Label totalQtyLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Button backButton;
        public System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox requestorNameTextBox;
        private System.Windows.Forms.Label requestorNameLabel;
        private System.Windows.Forms.TextBox buildingNameTextbox;
        private System.Windows.Forms.Label buildingNameLabel;
        private System.Windows.Forms.TextBox buildingNumberTextBox;
        private System.Windows.Forms.Label buildingNumberLabel;
        private System.Windows.Forms.ColumnHeader overridePriceColumnHeader;
        private System.Windows.Forms.ComboBox accountNumberComboBox;
    }
}