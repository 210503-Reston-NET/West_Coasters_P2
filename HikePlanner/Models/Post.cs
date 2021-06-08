namespace Models
{
    public class Post
    {
        public Post()
        { }

        public Post(int tripId, string userId, string Notes)
        {
            TripId = tripId;
            UserId = userId;
        }

        public Post(string imageURL, int tripId, string userId, string Notes) : this(tripId, userId, Notes)
        {
            ImageURL = imageURL;
        }

        public Post(int id, int tripId, string userId, string Notes) : this(tripId, userId, Notes)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int TripId { get; set; }
        public string UserId { get; set; }
        public string Notes { get; set; }
        public string ImageURL { get; set; }
    }
}