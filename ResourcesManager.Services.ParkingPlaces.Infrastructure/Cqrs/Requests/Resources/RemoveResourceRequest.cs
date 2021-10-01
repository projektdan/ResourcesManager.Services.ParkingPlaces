using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class RemoveResourceRequest : IRequest
    {
        public RemoveResourceRequest(string uniqueResourceIdentifierString)
        {
            UniqueResourceIdentifierString = uniqueResourceIdentifierString;
        }

        public string UniqueResourceIdentifierString { get; }
    }
}
