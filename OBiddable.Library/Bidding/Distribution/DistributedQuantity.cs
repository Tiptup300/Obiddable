using OBiddable.Library.Bidding.Cataloging;

namespace OBiddable.Library.Bidding.Distribution;

	public class DistributedQuantity
	{
		private Bid _bid;
		public Bid Bid
    {
			get => _bid;
			private set
        {
				_bid = value;
        }
    }

		private Item _item;
		public Item Item
		{
			get => _item;
			private set
			{
				if(value.Bid.Id != Bid.Id)
            {
					throw new ArgumentException("Item Bid must match bid.");
            }
				_item = value;
			}
		}

		private Building _building;
		public Building Building
		{
			get => _building;
			private set
			{
				if (value.Bid.Id != Bid.Id)
				{
					throw new ArgumentException("Building Bid must match bid.");
				}
				_building = value;
			}
		}

		private decimal _quantity;
		public decimal Quantity
		{
			get => _quantity;
			private set
			{
				if(value < 0)
            {
					throw new ArgumentException("Quantity cannot be negative.");
            }
				_quantity = value;
			}
		}


		public DistributedQuantity(Bid bid, Building building, Item item, decimal quantity)
		{
			Bid = bid;
			Building = building;
			Item = item;
			Quantity = quantity;
		}
	}
