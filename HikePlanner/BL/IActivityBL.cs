using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface IActivityBL
    {
        Task<Activity> AddNewActivityAsync(Activity activity);
        Task DeleteActivityAsync(Activity activity);
        Task<Activity> UpdateActivityAsync(Activity activity);
        Task<List<Activity>> GetAllActivitiessAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task<List<Activity>> GetAllActivitisByCreatorAsync(string creator);
    }
}