using Microsoft.EntityFrameworkCore;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.EF.Bidding.Requesting.RequestItems;

internal class RequestItemsValidation
{
    public void Validate_AddRequestItem_ToRequest(Dbc dbc, RequestItem obj, int requestId)
    {
        validateRequestItemValues(obj);

        var request = dbc.Requests.AsNoTracking().AsNoTracking().Include(x => x.RequestItems).ThenInclude(x => x.Item).Single(X => X.Id == requestId);
        if (request.RequestItems.Any(x => x.Item.Id == obj.Item.Id))
        {
            throw new DataValidationException("RequestItem for Item already added to request");
        }
    }
    public void Validate_UpdateRequestItem(Dbc dbc, RequestItem obj)
    {
        validateRequestItemValues(obj);

        if (obj.Request is null)
        {
            throw new DataValidationException("RequestItem Request cannot be null");
        }

        var request = dbc.Requests.AsNoTracking().Include(x => x.RequestItems).ThenInclude(x => x.Item).Single(X => X.Id == obj.Request.Id);
        if (request.RequestItems.Where(x => x.Id != obj.Id).Any(x => x.Item.Id == obj.Item.Id))
        {
            throw new DataValidationException("RequestItem Item already added to request");
        }
    }
    public void Validate_DeleteRequestItem(Dbc dbc, int requestItemId)
    {
        // program change: 02/05/21 -- previous change, you are now able to delete a request for a responded item
        //check if this is the last request item for a responded item
        //var obj = dbc.RequestItems.AsNoTracking().Include(x => x.Item).Single(x => x.Id == requestItemId);
        //var responseItemsForItem = dbc.ResponseItems.AsNoTracking().Include(x => x.Item).Where(x => x.Item.Id == obj.Item.Id).ToList();
        //var requestItemsForItem = dbc.RequestItems.AsNoTracking().Include(x => x.Item).Where(x => x.Item.Id == obj.Item.Id).ToList();
        //if(requestItemsForItem.Count == 1 && responseItemsForItem.Count > 0)
        //{
        //    throw new DataValidationException("RequestItem is last request item for a responded item.");
        //}


    }
    public void Validate_DeleteRequestItems_ByRequest(Dbc dbc, int requestId)
    {
        var requestItems = dbc.RequestItems.AsNoTracking().Include(x => x.Request).Where(x => x.Request.Id == requestId).ToList();
        requestItems.ForEach(x => Validate_DeleteRequestItem(dbc, x.Id));
    }
    public void Validate_DeleteRequestItems_ByBid(Dbc dbc, int bidId)
    {
        var requestItems = dbc.RequestItems.AsNoTracking().Include(x => x.Request).ThenInclude(x => x.Requestor).ThenInclude(x => x.Bid).Where(x => x.Request.Requestor.Bid.Id == bidId).ToList();
        requestItems.ForEach(x => Validate_DeleteRequestItem(dbc, x.Id));
    }
    private void validateRequestItemValues(RequestItem requestItem)
    {
        requestItem.Validate();
    }
}
