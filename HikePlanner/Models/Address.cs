using System;

namespace Models
{
    public class Address
    {
        public Address()
        {}
        
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}
