using System.Collections.Generic;
using Models;
using System.Threading.Tasks;

namespace BL
{
    public interface IEquipmentBL
    {
        Task<List<Equipment>> GetAllEquipmentsAsync();
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(Equipment equipment);
        Task<Equipment> GetEquipmentByIdAsync(int id);
    }
}