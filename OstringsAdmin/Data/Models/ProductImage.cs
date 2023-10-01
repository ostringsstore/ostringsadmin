using OstringsAdmin.Data.Models.Base;
using OstringsAdmin.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class ProductImage : ModelBase
    {
        public string ImageUrl { get; set; }
        public ProductImagesTypes Type { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
