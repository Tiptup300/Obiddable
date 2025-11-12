using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Bidding.Requesting.Extensions;
using Obiddable.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obiddable.Library.Bidding.Responding;
public class ResponseItem : IValidatable
{
   // Parent
   public VendorResponse VendorResponse { get; set; }

   //Fields
   [Required]
   public int Id { get; set; }

   [Required]
   public Item Item { get; set; }

   [Required, MaxLength(50)]
   public string Code { get; set; }

   [Required, Column(TypeName = "decimal(18,5)")]
   public decimal Price { get; set; }

   [Required, Column(TypeName = "decimal(18,5)")]
   public decimal AlternateQuantity { get; set; }

   [MaxLength(30)]
   public string? AlternateUnit { get; set; }

   [Required]
   public bool IsAlternate { get; set; }

   [MaxLength(500)]
   public string? AlternateDescription { get; set; }

   public bool Elected { get; set; }

   public string? ElectionReason { get; set; }

   private ResponseItem() { }

   public ResponseItem(int? id, Item item, string code,
       decimal price, decimal alternateQuantity,
       string alternateUnit, bool isAlternate,
       string alternateDescription, bool isElected,
       string electionReason
       )
   {
      Id = id.HasValue ? id.Value : 0;
      Item = item;
      Code = code;
      Price = price;
      AlternateQuantity = alternateQuantity;
      AlternateUnit = alternateUnit;
      IsAlternate = isAlternate;
      AlternateDescription = alternateDescription;
      Elected = isElected;
      ElectionReason = electionReason;
   }

   public decimal Get_Quantity(IRequestingRepo requestingRepo)
   {
      if (IsAlternate)
      {
         return AlternateQuantity;
      }
      else
      {
         return Item.GetRequestedQuantity(requestingRepo);
      }
   }

   public decimal GetExtendedPrice(IRequestingRepo requestingRepo)
   {
      return Math.Round(Price * Get_Quantity(requestingRepo), 2);
   }

   public bool GetGet_IsLowBid(IRespondingRepo respondingRepo, IRequestingRepo requestingRepo)
       => respondingRepo.Check_ResponseItemIsLowestBid(Id, requestingRepo);

   public override string ToString()
   {
      return $"{VendorResponse}_RI{Item.FormattedCode}";
   }

   public void Validate()
   {
      if (Item is null)
      {
         throw new DataValidationException("ResponseItem Item is null");
      }

      if (Code.Length > 255)
      {
         throw new DataValidationException("ResponseItem Code is invalid");
      }
      if (Price <= 0)
      {
         throw new DataValidationException("ResponseItem Price is invalid");
      }

      // election properties
      if (Elected && ElectionReason == null)
      {
         throw new DataValidationException("ResponseItem ReasonElected is invalid");
      }
      if (Elected && ElectionReason != null)
      {
         if (Elected == (ElectionReason == null))
         {
            throw new DataValidationException("ResponseItem ReasonElected is invalid");
         }
      }
      //Above replaced this below
      //if (Elected && ElectionReason != null)
      //{
      //throw new DataValidationException("ResponseItem ReasonElected is invalid");
      //}

      // alternate properties
      if (IsAlternate)
      {
         if (AlternateDescription == null || AlternateDescription.Length > 255)
         {
            throw new DataValidationException("ResponseItem AlternateDescription is invalid");
         }
         if (AlternateUnit == null || AlternateUnit.Length > 255)
         {
            throw new DataValidationException("ResponseItem AlternateUnit is invalid");
         }
         if (AlternateQuantity <= 0)
         {
            throw new DataValidationException("ResponseItem AlternateQuantity is invalid");
         }
      }
      else
      {
         if (AlternateDescription != null)
         {
            throw new DataValidationException("ResponseItem AlternateDescription must be null if not alternate");
         }
         if (AlternateUnit != null)
         {
            throw new DataValidationException("ResponseItem AlternateUnit must be null if not alternate");
         }
         if (AlternateQuantity != 0)
         {
            throw new DataValidationException("ResponseItem AlternateQuantity must be null if not alternate");
         }
      }
   }
}
