using Ostrings.Data.Models;

namespace OstringsAdmin.Dto
{
    public class User
    {
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string? Phone { get; set; }
        public bool IsLocked { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
