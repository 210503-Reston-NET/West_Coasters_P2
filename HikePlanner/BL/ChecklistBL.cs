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

        public void DeleteChecklist(Checklist checklist)
        {
            _repo.DeleteChecklist(checklist);
        }

        public List<Checklist> GetAllChecklists()
        {
            return _repo.GetAllChecklists();
        }

        public Checklist GetChecklistById(int id)
        {
            return _repo.GetChecklistById(id);
        }

        public Checklist UpdateChecklist(Checklist checklist)
        {
            return _repo.UpdateChecklist(checklist);
        }
    }
}
