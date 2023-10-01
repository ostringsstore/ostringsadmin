using Microsoft.AspNetCore.Identity;
using Ostrings.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstringsAdmin.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string? ResetPasswordCode { get; set; }
        public string? Phone { get; set; }
        public DateTime ResetPasswordCodeExpiration { get; set; }
        public bool IsLocked { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Location> Locations { get; set; }

        [NotMapped]
        public Order OpenOrder { get; set; }

        [NotMapped]
        public string RecoveryPasswordToken { get; set; }
    }
}
