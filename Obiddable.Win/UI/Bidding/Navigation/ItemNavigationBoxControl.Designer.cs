
namespace Obiddable.Win.UI.Bidding.Navigation
{
    partial class ItemNavigationBoxControl
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
            this.categoriesCount = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.itemsCount = new System.Windows.Forms.Label();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.categoriesCount);
            this.panel1.Controls.Add(this.itemsLabel);
            this.panel1.Controls.Add(this.itemsCount);
            this.panel1.Controls.Add(this.categoriesLabel);
            this.panel1.Size = new System.Drawing.Size(415, 121);
            this.panel1.Controls.SetChildIndex(this.categoriesLabel, 0);
            this.panel1.Controls.SetChildIndex(this.itemsCount, 0);
            this.panel1.Controls.SetChildIndex(this.itemsLabel, 0);
            this.panel1.Controls.SetChildIndex(this.categoriesCount, 0);
            // 
            // categoriesCount
            // 
            this.categoriesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.categoriesCount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.categoriesCount.Location = new System.Drawing.Point(186, 79);
            this.categoriesCount.Name = "categoriesCount";
            this.categoriesCount.Size = new System.Drawing.Size(220, 25);
            this.categoriesCount.TabIndex = 9;
            this.categoriesCount.Text = "value";
            this.categoriesCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // itemsLabel
            // 
            this.itemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsLabel.Location = new System.Drawing.Point(8, 54);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(61, 25);
            this.itemsLabel.TabIndex = 6;
            this.itemsLabel.Text = "Items:";
            this.itemsLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // itemsCount
            // 
            this.itemsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsCount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemsCount.Location = new System.Drawing.Point(186, 54);
            this.itemsCount.Name = "itemsCount";
            this.itemsCount.Size = new System.Drawing.Size(220, 25);
            this.itemsCount.TabIndex = 8;
            this.itemsCount.Text = "value";
            this.itemsCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesLabel.Location = new System.Drawing.Point(8, 79);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(106, 25);
            this.categoriesLabel.TabIndex = 7;
            this.categoriesLabel.Text = "Categories:";
            this.categoriesLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ItemNavigationBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ItemNavigationBoxControl";
            this.Size = new System.Drawing.Size(421, 127);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label categoriesCount;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Label itemsCount;
        private System.Windows.Forms.Label categoriesLabel;
    }
}
