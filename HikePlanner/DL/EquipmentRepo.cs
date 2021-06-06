using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class EquipmentRepo : IEquipmentRepo
    {
        public List<Equipment> GetAllEquipments()
        {
            return new List<Equipment>();
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            return new Equipment();
        }
    }
}
