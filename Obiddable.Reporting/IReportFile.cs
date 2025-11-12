namespace Obiddable.Reporting;
public interface IReportFile
{
   string Data { get; set; }
   DateTime TimeStamp { get; set; }
   string FileName { get; set; }
}
