using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Staging
{
    public class ItemElection
    {
        private Item _item;
        private MarkedElection _election;

        public Item Item
        {
            get => _item;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Item Cannot be Null");
                }
                _item = value;
            }
        }
        public MarkedElection Election
        {
            get => _election;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Election Cannot Be Null.");
                }
                if (value.Item.Id != Item.Id)
                {
                    throw new ArgumentException("Election Item Id Must Match RespondedItem Id");
                }
                _election = value;
            }
        }

        public ItemElection(Item item, MarkedElection election)
        {
            Item = item;
            Election = election;
        }
    }
}
