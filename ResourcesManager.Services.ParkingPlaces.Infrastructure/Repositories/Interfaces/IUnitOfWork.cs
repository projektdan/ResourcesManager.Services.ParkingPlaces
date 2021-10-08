using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IRepository
    {
        ILocationRepository Locations { get; }
        ILocationResourceRepository LocationResources { get;  }
        IReservationRepository Reservations { get; }
        IResourceRepository Resources { get; }
        IUserRepository Users { get; }
        IReservationStateRepository ReservationStates { get; }
        Task SaveAsync();
    }
}
