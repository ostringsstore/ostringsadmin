using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Data.Models;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Mapper
{
	public static class ProductsMapper
	{
		public static Dto.Product Map(Data.Models.Product product)
		{
			return new Dto.Product()
			{
				Description = product.Description,
				Id = product.Id,
				Name = product.Name,
				DistributionPrice = product.DistributionPrice,
				RetailPrice = product.RetailPrice,
				Quantity = product.Quantity,
				Reference = product.Reference,
				Category = product.Category == null ? new Dto.Category() : new Dto.Category()
				{
					Id = product.Category.Id,
					Name = product.Category.Name,
				},
				ProductLocations = product.ProductLocations?.Select(p => new Dto.ProductLocation()
				{
					LocationId = p.LocationId,
					Location = new Dto.Location()
					{
						Address = p.Location?.Address ?? string.Empty,
						Name = p.Location?.Name ?? string.Empty,
						PhoneNumer = p.Location?.PhoneNumer ?? string.Empty
					}
				}).ToList() ?? new List<Dto.ProductLocation>(),
			};
		}

		internal static Data.Models.Product MapRequest(ProductRequest product)
		{
			return new Data.Models.Product()
			{
				CategoryId = product.CateogryId.Value,
				CreateAt = DateTime.UtcNow,
				Description = product.Description,
				DistributionPrice = product.DistributionPrice.Value,
				IsDeleted = false,
				Name = product.Name,
				Quantity = product.Quantity.Value,
				Reference = product.Reference,
				RetailPrice = product.RetailPrice.Value,
				UpdateAt = DateTime.UtcNow,
			};
		}
	}
}
