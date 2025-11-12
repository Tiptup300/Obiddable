using System.Windows.Forms;

namespace Obiddable.Win.UI.Bidding.Electing
{
    partial class ElectionEditScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.quantityRequestedLabel = new System.Windows.Forms.Label();
            this.quantityRequestedTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.estimatedPriceLabel = new System.Windows.Forms.Label();
            this.estimatedPriceTextBox = new System.Windows.Forms.TextBox();
            this.lastOrderedPriceLabel = new System.Windows.Forms.Label();
            this.lastOrderedPriceTextBox = new System.Windows.Forms.TextBox();
            this.responsesToElectListView = new ListView();
            this.responseItemIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorPartnumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vendorPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isAlternateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alternateUnitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alternateQuantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alternateDescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fillerColHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qtyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extendedPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.electionReasonLabel = new System.Windows.Forms.Label();
            this.electionReasonTextBox = new System.Windows.Forms.TextBox();
            this.itemInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.topPanel.SuspendLayout();
            this.itemInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(117)))), ((int)(((byte)(135)))));
            this.topPanel.Controls.Add(this.clearButton);
            this.topPanel.Controls.Add(this.selectButton);
            this.topPanel.Controls.Add(this.cancelButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1277, 71);
            this.topPanel.TabIndex = 46;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearButton.FlatAppearance.BorderSize = 2;
            this.clearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(926, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 64);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.BackColor = System.Drawing.Color.Transparent;
            this.selectButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.selectButton.FlatAppearance.BorderSize = 2;
            this.selectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.selectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.selectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.ForeColor = System.Drawing.Color.White;
            this.selectButton.Location = new System.Drawing.Point(1044, 3);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(112, 64);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cancelButton.FlatAppearance.BorderSize = 2;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(1162, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 64);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(235, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Item Election";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(6, 16);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(37, 13);
            this.codeLabel.TabIndex = 48;
            this.codeLabel.Text = "Code:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Enabled = false;
            this.codeTextBox.Location = new System.Drawing.Point(9, 32);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(72, 20);
            this.codeTextBox.TabIndex = 5;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.Location = new System.Drawing.Point(84, 16);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(32, 13);
            this.unitLabel.TabIndex = 50;
            this.unitLabel.Text = "Unit:";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Enabled = false;
            this.unitTextBox.Location = new System.Drawing.Point(87, 32);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.ReadOnly = true;
            this.unitTextBox.Size = new System.Drawing.Size(72, 20);
            this.unitTextBox.TabIndex = 6;
            // 
            // quantityRequestedLabel
            // 
            this.quantityRequestedLabel.AutoSize = true;
            this.quantityRequestedLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityRequestedLabel.Location = new System.Drawing.Point(6, 55);
            this.quantityRequestedLabel.Name = "quantityRequestedLabel";
            this.quantityRequestedLabel.Size = new System.Drawing.Size(113, 13);
            this.quantityRequestedLabel.TabIndex = 52;
            this.quantityRequestedLabel.Text = "Quantity Requested:";
            // 
            // quantityRequestedTextBox
            // 
            this.quantityRequestedTextBox.Enabled = false;
            this.quantityRequestedTextBox.Location = new System.Drawing.Point(9, 71);
            this.quantityRequestedTextBox.Name = "quantityRequestedTextBox";
            this.quantityRequestedTextBox.ReadOnly = true;
            this.quantityRequestedTextBox.Size = new System.Drawing.Size(150, 20);
            this.quantityRequestedTextBox.TabIndex = 7;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Enabled = false;
            this.descriptionTextBox.Location = new System.Drawing.Point(165, 32);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(1091, 137);
            this.descriptionTextBox.TabIndex = 10;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(162, 16);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(69, 13);
            this.descriptionLabel.TabIndex = 54;
            this.descriptionLabel.Text = "Description:";
            // 
            // estimatedPriceLabel
            // 
            this.estimatedPriceLabel.AutoSize = true;
            this.estimatedPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estimatedPriceLabel.Location = new System.Drawing.Point(6, 94);
            this.estimatedPriceLabel.Name = "estimatedPriceLabel";
            this.estimatedPriceLabel.Size = new System.Drawing.Size(89, 13);
            this.estimatedPriceLabel.TabIndex = 56;
            this.estimatedPriceLabel.Text = "Estimated Price:";
            // 
            // estimatedPriceTextBox
            // 
            this.estimatedPriceTextBox.Enabled = false;
            this.estimatedPriceTextBox.Location = new System.Drawing.Point(9, 110);
            this.estimatedPriceTextBox.Name = "estimatedPriceTextBox";
            this.estimatedPriceTextBox.ReadOnly = true;
            this.estimatedPriceTextBox.Size = new System.Drawing.Size(150, 20);
            this.estimatedPriceTextBox.TabIndex = 8;
            // 
            // lastOrderedPriceLabel
            // 
            this.lastOrderedPriceLabel.AutoSize = true;
            this.lastOrderedPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastOrderedPriceLabel.Location = new System.Drawing.Point(6, 133);
            this.lastOrderedPriceLabel.Name = "lastOrderedPriceLabel";
            this.lastOrderedPriceLabel.Size = new System.Drawing.Size(104, 13);
            this.lastOrderedPriceLabel.TabIndex = 58;
            this.lastOrderedPriceLabel.Text = "Last Ordered Price:";
            // 
            // lastOrderedPriceTextBox
            // 
            this.lastOrderedPriceTextBox.Enabled = false;
            this.lastOrderedPriceTextBox.Location = new System.Drawing.Point(9, 149);
            this.lastOrderedPriceTextBox.Name = "lastOrderedPriceTextBox";
            this.lastOrderedPriceTextBox.ReadOnly = true;
            this.lastOrderedPriceTextBox.Size = new System.Drawing.Size(150, 20);
            this.lastOrderedPriceTextBox.TabIndex = 9;
            // 
            // responsesToElectListView
            // 
            this.responsesToElectListView.AllowColumnReorder = true;
            this.responsesToElectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responsesToElectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.responseItemIdColumnHeader,
            this.vendorNameColumnHeader,
            this.vendorPartnumberColumnHeader,
            this.vendorPriceColumnHeader,
            this.isAlternateColumnHeader,
            this.alternateUnitColumnHeader,
            this.alternateQuantityColumnHeader,
            this.alternateDescriptionColumnHeader,
            this.fillerColHead,
            this.qtyColumnHeader,
            this.unitColumnHeader,
            this.priceColumnHeader,
            this.extendedPriceColumnHeader});
            this.responsesToElectListView.FullRowSelect = true;
            this.responsesToElectListView.GridLines = true;
            this.responsesToElectListView.HideSelection = false;
            this.responsesToElectListView.Location = new System.Drawing.Point(12, 292);
            this.responsesToElectListView.Name = "responsesToElectListView";
            this.responsesToElectListView.Size = new System.Drawing.Size(1256, 468);
            this.responsesToElectListView.TabIndex = 1;
            this.responsesToElectListView.UseCompatibleStateImageBehavior = false;
            this.responsesToElectListView.View = System.Windows.Forms.View.Details;
            this.responsesToElectListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.responsesToElectListView_ColumnWidthChanged);
            this.responsesToElectListView.SelectedIndexChanged += new System.EventHandler(this.responsesToElectListView_SelectedIndexChanged);
            this.responsesToElectListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // responseItemIdColumnHeader
            // 
            this.responseItemIdColumnHeader.Text = "Response Item Id";
            this.responseItemIdColumnHeader.Width = 0;
            // 
            // vendorNameColumnHeader
            // 
            this.vendorNameColumnHeader.Text = "Vendor Name";
            this.vendorNameColumnHeader.Width = 126;
            // 
            // vendorPartnumberColumnHeader
            // 
            this.vendorPartnumberColumnHeader.Text = "Vendor Partnumber";
            this.vendorPartnumberColumnHeader.Width = 148;
            // 
            // vendorPriceColumnHeader
            // 
            this.vendorPriceColumnHeader.Text = "Vendor Price";
            this.vendorPriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vendorPriceColumnHeader.Width = 144;
            // 
            // isAlternateColumnHeader
            // 
            this.isAlternateColumnHeader.Text = "Is Alternate";
            this.isAlternateColumnHeader.Width = 104;
            // 
            // alternateUnitColumnHeader
            // 
            this.alternateUnitColumnHeader.Text = "Alternate Unit";
            this.alternateUnitColumnHeader.Width = 105;
            // 
            // alternateQuantityColumnHeader
            // 
            this.alternateQuantityColumnHeader.Text = "Alternate Quantity";
            this.alternateQuantityColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.alternateQuantityColumnHeader.Width = 106;
            // 
            // alternateDescriptionColumnHeader
            // 
            this.alternateDescriptionColumnHeader.Text = "Alternate Description";
            this.alternateDescriptionColumnHeader.Width = 119;
            // 
            // fillerColHead
            // 
            this.fillerColHead.Text = "";
            this.fillerColHead.Width = 1;
            // 
            // qtyColumnHeader
            // 
            this.qtyColumnHeader.Text = "QTY";
            this.qtyColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyColumnHeader.Width = 40;
            // 
            // unitColumnHeader
            // 
            this.unitColumnHeader.Text = "Unit";
            this.unitColumnHeader.Width = 40;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price Per";
            this.priceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceColumnHeader.Width = 133;
            // 
            // extendedPriceColumnHeader
            // 
            this.extendedPriceColumnHeader.Text = "Extended Price";
            this.extendedPriceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extendedPriceColumnHeader.Width = 133;
            // 
            // electionReasonLabel
            // 
            this.electionReasonLabel.AutoSize = true;
            this.electionReasonLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electionReasonLabel.Location = new System.Drawing.Point(17, 262);
            this.electionReasonLabel.Name = "electionReasonLabel";
            this.electionReasonLabel.Size = new System.Drawing.Size(135, 21);
            this.electionReasonLabel.TabIndex = 60;
            this.electionReasonLabel.Text = "Election Reason:";
            // 
            // electionReasonTextBox
            // 
            this.electionReasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.electionReasonTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electionReasonTextBox.Location = new System.Drawing.Point(158, 260);
            this.electionReasonTextBox.Name = "electionReasonTextBox";
            this.electionReasonTextBox.Size = new System.Drawing.Size(1110, 26);
            this.electionReasonTextBox.TabIndex = 0;
            this.electionReasonTextBox.TextChanged += new System.EventHandler(this.electionReasonTextBox_TextChanged);
            this.electionReasonTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // itemInfoGroupBox
            // 
            this.itemInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemInfoGroupBox.Controls.Add(this.codeLabel);
            this.itemInfoGroupBox.Controls.Add(this.codeTextBox);
            this.itemInfoGroupBox.Controls.Add(this.unitTextBox);
            this.itemInfoGroupBox.Controls.Add(this.unitLabel);
            this.itemInfoGroupBox.Controls.Add(this.lastOrderedPriceLabel);
            this.itemInfoGroupBox.Controls.Add(this.quantityRequestedTextBox);
            this.itemInfoGroupBox.Controls.Add(this.lastOrderedPriceTextBox);
            this.itemInfoGroupBox.Controls.Add(this.quantityRequestedLabel);
            this.itemInfoGroupBox.Controls.Add(this.estimatedPriceLabel);
            this.itemInfoGroupBox.Controls.Add(this.descriptionTextBox);
            this.itemInfoGroupBox.Controls.Add(this.estimatedPriceTextBox);
            this.itemInfoGroupBox.Controls.Add(this.descriptionLabel);
            this.itemInfoGroupBox.Location = new System.Drawing.Point(12, 75);
            this.itemInfoGroupBox.Name = "itemInfoGroupBox";
            this.itemInfoGroupBox.Size = new System.Drawing.Size(1262, 179);
            this.itemInfoGroupBox.TabIndex = 62;
            this.itemInfoGroupBox.TabStop = false;
            this.itemInfoGroupBox.Text = "Item Information:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ElectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemInfoGroupBox);
            this.Controls.Add(this.electionReasonTextBox);
            this.Controls.Add(this.electionReasonLabel);
            this.Controls.Add(this.responsesToElectListView);
            this.Controls.Add(this.topPanel);
            this.Name = "ElectionScreen";
            this.Size = new System.Drawing.Size(1277, 779);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.itemInfoGroupBox.ResumeLayout(false);
            this.itemInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label codeLabel;
        public System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label unitLabel;
        public System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label quantityRequestedLabel;
        public System.Windows.Forms.TextBox quantityRequestedTextBox;
        public System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label estimatedPriceLabel;
        public System.Windows.Forms.TextBox estimatedPriceTextBox;
        private System.Windows.Forms.Label lastOrderedPriceLabel;
        public System.Windows.Forms.TextBox lastOrderedPriceTextBox;
        private ListView responsesToElectListView;
        private System.Windows.Forms.ColumnHeader vendorNameColumnHeader;
        private System.Windows.Forms.ColumnHeader vendorPartnumberColumnHeader;
        private System.Windows.Forms.ColumnHeader vendorPriceColumnHeader;
        private System.Windows.Forms.ColumnHeader isAlternateColumnHeader;
        private System.Windows.Forms.ColumnHeader alternateUnitColumnHeader;
        private System.Windows.Forms.ColumnHeader alternateQuantityColumnHeader;
        private System.Windows.Forms.ColumnHeader alternateDescriptionColumnHeader;
        public System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label electionReasonLabel;
        public System.Windows.Forms.TextBox electionReasonTextBox;
        private System.Windows.Forms.GroupBox itemInfoGroupBox;
        private System.Windows.Forms.ColumnHeader responseItemIdColumnHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ColumnHeader fillerColHead;
        private System.Windows.Forms.ColumnHeader qtyColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ColumnHeader extendedPriceColumnHeader;
        private System.Windows.Forms.ColumnHeader unitColumnHeader;
    }
}
