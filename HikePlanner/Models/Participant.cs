namespace Models
{
    public class Participant
    {
        public Participant()
        { }

        public Participant(int tripId, string userId)
        {
            TripId = tripId;
            UserId = userId;
        }

        public Participant(int id, int tripId, string userId) : this (tripId, userId)
        {
            Id = id;
        }
        
        public int Id { get; set; }
        public int TripId { get; set; }
        public string UserId { get; set; }
    }
}