using AutoMapper;
using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Schema.Apartment;
using BillingSystem.Schema.User;

namespace BillingSystem.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.ApartmentInfo, opt => opt.MapFrom(src => src.Apartment.Block + " Block - No " + src.Apartment.Number));

        CreateMap<ApartmentRequest, Apartment>()
            .ForMember(dest => dest.Resident, opt => opt.MapFrom(src => (int)Enum.Parse(typeof(Resident), src.Resident)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)Enum.Parse(typeof(Status), src.Status)));
        CreateMap<Apartment, ApartmentResponse>()
            .ForMember(dest => dest.Resident, opt => opt.MapFrom(src => Enum.GetName(typeof(Resident), src.Resident)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(Status), src.Status)));
    }
}
