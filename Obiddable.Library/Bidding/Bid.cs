using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Purchasing;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Responding;
using Obiddable.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obiddable.Library.Bidding;
public class Bid : IValidatable
{

   private List<PurchaseOrder> _purchaseOrders = [];
   // Children
   public List<Item> Items { get; set; } = new List<Item>();
   public List<Requestor> Requestors { get; set; } = new List<Requestor>();
   public List<VendorResponse> VendorResponses { get; set; } = new List<VendorResponse>();
   public List<PurchaseOrder> PurchaseOrders
   {
      get => _purchaseOrders;
      set
      {
         // it is unclear why this is done this way as every other property
         // sets them directly, this one sets the bid on each purchase order
         // and it's not clear when it updates and actually fills the list
         // _purchaseOrders
         _purchaseOrders = [];
         foreach (var po in value)
            AddPurchaseOrder(po);
      }
   }


   //Fields
   [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }

   [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
   public string Name { get; set; }

   public void Validate()
   {
      if (Name.Length == 0 || Name.Length > 255)
      {
         throw new DataValidationException("Name is invalid");
      }
   }

   public override string ToString()
   {
      return $"B{Id.ToString("000000")}";
   }

   public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
   {
      purchaseOrder.SetBid(this);
      PurchaseOrders.Add(purchaseOrder);
   }
}
