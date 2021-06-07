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
        /// <summary>
        /// Add address Method to add address against user id
        /// </summary>
        /// <param name="id"></param> user id which is Guid string
        /// <param name="adressToAdd"></param> object to add in address
        /// <returns></returns>
        public Address AddAddress(string id, Address adressToAdd);
        public Address GetAddressById(int id);
        public Address UpdateAddress(Address newAddress);
        public Address DeleteAddress(Address address);
    }
}
