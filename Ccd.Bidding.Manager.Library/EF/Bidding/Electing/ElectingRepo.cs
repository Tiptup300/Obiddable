using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing
{
   public class ElectingRepo : IElectingRepo
   {
      public IEnumerable<MarkedElection> GetMarkedElectionsForBid(Bid bid)
      {
         IEnumerable<MarkedElection> output;

         using (var dbc = new Dbc())
         {
            output = dbc.GetMarkedElectionsByBidId(bid.Id).ToArray();
         }

         return output;
      }


      public void UpdateElections(IEnumerable<Election> elections)
      {
         using (var dbc = new Dbc())
         {
            addNewMarkedElections(dbc, elections);
            updateOldMarkedElections(dbc, elections);
            removeOldUnmarkedElections(dbc, elections);

            dbc.SaveChanges();
         }
      }

      private void addNewMarkedElections(Dbc dbc, IEnumerable<Election> elections)
      {
         IEnumerable<MarkedElection> newMarkedElections;

         newMarkedElections = getNewMarkedElections(elections);
         newMarkedElections.ToList().ForEach(newMarkedElection =>
         {
            dbc.AddMarkedElection(newMarkedElection);
         });
      }
      private static IEnumerable<MarkedElection> getNewMarkedElections(IEnumerable<Election> elections)
          => elections.OfType<MarkedElection>().Where(x => x.IsNew());

      private void updateOldMarkedElections(Dbc dbc, IEnumerable<Election> elections)
      {
         IEnumerable<MarkedElection> oldMarkedElections;

         oldMarkedElections = getOldMarkedElections(elections);
         oldMarkedElections.ToList().ForEach(oldMarkedElection =>
         {
            dbc.UpdateMarkedElection(oldMarkedElection);
         });
      }
      private static IEnumerable<MarkedElection> getOldMarkedElections(IEnumerable<Election> elections)
          => elections.OfType<MarkedElection>().Where(x => x.IsOld());

      private void removeOldUnmarkedElections(Dbc dbc, IEnumerable<Election> elections)
      {
         IEnumerable<UnmarkedElection> oldUnmarkedElections;
         MarkedElection markedElection;

         oldUnmarkedElections = getOldUnmarkedElections(elections);
         oldUnmarkedElections.ToList().ForEach(x =>
         {
            markedElection = dbc.GetMarkedElectionById(x.Id.Value);
            dbc.RemoveMarkedElection(markedElection);
         });
      }
      private static IEnumerable<UnmarkedElection> getOldUnmarkedElections(IEnumerable<Election> elections)
          => elections.OfType<UnmarkedElection>().Where(x => x.IsOld());


      public MarkedElection GetMarkedElectionForItem(Item item)
      {
         MarkedElection output;

         using (var dbc = new Dbc())
         {
            output = dbc.GetMarkedElectionByItemId(item.Id);
         }

         return output;
      }
   }
}
