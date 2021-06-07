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
        public UsersRepo(AppDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// get all users method
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            List<User> users = _context.Users
                .AsNoTracking()
                .ToList();
            return users;
        }
        /// <summary>
        /// Add user method with the auto generated Guid unique string
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
           User AddedUser =  _context.Users.Add(user).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return AddedUser;
        }

        public User GetUserById(string id)
        {
            User UserFound = _context.Users.FirstOrDefault(user=> user.UserId == id);
            if (UserFound == null) return null;
            return UserFound;
        }
        public User DeleteUser(User user)
        {
            User userToBeDeleted = _context.Users.FirstOrDefault(us=> us.UserId == user.UserId);
            _context.Remove(userToBeDeleted);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
           return user;
        }
        public User UpdateUser(User userToUpdate)
        {
            _context.Users
                .Update(userToUpdate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return userToUpdate;
        }
    }
}
