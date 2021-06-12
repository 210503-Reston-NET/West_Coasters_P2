using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IUsersBL
    {
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> UpdateUserAsync(User userToUpdate);
        Task<User> DeleteUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        
    }
}
