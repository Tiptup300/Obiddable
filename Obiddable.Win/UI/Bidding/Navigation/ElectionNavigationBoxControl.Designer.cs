
namespace Obiddable.Win.UI.Bidding.Navigation
{
    partial class ElectionNavigationBoxControl
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
            this.electedItemsValue = new System.Windows.Forms.Label();
            this.electedItemsLabel = new System.Windows.Forms.Label();
            this.electedTotalPriceValue = new System.Windows.Forms.Label();
            this.unelectedItemsValue = new System.Windows.Forms.Label();
            this.unelectedItemsLabel = new System.Windows.Forms.Label();
            this.electedTotalPriceLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.electedItemsValue);
            this.panel1.Controls.Add(this.electedItemsLabel);
            this.panel1.Controls.Add(this.electedTotalPriceValue);
            this.panel1.Controls.Add(this.unelectedItemsValue);
            this.panel1.Controls.Add(this.electedTotalPriceLabel);
            this.panel1.Controls.Add(this.unelectedItemsLabel);
            this.panel1.Size = new System.Drawing.Size(415, 144);
            this.panel1.Controls.SetChildIndex(this.unelectedItemsLabel, 0);
            this.panel1.Controls.SetChildIndex(this.electedTotalPriceLabel, 0);
            this.panel1.Controls.SetChildIndex(this.unelectedItemsValue, 0);
            this.panel1.Controls.SetChildIndex(this.electedTotalPriceValue, 0);
            this.panel1.Controls.SetChildIndex(this.electedItemsLabel, 0);
            this.panel1.Controls.SetChildIndex(this.electedItemsValue, 0);
            // 
            // electedItemsValue
            // 
            this.electedItemsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.electedItemsValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electedItemsValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.electedItemsValue.Location = new System.Drawing.Point(223, 55);
            this.electedItemsValue.Name = "electedItemsValue";
            this.electedItemsValue.Size = new System.Drawing.Size(187, 25);
            this.electedItemsValue.TabIndex = 14;
            this.electedItemsValue.Text = "value";
            this.electedItemsValue.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // electedItemsLabel
            // 
            this.electedItemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.electedItemsLabel.AutoSize = true;
            this.electedItemsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electedItemsLabel.Location = new System.Drawing.Point(9, 55);
            this.electedItemsLabel.Name = "electedItemsLabel";
            this.electedItemsLabel.Size = new System.Drawing.Size(127, 25);
            this.electedItemsLabel.TabIndex = 12;
            this.electedItemsLabel.Text = "Elected Items:";
            this.electedItemsLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // electedTotalPriceValue
            // 
            this.electedTotalPriceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.electedTotalPriceValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electedTotalPriceValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.electedTotalPriceValue.Location = new System.Drawing.Point(223, 105);
            this.electedTotalPriceValue.Name = "electedTotalPriceValue";
            this.electedTotalPriceValue.Size = new System.Drawing.Size(187, 25);
            this.electedTotalPriceValue.TabIndex = 17;
            this.electedTotalPriceValue.Text = "value";
            this.electedTotalPriceValue.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // unelectedItemsValue
            // 
            this.unelectedItemsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unelectedItemsValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unelectedItemsValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.unelectedItemsValue.Location = new System.Drawing.Point(223, 80);
            this.unelectedItemsValue.Name = "unelectedItemsValue";
            this.unelectedItemsValue.Size = new System.Drawing.Size(187, 25);
            this.unelectedItemsValue.TabIndex = 15;
            this.unelectedItemsValue.Text = "value";
            this.unelectedItemsValue.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // unelectedItemsLabel
            // 
            this.unelectedItemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.unelectedItemsLabel.AutoSize = true;
            this.unelectedItemsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unelectedItemsLabel.Location = new System.Drawing.Point(9, 80);
            this.unelectedItemsLabel.Name = "unelectedItemsLabel";
            this.unelectedItemsLabel.Size = new System.Drawing.Size(151, 25);
            this.unelectedItemsLabel.TabIndex = 13;
            this.unelectedItemsLabel.Text = "Unelected Items:";
            this.unelectedItemsLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // electedTotalPriceLabel
            // 
            this.electedTotalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.electedTotalPriceLabel.AutoSize = true;
            this.electedTotalPriceLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electedTotalPriceLabel.Location = new System.Drawing.Point(9, 105);
            this.electedTotalPriceLabel.Name = "electedTotalPriceLabel";
            this.electedTotalPriceLabel.Size = new System.Drawing.Size(169, 25);
            this.electedTotalPriceLabel.TabIndex = 16;
            this.electedTotalPriceLabel.Text = "Elected Total Price:";
            this.electedTotalPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ElectionNavigationBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ElectionNavigationBoxControl";
            this.Size = new System.Drawing.Size(421, 150);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label electedItemsValue;
        private System.Windows.Forms.Label electedItemsLabel;
        private System.Windows.Forms.Label electedTotalPriceValue;
        private System.Windows.Forms.Label unelectedItemsValue;
        private System.Windows.Forms.Label unelectedItemsLabel;
        private System.Windows.Forms.Label electedTotalPriceLabel;
    }
}
