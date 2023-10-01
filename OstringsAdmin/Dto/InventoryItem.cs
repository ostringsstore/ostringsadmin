
namespace OstringsAdmin.Dto
{
	public class InventoryItem
	{
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
		public Guid InventoryEntryId { get; set; }
		public InventoryEntry InventoryEntry { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }

		public int Quantity { get; set; }
		public int PayedQuantity { get; set; }
		public int OutstandingQuantity { get; set; }
		public double UnitPrice { get; set; }
        public string Details { get; set; }
    }
}
