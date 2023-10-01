using OstringsAdmin.Enumerations;

namespace OstringsAdmin.Dto
{
	public class Payment
	{
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ÚpdateAt { get; set; }
        public double TotalPrice { get; set; }
		public PaymentStatus Status { get; set; }
		public Guid OrderId { get; set; }
		public Order Order { get; set; }
	}
}
