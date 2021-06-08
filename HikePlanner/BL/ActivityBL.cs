using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public class ActivityBL : IActivityBL
    {
        private readonly IActivityRepo _activityRepo;
        public ActivityBL(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
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

        // public async Task<List<Activity>> GetAllActivitiesByCreator(string creator)
        // {
        //     return await _activityRepo.GetAllActivitiesByCreator(creator);
        // }
    }
}