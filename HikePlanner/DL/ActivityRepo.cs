using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class ActivityRepo
    {
        private readonly AppDBContext _context;
        public ActivityRepo(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Activity object in db
        /// </summary>
        /// <param name="activity">the Activity obj to be added</param>
        /// <returns>Activity obj that has been created</returns>
        public async Task<List<Activity>> GetAllActivitysAsync()
        {
            return await _context.Activities
                .AsNoTracking()
                .Select(activity => activity)
                .ToListAsync();
        }

        /// <summary>
        /// Get Activity object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _context.Activities
                .AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        /// <summary>
        /// Add new Activity object in db
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public async Task<Activity> AddNewActivityAsync(Activity activity)
        {
            Activity addedActivity = _context.Activities.Add(activity).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return addedActivity;
        }
        
        /// <summary>
        /// Update Activity object in db
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public async Task<Activity> UpdateActivityAsync(Activity activity)
        {
            Activity updated = _context.Activities.Update(activity).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }

        /// <summary>
        /// Delete Activity object in db
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public async Task DeleteActivityAsync(Activity Activity)
        {
            Activity toBeDeleted = _context.Activities.AsNoTracking().First(obj => obj.Id == Activity.Id);
            _context.Activities.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }    

        //To do - a list of trips
        //To do - get all activity by creator
        
    }
}