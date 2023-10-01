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
				Product	= entry.Product == null ? new Dto.Product() : new Dto.Product()
				{
					Id = entry.Product.Id,
					Name = entry.Product.Name,
				}
			};
		}
	}
}
