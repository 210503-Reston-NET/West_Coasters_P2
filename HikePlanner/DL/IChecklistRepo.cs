using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IChecklistRepo
    {
        Task<List<Checklist>> GetAllChecklistsAsync();
        Task<Checklist> GetChecklistByIdAsync(int id);
        Task<List<Checklist>> GetChecklistByUserIdAsync(string userId);
        Task<Checklist> CreateNewChecklistAsync(Checklist checklist);
        Task<Checklist> UpdateChecklistAsync(Checklist checklist);
        Task<bool> DeleteChecklistAsync(int id);
        Task<List<ChecklistItem>> GetChecklistItemsByChecklistIdAsync(int checklistId);
        Task<ChecklistItem> GetChecklistItemByIdAsync(int itemId);
        Task<ChecklistItem>  CreateNewChecklistItemAsync(ChecklistItem item);
        Task<ChecklistItem>  UpdateChecklistItemAsync(ChecklistItem item);
        Task<bool> DeleteChecklistItemAsync(int id);
    }
}
