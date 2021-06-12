using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBL _usersBL;
        public UserController(IUsersBL usersBL)
        {
            _usersBL = usersBL;
        }

        /// <summary>
        /// Getting all users from User's Table
        /// </summary>
        /// <returns></returns>
        // GET: api/<UserController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _usersBL.GetAllUsersAsync());
        }

        /// <summary>
        /// Finding User from User's table by user id
        /// </summary>
        /// <param name="userId"></param> this is user id
        /// <returns></returns>
        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(string userId)
        {
            return Ok(await _usersBL.GetUserByIdAsync(userId));
        }

        /// <summary>
        /// Query user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            return Ok(await _usersBL.GetUserByEmailAsync(email));
        }

        /// <summary>
        /// Registering user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User newUser)
        {
            Guid guid = Guid.NewGuid();
            //generating Guid unique id for user which is string
            newUser.UserId = guid.ToString();
            try
            {
                return Created("api/Users", await _usersBL.AddUserAsync(newUser));
            } catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Updating user by user id which is Guid string
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userToUpdtate"></param>
        /// <returns></returns>
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] User userToUpdtate)
        {
            await _usersBL.UpdateUserAsync(userToUpdtate);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _usersBL.DeleteUserAsync(await _usersBL.GetUserByIdAsync(id));
            return NoContent();
        }
    }
}
