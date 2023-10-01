namespace OstringsAdmin.Mapper
{
	public static class OrdersMapper
	{
		public static Dto.OrderItem Map(Data.Models.OrderItem orderItem)
		{
			return new Dto.OrderItem()
			{
				CreateAt = orderItem.CreateAt,
				Id = orderItem.Id,
				Order = orderItem.Order == null ? new Dto.Order() : new Dto.Order()
				{
					Id = orderItem.Order.Id,
					AddressId = orderItem.Order.AddressId,
					Address = orderItem.Order.Address == null ? new Dto.Address() : new Dto.Address()
					{
						AddresValue = orderItem.Order.Address.AddresValue,
						ContactPerson = orderItem.Order.Address.ContactPerson,
						Id = orderItem.Order.Address.Id,
						PhoneNumber = orderItem.Order.Address.PhoneNumber,
					},
					CreateAt = orderItem.Order.CreateAt,
					UpdateAt = orderItem.Order.CreateAt,
					UserId = orderItem.Order.User.Id,
					User = orderItem.Order.User == null ? new Dto.User() : new Dto.User()
					{
						CreateAt = orderItem.Order.User.CreateAt,
						Document = orderItem.Order.User.Document,
						Email = orderItem.Order.User.Email,
						LastName = orderItem.Order.User.LastName,
						Name = orderItem.Order.User.Name,
						Phone = orderItem.Order.User.Phone,
						PhoneNumber = orderItem.Order.User.PhoneNumber,
						UpdateAt = orderItem.Order.UpdateAt,
					},
					Payment = orderItem.Order.Payment == null ? new Dto.Payment() : new Dto.Payment()
					{
						CreateAt = orderItem.Order.Payment.CreateAt,
						Id = orderItem.Order.Payment.Id,
						OrderId = orderItem.Order.Payment.Id,
						Status = orderItem.Order.Payment.Status,
						ÚpdateAt = orderItem.Order.Payment.UpdateAt,
						TotalPrice = orderItem.Order.Payment.TotalPrice,
					},
					TotalPrice = orderItem.Order.TotalPrice,
				},
				ProductId = orderItem.ProductId,
				UpdateAt = orderItem.UpdateAt,
				OrderId	= orderItem.OrderId,
				Quantity = orderItem.Quantity,
				UnitPrice = orderItem.UnitPrice,
				Product = orderItem.Product == null ? new Dto.Product() : new Dto.Product()
				{
					Id = orderItem.ProductId,
					Description = orderItem.Product.Description,
					Name = orderItem.Product.Name,
					Reference = orderItem.Product.Reference,
					RetailPrice = orderItem.Product.RetailPrice,
					Quantity = orderItem.Product.Quantity,
				},
				Detail = orderItem.Detail,
			};
		}
	}
}
