using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class LocationResource : DbEntityBase
    {
        public Guid Id { get; private set; }
        public Location Location { get; private set; }
        public Resource Resource { get; private set; }
        public ResourceQuantity ResourceQuantity { get; private set; }

        public LocationResource(Location location, Resource resource, ResourceQuantity resourceQuantity)
        {
            Id = Guid.NewGuid();
            Location = location;
            Resource = resource;
            ResourceQuantity = resourceQuantity;
        }

        private LocationResource()
        {
        }


    }
}
