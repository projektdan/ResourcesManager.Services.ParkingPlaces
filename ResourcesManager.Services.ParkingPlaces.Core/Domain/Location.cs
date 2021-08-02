using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Location
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public IDictionary<Resource, int> Resources { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

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

        private void SetAddress(Address address)
        {
            throw new NotImplementedException();
        }

        private void SetName(Name name)
        {
            throw new NotImplementedException();
        }
    }
}
