using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext context;

        public ReservationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task AddAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStateAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
