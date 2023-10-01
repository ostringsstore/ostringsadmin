using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto;
using OstringsAdmin.Services;
using OstringsAdmin.Dto.Requests;

namespace OstringsAdmin.Pages
{
    public partial class ProductPage
    {
        private Product product;
        private List<ProductProvider> providers;
        private bool hasError;
        private string? errorMessage;
        private bool isProvidersCollapsed = true;
        private bool isLocationsCollapsed = true;
        private bool isProvidersTableVisible = true;

        [Inject] public ProductsService ProductsService { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public string productId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await ProductsService.GetProduct(Guid.Parse(productId));

                if (response.IsSucces)
                {
                    product = response.Data;
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

        private void CreateProductProvider()
        {
            isProvidersTableVisible = false;
        }


    }
}
