using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Test.Repos;

namespace Obiddable.Test.MockBids;
public class TwoItemsMock : IMockBidBuilder
{
   public Bid BuildBid()
   {
      Bid output;

      output = new Bid() { Id = 1, Name = "Mock Bid" };
      output.Items = new List<Item>()
         {
             new Item(1, output, 111,"Things","Widget",false,"Each", 10M, 20M),
             new Item(2, output, 222, "Things", "Doodat", true, "Each", 10M, 20M)
         };

      return output;
   }
}
