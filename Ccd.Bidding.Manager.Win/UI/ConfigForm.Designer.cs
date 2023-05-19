namespace Ccd.Bidding.Manager.Win.UI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.reportsFolderTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.savechangesButton = new System.Windows.Forms.ToolStripButton();
            this.reportsFolderLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.exportsFolderLabel = new System.Windows.Forms.Label();
            this.exportsFolderTextBox = new System.Windows.Forms.TextBox();
            this.reportsFolderButton = new System.Windows.Forms.Button();
            this.exportsFolderButton = new System.Windows.Forms.Button();
            this.allowBidDeletionCheckBox = new System.Windows.Forms.CheckBox();
            this.suppressFilePathSelectionsOnSavingCheckBox = new System.Windows.Forms.CheckBox();
            this.autoOpenExportsCheckBox = new System.Windows.Forms.CheckBox();
            this.autoOpenReportsCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.includeTimestampsOnAllFiles = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportsFolderTextBox
            // 
            this.reportsFolderTextBox.Location = new System.Drawing.Point(12, 25);
            this.reportsFolderTextBox.Name = "reportsFolderTextBox";
            this.reportsFolderTextBox.ReadOnly = true;
            this.reportsFolderTextBox.Size = new System.Drawing.Size(249, 22);
            this.reportsFolderTextBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.savechangesButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 274);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(350, 32);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripButton1.Size = new System.Drawing.Size(57, 29);
            this.toolStripButton1.Text = "Cancel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // savechangesButton
            // 
            this.savechangesButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.savechangesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savechangesButton.Image = ((System.Drawing.Image)(resources.GetObject("savechangesButton.Image")));
            this.savechangesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savechangesButton.Name = "savechangesButton";
            this.savechangesButton.Padding = new System.Windows.Forms.Padding(5);
            this.savechangesButton.Size = new System.Drawing.Size(94, 29);
            this.savechangesButton.Text = "Save Changes";
            this.savechangesButton.Click += new System.EventHandler(this.savechangesButton_Click);
            // 
            // reportsFolderLabel
            // 
            this.reportsFolderLabel.AutoSize = true;
            this.reportsFolderLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsFolderLabel.Location = new System.Drawing.Point(12, 9);
            this.reportsFolderLabel.Name = "reportsFolderLabel";
            this.reportsFolderLabel.Size = new System.Drawing.Size(86, 13);
            this.reportsFolderLabel.TabIndex = 5;
            this.reportsFolderLabel.Text = "Reports Folder:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // exportsFolderLabel
            // 
            this.exportsFolderLabel.AutoSize = true;
            this.exportsFolderLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportsFolderLabel.Location = new System.Drawing.Point(12, 59);
            this.exportsFolderLabel.Name = "exportsFolderLabel";
            this.exportsFolderLabel.Size = new System.Drawing.Size(85, 13);
            this.exportsFolderLabel.TabIndex = 7;
            this.exportsFolderLabel.Text = "Exports Folder:";
            // 
            // exportsFolderTextBox
            // 
            this.exportsFolderTextBox.Location = new System.Drawing.Point(12, 75);
            this.exportsFolderTextBox.Name = "exportsFolderTextBox";
            this.exportsFolderTextBox.ReadOnly = true;
            this.exportsFolderTextBox.Size = new System.Drawing.Size(249, 22);
            this.exportsFolderTextBox.TabIndex = 6;
            // 
            // reportsFolderButton
            // 
            this.reportsFolderButton.Location = new System.Drawing.Point(266, 25);
            this.reportsFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.reportsFolderButton.Name = "reportsFolderButton";
            this.reportsFolderButton.Size = new System.Drawing.Size(73, 22);
            this.reportsFolderButton.TabIndex = 8;
            this.reportsFolderButton.Text = "Browse...";
            this.reportsFolderButton.UseVisualStyleBackColor = true;
            this.reportsFolderButton.Click += new System.EventHandler(this.reportsFolderButton_Click);
            // 
            // exportsFolderButton
            // 
            this.exportsFolderButton.Location = new System.Drawing.Point(266, 75);
            this.exportsFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.exportsFolderButton.Name = "exportsFolderButton";
            this.exportsFolderButton.Size = new System.Drawing.Size(73, 22);
            this.exportsFolderButton.TabIndex = 9;
            this.exportsFolderButton.Text = "Browse...";
            this.exportsFolderButton.UseVisualStyleBackColor = true;
            this.exportsFolderButton.Click += new System.EventHandler(this.exportsFolderButton_Click);
            // 
            // allowBidDeletionCheckBox
            // 
            this.allowBidDeletionCheckBox.AutoSize = true;
            this.allowBidDeletionCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allowBidDeletionCheckBox.Location = new System.Drawing.Point(16, 29);
            this.allowBidDeletionCheckBox.Name = "allowBidDeletionCheckBox";
            this.allowBidDeletionCheckBox.Size = new System.Drawing.Size(126, 17);
            this.allowBidDeletionCheckBox.TabIndex = 12;
            this.allowBidDeletionCheckBox.Text = "Allow Bid Deletions";
            this.allowBidDeletionCheckBox.UseVisualStyleBackColor = true;
            // 
            // suppressFilePathSelectionsOnSavingCheckBox
            // 
            this.suppressFilePathSelectionsOnSavingCheckBox.AutoSize = true;
            this.suppressFilePathSelectionsOnSavingCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppressFilePathSelectionsOnSavingCheckBox.Location = new System.Drawing.Point(16, 52);
            this.suppressFilePathSelectionsOnSavingCheckBox.Name = "suppressFilePathSelectionsOnSavingCheckBox";
            this.suppressFilePathSelectionsOnSavingCheckBox.Size = new System.Drawing.Size(229, 17);
            this.suppressFilePathSelectionsOnSavingCheckBox.TabIndex = 15;
            this.suppressFilePathSelectionsOnSavingCheckBox.Text = "Suppress File Path Selections on Saving";
            this.suppressFilePathSelectionsOnSavingCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoOpenExportsCheckBox
            // 
            this.autoOpenExportsCheckBox.AutoSize = true;
            this.autoOpenExportsCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenExportsCheckBox.Location = new System.Drawing.Point(16, 75);
            this.autoOpenExportsCheckBox.Name = "autoOpenExportsCheckBox";
            this.autoOpenExportsCheckBox.Size = new System.Drawing.Size(205, 17);
            this.autoOpenExportsCheckBox.TabIndex = 16;
            this.autoOpenExportsCheckBox.Text = "Automatically Open All Export Files";
            this.autoOpenExportsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoOpenReportsCheckBox
            // 
            this.autoOpenReportsCheckBox.AutoSize = true;
            this.autoOpenReportsCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenReportsCheckBox.Location = new System.Drawing.Point(16, 98);
            this.autoOpenReportsCheckBox.Name = "autoOpenReportsCheckBox";
            this.autoOpenReportsCheckBox.Size = new System.Drawing.Size(243, 17);
            this.autoOpenReportsCheckBox.TabIndex = 17;
            this.autoOpenReportsCheckBox.Text = "Automatically Open All Generated Reports";
            this.autoOpenReportsCheckBox.UseVisualStyleBackColor = true;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.includeTimestampsOnAllFiles);
            this.optionsGroupBox.Controls.Add(this.allowBidDeletionCheckBox);
            this.optionsGroupBox.Controls.Add(this.autoOpenReportsCheckBox);
            this.optionsGroupBox.Controls.Add(this.suppressFilePathSelectionsOnSavingCheckBox);
            this.optionsGroupBox.Controls.Add(this.autoOpenExportsCheckBox);
            this.optionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 112);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(327, 150);
            this.optionsGroupBox.TabIndex = 18;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options:";
            // 
            // includeTimestampsOnAllFiles
            // 
            this.includeTimestampsOnAllFiles.AutoSize = true;
            this.includeTimestampsOnAllFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.includeTimestampsOnAllFiles.Location = new System.Drawing.Point(16, 121);
            this.includeTimestampsOnAllFiles.Name = "includeTimestampsOnAllFiles";
            this.includeTimestampsOnAllFiles.Size = new System.Drawing.Size(138, 17);
            this.includeTimestampsOnAllFiles.TabIndex = 18;
            this.includeTimestampsOnAllFiles.Text = "Timestamp All Exports";
            this.includeTimestampsOnAllFiles.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 306);
            this.ControlBox = false;
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.exportsFolderButton);
            this.Controls.Add(this.reportsFolderButton);
            this.Controls.Add(this.exportsFolderLabel);
            this.Controls.Add(this.exportsFolderTextBox);
            this.Controls.Add(this.reportsFolderLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.reportsFolderTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Configuration";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BidEditDialog_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox reportsFolderTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton savechangesButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
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
    }
}