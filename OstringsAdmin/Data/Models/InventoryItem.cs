using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class InventoryItem : ModelBase
    {
        [ForeignKey("InventoryEntry")]
        public Guid InventoryEntryId { get; set; }
        public InventoryEntry InventoryEntry { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int PayedQuantity { get; set; }
        public int OutstandingQuantity { get; set; }
        public double UnitPrice { get; set; }
        public string Details { get; set; }
    }
}
