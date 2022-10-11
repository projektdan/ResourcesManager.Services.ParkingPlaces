using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using System.Collections.Generic;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations
{
    public class GetAllLocationsByResourceRequest : IRequest<IEnumerable<LocationDto>>
    {
        public GetAllLocationsByResourceRequest(string uniqueResourceIdentifier)
        {
            UniqueResourceIdentifier = uniqueResourceIdentifier;
        }

        public string UniqueResourceIdentifier { get; }
    }
}
