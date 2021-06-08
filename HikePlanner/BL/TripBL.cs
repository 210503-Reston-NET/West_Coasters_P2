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

        public async Task<Dictionary<Trip, List<Participant>>> GetAllParticipantsByTripIdAsync()
        {
            List<Participant> participants = await _tripRepo.GetAllParticipantsByAsync();
            Dictionary<Trip, List<Participant>> tripWithParticipants = new Dictionary<Trip, List<Participant>>();
            foreach(Participant p in participants)
            {
                Trip key = await GetTripByIdAsync(p.TripId);
                if (!tripWithParticipants.ContainsKey(key))
                {
                    tripWithParticipants.Add(key, new List<Participant>());
                }
                List<Participant> value = tripWithParticipants.GetValueOrDefault(key);      
                value.Add(new Participant{Id = p.Id, UserId = p.UserId});
            }
            return tripWithParticipants;
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _tripRepo.GetAllTripsAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            return await _tripRepo.GetTripByIdAsync(id);
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