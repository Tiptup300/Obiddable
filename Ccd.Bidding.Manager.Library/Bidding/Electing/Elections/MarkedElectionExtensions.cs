using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
    public static class MarkedElectionExtensions
    {
        public static bool IsResponseItemAlternate(this MarkedElection markedElection) 
            => markedElection.ElectedResponseItem.IsAlternate;

        public static string GetResponseItemVendorName(this MarkedElection markedElection)
            => markedElection.ElectedResponseItem.VendorResponse.VendorName;

        public static decimal GetResponseItemPrice(this MarkedElection markedElection)
            => markedElection.ElectedResponseItem.Price;
    }
}
