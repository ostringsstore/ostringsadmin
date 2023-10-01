using Microsoft.AspNetCore.Components;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OstringsAdmin.Pages
{
    public partial class UsersPage
    {
        private List<User> users;
        private bool hasError;
        private string? errorMessage;

        [Inject] public UsersService UsersService { get; set; }

        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;

            if (isUserAuthenticated.HasValue && isUserAuthenticated.Value)
            {
                var response = await UsersService.GetUsers();

                if (response.IsSucces)
                {
                    users = response.Data;
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
