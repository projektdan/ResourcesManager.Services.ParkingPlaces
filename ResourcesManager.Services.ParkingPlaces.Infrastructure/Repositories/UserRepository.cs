using Microsoft.EntityFrameworkCore;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(User user)
            => await context.Users.AddAsync(user);

        public async Task DeleteAsync(User user)
        {
            this.context.Users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
            => await this.context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(Username username)
            => await this.context.Users.FirstOrDefaultAsync(x => x.Username == username);

        public async Task UpdateAsync(User user)
        {
            this.context.Users.Update(user);
            await Task.CompletedTask;
        }
    }
}
