using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class TripRepo
    {
        private readonly AppDBContext _context;
        public TripRepo(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Trip object in db
        /// </summary>
        /// <param name="Trip">the Trip obj to be added</param>
        /// <returns>Trip obj that has been created</returns>
        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips
                .AsNoTracking()
                .Select(trip => trip)
                .ToListAsync();
        }
        /// <summary>
        /// Get trip object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Trip> GetTripByIdAsync(int id)
        {
            return await _context.Trips
                .AsNoTracking()
                .FirstOrDefaultAsync(list => list.Id == id);
        }
        /// <summary>
        /// Add new trip object in db
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public async Task<Trip> AddNewTripAsync(Trip trip)
        {
            Trip addedTrip = _context.Trips.Add(trip).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return addedTrip;
        }
        /// <summary>
        /// Update trip object in db
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            Trip updated = _context.Trips.Update(trip).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }
        /// <summary>
        /// Delete trip object in db
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public async Task DeleteTripAsync(Trip trip)
        {
            Trip toBeDeleted = _context.Trips.AsNoTracking().First(obj => obj.Id == trip.Id);
            _context.Trips.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }    

        //To do - a list of posts
        
    }
}