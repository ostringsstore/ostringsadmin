using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Dto
{
    public class ProductLocation
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public int Quantity { get; set; }
    }
}
