using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Dto
{
    public class ProductProvider
    {
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int PayedQuantity { get; set; }
        public int OutstandingQuantity { get; set; }
    }
}
