using System.Collections.Generic;
using Models;
namespace DL
{
    public interface IRepository
    {
        /// <summary>
        /// CRUD Equipment
        /// </summary>
        List<Equipment> GetAllEquipments();
        Equipment AddEquipment(Equipment equipment);
    }
}