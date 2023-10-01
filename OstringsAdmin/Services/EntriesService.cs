using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Mapper;
using OstringsAdmin.Repository;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
    public class EntriesService : BaseRepository
	{
		private readonly IProvidersRepository providersRepository;
		private readonly IEntriesRepository entriesRepository;
		private readonly IProductsRepository productsRepository;

		public EntriesService(IProvidersRepository providersRepository,
			IEntriesRepository entriesRepository,
			IProductsRepository productsRepository)
		{
			this.providersRepository = providersRepository;
			this.entriesRepository = entriesRepository;
			this.productsRepository = productsRepository;
		}

		public async Task<ResponseBase<List<Provider>>> GetProviders()
		{
			try
			{
				var listUsers = await providersRepository.GetProviders();

				return new ResponseBase<List<Provider>>()
				{
					IsSucces = true,
					Data = listUsers.Select(x => GeneralMapper.MapProvider(x)).ToList(),
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse<List<Provider>>(ex);
			}
		}

		public async Task<ResponseBase<List<InventoryItem>>> GetEntries()
		{
			try
			{
				var listUsers = await entriesRepository.GetEntries();

				return new ResponseBase<List<InventoryItem>>()
				{
					IsSucces = true,
					Data = listUsers.Select(x => EntriesMapper.Map(x)).ToList(),
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse<List<InventoryItem>>(ex);
			}
		}

		internal async Task<ResponseBase> SaveEntry(Guid selectedProvider, int isCredit, List<InventoryItemRequest> inventoryItems)
		{

			try
			{
				var products = await productsRepository.GetProducts(inventoryItems.Where(i => i.ProductId.HasValue).Select(i => i.ProductId.Value));

				await entriesRepository.SaveEntry(EntriesMapper.MapRequest(selectedProvider, isCredit, inventoryItems, products));

				return new ResponseBase()
				{
					IsSucces = true,
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse(ex);
			}
		}
	}
}
