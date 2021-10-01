using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class AddResourceRequest : IRequest<ResourceDto>
    {
        public AddResourceRequest(AddResourcePayload payload)
        {
            this.Payload = payload;
        }

        public AddResourcePayload Payload { get; }
    }
}
