﻿using GymBE.Core.Enums;

namespace GymBE.Core.Entities
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
