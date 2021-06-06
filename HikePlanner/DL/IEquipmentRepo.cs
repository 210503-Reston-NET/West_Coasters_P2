using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IEquipmentRepo
    {
        public List<Equipment> GetAllEquipments();
        public Equipment AddEquipment(Equipment equipment);
    }
}
