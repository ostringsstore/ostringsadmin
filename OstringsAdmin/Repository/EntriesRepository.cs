using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
	public class EntriesRepository : IEntriesRepository
	{
		private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

		public EntriesRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
		{
			this.dbFactory = dbFactory;
		}

		public async Task<List<InventoryItem>> GetEntries()
		{
			using var context = dbFactory.CreateDbContext();

			return await context.InventoryItems.Include(i => i.Product).Include(i => i.InventoryEntry.Provider).ToListAsync();
		}
	}
}
