using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
	public interface IEntriesRepository
	{
		Task<List<InventoryItem>> GetEntries();
	}
}
