using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IAddressRepo
    {
    Task<Address> AddAddressAsync(string userId, Address adressToAdd);
    Task<Address> GetAddressByIdAsync(int id);
    Task<Address> UpdateAddressAysncAsync(Address newAddress);
    Task DeleteAddressAsync(Address address);
    }
}
