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
        public IActionResult GetAllEquipments()
        {
            return Ok(_equipmentBL.GetAllEquipments());
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipmentById(int id)
        {
            return Ok(_equipmentBL.GetEquipmentById(id));
        }

        [HttpPost]
        public IActionResult AddNewEquipment([FromBody] Equipment newEquipment)
        {
            return Created("api/Equipment", _equipmentBL.AddEquipment(newEquipment));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEquipment(int id, [FromBody] Equipment updateEquipment)
        {
            _equipmentBL.UpdateEquipment(updateEquipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEquipment(int id)
        {
             _equipmentBL.DeleteEquipment(_equipmentBL.GetEquipmentById(id));
            return NoContent();
        }

    }
}