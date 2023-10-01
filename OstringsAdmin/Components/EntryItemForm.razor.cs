using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Services;

namespace OstringsAdmin.Components
{
    public partial class EntryItemForm
    {
        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await CateogriesService.GetCategories();

                if (response.IsSucces)
                {
                    categories = response.Data;
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
