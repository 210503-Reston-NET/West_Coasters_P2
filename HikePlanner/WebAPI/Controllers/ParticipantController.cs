using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/Participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ITripBL _tripBL;

        public ParticipantController(ITripBL tripBL)
        {
            _tripBL = tripBL;
        }

        [HttpGet("trip/{tripId}")]
        public async Task<IActionResult> GetAllParticipantsByTripIdAsync(int tripId)
        {
            return Ok(await _tripBL.GetAllParticipantsByTripIdAsync(tripId));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewParticipantAsync([FromBody] Participant newParticipant)
        {
            return Created($"/api/Participants", await _tripBL.AddNewParticipantAsync(newParticipant));
        }
        /// <summary>
        /// Update Participants by its id
        /// </summary>
        /// <param name="id">Participant Id</param>
        /// <param name="updateParticipant">info to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipantAsync(int id, [FromBody] Participant updateParticipant)
        {
            await _tripBL.UpdateParticipantAsync(updateParticipant);
            return NoContent();
        }
        /// <summary>
        /// Participant id
        /// </summary>
        /// <param name="id">participant Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantAsync(int id)
        {
             await _tripBL.DeleteParticipantAsync(await _tripBL.GetParticipantByIdAsync(id));
            return NoContent();
        }
    }
}