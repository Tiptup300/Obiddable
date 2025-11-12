namespace Obiddable.Win.UI.Bidding.Requesting
{
    partial class RequestorEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestorEditForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.savechangesButton = new System.Windows.Forms.ToolStripButton();
            this.requestorNameLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.buildingNumberLabel = new System.Windows.Forms.Label();
            this.buildingNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buildingNameComboBox = new System.Windows.Forms.ComboBox();
            this.budgetedAmountLabel = new System.Windows.Forms.Label();
            this.budgtedAmountTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(13, 27);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(240, 29);
            this.nameTextBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.savechangesButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 172);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(442, 32);
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
            // requestorNameLabel
            // 
            this.requestorNameLabel.AutoSize = true;
            this.requestorNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestorNameLabel.Location = new System.Drawing.Point(10, 9);
            this.requestorNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.requestorNameLabel.Name = "requestorNameLabel";
            this.requestorNameLabel.Size = new System.Drawing.Size(97, 13);
            this.requestorNameLabel.TabIndex = 5;
            this.requestorNameLabel.Text = "Requestor Name:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(13, 79);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(127, 29);
            this.codeTextBox.TabIndex = 2;
            // 
            // buildingNumberLabel
            // 
            this.buildingNumberLabel.AutoSize = true;
            this.buildingNumberLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingNumberLabel.Location = new System.Drawing.Point(10, 61);
            this.buildingNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildingNumberLabel.Name = "buildingNumberLabel";
            this.buildingNumberLabel.Size = new System.Drawing.Size(100, 13);
            this.buildingNumberLabel.TabIndex = 12;
            this.buildingNumberLabel.Text = "Building Number:";
            // 
            // buildingNameLabel
            // 
            this.buildingNameLabel.AutoSize = true;
            this.buildingNameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingNameLabel.Location = new System.Drawing.Point(145, 61);
            this.buildingNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildingNameLabel.Name = "buildingNameLabel";
            this.buildingNameLabel.Size = new System.Drawing.Size(88, 13);
            this.buildingNameLabel.TabIndex = 18;
            this.buildingNameLabel.Text = "Building Name:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(270, 9);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(60, 13);
            this.passwordLabel.TabIndex = 22;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(270, 27);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(157, 29);
            this.passwordTextBox.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // buildingNameComboBox
            // 
            this.buildingNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.buildingNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.buildingNameComboBox.FormattingEnabled = true;
            this.buildingNameComboBox.Location = new System.Drawing.Point(148, 79);
            this.buildingNameComboBox.Name = "buildingNameComboBox";
            this.buildingNameComboBox.Size = new System.Drawing.Size(279, 29);
            this.buildingNameComboBox.TabIndex = 23;
            // 
            // budgetedAmountLabel
            // 
            this.budgetedAmountLabel.AutoSize = true;
            this.budgetedAmountLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetedAmountLabel.Location = new System.Drawing.Point(10, 113);
            this.budgetedAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.budgetedAmountLabel.Name = "budgetedAmountLabel";
            this.budgetedAmountLabel.Size = new System.Drawing.Size(107, 13);
            this.budgetedAmountLabel.TabIndex = 25;
            this.budgetedAmountLabel.Text = "Budgeted Amount:";
            // 
            // budgtedAmountTextBox
            // 
            this.budgtedAmountTextBox.Location = new System.Drawing.Point(13, 131);
            this.budgtedAmountTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.budgtedAmountTextBox.Name = "budgtedAmountTextBox";
            this.budgtedAmountTextBox.Size = new System.Drawing.Size(414, 29);
            this.budgtedAmountTextBox.TabIndex = 24;
            // 
            // RequestorEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 204);
            this.ControlBox = false;
            this.Controls.Add(this.budgetedAmountLabel);
            this.Controls.Add(this.budgtedAmountTextBox);
            this.Controls.Add(this.buildingNameComboBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.buildingNameLabel);
            this.Controls.Add(this.buildingNumberLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.requestorNameLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.nameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestorEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Requestor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RequestorEditDialog_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton savechangesButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label requestorNameLabel;
        public System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label buildingNumberLabel;
        private System.Windows.Forms.Label buildingNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        public System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox buildingNameComboBox;
        private System.Windows.Forms.Label budgetedAmountLabel;
        public System.Windows.Forms.TextBox budgtedAmountTextBox;
    }
}