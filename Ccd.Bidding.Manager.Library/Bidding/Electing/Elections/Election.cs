using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
public abstract class Election : Entity
{
   public Item Item { get; private set; }

   protected Election(Item item, int? id = null) : base(id)
   {
      Item = item ?? throw new ArgumentNullException(nameof(item));
   }

   public abstract MarkedElection Elect(ResponseItem electedResponseItem, string reason);
}
