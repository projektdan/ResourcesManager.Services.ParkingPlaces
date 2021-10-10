using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
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
        Task RegisterResourceInLocationAsync(string uniqueResourceIdentifier, int resourceQuantity, string locationNameString);
        Task UnregisterResourceFromLocationAsync(string uniqueResourceIdentifier, string locationNameString);
        Task UpdateResourceInLocation(string uniqueResourceIdentifier, int resourceQuantity, string locationName);
    }
}
