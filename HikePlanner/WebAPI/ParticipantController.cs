using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI
{
    [Route("api/Trips/{tripId}/Participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ITripBL _tripBL;

        public ParticipantController(ITripBL tripBL)
        {
            _tripBL = tripBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParticipantsByTripIdAsync(int tripId)
        {
            return Ok(await _tripBL.GetAllParticipantsByTripIdAsync(tripId));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewParticipantAsync(int tripId, [FromBody] Participant newParticipant)
        {
            return Created($"/api/Trips/{tripId}/Participants", await _tripBL.AddNewParticipantAsync(newParticipant));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipantAsync(int id, [FromBody] Participant updateParticipant)
        {
            await _tripBL.UpdateParticipantAsync(updateParticipant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantAsync(int id)
        {
             await _tripBL.DeleteParticipantAsync(await _tripBL.GetParticipantById(id));
            return NoContent();
        }
    }
}