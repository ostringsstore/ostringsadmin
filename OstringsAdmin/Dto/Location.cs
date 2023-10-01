namespace OstringsAdmin.Dto
{
    public class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumer { get; set; }
        public string FullName => $"{Name} - {Address}";
    }
}
