using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Dto;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Enumerations;
using OstringsAdmin.Mapper;
using OstringsAdmin.Repository;
using OstringsAdmin.Services.Base;

namespace OstringsAdmin.Services
{
	public class ProductsService : BaseRepository
	{
		private readonly IProductsRepository productsRepository;

		public ProductsService(IProductsRepository productsRepository)
		{
			this.productsRepository = productsRepository;
		}

		public async Task<ResponseBase<List<Product>>> GetProducts()
		{
			try
			{
				var products = await productsRepository.GetProducts();

				return new ResponseBase<List<Product>>()
				{
					IsSucces = true,
					Data = products.Select(x => ProductsMapper.Map(x)).ToList(),
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse<List<Product>>(ex);
			}
		}

		public async Task<ResponseBase<Product>> GetProduct(Guid productId)
		{
			try
			{
				var product = await productsRepository.GetProduct(productId);

				if (product == null)
				{
					return new ResponseBase<Product>()
					{
						IsSucces = true,
						CustomErrors = new List<RepositoryError>()
						{
							new RepositoryError()
							{
								Description = "No se encontro este prducto",
								Error = "Error al obtener el producto",
								Status = StatusResponse.DataNotFound,
							}
						},
					};
				}

				return new ResponseBase<Product>()
				{
					IsSucces = true,
					Data = ProductsMapper.Map(product),
				};
			}
			catch (Exception ex)
			{
				return GetServerErrorResponse<Product>(ex);
			}
		}

		public async Task<ResponseBase> CreateProduct(ProductRequest product)
		{
			try
			{
				var newProduct = ProductsMapper.MapRequest(product);

				await productsRepository.CreateProduct(newProduct);

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
