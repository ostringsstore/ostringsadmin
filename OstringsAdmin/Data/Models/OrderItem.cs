using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class OrderItem : ModelBase
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice => UnitPrice * Quantity;
        public DateTime UpdateAt { get; set; }
        public string Detail { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
