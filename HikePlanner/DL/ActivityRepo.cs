using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly AppDBContext _context;
        public ActivityRepo(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of Activities
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetAllActivitisAsync()
        {
            List<Activity> activities = await _context.Activities
                .AsNoTracking()
                .Select(activity => activity)
                .ToListAsync();
            return activities;
        }

        //Get a list of Acvitivies by creator
        public async Task<List<Activity>> GetAllActivitisByCreatorAsync(string creator)
        {
            return await _context.Activities
                .AsNoTracking()
                .Where(obj => obj.Creator == creator)
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
            Activity toBeDeleted = _context.Activities.First(obj => obj.Id == Activity.Id);
            _context.Activities.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }    
    }
}