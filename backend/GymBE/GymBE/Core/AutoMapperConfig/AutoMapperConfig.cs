using AutoMapper;
using GymBE.Core.Dtos.Equipment;
using GymBE.Core.Dtos.Membership;
using GymBE.Core.Dtos.Staff;
using GymBE.Core.Dtos.User;
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
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.MembershipName, opt => opt.MapFrom(src => src.Membership.Name));

            // Staff
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<Staff, StaffGetDto>();

            //Equipment
            CreateMap<EquipmentCreateDto, Equipment>();
            CreateMap<Equipment, EquipmentGetDto>();
        }
    }
}
