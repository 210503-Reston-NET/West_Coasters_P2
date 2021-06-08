using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAddressBL
    {
        Task<Address> AddAddressAsync(string userId, Address adressToAdd);
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> UpdateAddressAysncAsync(Address newAddress);
        Task DeleteAddressAsync(Address address);
    }
}
