using OBiddable.Library.Bidding.Cataloging;

namespace OBiddable.Library.EF.Bidding.Cataloging;

public class EFCatalogingOperations : ICatalogingOperations
{
    public static ICatalogingOperations Instance = new EFCatalogingOperations();

    public void UpdateItems_MassPriceChange_ByBid(int bidId, decimal multiplier)
    {
        using (var dbc = new Dbc())
        {
            if (multiplier < 0)
            {
                throw new Exception("multiplier cannot be negative");
            }

            var items = dbc.Items.Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();

            foreach (Item obj in items)
            {
                obj.Price = obj.Last_Order_Price * multiplier;
            }
            dbc.SaveChanges();
        }
    }
    public void UpdateItems_MassPriceReset_ByBid(int bidId)
    {
        using (var dbc = new Dbc())
        {
            var items = dbc.Items.Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();

            foreach (Item obj in items)
            {
                obj.Price = obj.Last_Order_Price;
            }
            dbc.SaveChanges();
        }
    }
}