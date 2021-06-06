using System;

namespace Models
{
    public class User
    {
        public User() {}

        public User(User user)
        {
            UserId = user.UserId;
            Name = user.Name;
            Email = user.Email;
            Phone = user.Phone;
            Password = user.Password;
        }

        //ToDo: Comeback after Auth0
        //For now, use Guid.NewGuid().ToString() to get unique user Id
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
    }
}