using DL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRepo _addressRepo;
        public AddressBL(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }
        public Address AddAddress(string id, Address adressToAdd)
        {
            return _addressRepo.AddAddress(id, adressToAdd);
        }

        public Address DeleteAddress(Address address)
        {
            return _addressRepo.DeleteAddress(address);
        }

        public Address GetAddressById(int id)
        {
            return _addressRepo.GetAddressById(id);
        }

        public Address UpdateAddress(Address newAddress)
        {
            return _addressRepo.UpdateAddress(newAddress);
        }
    }
}
