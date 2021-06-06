using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Linq;

namespace BL
{
    public interface IEquipmentBL
    {
        public List<Equipment> GetAllEquipments();

        public Equipment AddEquipment(Equipment equipment);
    }
}