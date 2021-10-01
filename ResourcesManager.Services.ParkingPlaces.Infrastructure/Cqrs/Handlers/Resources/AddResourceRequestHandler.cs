using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class AddResourceRequestHandler : IRequestHandler<AddResourceRequest, ResourceDto>
    {
        private readonly IResourceService resourceService;

        public AddResourceRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }
        public async Task<ResourceDto> Handle(AddResourceRequest request, CancellationToken cancellationToken)
            => await this.resourceService.CreateResourceAsync(request.Payload);
    }
}
