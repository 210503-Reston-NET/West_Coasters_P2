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
        public Address AddAddress(string id, Address adressToAdd);
        public Address GetAddressById(int id);
        public Address UpdateAddress(Address newAddress);
        public Address DeleteAddress(Address address);
    }
}
