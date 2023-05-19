using System.Collections.Generic;

namespace Ccd.Bidding.Manager.Library.Bidding.Cataloging
{
    public interface ICatalogingRepo
    {
        void AddItem(Item item, int bidId);
        Item GetItem(int itemId);
        IEnumerable<Item> GetItems(int bidId);
        void UpdateItem(Item item);
        void DeleteItem(int itemId);


    }
}