using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Models
{
    public class User
    {
        private string _name;
        public User() {}

        public User(User user)
        {
            UserId = user.UserId;
            Name = user.Name;
            Email = user.Email;
            Phone = user.Phone;
            Password = user.Password;
            AddressId = user.AddressId;
        }

        //ToDo: Comeback after Auth0
        //For now, use Guid.NewGuid().ToString() to get unique user Id
        public string UserId { get; set; }
        public string Name { get { return _name; } set {
                if (value.Length == 0)
                {
                    throw new Exception("Name cannot be empty");
                }
                //if (!Regex.IsMatch(value, @"^[0-9A-Za-z@ .-]+$"))
                //{
                //    throw new Exception("Name is not valid");
                //}
                _name = value;
            } }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}