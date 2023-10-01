using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts(IEnumerable<Guid>? enumerable = null);
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid productId);
    }
}
