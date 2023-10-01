using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace OstringsAdmin.Pages
{
	public partial class EntryForm
	{
		private List<Provider> providers;
		private List<Product> products;
		private Guid selectedProvider;
		private int isCredit;
		private InventoryEntryRequest inventoryEntry = new InventoryEntryRequest();
		private InventoryItemRequest inventoryItem = new InventoryItemRequest();
		private List<InventoryItemRequest> inventoryItems = new List<InventoryItemRequest>();
		private bool hasError;
		private string? errorMessage;
		private bool isFormVisible;
		private bool isValidProvider = true;
		private bool isAnyItem = true;

		[Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject] public NavigationManager NavigationManager { get; set; }

		[Inject] public EntriesService EntriesService { get; set; }
		[Inject] public ProductsService ProductsService { get; set; }


		protected async override Task OnInitializedAsync()
		{
			if (await ValidateAuth())
			{
				var providersResponse = await EntriesService.GetProviders();

				if (providersResponse.IsSucces)
				{
					providers = providersResponse.Data;
				}
				else
				{
					hasError = true;
					errorMessage = providersResponse.CustomErrors?.FirstOrDefault()?.Description;
				}

				var productsResponse = await ProductsService.GetProducts();

				if (productsResponse.IsSucces)
				{
					products = productsResponse.Data;
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

		private async void Confirm()
		{
			if (await ValidateAuth())
			{
				Validate();
				if (isAnyItem && isValidProvider)
				{
					var entryResponse = await EntriesService.SaveEntry(selectedProvider, isCredit, inventoryItems);

					if (!entryResponse.IsSucces)
					{
						hasError = true;
						errorMessage = entryResponse.CustomErrors?.FirstOrDefault()?.Description;
					}
				}
			}
		}

		private bool Validate()
		{
			bool isValid = true;
			if (!providers.Any(p => p.Id == selectedProvider))
			{
				isValidProvider = false;
			}

			if (!inventoryItems.Any())
			{
				isAnyItem = false;
			}
			return isValid;
		}

		private async void Cancel()
		{
			NavigationManager.NavigateTo("/Entradas");
		}

		private void NewItem()
		{
			inventoryItem = new InventoryItemRequest();
			isFormVisible = true;
		}

		private void AddItem()
		{
			inventoryItems.Add(inventoryItem.Clone());
			CloseForm();
		}

		private void CloseForm()
		{
			inventoryItem = new InventoryItemRequest();
			isFormVisible = false;
		}

		private async Task<bool> ValidateAuth()
		{
			var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
			var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

			return isUserAuthenticated.HasValue && isUserAuthenticated.Value;
		}
	}
}
