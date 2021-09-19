using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface IReservationStateRepository
    {
        Task<ReservationState> GetAsync(Guid Id);
        Task<ReservationState> GetAsync(Name name);
        Task<IEnumerable<ReservationState>> GetAllAsync();
        Task AddAsync(ReservationState reservationState);
        Task UpdateAsync(ReservationState reservationState);
    }
}
