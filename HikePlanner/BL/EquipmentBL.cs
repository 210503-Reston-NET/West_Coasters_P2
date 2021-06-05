using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Linq;

namespace BL
{
    public class EquipmentBL : IEquipmentBL
    {
        private IRepository _repo;
        public EquipmentBL(IRepository repo)
        {
            _repo = repo;
        }
        public Equipment AddEquipment(Equipment equipment)
        {
            return _repo.AddEquipment(equipment);
        }

        public List<Equipment> GetAllEquipments()
        {
            return _repo.GetAllEquipments();
        }
    }
}
