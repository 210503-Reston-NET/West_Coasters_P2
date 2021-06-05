using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Linq;
namespace BL
{
    public interface IEquipmentBL
    {
        List<Equipment> GetAllEquipments();
        Equipment AddEquipment(Equipment equipment);
    }
}