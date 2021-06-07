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
            //Adding address to address table
            Address addedAddress = _context.Address.Add(adressToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            //Once the Adress is added we can get the address id to update user table with addressId 
            //we received after creating address row
            //getting user by user id we received in the method parameter as "string id"
            User user = _context.Users.FirstOrDefault(us => us.UserId == id);

            //adding address id to user model 
            user.AddressId = addedAddress.Id;
            //updating user to user table
            _context.Users.Update(user);
            //Persisting data to user's table
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return addedAddress;
        }

        /// <summary>
        /// getting the address by using address id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address GetAddressById(int id)
        {
            return _context.Address.FirstOrDefault(add => add.Id == id);
        }

        /// <summary>
        /// Updating address in Address table by Address id
        /// </summary>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        public Address UpdateAddress(Address newAddress)
        {
            _context.Address.Update(newAddress);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newAddress;
        }

        /// <summary>
        /// Deleting the address by address id
        /// we can get address id from user table while we are iteracting with the UI
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
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
