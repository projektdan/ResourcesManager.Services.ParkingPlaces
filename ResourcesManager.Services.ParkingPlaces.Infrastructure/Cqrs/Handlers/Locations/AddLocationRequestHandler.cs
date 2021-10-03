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
    public class AddLocationRequestHandler : IRequestHandler<AddLocationRequest, LocationDto>
    {
        private readonly ILocationService locationService;

        public AddLocationRequestHandler(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        public async Task<LocationDto> Handle(AddLocationRequest request, CancellationToken cancellationToken)
            => await locationService.CreateLocationAsync(request.Payload);
    }
}
