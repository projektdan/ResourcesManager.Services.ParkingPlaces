using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Locations
{
    public class GetAllLocationsByResourceRequestHandler : IRequestHandler<GetAllLocationsByResourceRequest, IEnumerable<LocationDto>>
    {
        private readonly ILocationService locationService;

        public GetAllLocationsByResourceRequestHandler(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public async Task<IEnumerable<LocationDto>> Handle(GetAllLocationsByResourceRequest request, CancellationToken cancellationToken)
            => await locationService.GetLocationsByResourceAsync(request.UniqueResourceIdentifier);
    }
}
