using OstringsAdmin.Contracts;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Mapper;
using OstringsAdmin.Repository;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
	public class EntriesService : BaseRepository
	{
		private readonly IProvidersRepository providersRepository;
		private readonly IEntriesRepository entriesRepository;

		public EntriesService(IProvidersRepository providersRepository,
			IEntriesRepository entriesRepository)
        {
			this.providersRepository = providersRepository;
			this.entriesRepository = entriesRepository;
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
	}
}
