namespace OstringsAdmin.Dto
{
	public class Order
	{
		public Guid Id { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }
		public double TotalPrice { get; set; }
		public List<OrderItem> CartIiems { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }
		public Guid? AddressId { get; set; }
		public Address Address { get; set; }
		public Payment Payment { get; set; }
	}
}
