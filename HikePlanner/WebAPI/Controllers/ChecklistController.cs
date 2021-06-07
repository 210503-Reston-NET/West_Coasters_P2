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
        /// first, get the checklist by its id
        /// and then grab all its items and fill it in
        /// </summary>
        /// <param name="id">checklist id</param>
        /// <returns>found checklist</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Checklist checklist = _checklistBL.GetChecklistById(id);
            checklist.ChecklistItems = _checklistBL.GetChecklistItemsByChecklistId(checklist.Id);
            return Ok(checklist);
        }

        /// <summary>
        /// POST api/<ChecklistController>
        /// Creates new checklist
        /// </summary>
        /// <param name="value">checklist obj to be created</param>
        [HttpPost]
        public IActionResult Post([FromBody] Checklist checklist)
        {
            return Created("api/Checklist", _checklistBL.CreateNewChecklist(checklist));
        }

        /// <summary>
        /// Updates existing checklist
        /// PUT api/<ChecklistController>/5
        /// </summary>
        /// <param name="id">checklsit Id</param>
        /// <param name="value">checklist to be updated</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Checklist checklist)
        {
            return Ok(_checklistBL.UpdateChecklist(checklist));
        }

        /// <summary>
        /// DELETE api/<ChecklistController>/5
        /// Deletes the checklist with the passed Id
        /// </summary>
        /// <param name="id">checklist Id</param>
        /// <returns>Bool, true when successful</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_checklistBL.DeleteChecklist(id));
        }

        /// <summary>
        /// GET api/<ChecklistController>/5/item/5
        /// Gets one checklist item by id that belong in a checklist
        /// </summary>
        /// <param name="listId">checklist id</param>
        /// <param name="itemId">checklist item id</param>
        /// <returns>found checklist</returns>
        [HttpGet("{listId}/item/{itemId}")]
        public IActionResult Get(int listId, int itemId)
        {
            return Ok(_checklistBL.GetChecklistItemById(itemId));
        }

        /// <summary>
        /// POST api/<ChecklistController>/item
        /// Creates new checklist item
        /// </summary>
        /// <param name="listId">checklist item obj to be created</param>
        /// <param name="checklistItem"/>checklist item to be created</param>
        [HttpPost("{listId}/item")]
        public IActionResult Post(int listId, [FromBody] ChecklistItem checklistItem)
        {
            return Created("api/Checklist", _checklistBL.CreateNewChecklistItem(checklistItem));
        }

        /// <summary>
        /// Updates existing checklist item
        /// PUT api/<ChecklistController>/5/item/5
        /// </summary>
        /// <param name="listId">checklsit Id</param>
        /// <param name="itemId"/>checklist item id</param>
        /// <param name="checklistItem">checklist item to be updated</param>
        [HttpPut("{listId}/item/{itemId}")]
        public IActionResult Put(int listId, int itemId, [FromBody] ChecklistItem checklistItem)
        {
            return Ok(_checklistBL.UpdateChecklistItem(checklistItem));
        }

        /// <summary>
        /// DELETE api/<ChecklistController>/5/item/5
        /// Deletes the checklist with the passed Id
        /// </summary>
        /// <param name="listId">checklist Id</param>
        /// <param name="itemId">checklist item id</param>
        /// <returns>Bool, true when successful</returns>
        [HttpDelete("{listId}/item/{itemId}")]
        public IActionResult Delete(int listId, int itemId)
        {
            return Ok(_checklistBL.DeleteChecklistItem(itemId));
        }
    }
}
