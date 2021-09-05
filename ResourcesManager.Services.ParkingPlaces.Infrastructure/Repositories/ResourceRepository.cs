using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppDbContext context;

        public ResourceRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task AddAsync(Resource resource)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Resource resource)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Resource> GetAsync(UniqueResourceIdentifier uniqueResourceIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
