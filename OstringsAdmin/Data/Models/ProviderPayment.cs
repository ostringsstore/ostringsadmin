using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class ProviderPayment : ModelBase
    {
        public double Amount { get; set; }

        [ForeignKey("ProductProvider")]
        public Guid InventoryEntryId { get; set; }
        public InventoryEntry InventoryEntry { get; set; }
    }
}
