using AutoMapper;
using BillingSystem.Domain;
using BillingSystem.Schema;

namespace BillingSystem.Application;

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

        CreateMap<Apartment, ApartmentResponse>().ReverseMap()
            .ForMember(dest => dest.Resident, opt => opt.MapFrom(src => (int)Enum.Parse(typeof(Resident), src.Resident)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)Enum.Parse(typeof(Status), src.Status)));

        CreateMap<DuesRequest, Dues>();
        CreateMap<Dues, DuesResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(DuesPaymentStatus), src.DuesPaymentStatus)))
            .ForMember(dest => dest.Apartment, opt => opt.MapFrom(src => src.Apartment.Block + " Block - No " + src.Apartment.Number));
    }
}
