using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IEquipmentRepo
    {
        List<Equipment> GetAllEquipments();

        Equipment AddEquipment(Equipment equipment);

        void DeleteEquipment(Equipment equipment);
        Equipment UpdateEquipment(Equipment equipment);
        Equipment GetEquipmentById(int id);
    }
}