using OstringsAdmin.Data.Models.Base;
using OstringsAdmin.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ostrings.Data.Models
{
    public class Address : ModelBase
    {
        public string AddresValue { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }

        [ForeignKey("Category")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
