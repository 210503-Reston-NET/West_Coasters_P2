using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    class ChecklistRepo : IChecklistRepo
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
        public Checklist CreateNewChecklist(Checklist checklist)
        {
            Checklist added = _context.Checklists.Add(checklist).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return added;
        }
        /// <summary>
        /// Creates new checklist item associated to a checklist
        /// </summary>
        /// <param name="item">checklistItem to be added</param>
        /// <returns>created checklistItem</returns>
        public ChecklistItem CreateNewChecklistItem(ChecklistItem item)
        {
            ChecklistItem added = _context.ChecklistItems.Add(item).Entity;
            _context.SaveChanges();
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
        public bool DeleteChecklist(int id)
        {
            Checklist toDelete = new();
            toDelete.Id = id;
            bool successful = _context.Checklists.Remove(toDelete).State.ToString() == "Deleted" ? true : false;
            _context.SaveChanges();
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
        public bool DeleteChecklistItem(int id)
        {
            ChecklistItem toDelete = new();
            toDelete.Id = id;
            bool successful = _context.ChecklistItems.Remove(toDelete).State.ToString() == "Deleted" ? true : false;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return successful;
        }

        /// <summary>
        /// Get all checklists in db
        /// </summary>
        /// <returns>List of all checklists</returns>
        public List<Checklist> GetAllChecklists()
        {
            return _context.Checklists
                .AsNoTracking()
                .ToList();
        }
        /// <summary>
        /// Finds the first checklist with the given id
        /// </summary>
        /// <param name="id">checklist id to be searched for</param>
        /// <returns>If found, found checklist, null if not found</returns>
        public Checklist GetChecklistById(int id)
        {
            return _context.Checklists
                .AsNoTracking()
                .FirstOrDefault(list => list.Id == id);
        }
        /// <summary>
        /// Fetch the first checklistItem that matches the id param
        /// </summary>
        /// <param name="itemId">ChecklsitItem id</param>
        /// <returns>Found ChecklistItem. If none is found, null</returns>
        public ChecklistItem GetChecklistItemById(int itemId)
        {
            return _context.ChecklistItems
                .AsNoTracking()
                .FirstOrDefault(item => item.Id == itemId);
        }
        /// <summary>
        /// Gets all checklistItems associated to the checklist Id.
        /// </summary>
        /// <param name="checklistId">Checklist Id</param>
        /// <returns>List of checklist items associated to the checklist id</returns>
        public List<ChecklistItem> GetChecklistItemsByChecklistId(int checklistId)
        {
            return _context.ChecklistItems
                .AsNoTracking()
                .Where(item => item.ChecklistId == checklistId)
                .ToList();
        }

        /// <summary>
        /// Update a checklist
        /// </summary>
        /// <param name="checklist">the checklist to be updated (with the updated info)</param>
        /// <returns>updated checklist</returns>
        public Checklist UpdateChecklist(Checklist checklist)
        {
            Checklist updated = _context.Checklists.Update(checklist).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return updated;
        }

        public ChecklistItem UpdateChecklistItem(ChecklistItem item)
        {
            ChecklistItem updated = _context.ChecklistItems.Update(item).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return updated;
        }
    }
}
