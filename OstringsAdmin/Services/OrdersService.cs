using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Mapper;
using OstringsAdmin.Repository;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
	public class OrdersService : BaseRepository
	{
		private readonly IOrdersRepository ordersRepository;

		public OrdersService(IOrdersRepository ordersRepository)
        {
			this.ordersRepository = ordersRepository;
		}

		public async Task<ResponseBase<List<OrderItem>>> GetOrders()
		{
			try
			{
				var orderItems = await ordersRepository.GetOrders();

				return new ResponseBase<List<OrderItem>>()
				{
					IsSucces = true,
					Data = orderItems.Select(x => OrdersMapper.Map(x)).ToList(),
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse<List<OrderItem>>(ex);
			}
		}

		internal async Task<ResponseBase> SaveEntry(Guid selectedProvider, int isCredit, List<InventoryItemRequest> inventoryItems)
		{
			return new ResponseBase();
			//try
			//{
			//	var products = await productsRepository.GetProducts(inventoryItems.Where(i => i.ProductId.HasValue).Select(i => i.ProductId.Value));

			//	await entriesRepository.SaveEntry(EntriesMapper.MapRequest(selectedProvider, isCredit, inventoryItems, products));

			//	return new ResponseBase()
			//	{
			//		IsSucces = true,
			//	};
			//}
			//catch (Exception ex)
			//{
			//	return GetServerErrorResponse(ex);
			//}
		}
	}
}
