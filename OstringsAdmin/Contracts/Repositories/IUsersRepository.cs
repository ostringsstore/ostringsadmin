using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsers();
    }
}
