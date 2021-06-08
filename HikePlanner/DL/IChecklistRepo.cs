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
        public List<Checklist> GetAllChecklists();
        public Checklist GetChecklistById(int id);
        public Checklist CreateNewChecklist(Checklist checklist);
        public Checklist UpdateChecklist(Checklist checklist);
        public bool DeleteChecklist(int id);

        public List<ChecklistItem> GetChecklistItemsByChecklistId(int checklistId);
        public ChecklistItem GetChecklistItemById(int itemId);
        public ChecklistItem CreateNewChecklistItem(ChecklistItem item);
        public ChecklistItem UpdateChecklistItem(ChecklistItem item);
        public bool DeleteChecklistItem(int id);
    }
}
