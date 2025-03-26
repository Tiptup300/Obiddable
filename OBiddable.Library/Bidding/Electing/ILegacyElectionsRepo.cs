using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Responding;

namespace OBiddable.Library.Bidding.Electing;

public interface ILegacyElectionsRepo
{
    IEnumerable<ResponseItem> GetElectedResponseItemsByBid(int bidId);
    List<ResponseItem> GetResponseItems_Elected_ByVendorResponse(int vendorResponseId);
    ResponseItem GetElectedResponseItemForItem(int itemId);
    void UpdateResponseItems_ClearElections_ByBid(int bidId);
    void UpdateResponseItems_ClearElections_ByItem(int itemId);
    void UpdateResponseItem_Elect(int itemId, int responseItemId, string reasonElected);

    List<Item> GetItems_Responded_Elected_ByBid(int bidId);
    List<Item> GetItems_Responded_NotElected_ByBid(int bidId);
}