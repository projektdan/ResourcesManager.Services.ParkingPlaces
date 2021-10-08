using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class LocationResourceRepository : ILocationResourceRepository
    {
        private readonly AppDbContext context;

        public LocationResourceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(LocationResource locationResource)
            => await context.LocationResources.AddAsync(locationResource);

        public async Task RemoveAsync(LocationResource locationResource)
        {
            context.LocationResources.Remove(locationResource);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(LocationResource locationResource)
        {
            context.LocationResources.Update(locationResource);
            await Task.CompletedTask;
        }
    }
}
