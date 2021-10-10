using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class UpdateResourceInLocationRequestHandler : IRequestHandler<UpdateResourceInLocationRequest>
    {
        private readonly IResourceService resourceService;

        public UpdateResourceInLocationRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        public async Task<Unit> Handle(UpdateResourceInLocationRequest request, CancellationToken cancellationToken)
        {
            await resourceService.UpdateResourceInLocation(request.UniqeResourceIdentifier, request.ResourceQuantity, request.LocationName);
            return await Unit.Task;
        }
    }
}
