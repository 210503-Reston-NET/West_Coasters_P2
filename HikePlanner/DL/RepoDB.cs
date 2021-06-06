using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class RepoDB : IRepository
    {
        private AppDBContext _context;
        public RepoDB(AppDBContext context)
        {
            _context = context;
        }

        public List<Equipment> GetAllEquipments()
        {
            return _context.Equipments.Select(equip => equip).ToList();
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
            return equipment;
        }

    }
}
