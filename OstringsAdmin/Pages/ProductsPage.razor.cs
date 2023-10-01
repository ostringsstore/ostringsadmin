using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Pages
{
    public partial class ProductsPage
    {
        private List<Product> products;
        private bool hasError;
        private string? errorMessage;

        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public ProductsService ProductsService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await ProductsService.GetProducts();

                if (response.IsSucces)
                {
                    products = response.Data;
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

        private void CreateProduct()
        {
            NavigationManager.NavigateTo("/Crear-Producto");
        }

        private void ProductNavigate(Guid productId)
        {
            NavigationManager.NavigateTo($"/Productos/{productId}");
        }
    }
}
