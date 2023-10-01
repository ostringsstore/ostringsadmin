using OstringsAdmin.Data.Models.Base;

namespace OstringsAdmin.Data.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
