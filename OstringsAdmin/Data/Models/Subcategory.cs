using OstringsAdmin.Data.Models.Base;

namespace OstringsAdmin.Data.Models
{
    public class Subcategory : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<SubcategoryProduct> Products { get; set; }
    }
}
