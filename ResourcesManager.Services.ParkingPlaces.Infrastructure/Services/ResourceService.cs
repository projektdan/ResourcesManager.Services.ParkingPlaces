using AutoMapper;
using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
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
                .Throw(new CustomException(ErrorCodes.ResourceAlreadyExists, $"Device with identifier '{payload.UniqueResourceIdentifier}' already exists."))
                .WhenIsNotNull()
            .Validate();

            resource = new (uniqueResourceIdentifier, resourceName);

            await this.unitOfWork.Resources.AddAsync(resource);
            await this.unitOfWork.SaveAsync();

            return this.mapper.Map<ResourceDto>(resource);
        }

        public async Task<ResourceDto> GetResourceAsync(string uniqueResourceIdentifierString)
        {
            var uniqueResourceIdentifier = new UniqueResourceIdentifier(uniqueResourceIdentifierString);

            var resource = await this.unitOfWork.Resources.GetAsync(uniqueResourceIdentifier);
            resource.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceNotFound, $"Resource '{uniqueResourceIdentifierString}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var deviceDto = this.mapper.Map<ResourceDto>(resource);

            return deviceDto;
        }

        public async Task RemoveResourceAsync(string uniqueResourceIdentifierString)
        {
            var uniqueResourceIdentifier = new UniqueResourceIdentifier(uniqueResourceIdentifierString);

            var resource = await this.unitOfWork.Resources.GetAsync(uniqueResourceIdentifier);
            resource.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceNotFound, $"Resource '{uniqueResourceIdentifierString}' does not exist.").WithCode(HttpStatusCode.NotFound))
                .WhenIsNull()
            .Validate();

            var location = await this.unitOfWork.Locations.GetFirstOrDefaultByResource(resource);

            location.GetValidator()
                .Throw(new CustomException(ErrorCodes.ResourceIsInUse, $"There is at least one location which use '{uniqueResourceIdentifierString}'."))
                .WhenIsNotNull()
            .Validate();

            await unitOfWork.Resources.RemoveAsync(resource);
            await unitOfWork.SaveAsync();
        }
    }
}
