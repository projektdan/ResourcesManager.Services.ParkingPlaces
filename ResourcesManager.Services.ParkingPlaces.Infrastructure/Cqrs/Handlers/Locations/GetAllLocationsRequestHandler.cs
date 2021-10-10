using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Locations
{
    public class GetAllLocationsRequestHandler : IRequestHandler<GetAllLocationsRequest, IEnumerable<LocationDto>>
    {
        private readonly ILocationService locationService;

        public GetAllLocationsRequestHandler(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public async Task<IEnumerable<LocationDto>> Handle(GetAllLocationsRequest request, CancellationToken cancellationToken)
            => await locationService.GetAllLocationsAsync();
    }
}
