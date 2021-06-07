using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{
    public class UsersBL : IUsersBL
    {
        private readonly IUsersRepo _userrepo;
        public UsersBL(IUsersRepo usersRepo)
        {
            _userrepo = usersRepo;
        }
        public User AddUser(User user)
        {
            return _userrepo.AddUser(user);
        }

        public User DeleteUser(User user)
        {
            return _userrepo.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userrepo.GetAllUsers();
        }

        public User GetUserById(string id)
        {
            return _userrepo.GetUserById(id);
        }

        public User UpdateUser(User userToUpdate)
        {
            return _userrepo.UpdateUser(userToUpdate);
        }
    }
}
