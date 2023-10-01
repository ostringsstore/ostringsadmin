using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts
{
	public interface IProvidersRepository
	{
		Task<List<Provider>> GetProviders();
	}
}
