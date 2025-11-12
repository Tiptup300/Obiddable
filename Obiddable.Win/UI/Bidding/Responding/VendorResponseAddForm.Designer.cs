namespace Obiddable.Win.UI.Bidding.Responding
{
    partial class VendorResponseAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorResponseAddForm));
            this.vendorNameTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.savechangesButton = new System.Windows.Forms.ToolStripButton();
            this.vendorNameLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // vendorNameTextBox
            // 
            this.vendorNameTextBox.Location = new System.Drawing.Point(13, 27);
            this.vendorNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vendorNameTextBox.Name = "vendorNameTextBox";
            this.vendorNameTextBox.Size = new System.Drawing.Size(488, 29);
            this.vendorNameTextBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.savechangesButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(514, 32);
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
            // vendorNameLabel
            // 
            this.vendorNameLabel.AutoSize = true;
            this.vendorNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorNameLabel.Location = new System.Drawing.Point(10, 9);
            this.vendorNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vendorNameLabel.Name = "vendorNameLabel";
            this.vendorNameLabel.Size = new System.Drawing.Size(81, 13);
            this.vendorNameLabel.TabIndex = 5;
            this.vendorNameLabel.Text = "Vendor Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // VendorResponseAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 112);
            this.ControlBox = false;
            this.Controls.Add(this.vendorNameLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.vendorNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorResponseAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Vendor Reponse";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VendorResponseAddForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox vendorNameTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton savechangesButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label vendorNameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}