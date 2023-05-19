
using Ccd.Bidding.Manager.Win.Library.UI.Reporting;
using System.Drawing;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
    partial class BidNavigationScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BidNavigationScreen));
            this.topPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.centeredPanel = new System.Windows.Forms.Panel();
            this.itemNavigationBoxControl1 = new ItemNavigationBoxControl();
            this.reportsControl = new ReportsToolstrip();
            this.purchaseOrderNavigationBoxControl1 = new PurchaseOrderNavigationBoxControl();
            this.requestorsNavigationControl1 = new RequestorNavigationControl();
            this.electionNavigationBoxControl1 = new ElectionNavigationBoxControl();
            this.vendorResponseNavigationBoxControl1 = new VendorResponseNavigationBoxControl();
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.configButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reportsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.topPanel.SuspendLayout();
            this.centeredPanel.SuspendLayout();
            this.topToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1132, 71);
            this.topPanel.TabIndex = 5;
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
            this.backButton.Location = new System.Drawing.Point(1017, 3);
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
            this.titleLabel.Location = new System.Drawing.Point(3, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(264, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Bid Navigation";
            // 
            // centeredPanel
            // 
            this.centeredPanel.Controls.Add(this.itemNavigationBoxControl1);
            this.centeredPanel.Controls.Add(this.reportsControl);
            this.centeredPanel.Controls.Add(this.purchaseOrderNavigationBoxControl1);
            this.centeredPanel.Controls.Add(this.requestorsNavigationControl1);
            this.centeredPanel.Controls.Add(this.electionNavigationBoxControl1);
            this.centeredPanel.Controls.Add(this.vendorResponseNavigationBoxControl1);
            this.centeredPanel.Location = new System.Drawing.Point(67, 117);
            this.centeredPanel.Name = "centeredPanel";
            this.centeredPanel.Size = new System.Drawing.Size(981, 612);
            this.centeredPanel.TabIndex = 12;
            // 
            // itemNavigationBoxControl1
            // 
            this.itemNavigationBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.itemNavigationBoxControl1.Location = new System.Drawing.Point(1, 68);
            this.itemNavigationBoxControl1.Name = "itemNavigationBoxControl1";
            this.itemNavigationBoxControl1.Size = new System.Drawing.Size(488, 177);
            this.itemNavigationBoxControl1.TabIndex = 7;
            this.itemNavigationBoxControl1.EditClicked += new System.EventHandler(this.itemNavigationBoxControl1_EditClicked);
            // 
            // reportsControl
            // 
            this.reportsControl.BackColor = System.Drawing.Color.Transparent;
            this.reportsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportsControl.Location = new System.Drawing.Point(0, 0);
            this.reportsControl.Name = "reportsControl";
            this.reportsControl.Size = new System.Drawing.Size(981, 64);
            this.reportsControl.TabIndex = 6;
            // 
            // purchaseOrderNavigationBoxControl1
            // 
            this.purchaseOrderNavigationBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.purchaseOrderNavigationBoxControl1.Location = new System.Drawing.Point(1, 433);
            this.purchaseOrderNavigationBoxControl1.Name = "purchaseOrderNavigationBoxControl1";
            this.purchaseOrderNavigationBoxControl1.Size = new System.Drawing.Size(981, 177);
            this.purchaseOrderNavigationBoxControl1.TabIndex = 11;
            this.purchaseOrderNavigationBoxControl1.EditClicked += new System.EventHandler(this.purchaseOrderNavigationBoxControl1_EditClicked);
            // 
            // requestorsNavigationControl1
            // 
            this.requestorsNavigationControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.requestorsNavigationControl1.Location = new System.Drawing.Point(494, 68);
            this.requestorsNavigationControl1.Name = "requestorsNavigationControl1";
            this.requestorsNavigationControl1.Size = new System.Drawing.Size(488, 177);
            this.requestorsNavigationControl1.TabIndex = 8;
            this.requestorsNavigationControl1.EditClicked += new System.EventHandler(this.requestorsNavigationControl1_EditClicked);
            // 
            // electionNavigationBoxControl1
            // 
            this.electionNavigationBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.electionNavigationBoxControl1.Location = new System.Drawing.Point(494, 250);
            this.electionNavigationBoxControl1.Name = "electionNavigationBoxControl1";
            this.electionNavigationBoxControl1.Size = new System.Drawing.Size(488, 177);
            this.electionNavigationBoxControl1.TabIndex = 10;
            this.electionNavigationBoxControl1.EditClicked += new System.EventHandler(this.electionNavigationBoxControl1_EditClicked);
            // 
            // vendorResponseNavigationBoxControl1
            // 
            this.vendorResponseNavigationBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.vendorResponseNavigationBoxControl1.Location = new System.Drawing.Point(1, 250);
            this.vendorResponseNavigationBoxControl1.Name = "vendorResponseNavigationBoxControl1";
            this.vendorResponseNavigationBoxControl1.Size = new System.Drawing.Size(488, 177);
            this.vendorResponseNavigationBoxControl1.TabIndex = 9;
            this.vendorResponseNavigationBoxControl1.EditClicked += new System.EventHandler(this.vendorResponseNavigationBoxControl1_EditClicked);
            // 
            // topToolStrip
            // 
            this.topToolStrip.AllowMerge = false;
            this.topToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.topToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpButton,
            this.configButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.reportsButton,
            this.toolStripSeparator4,
            this.exportsButton,
            this.toolStripSeparator3});
            this.topToolStrip.Location = new System.Drawing.Point(0, 71);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.topToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.topToolStrip.Size = new System.Drawing.Size(1132, 35);
            this.topToolStrip.TabIndex = 13;
            this.topToolStrip.Text = "toolStrip1";
            // 
            // helpButton
            // 
            this.helpButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Padding = new System.Windows.Forms.Padding(5, 5, 3, 5);
            this.helpButton.Size = new System.Drawing.Size(30, 32);
            this.helpButton.Text = "Help";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // configButton
            // 
            this.configButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.configButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.configButton.Image = ((System.Drawing.Image)(resources.GetObject("configButton.Image")));
            this.configButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configButton.Name = "configButton";
            this.configButton.Padding = new System.Windows.Forms.Padding(5, 5, 3, 5);
            this.configButton.Size = new System.Drawing.Size(30, 32);
            this.configButton.Text = "Config";
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.refreshButton.Size = new System.Drawing.Size(27, 32);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // reportsButton
            // 
            this.reportsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.reportsButton.Image = ((System.Drawing.Image)(resources.GetObject("reportsButton.Image")));
            this.reportsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Padding = new System.Windows.Forms.Padding(5);
            this.reportsButton.Size = new System.Drawing.Size(115, 32);
            this.reportsButton.Text = "Reports Folder";
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // exportsButton
            // 
            this.exportsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportsButton.Image = ((System.Drawing.Image)(resources.GetObject("exportsButton.Image")));
            this.exportsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportsButton.Name = "exportsButton";
            this.exportsButton.Padding = new System.Windows.Forms.Padding(5, 5, 6, 5);
            this.exportsButton.Size = new System.Drawing.Size(115, 32);
            this.exportsButton.Text = "Exports Folder";
            this.exportsButton.Click += new System.EventHandler(this.exportsButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // BidNavigationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.topToolStrip);
            this.Controls.Add(this.centeredPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "BidNavigationScreen";
            this.Size = new System.Drawing.Size(1132, 770);
            this.SizeChanged += new System.EventHandler(this.BidNavigationScreen_SizeChanged);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.centeredPanel.ResumeLayout(false);
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Button backButton;
        public System.Windows.Forms.Label titleLabel;
        private ReportsToolstrip reportsControl;
        private ItemNavigationBoxControl itemNavigationBoxControl1;
        private RequestorNavigationControl requestorsNavigationControl1;
        private VendorResponseNavigationBoxControl vendorResponseNavigationBoxControl1;
        private ElectionNavigationBoxControl electionNavigationBoxControl1;
        private PurchaseOrderNavigationBoxControl purchaseOrderNavigationBoxControl1;
        private System.Windows.Forms.Panel centeredPanel;
        public System.Windows.Forms.ToolStrip topToolStrip;
        public System.Windows.Forms.ToolStripButton helpButton;
        public System.Windows.Forms.ToolStripButton configButton;
        public System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton reportsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton exportsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
