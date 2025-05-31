
namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
    partial class BidNavigationBoxControl
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
         titleLabel = new Label();
         panel1 = new Panel();
         editButton = new Button();
         panel1.SuspendLayout();
         SuspendLayout();
         // 
         // titleLabel
         // 
         titleLabel.AutoSize = true;
         titleLabel.Font = new Font("Segoe UI Light", 18F);
         titleLabel.Location = new Point(8, 17);
         titleLabel.Margin = new Padding(4, 0, 4, 0);
         titleLabel.Name = "titleLabel";
         titleLabel.Size = new Size(69, 41);
         titleLabel.TabIndex = 0;
         titleLabel.Text = "Title";
         // 
         // panel1
         // 
         panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
         panel1.BackColor = SystemColors.ControlLightLight;
         panel1.Controls.Add(editButton);
         panel1.Controls.Add(titleLabel);
         panel1.Location = new Point(4, 5);
         panel1.Margin = new Padding(4, 5, 4, 5);
         panel1.Name = "panel1";
         panel1.Size = new Size(792, 590);
         panel1.TabIndex = 5;
         // 
         // editButton
         // 
         editButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
         editButton.BackColor = SystemColors.ControlDarkDark;
         editButton.Font = new Font("Segoe UI Light", 18F);
         editButton.ForeColor = Color.White;
         editButton.Location = new Point(686, 6);
         editButton.Margin = new Padding(4, 5, 4, 5);
         editButton.Name = "editButton";
         editButton.Size = new Size(103, 71);
         editButton.TabIndex = 5;
         editButton.Text = "Edit";
         editButton.UseVisualStyleBackColor = false;
         // 
         // BidNavigationBoxControl
         // 
         AutoScaleDimensions = new SizeF(8F, 20F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.FromArgb(240, 240, 240);
         Controls.Add(panel1);
         Margin = new Padding(4, 5, 4, 5);
         Name = "BidNavigationBoxControl";
         Size = new Size(800, 600);
         panel1.ResumeLayout(false);
         panel1.PerformLayout();
         ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label titleLabel;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editButton;
    }
}
