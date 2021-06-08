using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/Trips/{tripId}/Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBL _postBL;

        public PostController(IPostBL postBL)
        {
            _postBL = postBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsByTripIdAsync(int tripId)
        {
            return Ok(await _postBL.GetAllPostsByTripIdAsync(tripId));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNewPostAsync(int tripId, [FromBody] Post newPost)
        {
            return Created($"/api/Trips/{tripId}/Posts", await _postBL.AddNewPostAsync(newPost));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] Post updatePost)
        {
            await _postBL.UpdatePostAsync(updatePost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
             await _postBL.DeletePostAsync(await _postBL.GetPostByIdAsync(id));
            return NoContent();
        }
    }
}