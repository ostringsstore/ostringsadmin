using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class Location : ModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumer { get; set; }

        public List<ProductLocation> ProductLocations { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
