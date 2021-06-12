using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UsersRepo : IUsersRepo
    {
        private readonly AppDBContext _context;
        public UsersRepo(AppDBContext context, IAddressRepo addressRepo)
        {
            _context = context;
            
        }
        /// <summary>
        /// get all users method
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = await _context.Users
                .AsNoTracking()
                //.Include(u => u.Address)
                .ToListAsync();
            users.ForEach(u => u.Address = (u.AddressId != 0 ? _context.Address.Find(u.AddressId) : null));
            return users;
        }

        /// <summary>
        /// Add user method with the auto generated Guid unique string
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User user)
        {
            User AddedUser =  _context.Users.Add(user).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return AddedUser;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            User UserFound = await _context.Users.FirstOrDefaultAsync(user=> user.UserId == id);
            UserFound.Address = (UserFound.AddressId != 0 ? _context.Address.Find(UserFound.AddressId) : null);
            return UserFound;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            User UserFound = await _context.Users.FirstOrDefaultAsync(user=> user.Email == email);
            UserFound.Address = (UserFound.AddressId != 0 ? _context.Address.Find(UserFound.AddressId) : null);
            return UserFound;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            User userToBeDeleted = _context.Users.First(us=> us.UserId == user.UserId);
            _context.Remove(userToBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return user;
        }
        public async Task<User> UpdateUserAsync(User userToUpdate)
        {
            User updated = _context.Users.Update(userToUpdate).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }
    }
}
