namespace Ccd.Bidding.Manager.Win.Library.UI;
public interface IActionMenu
{
   void AddSeparator();
   void AddAction(string title, Action action);
   void AddActionSubMenu(string title, Action<IActionMenu> addSubActions);
}
