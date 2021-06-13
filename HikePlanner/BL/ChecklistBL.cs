using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public class ChecklistBL : IChecklistBL
    {
        private readonly IChecklistRepo _repo;
        public ChecklistBL(IChecklistRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<Checklist>> GetChecklistByUserIdAsync(string userId)
        {
            return await _repo.GetChecklistByUserIdAsync(userId);
        }

        public async Task<Checklist> CreateNewChecklistAsync(Checklist checklist)
        {
            return await _repo.CreateNewChecklistAsync(checklist);
        }

        public async Task<ChecklistItem> CreateNewChecklistItemAsync(ChecklistItem item)
        {
            return await _repo.CreateNewChecklistItemAsync(item);
        }

        public async Task<bool> DeleteChecklistAsync(int id)
        {
            return await _repo.DeleteChecklistAsync(id);
        }

        public async Task<bool> DeleteChecklistItemAsync(int id)
        {
            return await _repo.DeleteChecklistItemAsync(id);
        }

        public async Task<List<Checklist>> GetAllChecklistsAsync()
        {
            return await _repo.GetAllChecklistsAsync();
        }

        public async Task<Checklist> GetChecklistByIdAsync(int id)
        {
            return await _repo.GetChecklistByIdAsync(id);
        }

        public async Task<ChecklistItem> GetChecklistItemByIdAsync(int itemId)
        {
            return await _repo.GetChecklistItemByIdAsync(itemId);
        }

        public async Task<List<ChecklistItem>> GetChecklistItemsByChecklistIdAsync(int checklistId)
        {
            return await _repo.GetChecklistItemsByChecklistIdAsync(checklistId);
        }

        public async Task<Checklist> UpdateChecklistAsync(Checklist checklist)
        {
            return await _repo.UpdateChecklistAsync(checklist);
        }

        public async Task<ChecklistItem> UpdateChecklistItemAsync(ChecklistItem item)
        {
            return await _repo.UpdateChecklistItemAsync(item);
        }
    }
}
