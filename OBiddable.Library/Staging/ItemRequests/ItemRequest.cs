using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.Staging.ItemRequests;

public class ItemRequest
{

    private Item _item;
    public Item Item
    {
        get => _item;
        private set
        {
            if (value is null)
            {
                throw new ArgumentException("Item cannot be null.");
            }
            _item = value;
        }
    }


    private IEnumerable<RequestItem> _requestItems;
    public IEnumerable<RequestItem> RequestItems
    {
        get => _requestItems;
        private set
        {
            if (value is null)
            {
                throw new ArgumentException("RequestItems Cannot Be Null");
            }
            if (value.Count() == 0)
            {
                throw new ArgumentException("RequestItems Cannot be empty");
            }
            if (isAnyRequestedItemsNotItem(value))
            {
                throw new ArgumentException("RequestItems Item Id Must Match That Of The Item");
            }
            _requestItems = value;
        }
    }
    private bool isAnyRequestedItemsNotItem(IEnumerable<RequestItem> requestItems)
        => requestItems.Any(x => x.Item.Id != Item.Id);


    public int ItemId => Item.Id;
    public int Quantity => RequestItems.Sum(x => x.Quantity);

    public ItemRequest(Item item, IEnumerable<RequestItem> requestItems)
    {
        Item = item;
        RequestItems = requestItems;
    }

}
