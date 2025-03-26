using OBiddable.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBiddable.Library.Bidding.Purchasing;

public class PurchaseOrder : IValidatable
{
    public Bid Bid { get; private set; }
    public List<LineItem> LineItems { get; set; } = new List<LineItem>();

    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [MaxLength(255), Column(TypeName = "varchar(255)")]
    public string Vendor { get; set; }

    [MaxLength(255), Column(TypeName = "varchar(255)")]
    public string Building { get; set; }
    public DateTime CreationDate { get; set; }

    private PurchaseOrder()
    {

    }

    public PurchaseOrder(int? id, IEnumerable<LineItem> lineItems, string vendor, string building, DateTime creationDate)
    {
        Id = id.HasValue ? id.Value : 0;
        Vendor = vendor;
        Building = building;
        CreationDate = creationDate;
        AddPurchases(lineItems);
    }

    public override string ToString()
    {
        return $"{ Bid }_P{Id.ToString("000000")}_{Vendor.ToLower() }_{Building.ToLower()}";
    }

    public void Validate()
    {
        if (Building.Length == 0 || Building.Length > 255)
        {
            throw new DataValidationException("PurchaseOrder Building is invalid");
        }
        if (Vendor.Length == 0 || Vendor.Length > 255)
        {
            throw new DataValidationException("PurchaseOrder Vendor is invalid");
        }
        if (CreationDate < new DateTime(2020, 08, 08))
        {
            throw new DataValidationException("PurchaseOrder CreationDate is invalid");
        }
    }

    public void SetBid(Bid bid)
    {
        Bid = bid;
    }


    public void AddPurchases(IEnumerable<LineItem> lineItems)
    {
        lineItems
            .ToList()
            .ForEach(lineItem =>
            {
                AddPurchase(lineItem);
            });
    }
    public void AddPurchase(LineItem lineItem)
    {
        lineItem.SetPurchaseOrder(this);
        if (isLineItemAlreadyAdded(lineItem))
        {
            addQuantityToExistingLineItem(lineItem.ItemId, lineItem.Quantity.Value);
        }
        else
        {
            LineItems.Add(lineItem);
        }
    }
    private bool isLineItemAlreadyAdded(LineItem lineItem) 
        => LineItems.Any(x => x.ItemId == lineItem.ItemId);

    private void addQuantityToExistingLineItem(int itemId, decimal quantity)
    {
        LineItem existingLineItem;

        existingLineItem = LineItems.Single(x => x.ItemId == itemId);
        existingLineItem.Quantity += quantity;
    }

    public PurchaseOrder CreateDuplicate()
    {
        PurchaseOrder output;

        output = new PurchaseOrder(
            null,
            LineItems.Select(lineItem => lineItem.CreateDuplicate()),
            Vendor,
            Building,
            CreationDate
            );

        return output;
    }
}
