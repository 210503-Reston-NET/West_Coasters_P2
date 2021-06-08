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

        /// <summary>
        /// Get all Equipments in db
        /// </summary>
        /// <returns>List of all Equipments</returns>
        public List<Equipment> GetAllEquipments()
        {
            return _context.Equipments
                .AsNoTracking()
                .Select(equip => equip)
                .ToList();
        }

        /// <summary>
        /// Finds the first equipment with the given id
        /// </summary>
        /// <param name="id">equipment id to be searched for</param>
        /// <returns>If found, found equipment, null if not found</returns>
        public Equipment GetEquipmentById(int id)
        {
            return _context.Equipments
                .AsNoTracking()
                .FirstOrDefault(obj => obj.Id == id);
        }

        /// Creates a new equipment object in db
        /// </summary>
        /// <param name="equipment">the equipment obj to be added</param>
        /// <returns>equipment obj that has been created</returns>
        public Equipment AddEquipment(Equipment equipment)
        {
            Equipment addedEquipment = _context.Equipments.Add(equipment).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return addedEquipment;
        }

        /// <summary>
        /// Delete selected equipment
        /// </summary>
        /// <param name="equipment">equipment to be deleted</param>
        public void DeleteEquipment(Equipment equipment)
        {
            _context.Equipments.Remove(equipment);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        /// <summary>
        /// Update a equipment
        /// </summary>
        /// <param name="equipment">the equipment to be updated (with the updated info)</param>
        /// <returns>updated equipment</returns>
        public Equipment UpdateEquipment(Equipment equipment)
        {
            Equipment updated = _context.Equipments.Update(equipment).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return updated;
        }
    }
}