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
        /// Delete selected checklist
        /// </summary>
        /// <param name="checklist">checklist to be deleted</param>
        public void DeleteChecklist(Checklist checklist)
        {
            _context.Checklists.Remove(checklist);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
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
    }
}
