namespace OstringsAdmin.Dto.Requests
{
	public class OrderRequest
	{
		public double TotalPrice { get; set; }
		public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
		public string LastName { get; set; }
		public string Document { get; set; }
		public string? Phone { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string AddresValue { get; set; }
		public string AddressPhoneNumber { get; set; }
		public string ContactPerson { get; set; }
	}
}
