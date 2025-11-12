using Obiddable.Library.Bidding.Requesting;

namespace Obiddable.Library.Bidding;
public class Building
{
   public Bid Bid { get; private set; }
   public string Name { get; private set; }
   public IEnumerable<Requestor> Requestors { get; private set; }


   public Building(Bid bid, string name, IEnumerable<Requestor> requestors)
   {
      Bid = bid;
      Name = name;
      Requestors = requestors;
   }

   public decimal GetRequestedQuantity(int itemId)
   {
      decimal output;

      IEnumerable<RequestItem> requestItems;

      requestItems = Requestors
          .SelectMany(x => x.Requests)
          .SelectMany(x => x.RequestItems)
          .Where(x => x.Item.Id == itemId);
      output = requestItems.Sum(x => x.Quantity);

      return output;
   }
}
