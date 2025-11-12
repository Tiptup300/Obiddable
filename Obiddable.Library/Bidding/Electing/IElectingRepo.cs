using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Electing.Elections;

namespace Obiddable.Library.Bidding.Electing;
public interface IElectingRepo
{
   IEnumerable<MarkedElection> GetMarkedElectionsForBid(Bid bid);

   void UpdateElections(IEnumerable<Election> elections);

   MarkedElection GetMarkedElectionForItem(Item item);
}