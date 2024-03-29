﻿namespace GymBE.Core.Entities
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        public ICollection<User> Users { get; set; }
    }
}
