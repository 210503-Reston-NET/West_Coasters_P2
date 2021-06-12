using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
using System.Linq;

namespace BL
{
    public class TripBL : ITripBL
    {
        private readonly ITripRepo _tripRepo;
        public TripBL(ITripRepo tripRepo)
        {
            _tripRepo = tripRepo;
        }

        public async Task<Participant> AddNewParticipantAsync(Participant participant)
        {
            return await _tripRepo.AddNewParticipantAsync(participant);
        }

        public async Task<Trip> AddNewTripAsync(Trip trip)
        {
            return await _tripRepo.AddNewTripAsync(trip);
        }

        public async Task DeleteParticipantAsync(Participant participant)
        {
            await _tripRepo.DeleteParticipantAsync(participant);
        }

        public async Task DeleteTripAsync(Trip trip)
        {
            await _tripRepo.DeleteTripAsync(trip);
        }

        public async Task<List<Participant>> GetAllParticipantsByTripIdAsync(int tripId)
        {
            return await _tripRepo.GetAllParticipantsByTripIdAsync(tripId);
            
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _tripRepo.GetAllTripsAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            return await _tripRepo.GetTripByIdAsync(id);
        }

        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _tripRepo.GetParticipantByIdAsync(id);
        }
        
        public async Task<Participant> UpdateParticipantAsync(Participant participant)
        {
            return await _tripRepo.UpdateParticipantAsync(participant);
        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            return await _tripRepo.UpdateTripAsync(trip);
        }

        public async Task<List<Trip>> GetAllTripsByActivityIdAsync(int activityId)
        {
            return await _tripRepo.GetTripsByActivityIdAsync(activityId);
        }

        public async Task<List<Trip>> GetAllTripsByCreatorAsync(string Creator)
        {
            return await _tripRepo.GetTripsByCreatorAsync(Creator);
        }

        public async Task<List<Trip>> GetAllTripsByParticipantAsync(string userId)
        {
            List<Trip> trips = await _tripRepo.GetAllTripsAsync();
            List<Trip> result = new List<Trip>();
            foreach (Trip t in trips)
            {
                List<Participant> participants = await GetAllParticipantsByTripIdAsync(t.Id);
                foreach (Participant p in participants)
                {
                    if (p.UserId == userId) result.Add(t);
                }
            }
            return result;
        }
    }
}