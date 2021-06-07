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
        public Checklist CreateNewChecklist(Checklist checklist)
        {
            return _repo.CreateNewChecklist(checklist);
        }

        public ChecklistItem CreateNewChecklistItem(ChecklistItem item)
        {
            return _repo.CreateNewChecklistItem(item);
        }

        public void DeleteChecklist(Checklist checklist)
        {
            _repo.DeleteChecklist(checklist);
        }

        public void DeleteChecklistItem(ChecklistItem item)
        {
            _repo.DeleteChecklistItem(item);
        }

        public List<Checklist> GetAllChecklists()
        {
            return _repo.GetAllChecklists();
        }

        public Checklist GetChecklistById(int id)
        {
            return _repo.GetChecklistById(id);
        }

        public ChecklistItem GetChecklistItemById(int itemId)
        {
            return _repo.GetChecklistItemById(itemId);
        }

        public List<ChecklistItem> GetChecklistItemsByChecklistId(int checklistId)
        {
            return _repo.GetChecklistItemsByChecklistId(checklistId);
        }

        public Checklist UpdateChecklist(Checklist checklist)
        {
            return _repo.UpdateChecklist(checklist);
        }

        public ChecklistItem UpdateChecklistItem(ChecklistItem item)
        {
            return _repo.UpdateChecklistItem(item);
        }
    }
}
