using Ccd.Bidding.Manager.Library.Bidding;

namespace Ccd.Bidding.Manager.Library.Staging
{
    public class ItemDistribution
    {
        public ItemElection ItemElection { get; private set; }
        public Building Building { get; private set; }
        public decimal Quantity { get; private set; }
    }
}
