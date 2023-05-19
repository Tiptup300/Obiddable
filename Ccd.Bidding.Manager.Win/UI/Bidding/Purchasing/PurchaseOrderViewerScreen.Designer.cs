namespace Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing
{
    partial class PurchaseOrderViewerScreen
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
            this.vendorNameTextBox = new System.Windows.Forms.TextBox();
            this.vendorNameLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.buildingNameLabel = new System.Windows.Forms.Label();
            this.buildingNameTextBox = new System.Windows.Forms.TextBox();
            this.dateCreatedLabel = new System.Windows.Forms.Label();
            this.dateCreatedTextBox = new System.Windows.Forms.TextBox();
            this.lineItemsListView = new System.Windows.Forms.ListView();
            this.lineItemIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.partNumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accountNumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vendorNameTextBox
            // 
            this.vendorNameTextBox.Location = new System.Drawing.Point(12, 101);
            this.vendorNameTextBox.Name = "vendorNameTextBox";
            this.vendorNameTextBox.ReadOnly = true;
            this.vendorNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.vendorNameTextBox.TabIndex = 0;
            // 
            // vendorNameLabel
            // 
            this.vendorNameLabel.AutoSize = true;
            this.vendorNameLabel.Location = new System.Drawing.Point(9, 85);
            this.vendorNameLabel.Name = "vendorNameLabel";
            this.vendorNameLabel.Size = new System.Drawing.Size(79, 13);
            this.vendorNameLabel.TabIndex = 1;
            this.vendorNameLabel.Text = "Vendor Name:";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(117)))), ((int)(((byte)(135)))));
            this.topPanel.Controls.Add(this.exportButton);
            this.topPanel.Controls.Add(this.cancelButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(878, 71);
            this.topPanel.TabIndex = 47;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.BackColor = System.Drawing.Color.Transparent;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exportButton.FlatAppearance.BorderSize = 2;
            this.exportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.exportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Location = new System.Drawing.Point(645, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(112, 64);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
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
            this.cancelButton.Location = new System.Drawing.Point(763, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 64);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Back";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(362, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "View Purchase Order";
            // 
            // buildingNameLabel
            // 
            this.buildingNameLabel.AutoSize = true;
            this.buildingNameLabel.Location = new System.Drawing.Point(293, 85);
            this.buildingNameLabel.Name = "buildingNameLabel";
            this.buildingNameLabel.Size = new System.Drawing.Size(85, 13);
            this.buildingNameLabel.TabIndex = 49;
            this.buildingNameLabel.Text = "Building Name:";
            // 
            // buildingNameTextBox
            // 
            this.buildingNameTextBox.Location = new System.Drawing.Point(296, 101);
            this.buildingNameTextBox.Name = "buildingNameTextBox";
            this.buildingNameTextBox.ReadOnly = true;
            this.buildingNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.buildingNameTextBox.TabIndex = 48;
            // 
            // dateCreatedLabel
            // 
            this.dateCreatedLabel.AutoSize = true;
            this.dateCreatedLabel.Location = new System.Drawing.Point(577, 85);
            this.dateCreatedLabel.Name = "dateCreatedLabel";
            this.dateCreatedLabel.Size = new System.Drawing.Size(77, 13);
            this.dateCreatedLabel.TabIndex = 51;
            this.dateCreatedLabel.Text = "Date Created:";
            // 
            // dateCreatedTextBox
            // 
            this.dateCreatedTextBox.Location = new System.Drawing.Point(580, 101);
            this.dateCreatedTextBox.Name = "dateCreatedTextBox";
            this.dateCreatedTextBox.ReadOnly = true;
            this.dateCreatedTextBox.Size = new System.Drawing.Size(278, 22);
            this.dateCreatedTextBox.TabIndex = 50;
            // 
            // lineItemsListView
            // 
            this.lineItemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lineItemIdColumnHeader,
            this.descriptionColumnHeader,
            this.partNumberColumnHeader,
            this.unitColumnHeader,
            this.quantityColumnHeader,
            this.priceColumnHeader,
            this.accountNumberColumnHeader,
            this.noteColumnHeader});
            this.lineItemsListView.FullRowSelect = true;
            this.lineItemsListView.GridLines = true;
            this.lineItemsListView.HideSelection = false;
            this.lineItemsListView.Location = new System.Drawing.Point(12, 129);
            this.lineItemsListView.Name = "lineItemsListView";
            this.lineItemsListView.Size = new System.Drawing.Size(846, 397);
            this.lineItemsListView.TabIndex = 52;
            this.lineItemsListView.UseCompatibleStateImageBehavior = false;
            this.lineItemsListView.View = System.Windows.Forms.View.Details;
            // 
            // lineItemIdColumnHeader
            // 
            this.lineItemIdColumnHeader.Text = "Line Item Id";
            this.lineItemIdColumnHeader.Width = 0;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 713;
            // 
            // partNumberColumnHeader
            // 
            this.partNumberColumnHeader.Text = "Part Number";
            this.partNumberColumnHeader.Width = 111;
            // 
            // unitColumnHeader
            // 
            this.unitColumnHeader.Text = "Unit";
            this.unitColumnHeader.Width = 119;
            // 
            // quantityColumnHeader
            // 
            this.quantityColumnHeader.Text = "Quantity";
            this.quantityColumnHeader.Width = 104;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price";
            this.priceColumnHeader.Width = 92;
            // 
            // accountNumberColumnHeader
            // 
            this.accountNumberColumnHeader.Text = "Account Number";
            this.accountNumberColumnHeader.Width = 186;
            // 
            // noteColumnHeader
            // 
            this.noteColumnHeader.Text = "Note";
            this.noteColumnHeader.Width = 372;
            // 
            // PurchaseOrderViewerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineItemsListView);
            this.Controls.Add(this.dateCreatedLabel);
            this.Controls.Add(this.dateCreatedTextBox);
            this.Controls.Add(this.buildingNameLabel);
            this.Controls.Add(this.buildingNameTextBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.vendorNameLabel);
            this.Controls.Add(this.vendorNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PurchaseOrderViewerScreen";
            this.Size = new System.Drawing.Size(878, 542);
            this.Load += new System.EventHandler(this.PurchaseOrderViewerScreen_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vendorNameTextBox;
        private System.Windows.Forms.Label vendorNameLabel;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Button exportButton;
        public System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label buildingNameLabel;
        private System.Windows.Forms.TextBox buildingNameTextBox;
        private System.Windows.Forms.Label dateCreatedLabel;
        private System.Windows.Forms.TextBox dateCreatedTextBox;
        private System.Windows.Forms.ListView lineItemsListView;
        private System.Windows.Forms.ColumnHeader lineItemIdColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader partNumberColumnHeader;
        private System.Windows.Forms.ColumnHeader unitColumnHeader;
        private System.Windows.Forms.ColumnHeader quantityColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ColumnHeader accountNumberColumnHeader;
        private System.Windows.Forms.ColumnHeader noteColumnHeader;
    }
}
