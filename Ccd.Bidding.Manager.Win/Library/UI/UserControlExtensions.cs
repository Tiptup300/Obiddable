namespace Ccd.Bidding.Manager.Win.Library.UI;
public static class UserControlExtensions
{
   public static IEnumerable<Control> GetAllNestedControls(this Control root)
   {
      Stack<Control> stack;
      Control control;

      stack = new Stack<Control>();
      stack.Push(root);
      do
      {
         control = stack.Pop();

         foreach (Control child in control.Controls)
         {
            yield return child;
            stack.Push(child);
         }
      }
      while (stack.Count > 0);
   }
}
