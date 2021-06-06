namespace Models
{
    public class User
    {
        public User()
        {}

        public User(User user)
        {
            UserId = user.UserId;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
        }

        //ToDo - confirm id field name : UUId vs UserId
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }

    }
}