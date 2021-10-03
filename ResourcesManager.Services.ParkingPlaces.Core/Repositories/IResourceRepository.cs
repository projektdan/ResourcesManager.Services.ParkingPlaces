using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface IResourceRepository : IRepository
    {
        Task AddAsync(Resource resource);
        Task<Resource> GetAsync(Guid id);
        Task<Resource> GetAsync(UniqueResourceIdentifier uniqueResourceIdentifier);
        Task<IEnumerable<Resource>> GetAllAsync();
        Task RemoveAsync(Resource resource);
    }
}
