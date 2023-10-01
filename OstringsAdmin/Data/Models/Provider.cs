using OstringsAdmin.Data.Models.Base;

namespace OstringsAdmin.Data.Models
{
    public class Provider : ModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNumber { get; set; }
    }
}
