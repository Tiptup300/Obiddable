namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    partial class ItemEditForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditForm));
         codeTextBox = new TextBox();
         codeLabel = new Label();
         categoryLabel = new Label();
         descriptionTextBox = new TextBox();
         substitutableCheckBox = new CheckBox();
         descriptionLabel = new Label();
         unitDescriptionTextBox = new TextBox();
         unitLabel = new Label();
         lastOrderPriceLabel = new Label();
         lastOrderPriceTextBox = new TextBox();
         estimatedPriceLabel = new Label();
         estimatedPriceTextBox = new TextBox();
         errorProvider1 = new ErrorProvider(components);
         toolStrip1 = new ToolStrip();
         cancelButton = new ToolStripButton();
         saveChangesButton = new ToolStripButton();
         categoryComboBox = new ComboBox();
         ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
         toolStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // codeTextBox
         // 
         codeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         codeTextBox.Location = new Point(13, 27);
         codeTextBox.Margin = new Padding(4, 5, 4, 5);
         codeTextBox.Name = "codeTextBox";
         codeTextBox.Size = new Size(217, 29);
         codeTextBox.TabIndex = 0;
         // 
         // codeLabel
         // 
         codeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         codeLabel.AutoSize = true;
         codeLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         codeLabel.Location = new Point(13, 9);
         codeLabel.Margin = new Padding(4, 0, 4, 0);
         codeLabel.Name = "codeLabel";
         codeLabel.Size = new Size(37, 13);
         codeLabel.TabIndex = 5;
         codeLabel.Text = "Code:";
         // 
         // categoryLabel
         // 
         categoryLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         categoryLabel.AutoSize = true;
         categoryLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         categoryLabel.Location = new Point(329, 9);
         categoryLabel.Margin = new Padding(4, 0, 4, 0);
         categoryLabel.Name = "categoryLabel";
         categoryLabel.Size = new Size(57, 13);
         categoryLabel.TabIndex = 7;
         categoryLabel.Text = "Category:";
         // 
         // descriptionTextBox
         // 
         descriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         descriptionTextBox.Location = new Point(13, 79);
         descriptionTextBox.Margin = new Padding(4, 5, 4, 5);
         descriptionTextBox.Multiline = true;
         descriptionTextBox.Name = "descriptionTextBox";
         descriptionTextBox.Size = new Size(617, 347);
         descriptionTextBox.TabIndex = 3;
         // 
         // substitutableCheckBox
         // 
         substitutableCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         substitutableCheckBox.Location = new Point(428, 451);
         substitutableCheckBox.Name = "substitutableCheckBox";
         substitutableCheckBox.Size = new Size(202, 25);
         substitutableCheckBox.TabIndex = 6;
         substitutableCheckBox.Text = "Allows Substitutes";
         substitutableCheckBox.UseVisualStyleBackColor = true;
         // 
         // descriptionLabel
         // 
         descriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         descriptionLabel.AutoSize = true;
         descriptionLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         descriptionLabel.Location = new Point(13, 61);
         descriptionLabel.Margin = new Padding(4, 0, 4, 0);
         descriptionLabel.Name = "descriptionLabel";
         descriptionLabel.Size = new Size(69, 13);
         descriptionLabel.TabIndex = 10;
         descriptionLabel.Text = "Description:";
         // 
         // unitDescriptionTextBox
         // 
         unitDescriptionTextBox.Location = new Point(236, 27);
         unitDescriptionTextBox.Margin = new Padding(4, 5, 4, 5);
         unitDescriptionTextBox.Name = "unitDescriptionTextBox";
         unitDescriptionTextBox.Size = new Size(88, 29);
         unitDescriptionTextBox.TabIndex = 1;
         // 
         // unitLabel
         // 
         unitLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         unitLabel.AutoSize = true;
         unitLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         unitLabel.Location = new Point(233, 9);
         unitLabel.Margin = new Padding(4, 0, 4, 0);
         unitLabel.Name = "unitLabel";
         unitLabel.Size = new Size(32, 13);
         unitLabel.TabIndex = 12;
         unitLabel.Text = "Unit:";
         // 
         // lastOrderPriceLabel
         // 
         lastOrderPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
         lastOrderPriceLabel.AutoSize = true;
         lastOrderPriceLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         lastOrderPriceLabel.Location = new Point(13, 431);
         lastOrderPriceLabel.Margin = new Padding(4, 0, 4, 0);
         lastOrderPriceLabel.Name = "lastOrderPriceLabel";
         lastOrderPriceLabel.Size = new Size(91, 13);
         lastOrderPriceLabel.TabIndex = 16;
         lastOrderPriceLabel.Text = "Last Order Price:";
         // 
         // lastOrderPriceTextBox
         // 
         lastOrderPriceTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
         lastOrderPriceTextBox.BackColor = SystemColors.Menu;
         lastOrderPriceTextBox.Enabled = false;
         lastOrderPriceTextBox.Location = new Point(13, 449);
         lastOrderPriceTextBox.Margin = new Padding(4, 5, 4, 5);
         lastOrderPriceTextBox.Name = "lastOrderPriceTextBox";
         lastOrderPriceTextBox.Size = new Size(200, 29);
         lastOrderPriceTextBox.TabIndex = 4;
         // 
         // estimatedPriceLabel
         // 
         estimatedPriceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
         estimatedPriceLabel.AutoSize = true;
         estimatedPriceLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         estimatedPriceLabel.Location = new Point(221, 431);
         estimatedPriceLabel.Margin = new Padding(4, 0, 4, 0);
         estimatedPriceLabel.Name = "estimatedPriceLabel";
         estimatedPriceLabel.Size = new Size(89, 13);
         estimatedPriceLabel.TabIndex = 18;
         estimatedPriceLabel.Text = "Estimated Price:";
         // 
         // estimatedPriceTextBox
         // 
         estimatedPriceTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
         estimatedPriceTextBox.Location = new Point(221, 449);
         estimatedPriceTextBox.Margin = new Padding(4, 5, 4, 5);
         estimatedPriceTextBox.Name = "estimatedPriceTextBox";
         estimatedPriceTextBox.Size = new Size(200, 29);
         estimatedPriceTextBox.TabIndex = 5;
         // 
         // errorProvider1
         // 
         errorProvider1.ContainerControl = this;
         // 
         // toolStrip1
         // 
         toolStrip1.Dock = DockStyle.Bottom;
         toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
         toolStrip1.Items.AddRange(new ToolStripItem[] { cancelButton, saveChangesButton });
         toolStrip1.Location = new Point(0, 494);
         toolStrip1.Name = "toolStrip1";
         toolStrip1.Padding = new Padding(0, 0, 2, 0);
         toolStrip1.Size = new Size(643, 32);
         toolStrip1.TabIndex = 20;
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
         cancelButton.Click += OnCancelButtonClicked;
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
         // categoryComboBox
         // 
         categoryComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         categoryComboBox.AutoCompleteMode = AutoCompleteMode.Append;
         categoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
         categoryComboBox.FormattingEnabled = true;
         categoryComboBox.Location = new Point(332, 27);
         categoryComboBox.Name = "categoryComboBox";
         categoryComboBox.Size = new Size(298, 29);
         categoryComboBox.TabIndex = 2;
         // 
         // ItemEditForm
         // 
         AutoScaleDimensions = new SizeF(9F, 21F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(643, 526);
         ControlBox = false;
         Controls.Add(categoryComboBox);
         Controls.Add(toolStrip1);
         Controls.Add(estimatedPriceLabel);
         Controls.Add(estimatedPriceTextBox);
         Controls.Add(lastOrderPriceLabel);
         Controls.Add(lastOrderPriceTextBox);
         Controls.Add(unitLabel);
         Controls.Add(unitDescriptionTextBox);
         Controls.Add(descriptionLabel);
         Controls.Add(substitutableCheckBox);
         Controls.Add(descriptionTextBox);
         Controls.Add(categoryLabel);
         Controls.Add(codeLabel);
         Controls.Add(codeTextBox);
         Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
         FormBorderStyle = FormBorderStyle.FixedDialog;
         KeyPreview = true;
         Margin = new Padding(4, 5, 4, 5);
         Name = "ItemEditForm";
         StartPosition = FormStartPosition.CenterParent;
         Text = "Create New Item";
         KeyDown += ItemEditForm_KeyDown;
         ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
         toolStrip1.ResumeLayout(false);
         toolStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();

      }

      #endregion

      public System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label categoryLabel;
        public System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.CheckBox substitutableCheckBox;
        private System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.TextBox unitDescriptionTextBox;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Label lastOrderPriceLabel;
        public System.Windows.Forms.TextBox lastOrderPriceTextBox;
        private System.Windows.Forms.Label estimatedPriceLabel;
        public System.Windows.Forms.TextBox estimatedPriceTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.ToolStripButton saveChangesButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
    }
}