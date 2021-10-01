using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class RemoveResourceRequestHandler : IRequestHandler<RemoveResourceRequest>
    {
        private readonly IResourceService resourceService;

        public RemoveResourceRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        public async Task<Unit> Handle(RemoveResourceRequest request, CancellationToken cancellationToken)
        {
            await this.resourceService.RemoveResourceAsync(request.UniqueResourceIdentifierString);

            return await Unit.Task;
        }
    }
}
