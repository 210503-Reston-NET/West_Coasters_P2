using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Trip
    {
        private int _distance;
        private string _creator;
        private int _activityId;

        public Trip()
        { }

        public Trip(int activityId, DateTime startDate, DateTime endDate, int distance, string creator)
        {
            ActivityId = activityId;
            StartDate = startDate;
            EndDate = endDate;
            Distance = distance;
            Creator = creator;
        }

        public Trip(int id, int activityId, DateTime startDate, DateTime endDate, int distance, string creator) : this (activityId, startDate, endDate, distance, creator)
        {
            Id = id;
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }

        public int Distance 
        {
            get { return _distance; } 
            set
            {
                if(value <= 0)
                {
                    throw new ValidationException("Distance cannot be less than or equal to 0");
                }
                _distance = value;
            }
        }

        //This field will map to User.UserId
        public string Creator 
        {
            get { return _creator; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ValidationException("creator cannot be empty");
                }
                _creator = value;
            }
        }

        public int ActivityId 
        { 
            get { return _activityId; }
            set
            {
                if(value <= 0)
                {
                    throw new ValidationException("Checklist TripId cannot be less than or equal to 0");
                }
                _activityId = value;
            }
        }

        //This can be empty
        public int CheckListId { get; set; }

        public Participant Participant { get; set; }
        public Checklist Checklist { get; set; }
        public List<Post> Posts { get; set; }
    }
}