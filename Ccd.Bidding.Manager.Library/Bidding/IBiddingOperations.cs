using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding
{
    public interface IBiddingOperations
    {
        bool ClearAndDeleteBid(Bid bid);
        Bid DuplicateBid(int bidId);
        Bid RollBid(int bidId);
    }

}
