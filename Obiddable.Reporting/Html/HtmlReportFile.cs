namespace Obiddable.Reporting.Html;
public class HtmlReportFile : IReportFile
{
   public string FileName { get; set; }
   public string Data { get; set; }
   public DateTime TimeStamp { get; set; }
}
