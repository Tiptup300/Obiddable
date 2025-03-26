using OBiddable.Library.Bidding.Cataloging;

namespace OBiddable.Library.EF.Bidding.Cataloging;

public class EFCatalogingValidation
{
    public void Validate_AddItem_ToBid(Dbc dbc, Item item, int bidId)
    {
        item.Validate();

        var bid = dbc.Bids.AsNoTracking().Include(x => x.Items).Single(x => x.Id == bidId);
        if (bid.Items.Any(x => x.Code == item.Code))
        {
            throw new DataValidationException("Code is already exists within this bid");
        }
    }
    public void Validate_UpdateItem(Dbc dbc, Item item)
    {
        item.Validate();

        if (item.Bid is null)
        {
            throw new DataValidationException("Item Bid is null");
        }

        var bid = dbc.Bids.AsNoTracking().Include(x => x.Items).Single(x => x.Id == item.Bid.Id);
        if (bid.Items.Where(x => x.Id != item.Id).Any(x => x.Code == item.Code))
        {
            throw new DataValidationException("Code is already exists within this bid");
        }
    }
    public void Validate_DeleteItem(Dbc dbc, int itemId)
    {
        if (dbc.ResponseItems.AsNoTracking().Include(x => x.Item).Any(x => x.Item.Id == itemId))
        {
            throw new DataValidationException("Request Items exist for this item.");
        }

        if (dbc.RequestItems.AsNoTracking().Include(x => x.Item).Any(x => x.Item.Id == itemId))
        {
            throw new DataValidationException("Response Items exist for this item.");
        }
    }
    public void Validate_DeleteItems_ByBid(Dbc dbc, int bidId)
    {
        var items = dbc.Items.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();
        items.ForEach(x => Validate_DeleteItem(dbc, x.Id));
    }
}
