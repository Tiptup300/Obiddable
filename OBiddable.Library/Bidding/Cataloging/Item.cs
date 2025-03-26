using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OBiddable.Library.Validations;

namespace OBiddable.Library.Bidding.Cataloging;

public class Item : IValidatable
{
    private const int PRICE_DECIMAL_PLACES = 5;

    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    public Bid Bid { get; private set; }


    [Required]
    public int Code { get; set; }

    [NotMapped]
    public string FormattedCode => Code.ToString("000000");

    [NotMapped]
    public string HyphenatedFormattedCode => $"{FormattedCode.Substring(0, 4)}-{FormattedCode.Substring(4, 2)}";


    [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
    public string Category { get; set; }


    [Required]
    public string Description { get; set; }


    [Required]
    public bool Substitutable { get; set; }


    [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
    public string Unit { get; set; }


    [Column(TypeName = "decimal(18,5)")]
    public decimal Last_Order_Price { get; set; }


    [Column(TypeName = "decimal(18,5)")]
    public decimal Price { get; set; }

    private Item()
    {

    }

    public Item(int? id, Bid bid, int? code, string category, string description, bool? substitutable, string unit, decimal? last_Order_Price, decimal? price)
    {
        Id = id.HasValue ? id.Value : 0;
        Bid = bid;
        Code = code.HasValue ? code.Value : 0;
        Category = category;
        Description = description;
        Substitutable = substitutable.HasValue ? substitutable.Value : false;
        Unit = unit;
        Last_Order_Price = last_Order_Price.HasValue ? last_Order_Price.Value : 0;
        Price = price.HasValue ? decimal.Round(price.Value, PRICE_DECIMAL_PLACES) : 0;
    }

    public Item ClearBid()
        => ChangeBid(null);

    public Item ChangeBid(Bid bid)
    {
        return new Item(Id, bid, Code, Category, Description, Substitutable, Unit, Last_Order_Price, Price);
    }

    public Item UpdateItem(Item newValues)
    {
        return new Item(Id, Bid, newValues.Code, newValues.Category,
            newValues.Description, newValues.Substitutable,
            newValues.Unit, newValues.Last_Order_Price,
            newValues.Price);
    }

    public override string ToString()
    {
        return $"I{FormattedCode}";
    }

    public void Validate()
    {
        if (Code == 0 || Code > 999999)
        {
            throw new DataValidationException("Code is invalid");
        }

        if (Price < 0)
        {
            throw new DataValidationException("Price is invalid");
        }

        if (Last_Order_Price < 0)
        {
            throw new DataValidationException("Last Order Price is invalid");
        }

        if (Description.Length == 0)
        {
            throw new DataValidationException("Description is invalid");
        }

        if (Unit.Length == 0 || Unit.Length > 255)
        {
            throw new DataValidationException("Unit is invalid");
        }
    }
}
