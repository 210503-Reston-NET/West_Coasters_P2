using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public interface ITripRepo
    {
        Task<List<Trip>> GetAllTripsAsync();
        Task<Trip> GetTripByIdAsync(int id);
        Task<List<Trip>> GetTripsByActivityIdAsync(int id);
        Task<Trip> AddNewTripAsync(Trip trip);
        Task<Trip> UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(Trip trip);

        Task<Participant> AddNewParticipantAsync(Participant participant);
        Task<Participant> UpdateParticipantAsync(Participant participant);
        Task DeleteParticipantAsync(Participant participant);
        Task<List<Participant>> GetAllParticipantsByTripIdAsync(int tripId);
        Task<Participant> GetParticipantByIdAsync(int id);
        Task<List<Trip>> GetTripsByCreatorAsync(string creator);
    }
}