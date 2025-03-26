using Microsoft.EntityFrameworkCore;
using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Purchasing;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Bidding.Responding;

namespace OBiddable.Library.EF;

public class UntrackedDbc : Dbc
{
    public List<Bid> GetUntrackedBids()
    {
        return getUntrackedBidIds()
            .Select(bidId => GetUntrackedBid(bidId))
            .ToList();
    }
    private List<int> getUntrackedBidIds()
    {
        return Bids
            .AsNoTracking()
            .Select(bid => bid.Id)
            .ToList();
    }
    public Bid GetUntrackedBid(int bidId)
    {
        Bid output;

        output = getUntrackedBidBase(bidId);
        output.Items = GetUntrackedItems(bidId);
        output.Requestors = getUntrackedRequestors(bidId);
        output.VendorResponses = getUntrackedVendorResponses(bidId);
        output.SetPurchaseOrders(getUntrackedPurchaseOrders(bidId));

        return output;
    }
    private Bid getUntrackedBidBase(int bidId)
    {
        return Bids
            .AsNoTracking()
            .Where(x => x.Id == bidId)
            .Single();
    }


    public List<Item> GetUntrackedItems(int bidId)
    {
        return getUntrackedItemIds(bidId)
            .Select(itemId => GetUntrackedItem(itemId))
            .ToList();
    }
    
    private List<int> getUntrackedItemIds(int bidId)
    {
        return Items
            .AsNoTracking()
            .Include(item => item.Bid)
            .Where(item => item.Bid.Id == bidId)
            .Select(item => item.Id)
            .ToList();
    }
    public Item GetUntrackedItem(int itemId)
    {
        return Items
            .AsNoTracking()
            .Where(x => x.Id == itemId)
            .Include(x => x.Bid)
            .Single();
    }

    private List<Requestor> getUntrackedRequestors(int bidId)
    {
        return Requestors
            .AsNoTracking()
            .Include(x => x.Bid)
            .Include(x => x.Requests)
            .ThenInclude(x => x.RequestItems)
            .ThenInclude(x => x.Item)
            .Where(x => x.Bid.Id == bidId)
            .ToList();
    }

    private List<VendorResponse> getUntrackedVendorResponses(int bidId)
    {
        return VendorResponses
            .AsNoTracking()
            .Include(x => x.Bid)
            .Include(x => x.ResponseItems)
            .ThenInclude(x => x.Item)
            .Where(x => x.Bid.Id == bidId)
            .ToList();
    }

    private List<PurchaseOrder> getUntrackedPurchaseOrders(int bidId)
    {
        return PurchaseOrders
            .AsNoTracking()
            .Include(x => x.Bid)
            .Include(x => x.LineItems)
            .Where(x => x.Bid.Id == bidId)
            .ToList();
    }
}
