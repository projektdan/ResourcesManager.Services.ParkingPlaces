using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces
{
    public interface ILocationService : IService
    {
        Task<LocationDto> CreateLocationAsync(AddLocationPayload payload);
        Task<LocationDto> GetLocationAsync(string locationName);
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
        Task<IEnumerable<LocationDto>> GetLocationsByResourceAsync(string uniqueResourceIdentifier);
        Task RemoveLocationAsync(string locationName);
    }
}
