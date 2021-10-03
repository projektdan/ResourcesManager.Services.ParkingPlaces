using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Handlers.Resources
{
    public class GetAllResourcesRequestHandler : IRequestHandler<GetAllResourcesRequest, IEnumerable<ResourceDto>>
    {
        private readonly IResourceService resourceService;

        public GetAllResourcesRequestHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        public async Task<IEnumerable<ResourceDto>> Handle(GetAllResourcesRequest request, CancellationToken cancellationToken)
            => await resourceService.GetAllResourcesAsync();
    }
}
