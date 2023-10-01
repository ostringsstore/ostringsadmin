using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto;
using OstringsAdmin.Services;
using OstringsAdmin.Dto.Requests;

namespace OstringsAdmin.Pages
{
	public partial class OrderForm
	{
		private List<Product> products;
		private List<Product> filteredProducts;
		private List<OrderItem> orderItems = new List<OrderItem>();
		private List<OrderRequest> order = new List<OrderRequest>();
		private bool hasError;
		private string? errorMessage;
		private bool isProductsCollapsed;
		private bool isClientCollapsed;
		private bool isFormVisible;

		[Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject] public NavigationManager NavigationManager { get; set; }

		[Inject] public ProductsService ProductsService { get; set; }

		[Inject] public OrdersService OrdersService { get; set; }

		protected async override Task OnInitializedAsync()
		{
			if (await ValidateAuth())
			{
				var productsResponse = await ProductsService.GetProducts();

				if (productsResponse.IsSucces)
				{
					products = productsResponse.Data;
					filteredProducts = products.Select(p => p.Clone()).ToList();
				}
				else
				{
					hasError = true;
					errorMessage = productsResponse.CustomErrors?.FirstOrDefault()?.Description;
				}
			}
			else
			{
				NavigationManager.NavigateTo("/Identity/Account/Login");
			}
		}

		private async Task<bool> ValidateAuth()
		{
			var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

			return isUserAuthenticated.HasValue && isUserAuthenticated.Value;
		}

		private void AddItem(Product product)
		{
			orderItems.Add(new OrderItem()
			{
				Product = product.Clone(),
				Quantity = 1,
				UnitPrice = product.RetailPrice,
				ProductId = product.Id,
			});

			filteredProducts.Remove(product);
		}

		private void RemoveItem(OrderItem item)
		{
			orderItems.Remove(item);

			var product = products.FirstOrDefault(p => p.Id == item.ProductId)?.Clone();

			if (product != null)
			{
				filteredProducts.Add(product);
			}
		}

		private void Confirm()
		{

		}

		private void Cancel()
		{

		}
	}
}
