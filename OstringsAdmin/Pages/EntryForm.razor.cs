using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Pages
{
	public partial class EntryForm
	{
        private List<Provider> providers;
        private Provider selectedProvider;
        private ProductRequest productRequest = new ProductRequest();
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private bool hasError;
        private string? errorMessage;

        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public EntriesService EntriesService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await EntriesService.GetProviders();

                if (response.IsSucces)
                {
                    providers = response.Data;
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

        private async void Confirm()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await ProductsService.CreateProduct(productRequest);

                if (response.IsSucces)
                {
                    NavigationManager.NavigateTo("/Productos");
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
    }
}
