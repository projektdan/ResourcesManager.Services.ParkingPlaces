using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces
{
    public interface IResourceService : IService
    {
        Task<ResourceDto> CreateResourceAsync(AddResourcePayload payload);
        Task<ResourceDto> GetResourceAsync(string uniqueResourceIdentifier);
        Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
        Task RemoveResourceAsync(string uniqueResourceIdentifier);
        Task RegisterResourceInLocationAsync(Guid resourceId, string locationName);
        Task UnregisterResourceFromLocationAsync(Guid resourceId, string locationName);
    }
}
