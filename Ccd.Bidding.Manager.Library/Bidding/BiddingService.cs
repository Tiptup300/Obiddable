using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding
{
    public class BiddingService
    {
        private readonly IBiddingRepo _biddingRepo;

        public BiddingService(IBiddingRepo biddingRepo)
        {
            _biddingRepo = biddingRepo;
        }

        public bool BidNameExists(string text, int bidId)
        {
            return _biddingRepo.GetBids()
                .Where(bid => bid.Id != bidId)
                .Any(bid => bid.Name == text);
        }
    }
}
