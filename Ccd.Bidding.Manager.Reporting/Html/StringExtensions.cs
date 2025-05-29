using System;

namespace Ccd.Bidding.Manager.Reporting.Html
{
   public static class StringExtensions
   {
      public static string CollapseSpaces(this string str)
      {
         return str
             .StripNewLines()
             .StripMultipleSpaces();
      }
      private static string StripMultipleSpaces(this string str)
      {
         string output;

         output = str.Replace("  ", " ");
         if (str.Length != output.Length)
         {
            output = StripMultipleSpaces(output);
         }

         return output;
      }

      private static string StripNewLines(this string str)
      {
         return str.Replace(Environment.NewLine, "");
      }
   }
}
