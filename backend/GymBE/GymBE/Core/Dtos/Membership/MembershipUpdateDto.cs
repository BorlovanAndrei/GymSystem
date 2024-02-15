namespace GymBE.Core.Dtos.Membership
{
    public class MembershipUpdateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
