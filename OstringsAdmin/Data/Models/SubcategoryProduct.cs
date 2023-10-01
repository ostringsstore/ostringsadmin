using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class SubcategoryProduct
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Subcategory")]
        public Guid SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
