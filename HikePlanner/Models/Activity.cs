namespace Models
{
    public class Activity
    {
        public Activity()
        {}
        public Activity(Activity activity)
        {
            Id = activity.Id;
            Name = activity.Name;
            TrailId = activity.TrailId;
            TrailHead = activity.TrailHead;
            Notes = activity.Notes;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TrailId { get; set; }
        public string TrailHead { get; set; }
    }
}