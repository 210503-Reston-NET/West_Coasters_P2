namespace Models
{
    public class Group
    {
        public Group()
        {}

        public Group(int tripId, string userId)
        {
            TripId = tripId;
            UserId = userId;
        }

        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }
    }
}