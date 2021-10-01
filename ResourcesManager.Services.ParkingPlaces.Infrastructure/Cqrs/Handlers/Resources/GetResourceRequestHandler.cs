using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class GetResourceRequestHandler : IRequestHandler<GetResourceRequest, ResourceDto>
    {
        private readonly IResourceService resourceService;

        public GetResourceRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }
        public async Task<ResourceDto> Handle(GetResourceRequest request, CancellationToken cancellationToken)
            => await this.resourceService.GetResourceAsync(request.UniqueResourceIdentifier);
    }
}
