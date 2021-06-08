using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Models
{
    public class Trip
    {
        public Trip()
        { }

        public Trip(int activityId, DateTime startTime, DateTime startDate, DateTime endDate, int distance, string creator)
        {
            ActivityId = activityId;
            StartTime = startTime;
            StartDate = startDate;
            EndDate = endDate;
            Distance = distance;
            Creator = creator;
        }

        public Trip(int id, int activityId, DateTime startTime, DateTime startDate, DateTime endDate, int distance, string creator) : this (activityId, startTime, startDate, endDate, distance, creator)
        {
            Id = id;
        }

        public Trip(int checklistId, int id, int activityId, DateTime startTime, DateTime startDate, DateTime endDate, int distance, string creator) : this (id, activityId, startTime, startDate, endDate, distance, creator)
        {
            CheckListId = checklistId;
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Distance { get; set; }

        //This field will map to User.UserId
        public string Creator { get; set; }

        public int ActivityId { get; set; }
        public int CheckListId { get; set; }

        public Participant Participant { get; set; }
        public Checklist Checklist { get; set; }
        public List<Post> Posts { get; set; }
    }
}