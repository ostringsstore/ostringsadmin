using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Pages
{
	public partial class SalesPage
	{
		private List<OrderItem> orders;
		private List<OrderItem> filteredOrders;
		private bool hasError;
		private bool isDateFilterVisible = false;
		private string? errorMessage;

		[Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject] public NavigationManager NavigationManager { get; set; }

		[Inject] public OrdersService OrdersService { get; set; }

		protected async override Task OnInitializedAsync()
		{
			var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

			if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
			{
				var response = await OrdersService.GetOrders();

				if (response.IsSucces)
				{
					orders = response.Data;
					filteredOrders = orders;
				}
				else
				{
					hasError = true;
					errorMessage = response.CustomErrors?.FirstOrDefault()?.Description;
				}
			}
			else
			{
				NavigationManager.NavigateTo("/Identity/Account/Login");
			}
		}

		private void FiterDate(ChangeEventArgs e)
		{
			isDateFilterVisible = false;
			if (DateTime.TryParse(e.Value?.ToString(), out DateTime date))
			{
				filteredOrders = orders.Where(e => e.CreateAt.Date == date.Date).ToList();
			}
		}

		private void OpenDatePicker()
		{
			isDateFilterVisible = true;
		}

		private void ResetFilters()
		{
			isDateFilterVisible = false;
			filteredOrders = orders;
		}

		private void TableClicked()
		{
			isDateFilterVisible = false;
		}

		private void CreateOrder()
		{
			NavigationManager.NavigateTo("/Crear-Orden");
		}
	}
}
