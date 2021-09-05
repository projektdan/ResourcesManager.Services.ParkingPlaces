using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces
{
    public interface IUnitOfWorkFactory : IDisposable, IService
    {
        IUnitOfWork Create();
    }
}
