using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ChecklistItem
    {
        private int _quantity;
        private int _equipmentId;
        private int _checklistId;
        public ChecklistItem()
        { }

        public int Id { get; set; }
        public int Quantity 
        {
            get { return _quantity; } 
            set
            {
                if(value <= 0)
                {
                    throw new ValidationException("Quantity cannot be less than or equal to 0");
                }
                _quantity = value;
            }
        }
        public int ChecklistId
        {
            get { return _checklistId; }
            set
            {
                if (value <= 0)
                {
                    throw new ValidationException("Checklist Id cannot be less than or equal to 0");
                }
                _checklistId = value;
            }
        }
        public int EquipmentId
        {
            get { return _equipmentId; }
            set
            {
                if (value <= 0)
                {
                    throw new ValidationException("Equipment Id cannot be less than or equal to 0");
                }
                _equipmentId = value;
            }
        }

        public Equipment Equipment { get; set; }
    }
}