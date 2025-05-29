using Ccd.Bidding.Manager.Win.Library;
using Ccd.Bidding.Manager.Win.Library.Operations.UI;
using Ccd.Bidding.Manager.Win.Library.UI;
using System;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI
{
   public partial class MaintenanceScreen : HostScreen
   {
      public IHostForm _hostForm;
      public ListViewItem SelectedItem;
      private int LastSelectedItemIndex;
      private ReportsFolderShower _reportsFolderShower = new ReportsFolderShower();
      private ExportsFolderShower _exportsFolderShower = new ExportsFolderShower();
      private HelpScreenShower _helpScreenShower = new HelpScreenShower(UserConfiguration.Instance, new UrlOpener());
      private readonly ToolStripDropDownActionMenu _actionMenu;
      public int SelectedItemTag
      {
         get
         {
            if (SelectedItem != null)
               return (int)SelectedItem.Tag;
            else
               return -1;
         }
      }

      public MaintenanceScreen(IHostForm hostForm)
      {
         InitializeComponent();

         _actionMenu = new ToolStripDropDownActionMenu(actionsMenu);

         configButton.Enabled = false;
         configButton.Visible = false;

         addButton.Click += AddButton_Click;
         editButton.Click += EditButton_Click;
         deleteButton.Click += DeleteButton_Click;
         refreshButton.Click += RefreshButton_Click;
         listViewMain.DoubleClick += ListViewMain_DoubleClick;
         _hostForm = hostForm;
      }

      #region INIT
      protected virtual void InitializeTitles() { }
      protected virtual void InitializeActionsMenu(IActionMenu actionMenu) { }
      protected void AddAction(string title, Action action)
      {
         var actionMenuItem = new ToolStripMenuItem() { Text = title };
         actionMenuItem.Click += delegate (Object sender, EventArgs eventArgs)
         {
            action.Invoke();
         };
         actionsMenu.DropDownItems.Add(actionMenuItem);
      }

      protected void AddActionSubMenu(string title, Action<IActionMenu> addSubActions)
      {
         var actionMenuItem = new ToolStripMenuItem() { Text = title };
         addSubActions.Invoke(new ToolStripDropDownActionMenu(actionMenuItem));
         actionsMenu.DropDownItems.Add(actionMenuItem);
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         InitializeTitles();
         InitializeActionsMenu(_actionMenu);
         InitializeColumns();
         LoadColumnWidths();
         RefreshList();
      }
      #endregion

      #region FORM OPERATIONS
      public override void Refresh()
      {
         base.Refresh();
         RefreshList();
         //listViewMain.Focus();
      }
      private void backButton_Click(object sender, EventArgs e)
      {
         _hostForm.GoBack();
      }
      #endregion

      #region LIST
      protected virtual void InitializeColumns() { }
      private void LoadColumnWidths()
      {
         _hostForm.HeaderWidthManager.LoadWidthsIntoColumns(listViewMain, Text);
         this.listViewMain.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.listViewMain_ColumnWidthChanged);
      }
      protected virtual void RefreshList() { }
      #endregion

      #region LIST OPERATIONS
      private void listViewMain_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (listViewMain.SelectedItems.Count > 0)
         {
            SelectedItem = listViewMain.SelectedItems[0];
            LastSelectedItemIndex = SelectedItem.Index;
         }
         else
         {
            SelectedItem = null;
         }

      }
      private void listViewMain_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
      {
         var col = listViewMain.Columns[e.ColumnIndex];

         _hostForm.HeaderWidthManager.SetHeaderWidth(this.Text, col.Index, col.Width);

      }

      public void ReselectItem()
      {
         if (listViewMain.Items.Count > LastSelectedItemIndex)
         {
            listViewMain.Items[LastSelectedItemIndex].Selected = true;
            listViewMain.Items[LastSelectedItemIndex].EnsureVisible();
         }
         else if (listViewMain.Items.Count > 0)
         {
            listViewMain.Items[listViewMain.Items.Count - 1].Selected = true;
            listViewMain.Items[LastSelectedItemIndex].EnsureVisible();
         }
         listViewMain.Focus();
      }
      private void ListViewMain_DoubleClick(object sender, System.EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }

         ListViewDoubleClicked();
      }
      #endregion

      #region CLICK EVENTS
      protected virtual void AddButtonClicked() { }
      protected virtual void EditButtonClicked() { }
      protected virtual void DeleteButtonClicked() { }
      protected virtual void ListViewDoubleClicked() { }
      #endregion

      #region BUTTONS
      private void AddButton_Click(object sender, System.EventArgs e) => AddButtonClicked();
      private void EditButton_Click(object sender, System.EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }

         EditButtonClicked();
      }
      private void DeleteButton_Click(object sender, System.EventArgs e)
      {
         if (SelectedItem == null)
         {
            return;
         }

         DeleteButtonClicked();
      }
      private void RefreshButton_Click(object sender, System.EventArgs e) => RefreshList();
      #endregion

      #region KEY INPUTS
      private void listViewMain_KeyDown(object sender, KeyEventArgs e)
      {
         CheckForMenuKeys(e);
         CheckForDeleteKey(e);
         CheckForEditKey(e);
         CheckForEnterKey(e);
         CheckForAddKey(e);
         CheckForListNavigationKeys(e);
         CheckForExitKey(e);
      }
      private void CheckForMenuKeys(KeyEventArgs e)
      {

         if (e.KeyCode == Keys.F2 && actionsMenu.Enabled)
         {
            actionsMenu.ShowDropDown();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForDeleteKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
         {
            DeleteButtonClicked();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForEditKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.E)
         {
            EditButtonClicked();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForEnterKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            ListViewDoubleClicked();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForAddKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.I || e.KeyCode == Keys.A)
         {
            AddButtonClicked();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForListNavigationKeys(KeyEventArgs e)
      {
         if (listViewMain.SelectedItems.Count < 1)
         {
            return;
         }

         int selectedIndex = listViewMain.SelectedItems[0].Index;
         if (e.KeyCode == Keys.Down && selectedIndex < listViewMain.Items.Count - 1)
         {

            listViewMain.Items[selectedIndex++].Selected = false;
            listViewMain.Items[selectedIndex].Selected = true;
            listViewMain.Items[selectedIndex].EnsureVisible();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }

         if (e.KeyCode == Keys.Up && selectedIndex > 0)
         {

            listViewMain.Items[selectedIndex--].Selected = false;
            listViewMain.Items[selectedIndex].Selected = true;
            listViewMain.Items[selectedIndex].EnsureVisible();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      private void CheckForExitKey(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Escape)
         {
            _hostForm.GoBack();

            e.Handled = true;
            e.SuppressKeyPress = true;
         }
      }
      #endregion


      private void actionsMenu_VisibleChanged(object sender, EventArgs e)
      {
         actionsMenuSeparator.Visible = actionsMenu.Visible;
      }

      private void reportsButton_Click(object sender, EventArgs e) => _reportsFolderShower.Run();

      private void exportsButton_Click(object sender, EventArgs e) => _exportsFolderShower.Run();

      private void helpButton_Click(object sender, EventArgs e) => _helpScreenShower.Run();
   }
}
