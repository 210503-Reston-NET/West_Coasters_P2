namespace Models
{
    public class Equipment
    {
        public Equipment()
        { }
        public Equipment(string name)
        { 
            Name = name;
        }

        public Equipment(string name, string description) : this (name)
        {
            Description = description;
        }

        public Equipment(Equipment equipment) : this (equipment.Name, equipment.Description)
        {
            Id = equipment.Id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}