namespace Ccd.Bidding.Manager.Win.UI.Bidding.Requesting
{
    partial class RequestAddForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestAddForm));
         toolStrip1 = new ToolStrip();
         CancelButton = new ToolStripButton();
         SaveChangesButton = new ToolStripButton();
         AccountNumberLabel = new Label();
         errorProvider = new ErrorProvider(components);
         AccountNumberComboBox = new ComboBox();
         AccountNumberFormatLabel = new Label();
         toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
         SuspendLayout();
         // 
         // toolStrip1
         // 
         toolStrip1.Dock = DockStyle.Bottom;
         toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
         toolStrip1.ImageScalingSize = new Size(28, 28);
         toolStrip1.Items.AddRange(new ToolStripItem[] { CancelButton, SaveChangesButton });
         toolStrip1.Location = new Point(0, 92);
         toolStrip1.Name = "toolStrip1";
         toolStrip1.Size = new Size(514, 32);
         toolStrip1.TabIndex = 4;
         toolStrip1.Text = "toolStrip1";
         // 
         // CancelButton
         // 
         CancelButton.Alignment = ToolStripItemAlignment.Right;
         CancelButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         CancelButton.Image = (Image)resources.GetObject("CancelButton.Image");
         CancelButton.ImageTransparentColor = Color.Magenta;
         CancelButton.Name = "CancelButton";
         CancelButton.Padding = new Padding(5);
         CancelButton.Size = new Size(57, 29);
         CancelButton.Text = "Cancel";
         CancelButton.Click += CancelButton_Click;
         // 
         // SaveChangesButton
         // 
         SaveChangesButton.Alignment = ToolStripItemAlignment.Right;
         SaveChangesButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         SaveChangesButton.Image = (Image)resources.GetObject("SaveChangesButton.Image");
         SaveChangesButton.ImageTransparentColor = Color.Magenta;
         SaveChangesButton.Name = "SaveChangesButton";
         SaveChangesButton.Padding = new Padding(5);
         SaveChangesButton.Size = new Size(94, 29);
         SaveChangesButton.Text = "Save Changes";
         SaveChangesButton.Click += SaveChangesButton_Click;
         // 
         // AccountNumberLabel
         // 
         AccountNumberLabel.AutoSize = true;
         AccountNumberLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         AccountNumberLabel.Location = new Point(13, 9);
         AccountNumberLabel.Margin = new Padding(4, 0, 4, 0);
         AccountNumberLabel.Name = "AccountNumberLabel";
         AccountNumberLabel.Size = new Size(99, 13);
         AccountNumberLabel.TabIndex = 5;
         AccountNumberLabel.Text = "Account Number:";
         // 
         // errorProvider
         // 
         errorProvider.ContainerControl = this;
         // 
         // AccountNumberComboBox
         // 
         AccountNumberComboBox.AutoCompleteMode = AutoCompleteMode.Append;
         AccountNumberComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
         AccountNumberComboBox.FormattingEnabled = true;
         AccountNumberComboBox.Location = new Point(12, 25);
         AccountNumberComboBox.Name = "AccountNumberComboBox";
         AccountNumberComboBox.Size = new Size(490, 29);
         AccountNumberComboBox.TabIndex = 6;
         // 
         // AccountNumberFormatLabel
         // 
         AccountNumberFormatLabel.AutoSize = true;
         AccountNumberFormatLabel.Location = new Point(12, 57);
         AccountNumberFormatLabel.Name = "AccountNumberFormatLabel";
         AccountNumberFormatLabel.Size = new Size(17, 21);
         AccountNumberFormatLabel.TabIndex = 7;
         AccountNumberFormatLabel.Text = "x";
         AccountNumberFormatLabel.TextAlign = ContentAlignment.BottomLeft;
         // 
         // RequestAddForm
         // 
         AutoScaleDimensions = new SizeF(9F, 21F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(514, 124);
         ControlBox = false;
         Controls.Add(AccountNumberFormatLabel);
         Controls.Add(AccountNumberComboBox);
         Controls.Add(AccountNumberLabel);
         Controls.Add(toolStrip1);
         Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
         FormBorderStyle = FormBorderStyle.FixedToolWindow;
         KeyPreview = true;
         Margin = new Padding(4, 5, 4, 5);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "RequestAddForm";
         StartPosition = FormStartPosition.CenterParent;
         Text = "Add New Request";
         Load += RequestAddForm_Load;
         KeyDown += BidEditDialog_KeyDown;
         toolStrip1.ResumeLayout(false);
         toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
         ResumeLayout(false);
         PerformLayout();

      }

      #endregion
      private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveChangesButton;
        private System.Windows.Forms.ToolStripButton CancelButton;
        private System.Windows.Forms.Label AccountNumberLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox AccountNumberComboBox;
      private Label AccountNumberFormatLabel;
   }
}