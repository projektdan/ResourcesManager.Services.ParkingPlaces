using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class BaseService : IService
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected async Task<Location> ValidateThrowWhenNotFoundAndGetLocationAsync(string locationName)
        {
            var location = await unitOfWork.Locations.GetAsync(new Name(locationName));
            location.GetValidator()
                .Throw(new CustomException(ErrorCodes.LocationNotFound, $"Location '{locationName}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            return location;
        }

        protected async Task<Resource> ValidateThrowWhenNotFoundAndGetResourceAsync(string uniqueResourceIdentifier)
        {
            var resource = await unitOfWork.Resources.GetAsync(new UniqueResourceIdentifier(uniqueResourceIdentifier));
            resource.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceNotFound, $"Resource '{uniqueResourceIdentifier}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            return resource;
        }
    }
}
