using AutoMapper;
using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class LocationService : BaseService, ILocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<LocationDto> CreateLocationAsync(AddLocationPayload payload)
        {
            var locationName = new Name(payload.Name);
            var location = await unitOfWork.Locations.GetAsync(locationName);
            location.GetValidator()
                .Throw(new CustomException(ErrorCodes.LocationAlreadyExists, $"Location with name '{payload.Name}' already exists."))
                .WhenIsNotNull()
            .Validate();

            var locationAddress = new Address(payload.Address);
            location = new(locationName, locationAddress);

            await unitOfWork.Locations.AddAsync(location);
            await unitOfWork.SaveAsync();

            return mapper.Map<LocationDto>(location);
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await unitOfWork.Locations.GetAllAsync();
            locations.GetValidator()
                .Throw(new CustomException(ErrorCodes.LocationNotFound, "Any locations exist.").WithCode(System.Net.HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var locationsDto = mapper.Map<IEnumerable<LocationDto>>(locations);

            return locationsDto;
        }

        public async Task<LocationDto> GetLocationAsync(string locationName)
        {
            var location = await ValidateThrowWhenNotFoundAndGetLocationAsync(locationName);

            var locationDto = mapper.Map<LocationDto>(location);

            return locationDto;
        }

        public async Task<IEnumerable<LocationDto>> GetLocationsByResourceAsync(string uniqueResourceIdentifier)
        {
            var resource = await unitOfWork.Resources.GetAsync(new UniqueResourceIdentifier(uniqueResourceIdentifier));
            resource.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceNotFound, $"Resource with unique identifier '{uniqueResourceIdentifier}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var locations = await unitOfWork.Locations.GetAllByResourceAsync(resource);
            locations.GetValidator()
                .Throw(new CustomException(ErrorCodes.LocationNotFound, $"Location with resource'{uniqueResourceIdentifier}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var locationsDto = mapper.Map<IEnumerable<LocationDto>>(locations);

            return locationsDto;
        }

        public async Task RemoveLocationAsync(string locationName)
        {
            var location = await ValidateThrowWhenNotFoundAndGetLocationAsync(locationName);
            //TODO : Validate if location is used for any reservation

            await unitOfWork.Locations.RemoveAsync(location);
            await unitOfWork.SaveAsync();
        }
    }
}
