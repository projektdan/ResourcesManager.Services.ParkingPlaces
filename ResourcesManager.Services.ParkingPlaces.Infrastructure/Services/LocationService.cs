using AutoMapper;
using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
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

        public Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LocationDto> GetLocationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LocationDto>> GetLocationsByResourceAsync(string uniqueResourceIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLocationAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
