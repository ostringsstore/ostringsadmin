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

		public async Task<List<Product>> GetProducts(IEnumerable<Guid>? products = null)
		{
			using var context = dbFactory.CreateDbContext();
			var query = context.Products.Include(pd => pd.Category).AsQueryable();

			if (products != null && products.Any())
				query = query.Where(p => products.Contains(p.Id));

			return await query.ToListAsync();
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
