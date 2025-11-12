namespace Obiddable.Library;
public static class StringExtensions
{
   public static string Join(this IEnumerable<string> values, string separator)
   {
      return String.Join(separator, values);
   }

   public static string JoinAsLines(this IEnumerable<string> values)
   {
      return values.Join(Environment.NewLine);
   }
}
