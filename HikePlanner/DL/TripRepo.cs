using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class TripRepo : ITripRepo
    {
        private readonly AppDBContext _context;
        public TripRepo(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all trips in db
        /// </summary>
        /// <returns></returns>
        public async Task<List<Trip>> GetAllTripsAsync()
        {

            List<Trip> trips =  await _context.Trips
            .AsNoTracking()                
            // .Include(t => t.Participants)
            // .Include(t => t.Posts)
            // .Include(t => t.Checklist)
            .ToListAsync();
            trips.ForEach(t => 
                {
                    t.Participants = _context.Participants
                        .Where(p => p.TripId == t.Id)
                        .Include(p => p.User)
                        .ToList();
                    //t.Posts = _context.Posts.Where(p => p.TripId == t.Id).ToList();
                    t.Checklist = _context.Checklists.Find(t.ChecklistId);
                    t.Activity = _context.Activities.Select(a => new Activity
                    {
                        Id = a.Id,
                        Name = a.Name,
                        TrailHead = a.TrailHead,
                        TrailId = a.TrailId,
                        Creator = a.Creator
                    }).FirstOrDefault();
                } 
            );
            
            return trips;
        }
        /// <summary>
        /// Get trips by activity id
        /// </summary>
        /// <param name="id">activity Id</param>
        /// <returns></returns>
        public async Task<List<Trip>> GetTripsByActivityIdAsync(int id)
        {
            List<Trip> trips = await _context.Trips
                .AsNoTracking()
                .Where(trip => trip.ActivityId == id)
                .ToListAsync();
            return trips;
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
                .FirstOrDefaultAsync(obj => obj.Id == id);
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

        /// <summary>
        /// Add Participant object in db
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        public async Task<Participant> AddNewParticipantAsync(Participant participant)
        {
            Participant addedParticipant = _context.Participants.Add(participant).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return addedParticipant;        
        }

        /// <summary>
        /// Update a participant 
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        public async Task<Participant> UpdateParticipantAsync(Participant participant)
        {
            Participant updated = _context.Participants.Update(participant).Entity;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return updated;
        }

        /// <summary>
        /// Delete a participant
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        public async Task DeleteParticipantAsync(Participant participant)
        {
            Participant toBeDeleted = _context.Participants.AsNoTracking().First(obj => obj.Id == participant.Id);
            _context.Participants.Remove(toBeDeleted);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }      

        /// <summary>
        /// Get a list of participants by tripId
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public async Task<List<Participant>> GetAllParticipantsByTripIdAsync(int tripId)
        {
            return await _context.Participants
                .AsNoTracking()
                .Where(obj => obj.TripId == tripId)
                .Select(participant => participant)
                .ToListAsync();
        }
        /// <summary>
        /// Get trips by creatorid
        /// </summary>
        /// <param name="id"></param> this is creator id
        /// <returns></returns>
        public async Task<List<Trip>> GetTripsByCreatorAsync(string creator)
        {
            return await _context.Trips
                .AsNoTracking()
                .Where(a => a.Creator == creator)
                .Select(t => new Trip
                {
                    Id = t.Id,
                    Activity = t.Activity,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Distance = t.Distance,
                    Creator = t.Creator
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get a parcipant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants
                .AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

    }
}