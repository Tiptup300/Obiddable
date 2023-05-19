using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing.Elections
{
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
}
