namespace Obiddable.Win.UI
{
    partial class ConfigForm
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
         components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
         reportsFolderTextBox = new TextBox();
         toolStrip1 = new ToolStrip();
         cancelButton = new ToolStripButton();
         saveChangesButton = new ToolStripButton();
         reportsFolderLabel = new Label();
         errorProvider1 = new ErrorProvider(components);
         exportsFolderLabel = new Label();
         exportsFolderTextBox = new TextBox();
         reportsFolderButton = new Button();
         exportsFolderButton = new Button();
         allowBidDeletionCheckBox = new CheckBox();
         suppressFilePathSelectionsOnSavingCheckBox = new CheckBox();
         autoOpenExportsCheckBox = new CheckBox();
         autoOpenReportsCheckBox = new CheckBox();
         optionsGroupBox = new GroupBox();
         includeTimestampsOnAllFiles = new CheckBox();
         epplusNoLicenseRadio = new RadioButton();
         groupBox1 = new GroupBox();
         linkLabel1 = new LinkLabel();
         licenseKeyLabbel = new Label();
         epplusCommercialPaidLicenseKeyTextBox = new TextBox();
         epplusLicenseCommercialPaidRadio = new RadioButton();
         organizationLabel = new Label();
         epplusNonCommercialOrganizationNameTextBox = new TextBox();
         epplusLicenseNonCommercialOrganizationRadio = new RadioButton();
         label2 = new Label();
         epplusNonCommercialPersonalNameTextBox = new TextBox();
         epplusLicenseNonCommercialPersonalRadio = new RadioButton();
         label1 = new Label();
         toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
         optionsGroupBox.SuspendLayout();
         groupBox1.SuspendLayout();
         SuspendLayout();
         // 
         // reportsFolderTextBox
         // 
         reportsFolderTextBox.Location = new Point(12, 25);
         reportsFolderTextBox.Name = "reportsFolderTextBox";
         reportsFolderTextBox.ReadOnly = true;
         reportsFolderTextBox.Size = new Size(348, 22);
         reportsFolderTextBox.TabIndex = 0;
         // 
         // toolStrip1
         // 
         toolStrip1.Dock = DockStyle.Bottom;
         toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
         toolStrip1.Items.AddRange(new ToolStripItem[] { cancelButton, saveChangesButton });
         toolStrip1.Location = new Point(0, 636);
         toolStrip1.Name = "toolStrip1";
         toolStrip1.Size = new Size(450, 32);
         toolStrip1.TabIndex = 4;
         toolStrip1.Text = "toolStrip1";
         // 
         // cancelButton
         // 
         cancelButton.Alignment = ToolStripItemAlignment.Right;
         cancelButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         cancelButton.Image = (Image)resources.GetObject("cancelButton.Image");
         cancelButton.ImageTransparentColor = Color.Magenta;
         cancelButton.Name = "cancelButton";
         cancelButton.Padding = new Padding(5);
         cancelButton.Size = new Size(57, 29);
         cancelButton.Text = "Cancel";
         cancelButton.Click += OnCancelClicked;
         // 
         // saveChangesButton
         // 
         saveChangesButton.Alignment = ToolStripItemAlignment.Right;
         saveChangesButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         saveChangesButton.Image = (Image)resources.GetObject("saveChangesButton.Image");
         saveChangesButton.ImageTransparentColor = Color.Magenta;
         saveChangesButton.Name = "saveChangesButton";
         saveChangesButton.Padding = new Padding(5);
         saveChangesButton.Size = new Size(94, 29);
         saveChangesButton.Text = "Save Changes";
         saveChangesButton.Click += OnSaveChangesClicked;
         // 
         // reportsFolderLabel
         // 
         reportsFolderLabel.AutoSize = true;
         reportsFolderLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         reportsFolderLabel.Location = new Point(12, 9);
         reportsFolderLabel.Name = "reportsFolderLabel";
         reportsFolderLabel.Size = new Size(86, 13);
         reportsFolderLabel.TabIndex = 5;
         reportsFolderLabel.Text = "Reports Folder:";
         // 
         // errorProvider1
         // 
         errorProvider1.ContainerControl = this;
         // 
         // exportsFolderLabel
         // 
         exportsFolderLabel.AutoSize = true;
         exportsFolderLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         exportsFolderLabel.Location = new Point(12, 59);
         exportsFolderLabel.Name = "exportsFolderLabel";
         exportsFolderLabel.Size = new Size(85, 13);
         exportsFolderLabel.TabIndex = 7;
         exportsFolderLabel.Text = "Exports Folder:";
         // 
         // exportsFolderTextBox
         // 
         exportsFolderTextBox.Location = new Point(12, 75);
         exportsFolderTextBox.Name = "exportsFolderTextBox";
         exportsFolderTextBox.ReadOnly = true;
         exportsFolderTextBox.Size = new Size(348, 22);
         exportsFolderTextBox.TabIndex = 6;
         // 
         // reportsFolderButton
         // 
         reportsFolderButton.Location = new Point(365, 25);
         reportsFolderButton.Margin = new Padding(2);
         reportsFolderButton.Name = "reportsFolderButton";
         reportsFolderButton.Size = new Size(73, 22);
         reportsFolderButton.TabIndex = 8;
         reportsFolderButton.Text = "Browse...";
         reportsFolderButton.UseVisualStyleBackColor = true;
         reportsFolderButton.Click += OnBrowseReportsFolderClicked;
         // 
         // exportsFolderButton
         // 
         exportsFolderButton.Location = new Point(365, 75);
         exportsFolderButton.Margin = new Padding(2);
         exportsFolderButton.Name = "exportsFolderButton";
         exportsFolderButton.Size = new Size(73, 22);
         exportsFolderButton.TabIndex = 9;
         exportsFolderButton.Text = "Browse...";
         exportsFolderButton.UseVisualStyleBackColor = true;
         exportsFolderButton.Click += ExportsFolderButton_Click;
         // 
         // allowBidDeletionCheckBox
         // 
         allowBidDeletionCheckBox.AutoSize = true;
         allowBidDeletionCheckBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
         allowBidDeletionCheckBox.Location = new Point(16, 29);
         allowBidDeletionCheckBox.Name = "allowBidDeletionCheckBox";
         allowBidDeletionCheckBox.Size = new Size(127, 17);
         allowBidDeletionCheckBox.TabIndex = 12;
         allowBidDeletionCheckBox.Text = "Allow Bid Deletions";
         allowBidDeletionCheckBox.UseVisualStyleBackColor = true;
         // 
         // suppressFilePathSelectionsOnSavingCheckBox
         // 
         suppressFilePathSelectionsOnSavingCheckBox.AutoSize = true;
         suppressFilePathSelectionsOnSavingCheckBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
         suppressFilePathSelectionsOnSavingCheckBox.Location = new Point(16, 52);
         suppressFilePathSelectionsOnSavingCheckBox.Name = "suppressFilePathSelectionsOnSavingCheckBox";
         suppressFilePathSelectionsOnSavingCheckBox.Size = new Size(229, 17);
         suppressFilePathSelectionsOnSavingCheckBox.TabIndex = 15;
         suppressFilePathSelectionsOnSavingCheckBox.Text = "Suppress File Path Selections on Saving";
         suppressFilePathSelectionsOnSavingCheckBox.UseVisualStyleBackColor = true;
         // 
         // autoOpenExportsCheckBox
         // 
         autoOpenExportsCheckBox.AutoSize = true;
         autoOpenExportsCheckBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
         autoOpenExportsCheckBox.Location = new Point(16, 75);
         autoOpenExportsCheckBox.Name = "autoOpenExportsCheckBox";
         autoOpenExportsCheckBox.Size = new Size(205, 17);
         autoOpenExportsCheckBox.TabIndex = 16;
         autoOpenExportsCheckBox.Text = "Automatically Open All Export Files";
         autoOpenExportsCheckBox.UseVisualStyleBackColor = true;
         // 
         // autoOpenReportsCheckBox
         // 
         autoOpenReportsCheckBox.AutoSize = true;
         autoOpenReportsCheckBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
         autoOpenReportsCheckBox.Location = new Point(16, 98);
         autoOpenReportsCheckBox.Name = "autoOpenReportsCheckBox";
         autoOpenReportsCheckBox.Size = new Size(243, 17);
         autoOpenReportsCheckBox.TabIndex = 17;
         autoOpenReportsCheckBox.Text = "Automatically Open All Generated Reports";
         autoOpenReportsCheckBox.UseVisualStyleBackColor = true;
         // 
         // optionsGroupBox
         // 
         optionsGroupBox.Controls.Add(includeTimestampsOnAllFiles);
         optionsGroupBox.Controls.Add(allowBidDeletionCheckBox);
         optionsGroupBox.Controls.Add(autoOpenReportsCheckBox);
         optionsGroupBox.Controls.Add(suppressFilePathSelectionsOnSavingCheckBox);
         optionsGroupBox.Controls.Add(autoOpenExportsCheckBox);
         optionsGroupBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         optionsGroupBox.Location = new Point(12, 112);
         optionsGroupBox.Name = "optionsGroupBox";
         optionsGroupBox.Size = new Size(426, 152);
         optionsGroupBox.TabIndex = 18;
         optionsGroupBox.TabStop = false;
         optionsGroupBox.Text = "Application Options:";
         // 
         // includeTimestampsOnAllFiles
         // 
         includeTimestampsOnAllFiles.AutoSize = true;
         includeTimestampsOnAllFiles.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
         includeTimestampsOnAllFiles.Location = new Point(16, 121);
         includeTimestampsOnAllFiles.Name = "includeTimestampsOnAllFiles";
         includeTimestampsOnAllFiles.Size = new Size(137, 17);
         includeTimestampsOnAllFiles.TabIndex = 18;
         includeTimestampsOnAllFiles.Text = "Timestamp All Exports";
         includeTimestampsOnAllFiles.UseVisualStyleBackColor = true;
         // 
         // epplusNoLicenseRadio
         // 
         epplusNoLicenseRadio.AutoSize = true;
         epplusNoLicenseRadio.Font = new Font("Segoe UI", 9F);
         epplusNoLicenseRadio.Location = new Point(35, 162);
         epplusNoLicenseRadio.Name = "epplusNoLicenseRadio";
         epplusNoLicenseRadio.Size = new Size(216, 19);
         epplusNoLicenseRadio.TabIndex = 19;
         epplusNoLicenseRadio.TabStop = true;
         epplusNoLicenseRadio.Text = "No License (Disable Excel Functions)";
         epplusNoLicenseRadio.UseVisualStyleBackColor = true;
         epplusNoLicenseRadio.CheckedChanged += OnEpplusLicenseSelectionChanged;
         // 
         // groupBox1
         // 
         groupBox1.Controls.Add(linkLabel1);
         groupBox1.Controls.Add(licenseKeyLabbel);
         groupBox1.Controls.Add(epplusCommercialPaidLicenseKeyTextBox);
         groupBox1.Controls.Add(epplusLicenseCommercialPaidRadio);
         groupBox1.Controls.Add(organizationLabel);
         groupBox1.Controls.Add(epplusNonCommercialOrganizationNameTextBox);
         groupBox1.Controls.Add(epplusLicenseNonCommercialOrganizationRadio);
         groupBox1.Controls.Add(label2);
         groupBox1.Controls.Add(epplusNonCommercialPersonalNameTextBox);
         groupBox1.Controls.Add(epplusLicenseNonCommercialPersonalRadio);
         groupBox1.Controls.Add(label1);
         groupBox1.Controls.Add(epplusNoLicenseRadio);
         groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
         groupBox1.Location = new Point(12, 270);
         groupBox1.Name = "groupBox1";
         groupBox1.Size = new Size(426, 355);
         groupBox1.TabIndex = 20;
         groupBox1.TabStop = false;
         groupBox1.Text = "EPPlus Licensing Information";
         // 
         // linkLabel1
         // 
         linkLabel1.AutoSize = true;
         linkLabel1.Location = new Point(16, 134);
         linkLabel1.Name = "linkLabel1";
         linkLabel1.Size = new Size(244, 15);
         linkLabel1.TabIndex = 30;
         linkLabel1.TabStop = true;
         linkLabel1.Text = "Click here for EPPlus Licensing Information";
         linkLabel1.LinkClicked += OnEpplusLicensingLinkClicked;
         // 
         // licenseKeyLabbel
         // 
         licenseKeyLabbel.AutoSize = true;
         licenseKeyLabbel.Font = new Font("Segoe UI", 9F);
         licenseKeyLabbel.Location = new Point(71, 319);
         licenseKeyLabbel.Name = "licenseKeyLabbel";
         licenseKeyLabbel.Size = new Size(71, 15);
         licenseKeyLabbel.TabIndex = 29;
         licenseKeyLabbel.Text = "License Key:";
         // 
         // epplusCommercialPaidLicenseKeyTextBox
         // 
         epplusCommercialPaidLicenseKeyTextBox.Location = new Point(148, 316);
         epplusCommercialPaidLicenseKeyTextBox.Name = "epplusCommercialPaidLicenseKeyTextBox";
         epplusCommercialPaidLicenseKeyTextBox.Size = new Size(272, 23);
         epplusCommercialPaidLicenseKeyTextBox.TabIndex = 28;
         // 
         // epplusLicenseCommercialPaidRadio
         // 
         epplusLicenseCommercialPaidRadio.AutoSize = true;
         epplusLicenseCommercialPaidRadio.Font = new Font("Segoe UI", 9F);
         epplusLicenseCommercialPaidRadio.Location = new Point(35, 293);
         epplusLicenseCommercialPaidRadio.Name = "epplusLicenseCommercialPaidRadio";
         epplusLicenseCommercialPaidRadio.Size = new Size(158, 19);
         epplusLicenseCommercialPaidRadio.TabIndex = 27;
         epplusLicenseCommercialPaidRadio.TabStop = true;
         epplusLicenseCommercialPaidRadio.Text = "Commercial Paid License";
         epplusLicenseCommercialPaidRadio.UseVisualStyleBackColor = true;
         epplusLicenseCommercialPaidRadio.CheckedChanged += OnEpplusLicenseSelectionChanged;
         // 
         // organizationLabel
         // 
         organizationLabel.AutoSize = true;
         organizationLabel.Font = new Font("Segoe UI", 9F);
         organizationLabel.Location = new Point(60, 268);
         organizationLabel.Name = "organizationLabel";
         organizationLabel.Size = new Size(78, 15);
         organizationLabel.TabIndex = 26;
         organizationLabel.Text = "Organization:";
         // 
         // epplusNonCommercialOrganizationNameTextBox
         // 
         epplusNonCommercialOrganizationNameTextBox.Location = new Point(147, 265);
         epplusNonCommercialOrganizationNameTextBox.Name = "epplusNonCommercialOrganizationNameTextBox";
         epplusNonCommercialOrganizationNameTextBox.Size = new Size(273, 23);
         epplusNonCommercialOrganizationNameTextBox.TabIndex = 25;
         // 
         // epplusLicenseNonCommercialOrganizationRadio
         // 
         epplusLicenseNonCommercialOrganizationRadio.AutoSize = true;
         epplusLicenseNonCommercialOrganizationRadio.Font = new Font("Segoe UI", 9F);
         epplusLicenseNonCommercialOrganizationRadio.Location = new Point(35, 240);
         epplusLicenseNonCommercialOrganizationRadio.Name = "epplusLicenseNonCommercialOrganizationRadio";
         epplusLicenseNonCommercialOrganizationRadio.Size = new Size(366, 19);
         epplusLicenseNonCommercialOrganizationRadio.TabIndex = 24;
         epplusLicenseNonCommercialOrganizationRadio.TabStop = true;
         epplusLicenseNonCommercialOrganizationRadio.Text = "NonCommercial Organization (Recommended For School Users)";
         epplusLicenseNonCommercialOrganizationRadio.UseVisualStyleBackColor = true;
         epplusLicenseNonCommercialOrganizationRadio.CheckedChanged += OnEpplusLicenseSelectionChanged;
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Font = new Font("Segoe UI", 9F);
         label2.Location = new Point(99, 217);
         label2.Name = "label2";
         label2.Size = new Size(42, 15);
         label2.TabIndex = 23;
         label2.Text = "Name:";
         // 
         // epplusNonCommercialPersonalNameTextBox
         // 
         epplusNonCommercialPersonalNameTextBox.Location = new Point(147, 214);
         epplusNonCommercialPersonalNameTextBox.Name = "epplusNonCommercialPersonalNameTextBox";
         epplusNonCommercialPersonalNameTextBox.Size = new Size(273, 23);
         epplusNonCommercialPersonalNameTextBox.TabIndex = 22;
         // 
         // epplusLicenseNonCommercialPersonalRadio
         // 
         epplusLicenseNonCommercialPersonalRadio.AutoSize = true;
         epplusLicenseNonCommercialPersonalRadio.Font = new Font("Segoe UI", 9F);
         epplusLicenseNonCommercialPersonalRadio.Location = new Point(35, 187);
         epplusLicenseNonCommercialPersonalRadio.Name = "epplusLicenseNonCommercialPersonalRadio";
         epplusLicenseNonCommercialPersonalRadio.Size = new Size(161, 19);
         epplusLicenseNonCommercialPersonalRadio.TabIndex = 21;
         epplusLicenseNonCommercialPersonalRadio.TabStop = true;
         epplusLicenseNonCommercialPersonalRadio.Text = "NonCommercial Personal";
         epplusLicenseNonCommercialPersonalRadio.UseVisualStyleBackColor = true;
         epplusLicenseNonCommercialPersonalRadio.CheckedChanged += OnEpplusLicenseSelectionChanged;
         // 
         // label1
         // 
         label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
         label1.ForeColor = SystemColors.ControlDarkDark;
         label1.Location = new Point(16, 18);
         label1.Name = "label1";
         label1.Size = new Size(404, 105);
         label1.TabIndex = 20;
         label1.Text = resources.GetString("label1.Text");
         // 
         // ConfigForm
         // 
         AutoScaleDimensions = new SizeF(6F, 13F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(450, 668);
         ControlBox = false;
         Controls.Add(groupBox1);
         Controls.Add(optionsGroupBox);
         Controls.Add(exportsFolderButton);
         Controls.Add(reportsFolderButton);
         Controls.Add(exportsFolderLabel);
         Controls.Add(exportsFolderTextBox);
         Controls.Add(reportsFolderLabel);
         Controls.Add(toolStrip1);
         Controls.Add(reportsFolderTextBox);
         Font = new Font("Segoe UI", 8.25F);
         FormBorderStyle = FormBorderStyle.FixedToolWindow;
         KeyPreview = true;
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "ConfigForm";
         StartPosition = FormStartPosition.CenterParent;
         Text = "Edit Configuration";
         KeyDown += OnKeyDown;
         toolStrip1.ResumeLayout(false);
         toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
         optionsGroupBox.ResumeLayout(false);
         optionsGroupBox.PerformLayout();
         groupBox1.ResumeLayout(false);
         groupBox1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();

      }

      #endregion

      public System.Windows.Forms.TextBox reportsFolderTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveChangesButton;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.Label reportsFolderLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button exportsFolderButton;
        private System.Windows.Forms.Button reportsFolderButton;
        private System.Windows.Forms.Label exportsFolderLabel;
        public System.Windows.Forms.TextBox exportsFolderTextBox;
        private System.Windows.Forms.CheckBox allowBidDeletionCheckBox;
        private System.Windows.Forms.CheckBox suppressFilePathSelectionsOnSavingCheckBox;
        private System.Windows.Forms.CheckBox autoOpenExportsCheckBox;
        private System.Windows.Forms.CheckBox autoOpenReportsCheckBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox includeTimestampsOnAllFiles;
      private RadioButton epplusNoLicenseRadio;
      private GroupBox groupBox1;
      private Label label1;
      private RadioButton epplusLicenseNonCommercialOrganizationRadio;
      private Label label2;
      private TextBox epplusNonCommercialPersonalNameTextBox;
      private RadioButton epplusLicenseNonCommercialPersonalRadio;
      private Label organizationLabel;
      private TextBox epplusNonCommercialOrganizationNameTextBox;
      private Label licenseKeyLabbel;
      private TextBox epplusCommercialPaidLicenseKeyTextBox;
      private RadioButton epplusLicenseCommercialPaidRadio;
      private LinkLabel linkLabel1;
   }
}