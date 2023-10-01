using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Mapper;
using OstringsAdmin.Repository;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
    public class CateogriesService : BaseRepository
    {
        private readonly ICateogriesRepository cateogriesRepository;

        public CateogriesService(ICateogriesRepository cateogriesRepository)
        {
            this.cateogriesRepository = cateogriesRepository;
        }

        public async Task<ResponseBase<List<Category>>> GetCategories()
        {
            try
            {
                var listUsers = await cateogriesRepository.GetCategories();

                return new ResponseBase<List<Category>>()
                {
                    IsSucces = true,
                    Data = listUsers.Select(x => GeneralMapper.MapCategory(x)).ToList(),
                };
            }
            catch (Exception ex)
            {
                return GetServerErrorResponse<List<Category>>(ex);
            }
        }
    }
}
