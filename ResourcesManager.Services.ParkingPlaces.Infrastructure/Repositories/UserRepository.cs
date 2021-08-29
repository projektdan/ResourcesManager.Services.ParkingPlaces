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
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Username username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
