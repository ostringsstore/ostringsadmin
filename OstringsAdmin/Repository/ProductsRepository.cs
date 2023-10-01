using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

        public ProductsRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<List<Product>> GetProducts()
        {
            using var context = dbFactory.CreateDbContext();

            return await context.Products.Include(pd => pd.Category).ToListAsync();
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            using var context = dbFactory.CreateDbContext();

            return await context.Products.Include(pd => pd.Category).Include(pd => pd.ProductLocations).ThenInclude(l => l.Location).FirstOrDefaultAsync(pd => pd.Id == productId);
        }

        public async Task CreateProduct(Product product)
        {
            using var context = dbFactory.CreateDbContext();

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();
        }
    }
}
