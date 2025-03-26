using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Purchasing;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Bidding.Responding;
using OBiddable.Library.Validations;

namespace OBiddable.Library.Bidding;

public class Bid : IValidatable
{
    // Children
    public List<Item> Items { get; set; } = new List<Item>();
    public List<Requestor> Requestors { get; set; } = new List<Requestor>();
    public List<VendorResponse> VendorResponses { get; set; } = new List<VendorResponse>();
    public List<PurchaseOrder> PurchaseOrders
    {
        get;
        private set;
    } = new List<PurchaseOrder>();

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

    public void SetPurchaseOrders(IEnumerable<PurchaseOrder> purchaseOrders)
    {
        PurchaseOrders = new List<PurchaseOrder>();
        purchaseOrders
            .ToList()
            .ForEach(purchaseOrder =>
            {
                AddPurchaseOrder(purchaseOrder);
            });
    }
}
