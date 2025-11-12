using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.EF.Bidding.Cataloging;
using Obiddable.Reporting.Html;
using System.Text;

namespace Obiddable.Reporting.Bidding.Cataloging;
public class ItemsListReportBuilder : BidHtmlReportBuilder
{
   private readonly ICatalogingRepo _catalogingRepo = new EFCatalogingRepo();
   protected override string Title => "Bid Items List Report";
   protected override string StyleName => "Reports.BidRoll.css";
   protected override PrintOrientation PrintOrientation => PrintOrientation.Landscape;

   public ItemsListReportBuilder()
   {
   }

   public override string GenerateTableData(Bid bid)
   {
      StringBuilder t = new StringBuilder();
      List<Item> items = _catalogingRepo.GetItems(bid.Id)
          .ToList();
      GenerateItemsTable(t, items);
      return t.ToString();
   }

   private void GenerateItemsTable(StringBuilder t, List<Item> items)
   {
      t.AppendLine($"<table>");
      t.AppendLine($" <thead>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th colspan='6'>Items</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($"     <tr>");
      t.AppendLine($"         <th class='itemCode'>Code</th>");
      t.AppendLine($"         <th class='itemCategory'>Category</th>");
      t.AppendLine($"         <th class='itemDescription'>Description</th>");
      t.AppendLine($"         <th class='itemLastOrderPrice'>Last Order Price</th>");
      t.AppendLine($"         <th class='itemEstimatedPrice'>Estimated Price</th>");
      t.AppendLine($"         <th class='itemSubstituable'>Sub<br />-ible</th>");
      t.AppendLine($"         <th class='itemUnit'>Unit</th>");
      t.AppendLine($"     </tr>");
      t.AppendLine($" </thead>");


      t.AppendLine($" <tbody>");
      foreach (Item i in items.OrderBy(x => x.Code).ToList())
      {
         t.AppendLine($"     <tr>");
         t.AppendLine($"         <td class='itemCode'><span class='clip'>{i.FormattedCode}</span></td>");
         t.AppendLine($"         <td class='itemCategory'><span class='clip'>{i.Category}</span></td>");
         t.AppendLine($"         <td class='itemDescription'><span class='clip'>{i.Description}</span></td>");
         t.AppendLine($"         <td class='itemLastOrderPrice'>{i.Last_Order_Price}</td>");
         t.AppendLine($"         <td class='itemEstimatedPrice'>{i.Price}</td>");
         t.AppendLine($"         <td class='itemSubstituable'>{i.Substitutable}</td>");
         t.AppendLine($"         <td class='itemUnit'><span class='clip'>{i.Unit}</span></td>");
         t.AppendLine($"     </tr>");
      }
      t.AppendLine($" </tbody>");
      t.AppendLine($"</table>");
   }
}
