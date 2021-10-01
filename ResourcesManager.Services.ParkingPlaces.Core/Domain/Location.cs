using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Location : DbEntityBase
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        private ISet<LocationResource> resources = new HashSet<LocationResource>();
        public IEnumerable<LocationResource> Resources
        {
            get => resources;
            private set => resources = value?.ToHashSet();
        }

        #region CTOR
        private Location()
        {
        }

        public Location(Name name, Address address)
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            SetName(name);
            SetAddress(address);
        }
        #endregion

        public void SetAddress(Address address)
        {
            if (address is null)
            {
                throw new NullEntityException<Address>();
            }

            if (this.Address != address && this.Address is not null)
            {
                Update();
            }

            this.Address = address;
        }

        public void SetName(Name name)
        {
            if (name is null)
            {
                throw new NullEntityException<Name>();
            }

            if (this.Name != name && this.Name is not null)
            {
                Update();
            }

            this.Name = name;
        }

        public LocationResource AddOrUpdateResource(Resource resource, ResourceQuantity quantity)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }
            if (quantity.Value <= 0)
            {
                throw new InvalidQuantityValueException(nameof(quantity));
            }

            var locationResource = new LocationResource(this, resource, quantity);

            var isResourceExist = resources.Any(x => x.Resource == resource);
            if (isResourceExist)
            {
                var resourceToRemove = resources.FirstOrDefault(x => x.Resource == resource);
                resources.Remove(resourceToRemove);
            }

            resources.Add(locationResource);
            Update();

            return locationResource;
        }

        public LocationResource RemoveResource(Resource resource)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }

            var resourceToRemove = resources.FirstOrDefault(x => x.Resource == resource);
            var isResourceExist = resources.Any(x => x.Resource == resource);
            if (!isResourceExist)
            {
                throw new CustomException(ErrorCodes.ResourceNotFound, $"Cannot remove resource '{resource.Name.Value}', because doesn't exist in Location: {this.Name.Value}");
            }

            resources.Remove(resourceToRemove);
            Update();

            return resourceToRemove;
        }
    }
}
