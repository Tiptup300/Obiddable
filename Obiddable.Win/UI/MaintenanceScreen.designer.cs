using Obiddable.Win.Library.UI.ListViews;

namespace Obiddable.Win.UI
{
    partial class MaintenanceScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceScreen));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.actionsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.configButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reportsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.actionsMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.subtitleLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewMain = new SortableListView();
            this.topPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsMenu,
            this.helpButton,
            this.configButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.reportsButton,
            this.toolStripSeparator4,
            this.exportsButton,
            this.toolStripSeparator3,
            this.actionsMenuSeparator,
            this.addButton,
            this.editButton,
            this.deleteButton,
            this.toolStripSeparator2,
            this.subtitleLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(1132, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // actionsMenu
            // 
            this.actionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("actionsMenu.Image")));
            this.actionsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.actionsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.actionsMenu.Name = "actionsMenu";
            this.actionsMenu.Padding = new System.Windows.Forms.Padding(55, 5, 0, 5);
            this.actionsMenu.Size = new System.Drawing.Size(136, 32);
            this.actionsMenu.Text = " Actions";
            this.actionsMenu.VisibleChanged += new System.EventHandler(this.actionsMenu_VisibleChanged);
            // 
            // toolStripButton1
            // 
            this.helpButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
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
            // actionsMenuSeparator
            // 
            this.actionsMenuSeparator.Name = "actionsMenuSeparator";
            this.actionsMenuSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // addButton
            // 
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(5);
            this.addButton.Size = new System.Drawing.Size(61, 32);
            this.addButton.Text = "Add";
            this.addButton.ToolTipText = "Create New (Hotkeys: A, I, Insert)";
            // 
            // editButton
            // 
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Padding = new System.Windows.Forms.Padding(5);
            this.editButton.Size = new System.Drawing.Size(59, 32);
            this.editButton.Text = "Edit";
            this.editButton.ToolTipText = "Edit Selected (Hotkey: E, Enter)";
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(5);
            this.deleteButton.Size = new System.Drawing.Size(72, 32);
            this.deleteButton.Text = "Delete";
            this.deleteButton.ToolTipText = "Delete Selected (Hotkey: D, Delete)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.Black;
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(135, 32);
            this.subtitleLabel.Text = "Obiddable (v1.0)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewMain);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 625);
            this.panel2.TabIndex = 2;
            // 
            // listViewMain
            // 
            this.listViewMain.AllowColumnReorder = true;
            this.listViewMain.BackColor = System.Drawing.Color.White;
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(0, 35);
            this.listViewMain.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(1132, 590);
            this.listViewMain.TabIndex = 1;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            this.listViewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewMain_KeyDown);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(117)))), ((int)(((byte)(135)))));
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1132, 71);
            this.topPanel.TabIndex = 1;
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
            this.titleLabel.Size = new System.Drawing.Size(328, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Maintenance Form";
            // 
            // MaintenanceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MaintenanceScreen";
            this.Size = new System.Drawing.Size(1132, 696);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }









        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton refreshButton;
        public System.Windows.Forms.ToolStripButton addButton;
        public System.Windows.Forms.ToolStripButton editButton;
        public System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.Panel panel2;
        public SortableListView listViewMain;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.ToolStripDropDownButton actionsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripLabel subtitleLabel;
        public System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ToolStripSeparator actionsMenuSeparator;
        public System.Windows.Forms.ToolStripButton configButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton reportsButton;
        public System.Windows.Forms.ToolStripButton exportsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton helpButton;
    }
}

