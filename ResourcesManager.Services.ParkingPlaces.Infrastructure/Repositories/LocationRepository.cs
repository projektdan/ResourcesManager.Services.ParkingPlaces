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
    public class LocationRepository : ILocationRepository
    {
        public Task AddAsync(Location location)
        {
            throw new NotImplementedException();
        }

        public Task AddResourceAsync(Resource resource)
        {
            throw new NotImplementedException();
        }

        public Task DeleteResourceAsync(Resource resource)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetAsync(Name name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
