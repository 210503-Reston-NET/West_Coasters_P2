using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    //[Route("api/Users/{userId}/Activities")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBL _activityBL;

        public ActivityController(IActivityBL activityBL)
        {
            _activityBL = activityBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivitiessAsync()
        {
            return Ok(await _activityBL.GetAllActivitiessAsync());
        }
        
        //Get all activity by creator
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetAllActivitisByCreatorAsync(string userId)
        {
            return Ok(await _activityBL.GetAllActivitisByCreatorAsync(userId));
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityByIdAsync(int id)
        {
            return Ok(await _activityBL.GetActivityByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewActivityAsync([FromBody] Activity newActivity)
        {
            return Created($"/api/Activity", await _activityBL.AddNewActivityAsync(newActivity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivityAsync(int id, [FromBody] Activity updateActivity)
        {
            await _activityBL.UpdateActivityAsync(updateActivity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityAsync(int id)
        {
             await _activityBL.DeleteActivityAsync(await _activityBL.GetActivityByIdAsync(id));
            return NoContent();
        }
    }
}