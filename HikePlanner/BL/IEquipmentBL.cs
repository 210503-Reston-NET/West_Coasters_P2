using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IEquipmentBL
    {
        public List<Equipment> GetAllEquipments();

        public Equipment AddEquipment(Equipment equipment);
    }
}