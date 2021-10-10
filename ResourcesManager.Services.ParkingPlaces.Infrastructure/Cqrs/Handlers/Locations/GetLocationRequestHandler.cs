using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Locations
{
    public class GetLocationRequestHandler : IRequestHandler<GetLocationRequest, LocationDto>
    {
        private readonly ILocationService locationService;

        public GetLocationRequestHandler(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        public async Task<LocationDto> Handle(GetLocationRequest request, CancellationToken cancellationToken)
            => await locationService.GetLocationAsync(request.LocationName);
    }
}
