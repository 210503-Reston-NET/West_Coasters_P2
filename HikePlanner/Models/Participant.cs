using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Participant
    {
        private int _tripId;
        private string _userId;
        private string _accept;
        public Participant()
        {}
         
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
        public Boolean Accept { 
            get;
            set;
        }

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

        public User User { get; set; }
    }
}