using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Resource resource)
            => await this.context.Resources.AddAsync(resource);

        public async Task RemoveAsync(Resource resource)
        {
            this.context.Resources.Remove(resource);
            await Task.CompletedTask;
        }

        public async Task<Resource> GetAsync(Guid id)
            => await this.context.Resources.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Resource> GetAsync(UniqueResourceIdentifier uniqueResourceIdentifier)
            => await this.context.Resources.FirstOrDefaultAsync(x => x.UniqueResourceIdentifier == uniqueResourceIdentifier);
    }
}
