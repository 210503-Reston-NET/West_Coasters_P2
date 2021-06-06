using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        
        [HttpPost]
        public IActionResult AddNewEquipment([FromBody] Equipment newEquipment)
        {
            return Created("api/Equipment", _equipmentBL.AddEquipment(newEquipment));
        }
    }
}