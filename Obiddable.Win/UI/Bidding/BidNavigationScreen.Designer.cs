
using Obiddable.Win.Library.UI.Reporting;
using System.Drawing;

namespace Obiddable.Win.UI.Bidding.Navigation
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
         topPanel = new Panel();
         backButton = new Button();
         titleLabel = new Label();
         centeredPanel = new Panel();
         itemNavigationBoxControl1 = new ItemNavigationBoxControl();
         reportsControl = new ReportsToolstrip();
         purchaseOrderNavigationBoxControl1 = new PurchaseOrderNavigationBoxControl();
         requestorsNavigationControl1 = new RequestorNavigationControl();
         electionNavigationBoxControl1 = new ElectionNavigationBoxControl();
         vendorResponseNavigationBoxControl1 = new VendorResponseNavigationBoxControl();
         topToolStrip = new ToolStrip();
         helpButton = new ToolStripButton();
         configButton = new ToolStripButton();
         refreshButton = new ToolStripButton();
         toolStripSeparator1 = new ToolStripSeparator();
         reportsButton = new ToolStripButton();
         toolStripSeparator4 = new ToolStripSeparator();
         exportsButton = new ToolStripButton();
         toolStripSeparator3 = new ToolStripSeparator();
         topPanel.SuspendLayout();
         centeredPanel.SuspendLayout();
         topToolStrip.SuspendLayout();
         SuspendLayout();
         // 
         // topPanel
         // 
         topPanel.Controls.Add(backButton);
         topPanel.Controls.Add(titleLabel);
         topPanel.Dock = DockStyle.Top;
         topPanel.Location = new Point(0, 0);
         topPanel.Margin = new Padding(2, 1, 2, 1);
         topPanel.Name = "topPanel";
         topPanel.Size = new Size(1321, 82);
         topPanel.TabIndex = 5;
         // 
         // backButton
         // 
         backButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
         backButton.BackColor = Color.Transparent;
         backButton.FlatAppearance.BorderColor = Color.White;
         backButton.FlatAppearance.BorderSize = 2;
         backButton.FlatAppearance.MouseDownBackColor = Color.DimGray;
         backButton.FlatAppearance.MouseOverBackColor = Color.Gray;
         backButton.FlatStyle = FlatStyle.Flat;
         backButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         backButton.ForeColor = Color.White;
         backButton.Location = new Point(1186, 3);
         backButton.Margin = new Padding(4, 3, 4, 3);
         backButton.Name = "backButton";
         backButton.Size = new Size(131, 74);
         backButton.TabIndex = 1;
         backButton.Text = "Go Back";
         backButton.UseVisualStyleBackColor = false;
         backButton.Click += backButton_Click;
         // 
         // titleLabel
         // 
         titleLabel.AutoSize = true;
         titleLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
         titleLabel.ForeColor = Color.FromArgb(236, 236, 236);
         titleLabel.Location = new Point(4, 9);
         titleLabel.Margin = new Padding(2, 0, 2, 0);
         titleLabel.Name = "titleLabel";
         titleLabel.Size = new Size(264, 50);
         titleLabel.TabIndex = 0;
         titleLabel.Text = "Bid Navigation";
         // 
         // centeredPanel
         // 
         centeredPanel.Controls.Add(itemNavigationBoxControl1);
         centeredPanel.Controls.Add(reportsControl);
         centeredPanel.Controls.Add(purchaseOrderNavigationBoxControl1);
         centeredPanel.Controls.Add(requestorsNavigationControl1);
         centeredPanel.Controls.Add(electionNavigationBoxControl1);
         centeredPanel.Controls.Add(vendorResponseNavigationBoxControl1);
         centeredPanel.Location = new Point(78, 135);
         centeredPanel.Margin = new Padding(4, 3, 4, 3);
         centeredPanel.Name = "centeredPanel";
         centeredPanel.Size = new Size(1144, 706);
         centeredPanel.TabIndex = 12;
         // 
         // itemNavigationBoxControl1
         // 
         itemNavigationBoxControl1.BackColor = Color.FromArgb(240, 240, 240);
         itemNavigationBoxControl1.Location = new Point(1, 78);
         itemNavigationBoxControl1.Margin = new Padding(6, 3, 6, 3);
         itemNavigationBoxControl1.Name = "itemNavigationBoxControl1";
         itemNavigationBoxControl1.Size = new Size(569, 204);
         itemNavigationBoxControl1.TabIndex = 7;
         itemNavigationBoxControl1.EditClicked += itemNavigationBoxControl1_EditClicked;
         // 
         // reportsControl
         // 
         reportsControl.BackColor = Color.Transparent;
         reportsControl.Dock = DockStyle.Top;
         reportsControl.Location = new Point(0, 0);
         reportsControl.Margin = new Padding(5, 3, 5, 3);
         reportsControl.Name = "reportsControl";
         reportsControl.Size = new Size(1144, 74);
         reportsControl.TabIndex = 6;
         // 
         // purchaseOrderNavigationBoxControl1
         // 
         purchaseOrderNavigationBoxControl1.BackColor = Color.FromArgb(240, 240, 240);
         purchaseOrderNavigationBoxControl1.Location = new Point(1, 500);
         purchaseOrderNavigationBoxControl1.Margin = new Padding(6, 3, 6, 3);
         purchaseOrderNavigationBoxControl1.Name = "purchaseOrderNavigationBoxControl1";
         purchaseOrderNavigationBoxControl1.Size = new Size(1144, 204);
         purchaseOrderNavigationBoxControl1.TabIndex = 11;
         purchaseOrderNavigationBoxControl1.EditClicked += purchaseOrderNavigationBoxControl1_EditClicked;
         // 
         // requestorsNavigationControl1
         // 
         requestorsNavigationControl1.BackColor = Color.FromArgb(240, 240, 240);
         requestorsNavigationControl1.Location = new Point(576, 78);
         requestorsNavigationControl1.Margin = new Padding(6, 3, 6, 3);
         requestorsNavigationControl1.Name = "requestorsNavigationControl1";
         requestorsNavigationControl1.Size = new Size(569, 204);
         requestorsNavigationControl1.TabIndex = 8;
         requestorsNavigationControl1.EditClicked += requestorsNavigationControl1_EditClicked;
         // 
         // electionNavigationBoxControl1
         // 
         electionNavigationBoxControl1.BackColor = Color.FromArgb(240, 240, 240);
         electionNavigationBoxControl1.Location = new Point(576, 288);
         electionNavigationBoxControl1.Margin = new Padding(6, 3, 6, 3);
         electionNavigationBoxControl1.Name = "electionNavigationBoxControl1";
         electionNavigationBoxControl1.Size = new Size(569, 204);
         electionNavigationBoxControl1.TabIndex = 10;
         electionNavigationBoxControl1.EditClicked += electionNavigationBoxControl1_EditClicked;
         // 
         // vendorResponseNavigationBoxControl1
         // 
         vendorResponseNavigationBoxControl1.BackColor = Color.FromArgb(240, 240, 240);
         vendorResponseNavigationBoxControl1.Location = new Point(1, 288);
         vendorResponseNavigationBoxControl1.Margin = new Padding(6, 3, 6, 3);
         vendorResponseNavigationBoxControl1.Name = "vendorResponseNavigationBoxControl1";
         vendorResponseNavigationBoxControl1.Size = new Size(569, 204);
         vendorResponseNavigationBoxControl1.TabIndex = 9;
         vendorResponseNavigationBoxControl1.EditClicked += vendorResponseNavigationBoxControl1_EditClicked;
         // 
         // topToolStrip
         // 
         topToolStrip.AllowMerge = false;
         topToolStrip.BackColor = Color.FromArgb(236, 236, 236);
         topToolStrip.GripStyle = ToolStripGripStyle.Hidden;
         topToolStrip.Items.AddRange(new ToolStripItem[] { helpButton, configButton, refreshButton, toolStripSeparator1, reportsButton, toolStripSeparator4, exportsButton, toolStripSeparator3 });
         topToolStrip.Location = new Point(0, 82);
         topToolStrip.Name = "topToolStrip";
         topToolStrip.Padding = new Padding(0);
         topToolStrip.RightToLeft = RightToLeft.No;
         topToolStrip.Size = new Size(1321, 35);
         topToolStrip.TabIndex = 13;
         topToolStrip.Text = "toolStrip1";
         // 
         // helpButton
         // 
         helpButton.Alignment = ToolStripItemAlignment.Right;
         helpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
         helpButton.Image = (Image)resources.GetObject("helpButton.Image");
         helpButton.ImageScaling = ToolStripItemImageScaling.None;
         helpButton.ImageTransparentColor = Color.Magenta;
         helpButton.Name = "helpButton";
         helpButton.Padding = new Padding(5, 5, 3, 5);
         helpButton.Size = new Size(30, 32);
         helpButton.Text = "Help";
         helpButton.Click += helpButton_Click;
         // 
         // configButton
         // 
         configButton.Alignment = ToolStripItemAlignment.Right;
         configButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
         configButton.Image = (Image)resources.GetObject("configButton.Image");
         configButton.ImageScaling = ToolStripItemImageScaling.None;
         configButton.ImageTransparentColor = Color.Magenta;
         configButton.Name = "configButton";
         configButton.Padding = new Padding(5, 5, 3, 5);
         configButton.Size = new Size(30, 32);
         configButton.Text = "Config";
         configButton.Click += configButton_Click;
         // 
         // refreshButton
         // 
         refreshButton.Alignment = ToolStripItemAlignment.Right;
         refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
         refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
         refreshButton.ImageScaling = ToolStripItemImageScaling.None;
         refreshButton.ImageTransparentColor = Color.Magenta;
         refreshButton.Name = "refreshButton";
         refreshButton.Padding = new Padding(5, 5, 0, 5);
         refreshButton.Size = new Size(27, 32);
         refreshButton.Text = "Refresh";
         refreshButton.Click += refreshButton_Click;
         // 
         // toolStripSeparator1
         // 
         toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
         toolStripSeparator1.Name = "toolStripSeparator1";
         toolStripSeparator1.Size = new Size(6, 35);
         // 
         // reportsButton
         // 
         reportsButton.Alignment = ToolStripItemAlignment.Right;
         reportsButton.Image = (Image)resources.GetObject("reportsButton.Image");
         reportsButton.ImageScaling = ToolStripItemImageScaling.None;
         reportsButton.ImageTransparentColor = Color.Magenta;
         reportsButton.Name = "reportsButton";
         reportsButton.Padding = new Padding(5);
         reportsButton.Size = new Size(115, 32);
         reportsButton.Text = "Reports Folder";
         reportsButton.Click += reportsButton_Click;
         // 
         // toolStripSeparator4
         // 
         toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
         toolStripSeparator4.Name = "toolStripSeparator4";
         toolStripSeparator4.Size = new Size(6, 35);
         // 
         // exportsButton
         // 
         exportsButton.Alignment = ToolStripItemAlignment.Right;
         exportsButton.Image = (Image)resources.GetObject("exportsButton.Image");
         exportsButton.ImageScaling = ToolStripItemImageScaling.None;
         exportsButton.ImageTransparentColor = Color.Magenta;
         exportsButton.Name = "exportsButton";
         exportsButton.Padding = new Padding(5, 5, 6, 5);
         exportsButton.Size = new Size(114, 32);
         exportsButton.Text = "Exports Folder";
         exportsButton.Click += exportsButton_Click;
         // 
         // toolStripSeparator3
         // 
         toolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
         toolStripSeparator3.Name = "toolStripSeparator3";
         toolStripSeparator3.Size = new Size(6, 35);
         // 
         // BidNavigationScreen
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.DimGray;
         Controls.Add(topToolStrip);
         Controls.Add(centeredPanel);
         Controls.Add(topPanel);
         Margin = new Padding(4, 3, 4, 3);
         Name = "BidNavigationScreen";
         Size = new Size(1321, 888);
         SizeChanged += BidNavigationScreen_SizeChanged;
         topPanel.ResumeLayout(false);
         topPanel.PerformLayout();
         centeredPanel.ResumeLayout(false);
         topToolStrip.ResumeLayout(false);
         topToolStrip.PerformLayout();
         ResumeLayout(false);
         PerformLayout();

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
