namespace Models
{
    public class Trip
    {
        public Trip()
        { }

        public Trip(int id, int checkListId, DateTime endDate, int distance, string creator, Group group)
        {
            this.Id = id;
            this.CheckListId = checkListId;
            this.EndDate = endDate;
            this.Distance = distance;
            this.Creator = creator;
            this.Group = group;

        }
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int CheckListId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public int Distance { get; set; }

        //This field will map to User.UserId
        public string Creator { get; set; }

        //Notes will be shown on Post.Notes

        public Group Group { get; set; }

    }
}