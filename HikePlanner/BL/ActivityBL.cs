using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
using System.Linq;

namespace BL
{
    public class ActivityBL : IActivityBL
    {
        private readonly IActivityRepo _activityRepo;
        private readonly ITripBL _tripBL;
        public ActivityBL(IActivityRepo activityRepo, ITripBL tripBL)
        {
            _activityRepo = activityRepo;
            _tripBL = tripBL;
            
        }
        public async Task<Activity> AddNewActivityAsync(Activity activity)
        {
            return await _activityRepo.AddNewActivityAsync(activity);
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            await _activityRepo.DeleteActivityAsync(activity);
        }

        public async Task<Activity> UpdateActivityAsync(Activity activity)
        {
            return await _activityRepo.UpdateActivityAsync(activity);
        }

        public async Task<List<Activity>> GetAllActivitiessAsync()
        {
            return await _activityRepo.GetAllActivitisAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _activityRepo.GetActivityByIdAsync(id);
        }

        public async Task<List<Activity>> GetAllActivitisByCreatorAsync(string creator)
        {
            List<Activity> activities = await _activityRepo.GetAllActivitisAsync();
            // List<Activity> result = new List<Activity>(); 
            // foreach(Activity a in activities)
            // {
            //     if (a.Creator == creator)
            //     {
            //         result.Add(a);
            //     }
            // }
            return activities.Where(a => a.Creator == creator).ToList();
        }
        // public async Task<List<Activity>> GetAllActivitisByParticipantAsync(string userId)
        // {
        //     List<Activity> activities = await _activityRepo.GetAllActivitisAsync();
        //     List<Activity> result = new List<Activity>();
        //     foreach (Activity a in activities)
        //     {
        //         foreach (Trip t in a.Trips)
        //         {
        //             List<Participant> participants = await _tripBL.GetAllParticipantsByTripIdAsync(t.Id);
        //             foreach (Participant p in participants)
        //             {
        //                 if (p.UserId == userId) result.Add(a);
        //             }
        //         }
        //     }
        //     return result;
        // }
    }
}