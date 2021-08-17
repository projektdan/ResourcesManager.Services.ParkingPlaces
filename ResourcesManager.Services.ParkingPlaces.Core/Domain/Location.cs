using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Location : DatabaseEntityBase
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        private IDictionary<Resource, int> resources = new Dictionary<Resource, int>();
        public IDictionary<Resource, int> Resources
        {
            get => this.resources;
            private set => this.resources = value;
        }

        public DateTime CreatedAt { get; private set; }

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

            if (this.Address != address)
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

            if (this.Name != name)
            {
                Update();
            }

            this.Name = name;
        }

        public void AddResource(Resource resource, int quantity)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }
            if (quantity <= 0)
            {
                throw new InvalidIntValueException(nameof(quantity));
            }

            var resourceInDictionary = this.resources.Any(x => x.Key == resource);
            if (resourceInDictionary)
            {
                this.resources[resource] = this.resources[resource] + quantity;
            }
            else if(!resourceInDictionary)
            {
                this.resources.Add(resource, quantity);
            }

            Update();
        }

        public void RemoveResource(Resource resource)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }

            var resourceInDictionary = this.resources.FirstOrDefault(x => x.Key == resource);

            if (resourceInDictionary.Key is not null)
            {
                this.resources.Remove(resource);
            }

            Update();
        }
    }
}
