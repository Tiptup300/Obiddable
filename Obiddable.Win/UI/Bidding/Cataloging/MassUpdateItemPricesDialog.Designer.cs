namespace Obiddable.Win.UI.Bidding.Cataloging
{
    partial class MassUpdateItemPricesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassUpdateItemPricesDialog));
         toolStrip1 = new ToolStrip();
         cancelButton = new ToolStripButton();
         runMassUpdateButton = new ToolStripButton();
         itemPriceMultiplierLabel = new Label();
         itemPriceMultiplierTextBox = new TextBox();
         label1 = new Label();
         toolStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // toolStrip1
         // 
         toolStrip1.Dock = DockStyle.Bottom;
         toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
         toolStrip1.ImageScalingSize = new Size(20, 20);
         toolStrip1.Items.AddRange(new ToolStripItem[] { cancelButton, runMassUpdateButton });
         toolStrip1.Location = new Point(0, 130);
         toolStrip1.Name = "toolStrip1";
         toolStrip1.Padding = new Padding(0, 0, 3, 0);
         toolStrip1.Size = new Size(346, 32);
         toolStrip1.TabIndex = 5;
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
         cancelButton.Click += CancelButton_Click;
         // 
         // runMassUpdateButton
         // 
         runMassUpdateButton.Alignment = ToolStripItemAlignment.Right;
         runMassUpdateButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
         runMassUpdateButton.Image = (Image)resources.GetObject("runMassUpdateButton.Image");
         runMassUpdateButton.ImageTransparentColor = Color.Magenta;
         runMassUpdateButton.Name = "runMassUpdateButton";
         runMassUpdateButton.Padding = new Padding(5);
         runMassUpdateButton.Size = new Size(113, 29);
         runMassUpdateButton.Text = "Run Mass Update";
         runMassUpdateButton.Click += RunMassUpdateButton_Click;
         // 
         // itemPriceMultiplierLabel
         // 
         itemPriceMultiplierLabel.AutoSize = true;
         itemPriceMultiplierLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
         itemPriceMultiplierLabel.Location = new Point(12, 9);
         itemPriceMultiplierLabel.Name = "itemPriceMultiplierLabel";
         itemPriceMultiplierLabel.Size = new Size(115, 13);
         itemPriceMultiplierLabel.TabIndex = 6;
         itemPriceMultiplierLabel.Text = "Item Price Multiplier:";
         // 
         // itemPriceMultiplierTextBox
         // 
         itemPriceMultiplierTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         itemPriceMultiplierTextBox.Location = new Point(12, 31);
         itemPriceMultiplierTextBox.Name = "itemPriceMultiplierTextBox";
         itemPriceMultiplierTextBox.Size = new Size(322, 29);
         itemPriceMultiplierTextBox.TabIndex = 7;
         itemPriceMultiplierTextBox.TextAlign = HorizontalAlignment.Right;
         // 
         // label1
         // 
         label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         label1.Location = new Point(12, 68);
         label1.Name = "label1";
         label1.Size = new Size(322, 62);
         label1.TabIndex = 8;
         label1.Text = "This will set all estimated prices to the last ordered price multiplied by the multiplier.";
         // 
         // MassUpdateItemPricesForm
         // 
         AutoScaleDimensions = new SizeF(9F, 21F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(346, 162);
         ControlBox = false;
         Controls.Add(label1);
         Controls.Add(itemPriceMultiplierTextBox);
         Controls.Add(itemPriceMultiplierLabel);
         Controls.Add(toolStrip1);
         Font = new Font("Segoe UI", 12F);
         FormBorderStyle = FormBorderStyle.FixedDialog;
         Margin = new Padding(4, 5, 4, 5);
         Name = "MassUpdateItemPricesForm";
         Text = "Item Price Mass Update";
         Load += MassUpdateItemPricesForm_Load;
         toolStrip1.ResumeLayout(false);
         toolStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.ToolStripButton runMassUpdateButton;
        private System.Windows.Forms.Label itemPriceMultiplierLabel;
        private System.Windows.Forms.TextBox itemPriceMultiplierTextBox;
      private Label label1;
   }
}