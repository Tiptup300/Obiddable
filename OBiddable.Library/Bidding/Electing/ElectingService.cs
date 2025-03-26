using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Electing.Elections;

namespace OBiddable.Library.Bidding.Electing;

public class ElectingService
{
    private readonly IElectingRepo _electionsRepo;
    private readonly ICatalogingRepo _itemsRepo;
    private readonly ElectionsSetFactory _factory;

    public ElectingService(IElectingRepo electionsRepo, ICatalogingRepo itemsRepo, ElectionsSetFactory factory)
    {
        _electionsRepo = electionsRepo;
        _itemsRepo = itemsRepo;
        _factory = factory;
    }

    public ElectionSet GetElectionSetForBid(Bid bid)
    {
        ElectionSet output;
        IEnumerable<Item> bidItems;
        IEnumerable<MarkedElection> markedElections;

        bidItems = _itemsRepo.GetItems(bid.Id);
        markedElections = _electionsRepo.GetMarkedElectionsForBid(bid);
        output = _factory.Build(bidItems, markedElections);

        return output;
    }

    public void SaveElections(IEnumerable<Election> elections) 
        => _electionsRepo.UpdateElections(elections);
}
