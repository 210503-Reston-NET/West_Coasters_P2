using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class EquipmentBL : IEquipmentBL
    {
        private readonly IEquipmentRepo _repo;

        public EquipmentBL(IEquipmentRepo repo)
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