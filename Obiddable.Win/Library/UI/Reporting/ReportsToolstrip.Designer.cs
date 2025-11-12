
namespace Obiddable.Win.Library.UI.Reporting
{
    partial class ReportsToolstrip
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.reportsDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.titleLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsDropdown,
            this.titleLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(634, 64);
            this.toolStrip.TabIndex = 0;
            // 
            // reportsDropdown
            // 
            this.reportsDropdown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.reportsDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.reportsDropdown.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportsDropdown.Name = "reportsDropdown";
            this.reportsDropdown.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.reportsDropdown.Size = new System.Drawing.Size(146, 61);
            this.reportsDropdown.Text = "Run Reports";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 21.75F);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.titleLabel.Size = new System.Drawing.Size(193, 61);
            this.titleLabel.Text = "toolStripLabel1";
            // 
            // ReportsToolstrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Name = "ReportsToolstrip";
            this.Size = new System.Drawing.Size(634, 64);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton reportsDropdown;
        private System.Windows.Forms.ToolStripLabel titleLabel;
    }
}
