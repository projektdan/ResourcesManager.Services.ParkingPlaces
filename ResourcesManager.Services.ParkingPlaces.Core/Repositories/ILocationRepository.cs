using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface ILocationRepository : IRepository
    {
        Task AddAsync(Location location);
        Task<Location> GetAsync(Guid id);
        Task<Location> GetAsync(Name name);
        Task<Location> GetFirstOrDefaultByResource(Resource resource);
        Task<IEnumerable<Location>> GetAllAsync();
        Task RemoveAsync(Location location);
    }
}
