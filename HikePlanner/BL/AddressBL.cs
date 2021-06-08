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
        public async Task<Address> AddAddressAsync(string userId, Address adressToAdd)
        {
            return await _addressRepo.AddAddressAsync(userId, adressToAdd);
        }

        public async Task DeleteAddressAsync(Address address)
        {
             await _addressRepo.DeleteAddressAsync(address);
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressRepo.GetAddressByIdAsync(id);
        }
        
        public async Task<Address> UpdateAddressAysncAsync(Address newAddress)
        {
            return await _addressRepo.UpdateAddressAysncAsync(newAddress);
        }
    }
}
