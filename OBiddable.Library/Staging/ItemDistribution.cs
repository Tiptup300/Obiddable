using OBiddable.Library.Bidding;
using OBiddable.Library.Staging.ItemElections;

namespace OBiddable.Library.Staging;

public class ItemDistribution
{
    public ItemElection ItemElection { get; private set; }
    public Building Building { get; private set; }
    public decimal Quantity { get; private set; }
}
