using System.ComponentModel.DataAnnotations;

namespace OstringsAdmin.Dto.Requests
{
    public class InventoryEntryRequest
    {
        private const string obligatoryField = "Campo obligatorio";
        [Required(ErrorMessage = obligatoryField)]
        public Guid? ProviderId { get; set; }
        public bool IsCredit { get; set; }
        public List<InventoryItemRequest> Items { get; set; }
    }
}
