using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations
{
    public class AddLocationRequest : IRequest<LocationDto>
    {
        public AddLocationRequest(AddLocationPayload payload)
        {
            Payload = payload;
        }

        public AddLocationPayload Payload { get; }
    }
}
