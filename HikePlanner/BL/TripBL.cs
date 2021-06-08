using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

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

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _tripRepo.GetParticipantById(id);
        }
        
        public async Task<Participant> UpdateParticipantAsync(Participant participant)
        {
            return await _tripRepo.UpdateParticipantAsync(participant);
        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            return await _tripRepo.UpdateTripAsync(trip);
        }
    }
}