using OstringsAdmin.Data.Models.Base;
using OstringsAdmin.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class Payment : ModelBase
    {
        public double TotalPrice { get; set; }
        public PaymentStatus Status { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
