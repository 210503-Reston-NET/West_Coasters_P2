using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[Route("api/activities/{activityId}/trips")]
    [Route("api/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripBL _tripBL;

        public TripController(ITripBL tripBL)
        {
            _tripBL = tripBL;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllTripsAsync()
        {
            return Ok(await _tripBL.GetAllTripsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripByIdAsync(int id)
        {
            return Ok(await _tripBL.GetTripByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTripAsync([FromBody] Trip newTrip)
        {
            return Created("api/Trip", await _tripBL.AddNewTripAsync(newTrip));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTripAsync(int id, [FromBody] Trip updateTrip)
        {
            await _tripBL.UpdateTripAsync(updateTrip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripAsync(int id)
        {
             await _tripBL.DeleteTripAsync(await _tripBL.GetTripByIdAsync(id));
            return NoContent();
        }
    }
}