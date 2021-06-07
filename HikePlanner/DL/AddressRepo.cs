using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AddressRepo:IAddressRepo
    {
        private readonly AppDBContext _context;
        public AddressRepo(AppDBContext context)
        {
            _context = context;
        }

        public Address AddAddress(string id, Address adressToAdd)
        {
            Address addedAddress = _context.Address.Add(adressToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            User user = _context.Users.FirstOrDefault(us => us.UserId == id);
            user.AddressId = addedAddress.Id;
            _context.Users.Update(user);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return addedAddress;
        }

        public Address GetAddressById(int id)
        {
            return _context.Address.FirstOrDefault(add => add.Id == id);
        }

        public Address UpdateAddress(Address newAddress)
        {
            _context.Address.Update(newAddress);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newAddress;
        }
        public Address DeleteAddress(Address address)
        {
            Address addressToBeDeleted = _context.Address.FirstOrDefault(add => add.Id == address.Id);
            _context.Remove(addressToBeDeleted);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return address;
        }
    }
}
