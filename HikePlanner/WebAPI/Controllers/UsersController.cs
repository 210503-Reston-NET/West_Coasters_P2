using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBL _iusersBL;
        public UsersController(IUsersBL usersBL)
        {
            _iusersBL = usersBL;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetAllUsers()
        {
            return Ok(_iusersBL.GetAllUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public IActionResult GetUserById(string userId)
        {
            return Ok(_iusersBL.GetUserById(userId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            Guid guid = Guid.NewGuid();
            newUser.UserId = guid.ToString();
            return Created("api/Users",_iusersBL.AddUser(newUser));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] User userToUpdtate)
        {
            _iusersBL.UpdateUser(userToUpdtate);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _iusersBL.DeleteUser(_iusersBL.GetUserById(id));
            return NoContent();
        }
    }
}
