using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BL
{
    public interface ITripBL
    {
        Task<List<Trip>> GetAllTripsAsync();
        Task<Trip> GetTripByIdAsync(int id);
        Task<Trip> AddNewTripAsync(Trip trip);
        Task<Trip> UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(Trip trip);

        Task<Participant> AddNewParticipantAsync(Participant participant);
        Task<Participant> UpdateParticipantAsync(Participant participant);
        Task DeleteParticipantAsync(Participant participant);
        Task<List<Participant>> GetAllParticipantsByTripIdAsync(int tripId);
        Task<Participant> GetParticipantByIdAsync(int id);
        Task<List<Trip>> GetAllTripsByActivityIdAsync(int activityId);
    }
}