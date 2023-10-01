using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
    public interface ICateogriesRepository
    {
        Task<List<Category>> GetCategories();
    }
}
