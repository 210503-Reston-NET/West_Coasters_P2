using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Checklist
    {
        private string _name;
        private int _tripId;
        public Checklist()
        {
        }

        public int Id { get; set; }
        public string Name
        { 
            get { return _name; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ValidationException("Checklist name cannot be empty");
                }
                _name = value;
            }
        }
        public int TripId 
        {
            get { return _tripId; }
            set
            {
                if(value <= 0)
                {
                    throw new ValidationException("Checklist TripId cannot be less than or equal to 0");
                }
                _tripId = value;
            }
        }
        public List<ChecklistItem> ChecklistItems { get; set; }
    }
}