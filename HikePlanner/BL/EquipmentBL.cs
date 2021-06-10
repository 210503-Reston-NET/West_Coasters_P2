using System.Collections.Generic;
using DL;
using Models;
using System.Threading.Tasks;

namespace BL
{
    public class EquipmentBL : IEquipmentBL
    {
        private readonly IEquipmentRepo _repo;

        public EquipmentBL(IEquipmentRepo repo)
        {
            _repo = repo;
        }

        public async Task<Equipment> AddEquipmentAsync(Equipment equipment)
        {
            return await _repo.AddEquipmentAsync(equipment);
        }

        public async Task<List<Equipment>> GetAllEquipmentsAsync()
        {
            return await _repo.GetAllEquipmentsAsync();
        }
        
        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _repo.GetEquipmentByIdAsync(id);
        }

        public async Task DeleteEquipmentAsync(Equipment equipment)
        {
            await _repo.DeleteEquipmentAsync(equipment);
        }

        public async Task<Equipment> UpdateEquipmentAsync(Equipment equipment)
        {
            return await _repo.UpdateEquipmentAsync(equipment);
        }

    }
}