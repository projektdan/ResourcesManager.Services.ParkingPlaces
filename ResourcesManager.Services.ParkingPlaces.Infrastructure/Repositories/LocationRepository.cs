using Microsoft.EntityFrameworkCore;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext context;

        public LocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Location location)
            => await this.context.Locations.AddAsync(location);

        public async Task<IEnumerable<Location>> GetAllAsync()
            => await this.context.Locations.ToListAsync();

        public async Task<Location> GetAsync(Guid id)
            => await this.context.Locations.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Location> GetAsync(Name name)
            => await this.context.Locations.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<Location> GetFirstOrDefaultByResource(Resource resource)
            => await context.Locations.FirstOrDefaultAsync(x => x.Resources.OrderByDescending(r => r.CreatedAt).First().Resource == resource);

        public async Task RemoveAsync(Location location)
        {
            this.context.Locations.Remove(location);
            await Task.CompletedTask;
        }
    }
}
