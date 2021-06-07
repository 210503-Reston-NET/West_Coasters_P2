using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    interface IChecklistBL
    {
        public List<Checklist> GetAllChecklists();
        public Checklist GetChecklistById(int id);
        public Checklist CreateNewChecklist(Checklist checklist);
        public Checklist UpdateChecklist(Checklist checklist);
        public void DeleteChecklist(Checklist checklist);
        public List<ChecklistItem> GetChecklistItemsByChecklistId(int checklistId);
        public ChecklistItem GetChecklistItemById(int itemId);
        public ChecklistItem CreateNewChecklistItem(ChecklistItem item);
        public ChecklistItem UpdateChecklistItem(ChecklistItem item);
        public void DeleteChecklistItem(ChecklistItem item);
    }
}
