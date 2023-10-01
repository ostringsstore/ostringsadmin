using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class InventoryEntry : ModelBase
    {
        [ForeignKey("Provider")]
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }
        public double TotalAmount { get; set; }

        public List<ProviderPayment> ProviderPayments { get; set; }
    }
}
