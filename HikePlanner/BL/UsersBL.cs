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
        public async Task<User> AddUserAsync(User user)
        {
            return await _userrepo.AddUserAsync(user);
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            return await _userrepo.DeleteUserAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userrepo.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userrepo.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(User userToUpdate)
        {
            return await _userrepo.UpdateUserAsync(userToUpdate);
        }
    }
}
