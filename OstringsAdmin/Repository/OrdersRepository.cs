using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
	public class OrdersRepository : IOrdersRepository
	{
		private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

		public OrdersRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
		{
			this.dbFactory = dbFactory;
		}

		public async Task<List<OrderItem>> GetOrders()
		{
			using var context = dbFactory.CreateDbContext();

			return await context.OrderItems.Include(i => i.Product).Include(i => i.Order.Payment).ToListAsync();
		}

		public async Task SaveEntry(Order order)
		{
			using var context = dbFactory.CreateDbContext();

			await context.Orders.AddAsync(order);

			await context.SaveChangesAsync();
		}
	}
}
