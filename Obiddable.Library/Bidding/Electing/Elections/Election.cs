using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Library.Bidding.Electing.Elections;
public abstract class Election : Entity
{
   public Item Item { get; private set; }

   protected Election(Item item, int? id = null) : base(id)
   {
      Item = item ?? throw new ArgumentNullException(nameof(item));
   }

   public abstract MarkedElection Elect(ResponseItem electedResponseItem, string reason);
}
