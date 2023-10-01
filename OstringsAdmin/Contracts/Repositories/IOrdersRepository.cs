using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Contracts.Repositories
{
	public interface IOrdersRepository
	{
		Task<List<OrderItem>> GetOrders();
		Task SaveEntry(Order order);
	}
}
