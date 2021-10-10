using AutoMapper;
using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class ResourceService : BaseService, IResourceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResourceDto> CreateResourceAsync(AddResourcePayload payload)
        {
            var uniqueResourceIdentifier = new UniqueResourceIdentifier(payload.UniqueResourceIdentifier);
            var resourceName = new Name(payload.Name);

            var resource = await this.unitOfWork.Resources.GetAsync(uniqueResourceIdentifier);
            resource.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceAlreadyRegistered, $"Resource with identifier '{payload.UniqueResourceIdentifier}' already exists."))
                .WhenIsNotNull()
            .Validate();

            resource = new (uniqueResourceIdentifier, resourceName);

            await this.unitOfWork.Resources.AddAsync(resource);
            await this.unitOfWork.SaveAsync();

            return this.mapper.Map<ResourceDto>(resource);
        }

        public async Task<ResourceDto> GetResourceAsync(string uniqueResourceIdentifier)
        {
            var resource = await ValidateThrowWhenNotFoundAndGetResourceAsync(uniqueResourceIdentifier);

            var deviceDto = this.mapper.Map<ResourceDto>(resource);

            return deviceDto;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
        {
            var resources = await unitOfWork.Resources.GetAllAsync();
            resources.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceNotFound, $"Any resources exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var resourcesDto = mapper.Map<IEnumerable<ResourceDto>>(resources);

            return resourcesDto;
        }

        public async Task RemoveResourceAsync(string uniqueResourceIdentifier)
        {
            var resource = await ValidateThrowWhenNotFoundAndGetResourceAsync(uniqueResourceIdentifier);

            var location = await this.unitOfWork.Locations.GetFirstOrDefaultByResourceAsync(resource);
            location.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceIsInUse, $"There is at least one location which use '{uniqueResourceIdentifier}'.").WithCode(HttpStatusCode.BadRequest))
                .WhenIsNotNull()
            .Validate();

            await unitOfWork.Resources.RemoveAsync(resource);
            await unitOfWork.SaveAsync();
        }

        public async Task RegisterResourceInLocationAsync(string uniqueResourceIdentifier, int resourceQuantity, string locationName)
        {
            var location = await ValidateThrowWhenNotFoundAndGetLocationAsync(locationName);
            var resource = await ValidateThrowWhenNotFoundAndGetResourceAsync(uniqueResourceIdentifier);

            var locationResource = location.RegisterResource(resource, new ResourceQuantity(resourceQuantity));
            await unitOfWork.LocationResources.AddAsync(locationResource);
            await unitOfWork.SaveAsync();
        }

        public async Task UnregisterResourceFromLocationAsync(string uniqueResourceIdentifier, string locationName)
        {
            var location = await ValidateThrowWhenNotFoundAndGetLocationAsync(locationName);
            var resource = await unitOfWork.Resources.GetAsync(new UniqueResourceIdentifier(uniqueResourceIdentifier));
            var locationResourceToRemove = location.UnregisterResource(resource);

            await unitOfWork.LocationResources.RemoveAsync(locationResourceToRemove);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateResourceInLocation(string uniqueResourceIdentifier, int resourceQuantity, string locationName)
        {
            var location = await ValidateThrowWhenNotFoundAndGetLocationAsync(locationName);
            var locationResource = location.Resources.FirstOrDefault(r => r.Resource.UniqueResourceIdentifier.Value == uniqueResourceIdentifier);
            locationResource.SetQuantity(new ResourceQuantity(resourceQuantity));
            
            await unitOfWork.LocationResources.UpdateAsync(locationResource);
            await unitOfWork.SaveAsync();
        }
    }
}
