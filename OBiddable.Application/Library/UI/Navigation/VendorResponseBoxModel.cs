using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.UI.Navigation
{
    class VendorResponseBoxModel
    {
        public VendorResponseBoxModel(Bid bid, IRequestingRepo repo)
        {
            VendorResponses = bid.GetVendorResponsesCount();
            ItemResponses = bid.GetVendorResponsesItemResponsesCount();
            NoResponseItems = bid.GetNoResponseItemsCount(repo);
            CanEditVendorResponses = bid.CanEditVendorResponses();
        }

        public int VendorResponses { get; private set; }
        public int ItemResponses { get; private set; }
        public int NoResponseItems { get; private set; }
        public bool CanEditVendorResponses { get; private set; }
    }
}
