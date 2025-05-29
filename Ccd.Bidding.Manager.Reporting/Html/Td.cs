namespace Ccd.Bidding.Manager.Reporting.Html
{
   public class Td
   {
      private readonly string _body;
      private readonly string _classes;
      private readonly int? _columnSpan;
      private readonly int? _rowSpan;

      public Td(string body, string classes = null, int? columnSpan = null, int? rowSpan = null)
      {
         _body = body;
         _classes = classes;
         _columnSpan = columnSpan;
         _rowSpan = rowSpan;
      }

      public string Terminate()
      {
         return ($"<td" +
             $"{(_classes is null ? "" : $" class='{_classes}'")}" +
             $"{(_columnSpan is null ? "" : $" colspan='{_columnSpan}'")}" +
             $"{(_rowSpan is null ? "" : $" rowspan='{_rowSpan}'")}" +
             $">{_body}</td>").CollapseSpaces();
      }
   }
}
