using Microsoft.AspNetCore.Components;
using OstringsAdmin.Dto.Requests;
using OstringsAdmin.Dto;
using System.Xml.Linq;

namespace OstringsAdmin.Components
{
	public partial class EntryItemForm
	{
		private List<ProductRequest> filteredProducts = new List<ProductRequest>();
		private bool isProductsVisible = false;

		private string searchText;


		[Parameter] public InventoryItemRequest Item { get; set; }
		[Parameter] public List<Product> Products { get; set; }

		[Parameter] public EventCallback OnSave { get; set; }

		[Parameter] public EventCallback OnCancel { get; set; }

		protected override void OnInitialized()
		{
			Item.Product = new ProductRequest();
			filteredProducts = Products.Select(p => MapProductRequest(p)).ToList();
			base.OnInitialized();
		}

		private ProductRequest MapProductRequest(Product p)
		{
			return new ProductRequest()
			{
				Name = p.Name,
				Reference = p.Reference,
				Id = p.Id,
				DistributionPrice = p.DistributionPrice,
			};
		}

		private void SelectProduct(ProductRequest product)
		{
			searchText = product.Name;
			isProductsVisible = false;
			Item.ProductId = product.Id;
			Item.Product = product;
		}

		private void FilterProducts(ChangeEventArgs e)
		{
			isProductsVisible = true;
			
			if (e == null || e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
			{
				filteredProducts = Products.Select(p => MapProductRequest(p)).ToList();
			}
			else
			{
				filteredProducts = Products.Where(p => p.Reference.ToUpper().Contains(e.Value.ToString().ToUpper()) || p.Name.ToUpper().Contains(e.Value.ToString().ToUpper())).Select(p => MapProductRequest(p)).ToList();
			}
		}

		private void FocusSerarch(EventArgs e)
		{
			isProductsVisible = true;
		}

		private async Task HandleValidSubmit()
		{
			await OnSave.InvokeAsync();
		}

		private async Task HandleReset()
		{
			await OnCancel.InvokeAsync();
		}
	}
}
