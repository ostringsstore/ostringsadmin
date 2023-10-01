namespace OstringsAdmin.Dto
{
	public class InventoryEntry
	{
        public Guid Id { get; set; }
		public Guid ProviderId { get; set; }
		public Provider Provider { get; set; }
		public double TotalAmount { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
