using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class RegisterResourceInLocationRequestHandler : IRequestHandler<RegisterResourceInLocationRequest>
    {
        private readonly IResourceService resourceService;

        public RegisterResourceInLocationRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }
        public async Task<Unit> Handle(RegisterResourceInLocationRequest request, CancellationToken cancellationToken)
        {
            await resourceService.RegisterResourceInLocationAsync(request.UniqeResourceIdentifier, request.ResourceQuantity, request.LocationName);
            return await Unit.Task;
        }
    }
}
