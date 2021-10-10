using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Locations
{
    public class RemoveLocationRequestHandler : IRequestHandler<RemoveLocationRequest>
    {
        private readonly ILocationService locationService;

        public RemoveLocationRequestHandler(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public async Task<Unit> Handle(RemoveLocationRequest request, CancellationToken cancellationToken)
        {
            await locationService.RemoveLocationAsync(request.LocationName) ;
            return await Unit.Task;
        }
    }
}
