using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Mapper;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
    public class UsersService : BaseRepository
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<ResponseBase<List<Dto.User>>> GetUsers()
        {
            try
            {
                var listUsers = await usersRepository.GetUsers();

                return new ResponseBase<List<User>>()
                {
                    IsSucces = true,
                    Data = listUsers.Select(x => UsersMapper.Map(x)).ToList(),
                };
            }
            catch (Exception ex)
            {
                return GetServerErrorResponse<List<User>>(ex);
            }
        }
    }
}
