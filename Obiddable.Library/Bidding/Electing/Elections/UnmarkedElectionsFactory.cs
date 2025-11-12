using Obiddable.Library.Bidding.Cataloging;

namespace Obiddable.Library.Bidding.Electing.Elections;
public class UnmarkedElectionsFactory
{
   public IEnumerable<UnmarkedElection> BuildUnmarkedElectionsForItems(IEnumerable<Item> bidItems, IEnumerable<MarkedElection> markedElections)
   {
      IEnumerable<UnmarkedElection> output;
      IEnumerable<Item> unelectedItems;

      unelectedItems = getUnelectedItems(bidItems, markedElections);
      output = buildUnmarkedElectionsForItems(unelectedItems, markedElections);

      return output;
   }

   private IEnumerable<Item> getUnelectedItems(IEnumerable<Item> items, IEnumerable<MarkedElection> markedElections)
       => items.Where(itemIsNotElected(markedElections));

   private static Func<Item, bool> itemIsNotElected(IEnumerable<MarkedElection> markedElections)
       => item => markedElections.Any(election => election.Item.Id == item.Id) == false;

   private IEnumerable<UnmarkedElection> buildUnmarkedElectionsForItems(IEnumerable<Item> unelectedItems, IEnumerable<MarkedElection> markedElections)
   {
      List<UnmarkedElection> output;
      UnmarkedElection unmarkedElection;

      output = new List<UnmarkedElection>();
      foreach (Item unelectedItem in unelectedItems)
      {
         unmarkedElection = new UnmarkedElection(unelectedItem);
         output.Add(unmarkedElection);
      }

      return output;
   }
}
