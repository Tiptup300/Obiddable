namespace OBiddable.Library.Bidding.Electing;

public class LegacyElectionsService
{
    private readonly ILegacyElectionsRepo _legacyElectionsRepo;

    public LegacyElectionsService(ILegacyElectionsRepo legacyElectionsRepo)
    {
        _legacyElectionsRepo = legacyElectionsRepo;
    }


    public bool Check_BidHasInvalidMultipleElections(int bidId)
    {
        return _legacyElectionsRepo.GetElectedResponseItemsByBid(bidId)
            .GroupBy(x => x.Id)
            .Any(x => x.Count() > 1);
    }
}
