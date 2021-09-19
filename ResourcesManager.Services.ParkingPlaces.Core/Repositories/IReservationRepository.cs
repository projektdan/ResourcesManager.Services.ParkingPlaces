using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface IReservationRepository : IRepository
    {
        Task AddAsync(Reservation reservation);
        Task<Reservation> GetAsync(Guid id);
        Task<Reservation> GetAsync(User user);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task DeleteAsync(Reservation reservation);
        Task UpdateStateAsync(Reservation reservation);
    }
}
