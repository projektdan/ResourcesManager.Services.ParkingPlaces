using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Repositories
{
    public interface ILocationResourceRepository
    {
        Task AddAsync(LocationResource locationResource);
        Task RemoveAsync(LocationResource locationResource);
        Task UpdateAsync(LocationResource locationResource);
    }
}
