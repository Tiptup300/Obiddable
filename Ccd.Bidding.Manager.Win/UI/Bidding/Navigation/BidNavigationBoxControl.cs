using Ccd.Bidding.Manager.Library.Bidding;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Navigation
{
   public partial class BidNavigationBoxControl : UserControl
   {
      protected Bid _bid;
      public event EventHandler EditClicked;

      private bool editEnabled;
      protected bool EditEnabled
      {
         get
         {
            return editEnabled;
         }
         set
         {
            editEnabled = value;
            SetButtonEnabled(value);
         }
      }

      public BidNavigationBoxControl()
      {
         InitializeComponent();
         titleLabel.Text = GetType().Name;
      }

      protected void SetClickEventOnControls(Control control)
      {
         control.Click += new EventHandler(_Click);
         foreach (Control c in control.Controls)
         {
            SetClickEventOnControls(c);
         }
      }

      public void SetBid(Bid bid)
      {
         _bid = bid;
         InitLabels();
      }

      protected void SetTitle(string title)
      {
         titleLabel.Text = title;
      }

      protected void SetButtonColor(Color color)
      {
         editButton.BackColor = color;
      }

      private void SetButtonEnabled(bool buttonEnabled)
      {
         editButton.Enabled = buttonEnabled;
         if (editButton.Enabled == false)
         {
            setButtonDisabledStyle();
         }
      }

      private void setButtonDisabledStyle()
      {
         editButton.BackColor = Color.Gray;
         editButton.ForeColor = Color.DarkGray;
         editButton.Hide();
         panel1.BackColor = Color.LightGray;
      }

      protected virtual void InitLabels() { }

      private void _Click(object sender, EventArgs e) => triggerEdit();
      private void panel1_Click(object sender, EventArgs e) => triggerEdit();

      private void triggerEdit()
      {
         if (editEnabled == false)
         {
            return;
         }
         if (EditClicked is null)
         {
            return;
         }
         EditClicked.Invoke(this, null);
      }
   }
}
