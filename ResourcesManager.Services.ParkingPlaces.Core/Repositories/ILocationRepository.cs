using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface ILocationRepository : IRepository
    {
        Task AddAsync(Location location);
        Task<Location> GetAsync(Guid id);
        Task<Location> GetAsync(Name name);
        Task<IEnumerable<Location>> GetAllAsync();
        Task RemoveAsync(Location location);
        Task AddResourceAsync(Resource resource);
        Task DeleteResourceAsync(Resource resource);
    }
}
