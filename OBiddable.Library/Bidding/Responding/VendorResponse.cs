using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBiddable.Library.Bidding.Responding;

public class VendorResponse : IValidatable
{
    // Parent
    public Bid Bid { get; set; }

    // Children
    public List<ResponseItem> ResponseItems { get; set; }

    // Fields
    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string VendorName { get; set; }

    public decimal GetGetSum_TotalPrice(IRequestingRepo requestingRepo)
    {
        return ResponseItems.Select(x => x.GetExtendedPrice(requestingRepo)).Sum();
    }

    public decimal GetGetSum_Quantity(IRequestingRepo requestingRepo)
    {
        return ResponseItems.Select(x => x.Get_Quantity(requestingRepo)).Sum();
    }

    public int GetCount_Elected 
        => ResponseItems.Where(x => x.Elected).Count();

    public decimal GetGetSum_ElectedTotalPrice(IRequestingRepo requestingRepo)
    {
        return ResponseItems.Where(x => x.Elected).Select(x => x.GetExtendedPrice(requestingRepo)).Sum();
    }

    public decimal GetGetSum_ElectedQuantity(IRequestingRepo requestingRepo)
    {
        return ResponseItems.Where(x => x.Elected).Select(x => x.Get_Quantity(requestingRepo)).Sum();
    }

    public int Count_LowBid(IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
        => ResponseItems.Where(x => x.GetGet_IsLowBid(respondingRepo, requestingRepo)).Count();

    public decimal Sum_LowBidTotalPrice(IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
        => ResponseItems.Where(x => x.GetGet_IsLowBid(respondingRepo, requestingRepo)).Select(x => x.GetExtendedPrice(requestingRepo)).Sum();

    public decimal Sum_LowBidQuantity(IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
        => ResponseItems.Where(x => x.GetGet_IsLowBid(respondingRepo, requestingRepo)).Select(x => x.AlternateQuantity).Sum();

    public override string ToString()
    {
        return $"{Bid}_V{ VendorName.ToUpper() }";
    }

    public void Validate()
    {
        if (VendorName.Length == 0 || VendorName.Length > 255)
        {
            throw new DataValidationException("Vendor Name invalid");
        }
    }
}
