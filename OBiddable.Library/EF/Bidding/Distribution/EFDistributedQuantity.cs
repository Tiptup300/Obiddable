using OBiddable.Library.Bidding.Cataloging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBiddable.Library.EF.Bidding.Distribution;

internal class EFDistributedQuantity
{
    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
    [Required] public Item Item { get; set; }
    [Required] public decimal Quantity { get; set; }
    [Required] public string BuildingName { get; set; }
    private EFDistributedQuantity() { }
}
    
