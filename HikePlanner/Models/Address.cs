namespace Models
{
    public class Address
    {
        public Address() { }

        public Address(Address address)
        {
            Street = address.Street;
            City = address.City;
            State = address.State;
            Zipcode = address.Zipcode;
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}