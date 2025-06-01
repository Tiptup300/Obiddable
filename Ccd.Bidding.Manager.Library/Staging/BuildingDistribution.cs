using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Staging.ItemRequests;

namespace Ccd.Bidding.Manager.Library.Staging;
public class BuildingDistribution
{
   public Bid Bid
   {
      get => _bid;
      set
      {
         if (value is null)
         {
            throw new ArgumentException("Bid cannot be null.");
         }
         _bid = value;
      }
   }
   private Bid _bid;


   public string Name
   {
      get => _name;
      private set
      {
         if (value is null)
         {
            throw new ArgumentException("Name Cannot Be Null.");
         }
         if (value.Length == 0 || value.Length > 255)
         {
            throw new ArgumentException("Name Cannot Have Invalid Length");
         }
         _name = value;
      }
   }
   private string _name;


   public IEnumerable<Requestor> Requestors
   {
      get => _requestors;
      private set
      {
         if (value is null)
         {
            throw new ArgumentException("Requestors Cannot Be Null.");
         }
         _requestors = value;
      }
   }
   private IEnumerable<Requestor> _requestors;


   public IEnumerable<ItemRequest> ItemRequests
   {
      get => _itemRequests;
      private set
      {
         if (value is null)
         {
            throw new ArgumentException(" Requested Items Cannot Be Null.");
         }
         if (value.Count() == 0)
         {
            throw new ArgumentException("Requested Items Cannot Be Empty.");
         }
         if (isRequestedItemsAllInRequestors(value) == false)
         {
            throw new ArgumentException("All Requested Items's Requestors Must Be In Requestors");
         }
         _itemRequests = value;
      }
   }
   private IEnumerable<ItemRequest> _itemRequests;


   public IEnumerable<ItemDistribution> ItemDistributions
   {
      get => _itemDistributions;
      set { _itemDistributions = value; }
   }
   private IEnumerable<ItemDistribution> _itemDistributions;

   public BuildingDistribution(Bid bid, string name, IEnumerable<Requestor> requestors,
       IEnumerable<ItemRequest> itemRequests, IEnumerable<ItemDistribution> itemDistributions)
   {
      Bid = bid;
      Name = name;
      Requestors = requestors;
      ItemRequests = itemRequests;
      ItemDistributions = itemDistributions;
   }

   private bool isRequestedItemsAllInRequestors(IEnumerable<ItemRequest> requestedItems)
   {
      return requestedItems
          .SelectMany(x => x.RequestItems)
          .Select(x => x.Request.Requestor)
          .All(x => Requestors.Contains(x));
   }
}
