using System;
using System.Collections.Generic;

namespace Models
{
    public class Activity
    {
        public Activity()
        {
        }

        public Activity(string name, string traidId, string trailhead, string creator)
        {
            Name = name;
            TrailId = traidId;
            TrailHead = trailhead;
            Creator = creator;
        }

        public Activity(int id, string name, string traidId, string trailhead, string creator) : this (name, traidId, trailhead, creator)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TrailId { get; set; }
        public string TrailHead { get; set; }
        public string Creator { get; set; }

        public List<Trip> Trips { get; set; }
    }
}