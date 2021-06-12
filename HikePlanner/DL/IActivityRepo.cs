using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public interface IActivityRepo
    {
        Task<List<Activity>> GetAllActivitisAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task<Activity> AddNewActivityAsync(Activity activity);
        Task<Activity> UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(Activity Activity);
        Task<List<Activity>> GetAllActivitisByCreatorAsync(string creator);
    }
}