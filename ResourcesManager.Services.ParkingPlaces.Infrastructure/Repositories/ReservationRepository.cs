using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
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
