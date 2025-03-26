using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Electing.Elections;

namespace OBiddable.Library.Bidding.Electing;

public interface IElectingRepo
{
    IEnumerable<MarkedElection> GetMarkedElectionsForBid(Bid bid);

    void UpdateElections(IEnumerable<Election> elections);

    MarkedElection GetMarkedElectionForItem(Item item);
}