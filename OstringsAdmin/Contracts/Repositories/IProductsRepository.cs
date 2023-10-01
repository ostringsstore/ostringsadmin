using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid productId);
    }
}
