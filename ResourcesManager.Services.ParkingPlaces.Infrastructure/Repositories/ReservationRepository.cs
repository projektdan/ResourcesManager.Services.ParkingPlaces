using Microsoft.EntityFrameworkCore;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Collections.Generic;
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
        public async Task AddAsync(Reservation reservation)
            => await this.context.Reservations.AddAsync(reservation);

        public async Task DeleteAsync(Reservation reservation)
        {
            this.context.Reservations.Remove(reservation);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
            => await this.context.Reservations.ToListAsync();

        public async Task<Reservation> GetAsync(Guid id)
            => await this.context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Reservation> GetAsync(User user)
            => await this.context.Reservations.FirstOrDefaultAsync(x => x.User == user);

        public async Task UpdateStateAsync(Reservation reservation)
        {
            this.context.Reservations.Update(reservation);
            await Task.CompletedTask;
        }
    }
}
