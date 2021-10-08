using AutoMapper;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Resource, ResourceDto>()
                .ForMember(dst => dst.Name, x => x.MapFrom(src => src.Name.Value))
                .ForMember(dst => dst.UniqueResourceIdentifier, x => x.MapFrom(src => src.UniqueResourceIdentifier.Value));
            CreateMap<User, UserDto>()
                .ForMember(dst => dst.Username, x => x.MapFrom(src => src.Username.Value))
                .ForMember(dst => dst.Email, x => x.MapFrom(src => src.Email.Value))
                .ForMember(dst => dst.Firstname, x => x.MapFrom(src => src.Firstname.Value))
                .ForMember(dst => dst.Lastname, x => x.MapFrom(src => src.Lastname.Value));
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dst => dst.User, x => x.MapFrom(src => src.User))
                .ForMember(dst => dst.Resource, x => x.MapFrom(src => src.Resource))
                .ForMember(dst => dst.ResourceQuantity, x => x.MapFrom(src => src.ResourceQuantity))
                .ForMember(dst => dst.Location, x => x.MapFrom(src => src.Location))
                .ForMember(dst => dst.State, x => x.MapFrom(src => src.State.Name.Value));
            CreateMap<Location, LocationDto>()
                .ForMember(dst => dst.Name, x => x.MapFrom(src => src.Name.Value))
                .ForMember(dst => dst.Address, x => x.MapFrom(src => src.Address.Value))
                .ForMember(dst => dst.Resources, x => x.MapFrom(src => src.Resources));
            CreateMap<LocationResource, LocationResourceDto>()
                .ForMember(dst => dst.Location, x => x.MapFrom(src => src.Location))
                .ForMember(dst => dst.Resource, x => x.MapFrom(src => src.Resource))
                .ForMember(dst => dst.ResourceQuantity, x => x.MapFrom(src => src.ResourceQuantity.Value));
        }
    }
}
