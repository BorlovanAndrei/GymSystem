namespace GymBE.Core.Dtos.Membership
{
    public class MembershipGetDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
