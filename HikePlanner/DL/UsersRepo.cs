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
        public List<User> GetAllUsers()
        {
            List<User> users = _context.Users
                .AsNoTracking()
                .Select(user=> user)
                .ToList();
            return users;
        }
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
            User userToBeDeleted = _context.Users.FirstOrDefault(user=> user.UserId == user.UserId);
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
