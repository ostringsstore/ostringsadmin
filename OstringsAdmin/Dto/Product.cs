using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Dto
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DistributionPrice { get; set; }
        public double RetailPrice { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public Category Category { get; set; }
        public List<ProductProvider> ProductProviders { get; set; }
        public List<ProductLocation> ProductLocations { get; set; }
    }
}
