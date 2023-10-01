using Microsoft.CodeAnalysis.Completion;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OstringsAdmin.Dto.Requests;

namespace OstringsAdmin.Mapper
{
	public static class EntriesMapper
	{
		public static Dto.InventoryItem Map(Data.Models.InventoryItem entry)
		{
			return new Dto.InventoryItem()
			{
				CreateAt = entry.CreateAt,
				Id = entry.Id,
				InventoryEntryId = entry.InventoryEntryId,
				ProductId = entry.ProductId,
				OutstandingQuantity = entry.OutstandingQuantity,
				PayedQuantity = entry.PayedQuantity,
				Quantity = entry.Quantity,
				UnitPrice = entry.UnitPrice,
				InventoryEntry = entry.InventoryEntry == null ? new Dto.InventoryEntry() : new Dto.InventoryEntry()
				{
					CreateAt = entry.InventoryEntry.CreateAt,
					Id = entry.InventoryEntry.Id,
					ProviderId = entry.InventoryEntry.ProviderId,
					TotalAmount = entry.InventoryEntry.TotalAmount,
					Provider = entry.InventoryEntry.Provider == null ? new Dto.Provider() : new Dto.Provider()
					{
						Id = entry.InventoryEntry.ProviderId,
						Name = entry.InventoryEntry.Provider.Name,
						Address = entry.InventoryEntry.Provider.Address,
						PhoneNumber = entry.InventoryEntry.Provider.PhoneNumber,
					},
				},
				Product = entry.Product == null ? new Dto.Product() : new Dto.Product()
				{
					Id = entry.Product.Id,
					Name = entry.Product.Name,
				}
			};
		}

		internal static Data.Models.InventoryEntry MapRequest(Guid selectedProvider, int isCredit, List<InventoryItemRequest> inventoryItems, List<Data.Models.Product> products)
		{
			var entry = new Data.Models.InventoryEntry()
			{
				CreateAt = DateTime.UtcNow,
				Id = Guid.NewGuid(),
				ProviderId = selectedProvider,
				IsCredit = isCredit == 1,
				IsDeleted = false,
				UpdateAt = DateTime.UtcNow,
			};

			entry.InventoryItems = inventoryItems.Select(i => MapItems(i, entry.Id, products)).ToList();
			entry.TotalAmount = entry.InventoryItems.Sum(i=> i.UnitPrice * i.Quantity);

			return entry;
		}

		private static Data.Models.InventoryItem MapItems(InventoryItemRequest i, Guid id, List<Data.Models.Product> products)
		{
			return new Data.Models.InventoryItem()
			{
				CreateAt = DateTime.UtcNow,
				Details = i.Details,
				Id = Guid.NewGuid(),
				InventoryEntryId = id,
				IsDeleted = false,
				ProductId = i.ProductId.Value,
				Quantity = i.Quantity.Value,
				UpdateAt = DateTime.UtcNow,
				UnitPrice = products.FirstOrDefault(p => p.Id == i.ProductId)?.DistributionPrice ?? 0,
			};
		}
	}
}
