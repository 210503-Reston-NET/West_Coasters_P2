namespace Models
{
    public class Post
    {
        public Post()
        {}

        public Post(int tripId, string userId, string Notes)
        {
            TripId = tripId;
            UserId = userId;
        }

        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }
        public string Notes { get; set; }
    }
}