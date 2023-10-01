using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double RetailPrice { get; set; }
        public double DistributionPrice { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }

        public List<ProductImage> Images { get; set; }
        public List<OrderItem> CartIiems { get; set; }
        public List<SubcategoryProduct> Subcategories { get; set; }
        public List<InventoryItem> ProductProviders { get; set; }
        public List<ProductLocation> ProductLocations { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
