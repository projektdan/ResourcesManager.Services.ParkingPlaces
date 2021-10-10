using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations
{
    public class GetLocationRequest : IRequest<LocationDto>
    {
        public GetLocationRequest(string locationName)
        {
            LocationName = locationName;
        }

        public string LocationName { get; }
    }
}
