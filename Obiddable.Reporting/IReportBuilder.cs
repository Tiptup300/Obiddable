namespace Obiddable.Reporting;

public interface IReportBuilder<TObject>
{
   IReportFile BuildReport(TObject reportObject);
}
