using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IEquipmentRepo
    {
        Task<List<Equipment>> GetAllEquipmentsAsync();
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(Equipment equipment);
        Task<Equipment> GetEquipmentByIdAsync(int id);
    }
}