namespace OstringsAdmin.Dto
{
	public class OrderItem
	{
		public double UnitPrice { get; set; }
		public int Quantity { get; set; }
		public double TotalPrice => UnitPrice * Quantity;
		public Guid Id { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }
        public string Detail { get; set; }

        public Guid OrderId { get; set; }
		public Order Order { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
