﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL _iAddressBL;
        public AddressController(IAddressBL addressBL)
        {
            _iAddressBL = addressBL;
        }
        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            return Ok(_iAddressBL.GetAddressById(id));
        }
        /// <summary>
        /// this Method is adding address of a user against userId
        /// </summary>
        /// <param name="id"></param> this is the userid to which we are going to insert the address id
        /// <param name="adressToAdd"></param> this is the address with street, city, state and zipcode params
        /// <returns></returns> returns the created address
        // POST api/<AddressController>
        [HttpPost]
        public IActionResult AddAddress(string id, [FromBody] Address adressToAdd)
        {
            return Created("api/Address", _iAddressBL.AddAddress(id, adressToAdd));
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
        public IActionResult Put(int id, [FromBody] Address addressToUpdate)
        {
            _iAddressBL.UpdateAddress(addressToUpdate);
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
        public IActionResult Delete(int id)
        {
            _iAddressBL.DeleteAddress(_iAddressBL.GetAddressById(id));
            return NoContent();
        }
    }
}
