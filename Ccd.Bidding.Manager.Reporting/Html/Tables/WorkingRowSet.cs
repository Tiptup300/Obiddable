using System.Text;

namespace Ccd.Bidding.Manager.Reporting.Html.Tables;
public class WorkingRowSet
{
   public List<Row> Rows { get; private set; }
   public int LineHeight { get => Rows.Sum(x => x.LineHeight); }

   public WorkingRowSet()
   {
      Rows = new List<Row>();
   }

   public void AddRow(Row row)
   {
      Rows.Add(row);
   }

   public string GetHtml()
   {
      StringBuilder output;

      output = new StringBuilder();
      Rows.ForEach(x => output.AppendLine(x.Html));

      return output.ToString();
   }
}
