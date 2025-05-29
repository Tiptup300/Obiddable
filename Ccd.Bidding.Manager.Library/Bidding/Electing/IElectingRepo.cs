using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
   public interface IElectingRepo
   {
      IEnumerable<MarkedElection> GetMarkedElectionsForBid(Bid bid);

      void UpdateElections(IEnumerable<Election> elections);

      MarkedElection GetMarkedElectionForItem(Item item);
   }
}