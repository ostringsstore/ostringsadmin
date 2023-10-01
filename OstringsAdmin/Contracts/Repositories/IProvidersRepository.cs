using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
    public interface IProvidersRepository
    {
        Task<List<Provider>> GetProviders();
    }
}
