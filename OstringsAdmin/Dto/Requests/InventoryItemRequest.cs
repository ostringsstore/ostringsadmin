using System.ComponentModel.DataAnnotations;

namespace OstringsAdmin.Dto.Requests
{
    public class InventoryItemRequest
    {
        private const string obligatoryField = "Campo obligatorio";

        [Required(ErrorMessage = obligatoryField)]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = obligatoryField)]
        public string Details { get; set; }

        public bool IsCredit { get; set; }

		[Required(ErrorMessage = obligatoryField)]
		public Guid? ProductId { get; set; }

        public ProductRequest Product { get; set; }

        public InventoryItemRequest Clone()
        {
            var item = (InventoryItemRequest)MemberwiseClone();
            item.Product = Product.Clone();
            return item;
        }

    }
}
