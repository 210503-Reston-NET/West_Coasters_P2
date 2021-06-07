using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IEquipmentBL
    {
        List<Equipment> GetAllEquipments();

        Equipment AddEquipment(Equipment equipment);

        void DeleteEquipment(Equipment equipment);
        Equipment UpdateEquipment(Equipment equipment);
        Equipment GetEquipmentById(int id);
    }
}