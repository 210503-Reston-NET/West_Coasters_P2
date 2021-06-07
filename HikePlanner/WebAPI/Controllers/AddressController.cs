using Microsoft.AspNetCore.Mvc;
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
        // POST api/<AddressController>
        [HttpPost]
        public IActionResult AddAddress(string id, [FromBody] Address adressToAdd)
        {
            return Created("api/Address", _iAddressBL.AddAddress(id, adressToAdd));
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Address addressToUpdate)
        {
            _iAddressBL.UpdateAddress(addressToUpdate);
            return NoContent();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _iAddressBL.DeleteAddress(_iAddressBL.GetAddressById(id));
            return NoContent();
        }
    }
}
