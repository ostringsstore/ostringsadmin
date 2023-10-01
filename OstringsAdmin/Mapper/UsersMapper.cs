using OstringsAdmin.Dto;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Mapper
{
    public static class UsersMapper
    {
        public static Dto.User Map(Data.Models.User user)
        {
            return new Dto.User()
            {
                CreateAt = user.CreateAt,
                Document = user.Document,
                ImageUrl = user.ImageUrl,
                IsDeleted = user.IsDeleted,
                LastName = user.LastName,
                Name = user.Name,
                Phone = user.Phone,
                UpdateAt = user.UpdateAt,
                IsLocked = user.IsLocked,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
