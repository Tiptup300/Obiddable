using OBiddable.Library.Bidding.Responding;
using OBiddable.Library.EF.Bidding.Responding;

namespace OBiddable.Library.EF.Bidding.Responding;

public static class ResponseItemsValidations
{
    public static void Validate_AddResponseItem_ToVendorResponse(this Dbc dbc, ResponseItem obj, int vendorResponseId)
    {
        validateResponseItemValues(obj);
    }
    public static void Validate_UpdateResponseItem(this Dbc dbc, ResponseItem obj)
    {
        validateResponseItemValues(obj);

        if (obj.VendorResponse is null)
        {
            throw new DataValidationException("ResponseItem VendorResponse is null");
        }
    }
    public static void Validate_UpdateResponseItems_ClearElections_ByBid(this Dbc dbc, int bidId)
    {
        // no constraints 
    }
    public static void Validate_UpdateResponseItems_ClearElections_ByItem(this Dbc dbc, int itemId)
    {
        // no constraints 
    }
    public static void Validate_DeleteResponseItem(this Dbc dbc, int responseItemId)
    {
        var responseItem = dbc.ResponseItems.AsNoTracking().Include(x => x.Item).Single(x => x.Id == responseItemId);
    }
    public static void Validate_DeleteResponseItems_ByVendorResponse(this Dbc dbc, int vendorResponseId)
    {
        // validate each responseitem in vendor response
        var responseItems = dbc.ResponseItems.AsNoTracking().Include(x => x.VendorResponse).Where(x => x.VendorResponse.Id == vendorResponseId).ToList();
        responseItems.ForEach(x => dbc.Validate_DeleteResponseItem(x.Id));
    }
    public static void Validate_DeleteResponseItems_ByBid(this Dbc dbc, int bidId)
    {
        var responseItems = dbc.ResponseItems.AsNoTracking().Include(x => x.VendorResponse).ThenInclude(x => x.Bid).Where(x => x.VendorResponse.Bid.Id == bidId).ToList();
        responseItems.ForEach(x => dbc.Validate_DeleteResponseItems_ByBid(x.Id));
    }
    private static void validateResponseItemValues(ResponseItem responseItem)
    {
        responseItem.Validate();
    }
}
