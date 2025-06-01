namespace Ccd.Bidding.Manager.Win.Library.UI;
public class ToolStripDropDownActionMenu : IActionMenu
{
   private readonly ToolStripDropDownItem _toolStripMenuItem;

   public ToolStripDropDownActionMenu(ToolStripDropDownItem toolStripMenuItem)
   {
      _toolStripMenuItem = toolStripMenuItem;
   }
   public void AddSeparator()
   {
      _toolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
   }

   public void AddAction(string title, Action action)
   {
      var actionMenuItem = new ToolStripMenuItem() { Text = title };
      actionMenuItem.Click += delegate (Object sender, EventArgs eventArgs)
      {
         action.Invoke();
      };
      _toolStripMenuItem.DropDownItems.Add(actionMenuItem);
   }
   public void AddActionSubMenu(string title, Action<IActionMenu> addSubActions)
   {
      var subMenu = new ToolStripMenuItem() { Text = title };
      addSubActions.Invoke(new ToolStripDropDownActionMenu(subMenu));
      _toolStripMenuItem.DropDownItems.Add(subMenu);
   }

}
