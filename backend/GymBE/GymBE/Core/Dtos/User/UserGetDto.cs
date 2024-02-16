namespace GymBE.Core.Dtos.User
{
    public class UserGetDto
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long MembershipId { get; set; }
        public string MembershipName { get; set; }
    }
}
