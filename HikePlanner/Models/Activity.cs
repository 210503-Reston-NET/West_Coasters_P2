using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class Activity
    {
        private string _name;
        private string _creator;
        public Activity()
        {
        }

        public Activity(string name, string notes, string traidId, string trailhead, string creator)
        {
            Name = name;
            Notes = notes;
            TrailId = traidId;
            TrailHead = trailhead;
            Creator = creator;
        }

        public Activity(int id, string name, string notes, string traidId, string trailhead, string creator) : this (name,notes, traidId, trailhead, creator)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name
        { 
            get { return _name; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ValidationException("Name cannot be empty");
                }
                _name = value;
            }
        }
        
        //This can be optional
        public string Notes { get; set; }

        //Not sure exactly data type for these foreign keys
        public string TrailId { get; set; }
        public string TrailHead { get; set; }

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

        public List<Trip> Trips { get; set; }
    }
}