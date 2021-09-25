using Microsoft.EntityFrameworkCore;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class ReservationStateRepository : IReservationStateRepository
    {
        private readonly AppDbContext context;

        public ReservationStateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(ReservationState reservationState)
            => await this.context.ReservationStates.AddAsync(reservationState);

        public async Task<ReservationState> GetAsync(Guid Id)
            => await this.context.ReservationStates.FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<ReservationState> GetAsync(Name name)
            => await this.context.ReservationStates.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<ReservationState>> GetAllAsync()
            => await this.context.ReservationStates.ToListAsync();
            

        public async Task UpdateAsync(ReservationState reservationState)
        {
            this.context.ReservationStates.Update(reservationState);
            await Task.CompletedTask;
        }
    }
}
