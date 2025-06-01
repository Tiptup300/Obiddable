using Ccd.Bidding.Manager.Library.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting;
public class Request : IValidatable
{
   public Requestor Requestor { get; set; }

   public List<RequestItem> RequestItems { get; set; }

   [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }

   [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
   public string Account_Number { get; set; }


   public void Validate()
   {
      if (AccountNumber.IsInvalid(Account_Number))
      {
         throw new DataValidationException("Account number is invalid.");
      }
   }

   public override string ToString()
       => $"{Account_Number}";
}
