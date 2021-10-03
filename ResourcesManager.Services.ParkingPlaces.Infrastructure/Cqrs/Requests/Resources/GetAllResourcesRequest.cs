using MediatR;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using System.Collections.Generic;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class GetAllResourcesRequest : IRequest<IEnumerable<ResourceDto>>
    {
    }
}
