using AutoMapper;
using GymBE.Core.Dtos.Membership;
using GymBE.Core.Entities;

namespace GymBE.Core.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Membership
            CreateMap<MembershipCreateDto, Membership>();
            CreateMap<Membership, MembershipGetDto>();

            // User

            // Staff

            //Equipment
        }
    }
}
