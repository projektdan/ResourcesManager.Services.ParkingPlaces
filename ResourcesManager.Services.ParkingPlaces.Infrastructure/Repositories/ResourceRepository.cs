using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
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
