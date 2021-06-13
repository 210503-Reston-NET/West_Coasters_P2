using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;

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
        public async Task<IActionResult> GetAsync()
        {
            Log.Information("GET api/Checklist");
            return Ok(await _checklistBL.GetAllChecklistsAsync());
        }
        /// <summary>
        /// GET api/<ChecklistController>/5
        /// first, get the checklist by its id
        /// and then grab all its items and fill it in
        /// </summary>
        /// <param name="id">checklist id</param>
        /// <returns>found checklist</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Log.Information("GET api/Checklist/{id}", id);
            return Ok(await _checklistBL.GetChecklistByIdAsync(id));
        }
        
        /// <summary>
        /// Grabs all checklist by User Id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>list of checklists</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAsync(string userId)
        {
            Log.Information("Getting all checklists by userId, {userId}", userId);
            return Ok(await _checklistBL.GetChecklistByUserIdAsync(userId));
        }

        /// <summary>
        /// POST api/<ChecklistController>
        /// Creates new checklist
        /// </summary>
        /// <param name="value">checklist obj to be created</param>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Checklist checklist)
        {
            Log.Information("Reached Controller POST api/Checklist");
            Log.Information("Received following item: {Checklist}", checklist);
            return Created("api/Checklist", await _checklistBL.CreateNewChecklistAsync(checklist));
        }

        /// <summary>
        /// Updates existing checklist
        /// PUT api/<ChecklistController>/5
        /// </summary>
        /// <param name="id">checklsit Id</param>
        /// <param name="value">checklist to be updated</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Checklist checklist)
        {
            Log.Information("Reached Controller PUT api/Checklist/{id}", id);
            Log.Information("Received following item: {Checklist}", checklist);
            return Ok(await _checklistBL.UpdateChecklistAsync(checklist));
        }

        /// <summary>
        /// DELETE api/<ChecklistController>/5
        /// Deletes the checklist with the passed Id
        /// </summary>
        /// <param name="id">checklist Id</param>
        /// <returns>Bool, true when successful</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information("Reached Controller DELETE api/Checklist/{id}", id);
            return Ok(await _checklistBL.DeleteChecklistAsync(id));
        }

        /// <summary>
        /// GET api/<ChecklistController>/5/item/5
        /// Gets one checklist item by id that belong in a checklist
        /// </summary>
        /// <param name="listId">checklist id</param>
        /// <param name="itemId">checklist item id</param>
        /// <returns>found checklist</returns>
        [HttpGet("{listId}/item/{itemId}")]
        public async Task<IActionResult> GetAsync(int listId, int itemId)
        {
            return Ok(await _checklistBL.GetChecklistItemByIdAsync(itemId));
        }

        /// <summary>
        /// POST api/<ChecklistController>/5/item
        /// Creates new checklist item
        /// </summary>
        /// <param name="listId">checklist item obj to be created</param>
        /// <param name="checklistItem"/>checklist item to be created</param>
        [HttpPost("{listId}/item")]
        public IActionResult Post(int listId, [FromBody] ChecklistItem checklistItem)
        {
            return Created("api/Checklist", _checklistBL.CreateNewChecklistItemAsync(checklistItem));
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
            return Ok(_checklistBL.UpdateChecklistItemAsync(checklistItem));
        }

        /// <summary>
        /// DELETE api/<ChecklistController>/5/item/5
        /// Deletes the checklist with the passed Id
        /// </summary>
        /// <param name="listId">checklist Id</param>
        /// <param name="itemId">checklist item id</param>
        /// <returns>Bool, true when successful</returns>
        [HttpDelete("{listId}/item/{itemId}")]
        public async Task<IActionResult> DeleteAsync(int listId, int itemId)
        {
            return Ok(await _checklistBL.DeleteChecklistItemAsync(itemId));
        }
    }
}
