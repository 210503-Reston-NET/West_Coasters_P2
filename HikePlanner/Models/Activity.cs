using System;
using System.Collections.Generic;

namespace Models
{
    public class Activity
    {
        public Activity()
        {
        }

        public Activity(string name, string traidId, string trailhead)
        {
            Name = name;
            TrailId = traidId;
            TrailHead = trailhead;
        }

        public Activity(int id, string name, string traidId, string trailhead) : this (name, traidId, trailhead)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TrailId { get; set; }
        public string TrailHead { get; set; }

        public List<Activity> Activities { get; set; }
    }
}