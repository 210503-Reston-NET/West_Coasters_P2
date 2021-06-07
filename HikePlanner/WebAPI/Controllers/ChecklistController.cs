using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistBL _checklistBL;
        
        public ChecklistController(IChecklistBL checklistBL)
        {
            _checklistBL = checklistBL;
        }
        /// <summary>
        /// Gets all Checklists
        /// GET api/<ChecklistController>
        /// </summary>
        /// <returns>list of checklists</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_checklistBL.GetAllChecklists());
        }
        /// <summary>
        /// GET api/<ChecklistController>/5
        /// Gets a checklist by its id
        /// </summary>
        /// <param name="id">checklist id</param>
        /// <returns>found checklist</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok(_checklistBL.GetChecklistById(id));
        }

        /// <summary>
        /// POST api/<ChecklistController>
        /// Create new checklist
        /// </summary>
        /// <param name="value">checklist obj to be created</param>
        [HttpPost]
        public IActionResult Post([FromBody] Checklist checklist)
        {
            return Created("api/Checklist", _checklistBL.CreateNewChecklist(checklist));
        }

        // PUT api/<ChecklistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChecklistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
