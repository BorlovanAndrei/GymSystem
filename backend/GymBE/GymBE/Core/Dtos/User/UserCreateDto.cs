﻿namespace GymBE.Core.Dtos.User
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long MembershipId { get; set; }
    }
}
