using Obiddable.Library.Bidding;

namespace Obiddable.Win.UI.Bidding.Navigation;
public partial class BidNavigationBoxControl : UserControl
{
   protected Bid _bid;
   public event EventHandler EditClicked;

   private bool _editEnabled;
   protected bool EditEnabled
   {
      get
      {
         return _editEnabled;
      }
      set
      {
         _editEnabled = value;
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
         SetButtonDisabledStyle();
      }
   }

   private void SetButtonDisabledStyle()
   {
      editButton.BackColor = Color.Gray;
      editButton.ForeColor = Color.DarkGray;
      editButton.Hide();
      panel1.BackColor = Color.LightGray;
   }

   protected virtual void InitLabels() { }

   private void _Click(object sender, EventArgs e) => TriggerEdit();
   private void Panel1_Click(object sender, EventArgs e) => TriggerEdit();

   private void TriggerEdit()
   {
      if (_editEnabled == false)
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
