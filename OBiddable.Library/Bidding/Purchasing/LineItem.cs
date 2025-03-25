using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
    public class LineItem
    {
        private PurchaseOrder PurchaseOrder { get; set; }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(255), Column(TypeName = "varchar(255)")]
        public string PartNumber { get; set; }

        [MaxLength(255), Column(TypeName = "varchar(255)")]
        public string Unit { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        [MaxLength(255), Column(TypeName = "varchar(255)")]
        public string AccountNumber { get; set; }

        [MaxLength(255), Column(TypeName = "varchar(255)")]
        public string Note { get; set; }

        public int ItemCode { get; set; }

        public int ItemId { get; set; }

        private LineItem() { }

        public LineItem(int? id, string accountNumber, string description, 
            string partNumber, decimal price, decimal? quantity, string unit, string note, int itemCode, int itemId)
        {
            Id = id.HasValue ? id.Value : 0;
            AccountNumber = accountNumber;
            Description = description;
            PartNumber = partNumber;
            Price = price;
            Quantity = quantity;
            Unit = unit;
            Note = note;
            ItemCode = itemCode;
            ItemId = itemId;
        }

        public void SetPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            PurchaseOrder = purchaseOrder;
        }

        public LineItem CreateDuplicate()
        {
            LineItem output;

            output = new LineItem(
                null, 
                AccountNumber, 
                Description, 
                PartNumber, 
                Price, 
                Quantity, 
                Unit, 
                Note, 
                ItemCode, 
                ItemId);

            return output;
        }
    }
}
