using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Pages
{
	public partial class EntriesPage
	{
        private List<InventoryItem> entries;
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
                var response = await EntriesService.GetEntries();

                if (response.IsSucces)
                {
                    entries = response.Data;
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

        private void CreateEntry()
        {
            NavigationManager.NavigateTo("/Crear-Entrada");
        }
    }
}
