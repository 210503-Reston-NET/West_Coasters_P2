using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class ChecklistRepo : IChecklistRepo
    {
        private readonly AppDBContext _context;
        public ChecklistRepo(AppDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a new checklist object in db
        /// </summary>
        /// <param name="checklist">the checklist obj to be added</param>
        /// <returns>checklist obj that has been created</returns>
        public async Task<Checklist> CreateNewChecklistAsync(Checklist checklist)
        {
            Checklist added = _context.Checklists.Add(checklist).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return added;
        }
        /// <summary>
        /// Creates new checklist item associated to a checklist
        /// </summary>
        /// <param name="item">checklistItem to be added</param>
        /// <returns>created checklistItem</returns>
        public async Task<ChecklistItem> CreateNewChecklistItemAsync(ChecklistItem item)
        {
            ChecklistItem added = _context.ChecklistItems.Add(item).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return added;
        }

        /// <summary>
        /// Delete selected checklist
        /// Takes the id of the checklist to be deleted
        /// And gets the state of the object from the ChangeTracker
        /// If it is "Deleted" return true
        /// If it's anything else, return false
        /// </summary>
        /// <param name="id">Id of the checklist to be deleted</param>
        /// <returns>Boolean, true for operation successful, false for something went wrong</returns>
        public async Task<bool> DeleteChecklistAsync(int id)
        {
            Checklist toDelete = new();
            toDelete.Id = id;
            bool successful = _context.Checklists.Remove(toDelete).State.ToString() == "Deleted" ? true : false;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return successful;
        }
        /// <summary>
        /// Delete a ChecklistItem
        ///Takes the id of the checklistItem to be deleted
        /// And gets the state of the object from the ChangeTracker
        /// If it is "Deleted" return true
        /// If it's anything else, return false
        /// </summary>
        /// <param name="id">The id fo the checklist item to be deleted</param>
        public async Task<bool> DeleteChecklistItemAsync(int id)
        {
            ChecklistItem toDelete = new();
            toDelete.Id = id;
            bool successful = _context.ChecklistItems.Remove(toDelete).State.ToString() == "Deleted" ? true : false;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return successful;
        }

        /// <summary>
        /// Get all checklists in db
        /// </summary>
        /// <returns>List of all checklists</returns>
        public async Task<List<Checklist>> GetAllChecklistsAsync()
        {
            return await _context.Checklists
                .AsNoTracking()
                .Include(i => i.ChecklistItems)
                .ThenInclude(i => i.Equipment)
                .ToListAsync();
        }
        /// <summary>
        /// Finds the first checklist with the given id
        /// </summary>
        /// <param name="id">checklist id to be searched for</param>
        /// <returns>If found, found checklist, null if not found</returns>
        public async Task<Checklist> GetChecklistByIdAsync(int id)
        {
            return await _context.Checklists
                .AsNoTracking()
                .Include(i => i.ChecklistItems)
                .ThenInclude(i => i.Equipment)
                .FirstOrDefaultAsync(list => list.Id == id);
        }

        public async Task<List<Checklist>> GetChecklistByUserIdAsync(string userId)
        {
            return await _context.Checklists
                .AsNoTracking()
                .Where(list => list.Creator == userId)
                .Include(i => i.ChecklistItems)
                .ThenInclude(i => i.Equipment)
                .ToListAsync();
        }
        /// <summary>
        /// Fetch the first checklistItem that matches the id param
        /// </summary>
        /// <param name="itemId">ChecklsitItem id</param>
        /// <returns>Found ChecklistItem. If none is found, null</returns>
        public async Task<ChecklistItem> GetChecklistItemByIdAsync(int itemId)
        {
            return await _context.ChecklistItems
                .AsNoTracking()
                .Include("Equipment")
                .FirstOrDefaultAsync(item => item.Id == itemId);
        }
        /// <summary>
        /// Gets all checklistItems associated to the checklist Id.
        /// </summary>
        /// <param name="checklistId">Checklist Id</param>
        /// <returns>List of checklist items associated to the checklist id</returns>
        public async Task<List<ChecklistItem>> GetChecklistItemsByChecklistIdAsync(int checklistId)
        {
            return await _context.ChecklistItems
                .AsNoTracking()
                .Where(item => item.ChecklistId == checklistId)
                .Include("Equipment")
                .ToListAsync();
        }

        /// <summary>
        /// Update a checklist
        /// </summary>
        /// <param name="checklist">the checklist to be updated (with the updated info)</param>
        /// <returns>updated checklist</returns>
        public async Task<Checklist> UpdateChecklistAsync(Checklist checklist)
        {
            Checklist updated = _context.Checklists.Update(checklist).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }

        public async Task<ChecklistItem> UpdateChecklistItemAsync(ChecklistItem item)
        {
            ChecklistItem updated = _context.ChecklistItems.Update(item).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }
    }
}
