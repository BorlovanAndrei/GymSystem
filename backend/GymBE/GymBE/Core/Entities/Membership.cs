namespace GymBE.Core.Entities
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
