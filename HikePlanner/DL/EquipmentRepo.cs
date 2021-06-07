using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class EquipmentRepo : IEquipmentRepo
    {
        private readonly AppDBContext _context;

        public EquipmentRepo(AppDBContext context)
        {
            _context = context;
        }

        public List<Equipment> GetAllEquipments()
        {
            return _context.Equipments
                .AsNoTracking()
                .Select(equip => equip)
                .ToList();
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            Equipment addedEquipment = _context.Equipments.Add(equipment).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return addedEquipment;
        }
    }
}