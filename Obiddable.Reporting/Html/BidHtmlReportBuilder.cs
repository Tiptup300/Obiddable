using Obiddable.Library.Bidding;

namespace Obiddable.Reporting.Html;
public abstract class BidHtmlReportBuilder : HtmlReportBuilder<Bid>
{

   public override IReportFile BuildReport(Bid bid)
   {
      if (bid == null)
      {
         return null;
      }

      Subtitle = bid.ToString();
      FileNameSubtitle = bid.ToString();

      return base.BuildReport(bid);
   }
}
