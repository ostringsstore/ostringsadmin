using Ostrings.Data.Models;
using OstringsAdmin.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class Order : ModelBase
    {
        public double TotalPrice => CartIiems != null ? CartIiems.Sum(x => x.TotalPrice) : 0;

        public List<OrderItem> CartIiems { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
