namespace Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging
{
    partial class MassUpdateItemPricesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassUpdateItemPricesForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.runMassUpdateButton = new System.Windows.Forms.ToolStripButton();
            this.itemPriceMultiplierLabel = new System.Windows.Forms.Label();
            this.itemPriceMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelButton,
            this.runMassUpdateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 67);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(335, 32);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cancelButton
            // 
            this.cancelButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(57, 29);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // runMassUpdateButton
            // 
            this.runMassUpdateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.runMassUpdateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.runMassUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("runMassUpdateButton.Image")));
            this.runMassUpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runMassUpdateButton.Name = "runMassUpdateButton";
            this.runMassUpdateButton.Padding = new System.Windows.Forms.Padding(5);
            this.runMassUpdateButton.Size = new System.Drawing.Size(113, 29);
            this.runMassUpdateButton.Text = "Run Mass Update";
            this.runMassUpdateButton.Click += new System.EventHandler(this.runMassUpdateButton_Click);
            // 
            // itemPriceMultiplierLabel
            // 
            this.itemPriceMultiplierLabel.AutoSize = true;
            this.itemPriceMultiplierLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.itemPriceMultiplierLabel.Location = new System.Drawing.Point(13, 9);
            this.itemPriceMultiplierLabel.Name = "itemPriceMultiplierLabel";
            this.itemPriceMultiplierLabel.Size = new System.Drawing.Size(115, 13);
            this.itemPriceMultiplierLabel.TabIndex = 6;
            this.itemPriceMultiplierLabel.Text = "Item Price Multiplier:";
            // 
            // itemPriceMultiplierTextBox
            // 
            this.itemPriceMultiplierTextBox.Location = new System.Drawing.Point(16, 25);
            this.itemPriceMultiplierTextBox.Name = "itemPriceMultiplierTextBox";
            this.itemPriceMultiplierTextBox.Size = new System.Drawing.Size(307, 29);
            this.itemPriceMultiplierTextBox.TabIndex = 7;
            this.itemPriceMultiplierTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.itemPriceMultiplierTextBox.TextChanged += new System.EventHandler(this.itemPriceMultiplierTextBox_TextChanged);
            // 
            // MassUpdateItemPricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 99);
            this.ControlBox = false;
            this.Controls.Add(this.itemPriceMultiplierTextBox);
            this.Controls.Add(this.itemPriceMultiplierLabel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MassUpdateItemPricesForm";
            this.Text = "Item Price Mass Update";
            this.Load += new System.EventHandler(this.MassUpdateItemPricesForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.ToolStripButton runMassUpdateButton;
        private System.Windows.Forms.Label itemPriceMultiplierLabel;
        private System.Windows.Forms.TextBox itemPriceMultiplierTextBox;
    }
}