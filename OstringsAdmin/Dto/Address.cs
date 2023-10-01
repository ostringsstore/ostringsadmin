
namespace OstringsAdmin.Dto
{
	public class Address
	{
		public Guid Id { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime ÚpdateAt { get; set; }
		public string AddresValue { get; set; }
		public string PhoneNumber { get; set; }
		public string ContactPerson { get; set; }
		public Guid UserId { get; set; }
	}
}
