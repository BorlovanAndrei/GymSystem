using GymBE.Core.Enums;

namespace GymBE.Core.Dtos.Equipment
{
    public class EquipmentUpdateDto
    {
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
