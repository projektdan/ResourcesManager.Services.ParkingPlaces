using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class UnregisterResourceInLocationRequestHandler : IRequestHandler<UnregisterResourceInLocationRequest>
    {
        private readonly IResourceService resourceService;

        public UnregisterResourceInLocationRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }
        public async Task<Unit> Handle(UnregisterResourceInLocationRequest request, CancellationToken cancellationToken)
        {
            await resourceService.UnregisterResourceFromLocationAsync(request.UniqueResourceIdentifier, request.LocationName);
            return await Unit.Task;
        }
    }
}
