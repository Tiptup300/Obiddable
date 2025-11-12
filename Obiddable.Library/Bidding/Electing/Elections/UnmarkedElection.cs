using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Library.Bidding.Electing.Elections;
public class UnmarkedElection : Election
{
   public UnmarkedElection(Item item, int? id = null) : base(item, id)
   {
   }

   public override string ToString()
       => $"Unmarked Election:({Item})";

   public override MarkedElection Elect(ResponseItem electedResponseItem, string reason)
       => new MarkedElection(electedResponseItem, reason, Id);
}
