﻿using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces
{
    public interface IResourceService : IService
    {
        Task<ResourceDto> CreateResourceAsync(AddResourcePayload payload);
        Task<ResourceDto> GetResourceAsync(string uniqueResourceIdentifier);
        Task RemoveResourceAsync(string uniqueResourceIdentifier);
    }
}
