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
            => await context.Locations.AddAsync(location);

        public async Task<IEnumerable<Location>> GetAllAsync()
            => await context.Locations.Include(x => x.Resources).ThenInclude(x => x.Resource).ToListAsync();

        public async Task<Location> GetAsync(Guid id)
            => await context.Locations.Include(x => x.Resources).ThenInclude(x => x.Resource).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Location> GetAsync(Name name)
            => await context.Locations.Include(x => x.Resources).ThenInclude(x => x.Resource).FirstOrDefaultAsync(x => x.Name == name);

        public async Task<Location> GetFirstOrDefaultByResourceAsync(Resource resource)
            => await context.Locations.FirstOrDefaultAsync(x => x.Resources.OrderByDescending(r => r.CreatedAt).First().Resource == resource);

        public async Task<IEnumerable<Location>> GetAllByResourceAsync(Resource resource)
            => await context.Locations.Include(x => x.Resources).ThenInclude(x => x.Resource).Where(x => x.Resources.Any(x => x.Resource == resource)).ToListAsync();
        public async Task RemoveAsync(Location location)
        {
            context.Locations.Remove(location);
            await Task.CompletedTask;
        }
    }
}
