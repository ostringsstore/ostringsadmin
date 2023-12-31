﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using OstringsAdmin.Services;
using OstringsAdmin.Dto;

namespace OstringsAdmin.Pages
{
	public partial class EntriesPage
	{
		private List<InventoryItem> entries;
		private List<InventoryItem> filteredEntries;
		private bool hasError;
		private bool isDateFilterVisible = false;
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
					filteredEntries = entries;
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
				filteredEntries = entries.Where(e=>e.CreateAt.Date ==  date.Date).ToList();
			}
		}

		private void OpenDatePicker()
		{
			isDateFilterVisible = true;
		}

		private void ResetFilters()
		{
			isDateFilterVisible = false;
			filteredEntries = entries;
		}

		private void TableClicked()
		{
			isDateFilterVisible = false;
		}

		private void CreateEntry()
		{
			NavigationManager.NavigateTo("/Crear-Entrada");
		}
	}
}
