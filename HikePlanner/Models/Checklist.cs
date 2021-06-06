using System.Collections.Generic;
namespace Models
{
    public class Checklist
    {
        public Checklist()
        {}
        public int Id { get; set; }
        public string Name { get; set; }
        //ToDo: decide TripId or GroupId or UserId
        // vote for TripId since this checklist can be visible to all group memebers (trip participants)
        public int TripId { get; set; }
        //public string UserId { get; set; }
        List<ChecklistItem> ChecklistItems { get; set; }
    }
}