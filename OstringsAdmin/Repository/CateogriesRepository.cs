using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
    public class CateogriesRepository : ICateogriesRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

        public CateogriesRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<List<Category>> GetCategories()
        {
            using var context = dbFactory.CreateDbContext();

            return await context.Categories.ToListAsync();
        }
    }
}
