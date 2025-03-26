using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Electing;
using OBiddable.Library.Bidding.Electing.Elections;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.Staging.ItemElections;

public class ItemElectionService
{
    private readonly IRequestingRepo _requestingRepo;
    private readonly ICatalogingRepo _catalogingRepo;
    private readonly IElectingRepo _electingRepo;

    public ItemElectionService(IRequestingRepo requestingRepo, ICatalogingRepo catalogingRepo, IElectingRepo electingRepo)
    {
        _requestingRepo = requestingRepo;
        _catalogingRepo = catalogingRepo;
        _electingRepo = electingRepo;
    }

    public ItemElection GetItemElectionForItem(int itemId)
    {
        ItemElection output;

        Item item = _catalogingRepo.GetItem(itemId);
        output = buildItemElectionFromItem(item);

        return output;

    }

    public IEnumerable<ItemElection> GetItemElectionsForBid(int bidId)
    {
        IEnumerable<ItemElection> output;
        IEnumerable<Item> bidItems;

        bidItems = _catalogingRepo.GetItems(bidId);
        output = bidItems.Select(item => buildItemElectionFromItem(item));

        return output;
    }

    private ItemElection buildItemElectionFromItem(Item item)
    {
        ItemElection output;
        MarkedElection election;

        election = _electingRepo.GetMarkedElectionForItem(item);
        output = new ItemElection(item, election);

        return output;
    }
}
