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
        private readonly IUsersRepo _userRepo;

        public UsersBL(IUsersRepo usersRepo)
        {
            _userRepo = usersRepo;
           // _actRepo = actRepo;
        }
        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepo.AddUserAsync(user);
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            return await _userRepo.DeleteUserAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = await _userRepo.GetAllUsersAsync();
            return users;
        } 

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepo.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(User userToUpdate)
        {
            return await _userRepo.UpdateUserAsync(userToUpdate);
        }
    }
}
