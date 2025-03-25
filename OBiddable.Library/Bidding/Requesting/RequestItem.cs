using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ccd.Bidding.Manager.Library.Validations;

namespace Ccd.Bidding.Manager.Library.Bidding.Requesting
{
    public class RequestItem : IValidatable
    {
        //Parents
        public Request Request { get; set; }

        // Fields
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, Column(TypeName = "decimal(18,5)")]
        public decimal OverridePrice { get; set; }

        public void Validate()
        {
            if (Item is null)
            {
                throw new DataValidationException("RequestItem Item cannot be null");
            }

            if (OverridePrice < 0)
            {
                throw new DataValidationException("RequestItem Override Price cannot be negative");
            }

            if (Quantity <= 0)
            {
                throw new DataValidationException("RequestItem Quantity cannot be negative or zero");
            }
        }

        public override string ToString()
            => $"{Request}__rqitm_{Item.FormattedCode}";
    }
}
