using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
    public class ProvidersRepository : IProvidersRepository
	{
		private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

		public ProvidersRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
		{
			this.dbFactory = dbFactory;
		}

		public async Task<List<Provider>> GetProviders()
		{
			using var context = dbFactory.CreateDbContext();

			return await context.Providers.ToListAsync();
		}
	}
}
