using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing
{
    public static class ConversionExtensions
    {
        public static DbcMarkedElection ToDbObject(this MarkedElection markedElection, Dbc dbc)
        {
            DbcMarkedElection output;
            ResponseItem electedResponseItem;

            electedResponseItem = getTrackedResponseItemById(dbc, markedElection.ElectedResponseItem.Id);
            output = new DbcMarkedElection(markedElection.Id, electedResponseItem, markedElection.Reason);

            return output;
        }

        private static ResponseItem getTrackedResponseItemById(Dbc dbc, int responseItemId)
        {
            return dbc.ResponseItems
                .Where(x => x.Id == responseItemId)
                .Include(x => x.Item)
                .Single();
        }

        public static MarkedElection ToDomainObject(this DbcMarkedElection dbMarkedElection, Dbc dbc)
            => new MarkedElection(dbMarkedElection.ElectedResponseItem, dbMarkedElection.Reason, dbMarkedElection.Id);

        public static IEnumerable<MarkedElection> ToDomainObjects(this IEnumerable<DbcMarkedElection> dbMarkedElections, Dbc dbc)
            => dbMarkedElections.Select(x => x.ToDomainObject(dbc));
    }
}
