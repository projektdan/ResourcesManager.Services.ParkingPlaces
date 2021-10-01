using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class GetResourceRequest : IRequest<ResourceDto>
    {
        public GetResourceRequest(string uniqueResourceIdentifier)
        {
            this.UniqueResourceIdentifier = uniqueResourceIdentifier;
        }

        public string UniqueResourceIdentifier { get; }
    }
}
