using Obiddable.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obiddable.Library.Bidding.Requesting;
public class Requestor : IValidatable
{
   //Parent
   public Bid Bid { get; set; }

   // Children
   public List<Request> Requests { get; set; } = new List<Request>();

   //Fields
   [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }

   [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
   public string Name { get; set; }

   [Required]
   public int Code { get; set; }
   [NotMapped]
   public string FormattedCode => Code.ToString("000000");

   [Required, MaxLength(50), Column(TypeName = "varchar(50)")]
   public string Building { get; set; }

   [Required, MaxLength(30), Column(TypeName = "varchar(30)")]
   public string Password { get; set; }

   public decimal? AmountBudgeted { get; set; }


   public void Validate()
   {
      if (Name.Length == 0 || Name.Length > 255)
      {
         throw new DataValidationException("Requestor Name is invalid");
      }

      if (Password.Length == 0)
      {
         throw new DataValidationException("Requestor Password invalid");
      }

      if (Building.Length == 0 || Building.Length > 255)
      {
         throw new DataValidationException("Requestor Building Name invaild");
      }

      if (Code == 0 || Code > 999999)
      {
         throw new DataValidationException("Requestor Code invalid");
      }

      if (AmountBudgeted < 0)
      {
         throw new DataValidationException("Amount Budgeted cannot be negative");
      }
   }
   public override string ToString()
   {
      return $"R{Code.ToString("000000")}";
   }
}
