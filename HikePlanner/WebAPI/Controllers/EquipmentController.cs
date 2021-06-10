using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

//https://localhost:5001/api/Equipments

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Equipments")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentBL _equipmentBL;

        public EquipmentController(IEquipmentBL equipmentBL)
        {
            _equipmentBL = equipmentBL;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllEquipmentsAsync()
        {
            return Ok(await _equipmentBL.GetAllEquipmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipmentByIdAsync(int id)
        {
            return Ok(await _equipmentBL.GetEquipmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEquipmentAsync([FromBody] Equipment newEquipment)
        {
            return Created("api/Equipment", await _equipmentBL.AddEquipmentAsync(newEquipment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipmentAsync(int id, [FromBody] Equipment updateEquipment)
        {
            await _equipmentBL.UpdateEquipmentAsync(updateEquipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentAsync(int id)
        {
            await _equipmentBL.DeleteEquipmentAsync(await _equipmentBL.GetEquipmentByIdAsync(id));
            return NoContent();
        }

    }
}