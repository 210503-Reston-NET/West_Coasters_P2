using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Post
    {
        private int _tripId;
        private string _userId;
        private string _notes;
        public Post()
        { }

        public Post(int tripId, string userId, string Notes, DateTime dateCreated)
        {
            TripId = tripId;
            UserId = userId;
            DateCreated = dateCreated;
        }

        public Post(string imageURL, int tripId, string userId, string Notes, DateTime dateCreated) : this(tripId, userId, Notes, dateCreated)
        {
            ImageURL = imageURL;
        }

        public Post(int id, int tripId, string userId, string Notes, DateTime dateCreated) : this(tripId, userId, Notes, dateCreated)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int TripId 
        {
            get { return _tripId; }
            set
            {
                if(value <= 0)
                {
                    throw new ValidationException("TripId cannot be less than or equal to 0");
                }
                _tripId = value;
            }
        }
        public string UserId 
        {
            get { return _userId; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ValidationException("userId cannot be empty");
                }
                _userId = value;
            }
        }

        public string Notes 
        { 
            get { return _notes; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ValidationException("userId cannot be empty");
                }
                _notes = value;
            }
        }
        public string ImageURL { get; set; }
        public DateTime DateCreated { get; set; }
    }
}