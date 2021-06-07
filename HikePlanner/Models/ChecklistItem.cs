namespace Models
{
    public class ChecklistItem
    {
        public ChecklistItem()
        { }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ChecklistId { get; set; }
        public int EquipmentId { get; set; }
    }
}