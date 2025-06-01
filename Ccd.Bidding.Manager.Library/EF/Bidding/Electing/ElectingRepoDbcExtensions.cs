using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using Microsoft.EntityFrameworkCore;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
public static class ElectingRepoDbcExtensions
{
   public static IEnumerable<MarkedElection> GetMarkedElectionsByBidId(this Dbc dbc, int bidId)
   {
      return dbc.MarkedElections
          .AsNoTracking()
          .Include(x => x.ElectedResponseItem).ThenInclude(x => x.Item).ThenInclude(x => x.Bid)
          .Where(x => x.ElectedResponseItem.Item.Bid.Id == bidId)
          .ToDomainObjects(dbc);
   }
   public static MarkedElection GetMarkedElectionById(this Dbc dbc, int electionId)
   {
      return dbc.MarkedElections
          .AsNoTracking()
          .Include(x => x.ElectedResponseItem).ThenInclude(x => x.Item).ThenInclude(x => x.Bid)
          .Single(x => x.Id == electionId)
          .ToDomainObject(dbc);
   }

   public static void AddMarkedElection(this Dbc dbc, MarkedElection markedElection)
       => dbc.MarkedElections.Add(markedElection.ToDbObject(dbc));

   public static void UpdateMarkedElection(this Dbc dbc, MarkedElection markedElection)
       => dbc.MarkedElections.Update(markedElection.ToDbObject(dbc));
   public static void RemoveMarkedElection(this Dbc dbc, MarkedElection markedElection)
       => dbc.MarkedElections.Remove(markedElection.ToDbObject(dbc));

   public static MarkedElection GetMarkedElectionByItemId(this Dbc dbc, int itemId)
   {
      int electionId;

      electionId = dbc.MarkedElections
          .AsNoTracking()
          .Include(x => x.Item)
          .Single(x => x.Item.Id == itemId)
          .Id;

      return GetMarkedElectionById(dbc, electionId);
   }
}
