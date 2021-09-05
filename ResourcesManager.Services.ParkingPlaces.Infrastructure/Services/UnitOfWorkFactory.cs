using ResourcesManager.Services.Libraries.Options;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DatabaseOptions options;

        public UnitOfWorkFactory(DatabaseOptions options)
        {
            this.options = options;
        }
        public IUnitOfWork Create()
        {
            var context = new AppDbContext(this.options);
            return new UnitOfWork(context);
        }

        public void Dispose()
        {
            ;
        }
    }
}
