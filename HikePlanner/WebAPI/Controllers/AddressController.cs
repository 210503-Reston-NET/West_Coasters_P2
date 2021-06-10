using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// https://localhost:5001/api/Equipments
namespace WebAPI.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL _addressBL;
        public AddressController(IAddressBL addressBL)
        {
            _addressBL = addressBL;
        }
        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressByIdAsync(int id)
        {
            return Ok(await _addressBL.GetAddressByIdAsync(id));
        }
        /// <summary>
        /// this Method is adding address of a user against userId
        /// </summary>
        /// <param name="id"></param> this is the userid to which we are going to insert the address id
        /// <param name="adressToAdd"></param> this is the address with street, city, state and zipcode params
        /// <returns></returns> returns the created address
        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> AddAddressAsync(string userId, [FromBody] Address adressToAdd)
        {
            return Created("api/Users/{userId}/Address",await _addressBL.AddAddressAsync(userId, adressToAdd));
        }

        /// <summary>
        /// This method is created to update the address against address id which we can get from user
        /// table
        /// </summary>
        /// <param name="id"></param> Id of address table
        /// <param name="addressToUpdate"></param> form data to update address
        /// <returns></returns>

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Address addressToUpdate)
        {
            await _addressBL.UpdateAddressAysncAsync(addressToUpdate);
            return NoContent();
        }

        /// <summary>
        /// This method is deleting address from address table by using address id which we can get 
        /// from users table by AddressId
        /// </summary>
        /// <param name="id"></param> Id of address table
        /// <returns></returns>
        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _addressBL.DeleteAddressAsync(await _addressBL.GetAddressByIdAsync(id));
            return NoContent();
        }
    }
}
