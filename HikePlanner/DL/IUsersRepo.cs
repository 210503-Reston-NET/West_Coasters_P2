using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DL
{
    public interface IUsersRepo
    {
        public User AddUser(User user);
        public List<User> GetAllUsers();
        public User GetUserById(string id);
        public User UpdateUser(User userToUpdate);
        public User DeleteUser(User user);
    }
}
