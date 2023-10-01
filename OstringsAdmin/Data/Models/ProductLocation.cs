using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class ProductLocation
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public int Quantity { get; set; }
    }
}
