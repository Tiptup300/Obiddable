namespace Ccd.Bidding.Manager.Reporting
{
   public interface IReportBuilder<TObject>
   {
      IReportFile BuildReport(TObject reportObject);
   }
}
